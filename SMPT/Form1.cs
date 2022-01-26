using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Threading;

namespace SMPT
{
    public partial class Form1 : Form
    {
        private Socket so;
        private TcpClient client; 
        private SslStream sslStream;
        private int sslfg;
        public List<contact> Contacts = new List<contact>();
        public List<sendlist> Targets = new List<sendlist>();
        private Thread thread_bk; //用于备份邮件内容
        private volatile bool stop_backup;
        /*
         * 与邮件发送相关：
         * cmd_rec: 发送cmd，返回回应的前三个字符.根据不同的连接方式(sslfg)，使用不同的发送方法.
         * check:检查cmd_rec返回字符和期待的返回字符是否一致
         * encode64base：base64编码
         * decode64base：base64解码
         * getIP:由域名得到IP地址（IP4)
         * create_sslcon：使用TcpClient连接465端口，建立ssl连接，并建立SslStream以发送信息.
         * create_nossl_con:简单地用套接字连接587端口，建立套接字连接.
         * bt_con_Click：尝试建立SSL连接，失败则不加密连接.连接后发送HELO、AUTH LOGIN验证用户名和授权码进行登录.
         * re_login()： 重复发送 HELO 并 AUTH LOGIN 的过程,避免一次失败后的状态异常.
         * send_a_mail：发送一封邮件：先验证发件人、收件人、再编辑邮件内容（主题、from、to、内容）
         * bt_sendall_Click：群发邮件（发送失败需要re_login重新连接，再发送下一封邮件）
        */

        private string cmd_rec(string cmd)
        {
            //向服务器发送cmd，并接受服务器的回应
            byte[] data = new byte[1024];
            int recv;
            if (sslfg == 1)
            {
                //ssl连接
                if (cmd != "first_rec")
                {
                    Console.WriteLine("client: " + cmd);
                    sslStream.Write(Encoding.ASCII.GetBytes(cmd));
                    sslStream.Flush();
                }
                recv = sslStream.Read(data, 0, data.Length);
            }
            else
            {
                //无ssl连接
                if (cmd != "first_rec")
                {  //cmd =="first_rec", 表示建立套接字连接,首次接收信息;否则，向服务器发送cmd:        
                    so.Send(Encoding.ASCII.GetBytes(cmd));  //字符串转ASCII码;
                }
                recv = so.Receive(data);
            }
            //返回服务器回应的前三位
            string stringdata = Encoding.ASCII.GetString(data, 0, recv);  //ASCII码转字符;
            Console.WriteLine(stringdata);
            if (stringdata.Length > 2)
                return stringdata.Substring(0, 3);
            else return "";
        }
        private bool check(string re_info, string info, int need_message)
        {
            //判断re_info和预期info是否一致，need_message为是否需要窗口提示
            if (re_info != info)
            {
                Console.WriteLine(info + " reply not received from server");
                if (need_message == 1) MessageBox.Show(info + "reply not received from server", "提示信息");
                return false;
            }
            return true;
        }

        public string encode64base(string str)
        {   // base64编码
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }
        public string decode64base(string str)
        {   // base64解码
            byte[] outputb = Convert.FromBase64String(str);
            return Encoding.Default.GetString(outputb);
        }
        public IPAddress getIP(string server)
        {
            //域名返回IP地址，这里对查询的IP检查其类型，返回IP4.
            IPHostEntry hostInfo = Dns.GetHostEntry(server);
            foreach (IPAddress _ipAddress in hostInfo.AddressList)
            {
                if (_ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    return _ipAddress;
                }             
            }
            return null;
        }

        //ssl证书认证
        private static Hashtable certificateErrors = new Hashtable();
        // The following method is invoked by the RemoteCertificateValidationDelegate.
        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;
            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);
            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }

        private void load_config()
        {
            //根据文本文件初始化用户配置
            if (!System.IO.File.Exists(".\\User_config.txt")) return;
            string[] lines = System.IO.File.ReadAllLines(".\\User_config.txt", Encoding.Default);
            in_mailserver.Text = lines[0];
            in_username.Text = lines[1];
            in_password.Text = lines[2];
            in_sender.Text = lines[3];
        }
        
        public Form1()
        {
            InitializeComponent();
            load_config();
            BindData_cont();
            List<sendlist> Targets_tmp = new List<sendlist>();
            Targets_tmp.Clear();
            sendlist_view.DataSource = Targets_tmp;
        }
        private void label1_Click(object sender, EventArgs e) { }

        private bool create_nossl_con(IPAddress ipAddress)
        {
            //建立套接字，不使用ssl，连接服务器587端口
            //SMTP 端口：465 或者 587
            //587端口支持STARTTLS协议,465端口必须先建立ssl连接
            sslfg = 0;
            int serverport = 587;
            // 创建套接字并建立连接
            try
            {
                so = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ie = new IPEndPoint(ipAddress, serverport);
                so.Connect(ie);
                return true;
            }
            catch (SocketException e)
            {
                MessageBox.Show("unable to connect to server", "提示信息");
                Console.WriteLine(e.ToString());
                return false;
            }
        }
        private bool create_sslcon(string mailserver)
        {
            //连接465端口，建立ssl连接，并通过sslStream安全地向服务器发送信息.
            try
            {
                sslfg = 1;
                int serverport = 465;
                client = new TcpClient(mailserver, serverport);
                sslStream = new SslStream(client.GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
                sslStream.AuthenticateAsClient(mailserver);
                return true;
            }
            catch (AuthenticationException er)
            {
                MessageBox.Show("Authentication failed - closing the connection.", "提示信息");
                Console.WriteLine(er.ToString());
                client.Close();
                return false;
            }
        }
        
        private void bt_con_Click(object sender, EventArgs e)
        {
            //尝试ssl连接或无ssl连接，然后发送helo和账户密码进行登录
            if (bt_con.Text == "连接")
            {
                sslfg = -1;
                Console.WriteLine("connect: HELO Alice & AUTH LOGIN");
                string mailserver = in_mailserver.Text.Trim();
                string username = in_username.Text.Trim();
                string password = in_password.Text.Trim();
                // SMTP 端口：465(ssl) 或者 587
                // 尝试在465端口建立ssl连接，不成功则进行普通连接
                IPAddress ipAddress = getIP(mailserver);
                if (ipAddress == null)
                {
                    MessageBox.Show("can't get IP : mailserver may be wrong！", "提示信息");
                    return;
                }
                // 先尝试ssl连接，端口465
                if (!create_sslcon(mailserver))
                {
                    //不成功则尝试直接建立连接，端口587
                    if (!create_nossl_con(ipAddress))
                    {
                        sslfg = -1;
                        return;
                    }
                }
                // 接受服务器连接信息          
                string re_info;
                re_info = cmd_rec("first_rec");
                if (!check(re_info, "220", 1)) return;
                // 发送 HELO 命令并且打印服务端回复
                re_info = cmd_rec("HELO ME\r\n");
                if (!check(re_info, "250", 1)) return;
                // AUTH LOGIN
                re_info = cmd_rec("AUTH LOGIN\r\n");
                if (!check(re_info, "334", 1)) return;
                re_info = cmd_rec(encode64base(username) + "\r\n"); //不要忘记 + "\r\n" ！！
                if (!check(re_info, "334", 1)) return;
                re_info = cmd_rec(encode64base(password) + "\r\n");
                if (!check(re_info, "235", 1)) return;
                
                bt_con.Text = "断开";
                string mess = "成功连接并登录！连接方式：";
                if (sslfg == 1) MessageBox.Show(mess + "SSL连接", "提示信息");
                else if (sslfg == 0) MessageBox.Show(mess + "非SSL连接", "提示信息");
            }
            else
            {   // bt_con.Text = "断开";
                cmd_rec("QUIT\r\n");
                if (so != null)
                {
                    so.Shutdown(SocketShutdown.Both);
                    so.Close();
                }
                if (client != null)
                {
                    sslStream.Close();
                    client.Close();
                }
                Console.WriteLine("close con.");
                bt_con.Text = "连接";
            }
        }
        private void bt_save_Click(object sender, EventArgs e)
        {
            //储存用户登录信息
            FileStream fs = new FileStream(".\\User_config.txt", FileMode.Create, FileAccess.Write);//创建写入文件
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(in_mailserver.Text.Trim());
            sw.WriteLine(in_username.Text.Trim());
            sw.WriteLine(in_password.Text.Trim());
            sw.WriteLine(in_sender.Text.Trim());
            sw.Close();
            fs.Close();
            MessageBox.Show("配置已保存", "提示信息");
            return;
        }
        private bool send_a_mail(string sender, string rec, string subject)
        {
            string re_info;
            //发件人
            re_info = cmd_rec("MAIL FROM:<" + sender + ">\r\n");
            if (!check(re_info, "250", 0)) return false;
            //收件人
            re_info = cmd_rec("RCPT TO:<" + rec + ">\r\n");
            if (!check(re_info, "250", 0)) return false;
            re_info = cmd_rec("DATA\r\n");
            if (!check(re_info, "354", 0)) return false;
            // 编辑邮件信息
            string contentType = "text/plain";
            string message = "subject:" + subject + "\r\n";
            message += "from:<" + sender + ">\r\n";
            message += "to:<" + rec + ">\r\n";
            message += "Content-Type:" + contentType + "\t\n";
            message += "\r\n" + in_mail.Text + "\r\n";
            //发送邮件
            re_info = cmd_rec(message + ".\r\n");
            if (!check(re_info, "250", 0)) return false;
            return true;
        }
        private void re_login()
        {
            //重新登录，避免错误发生后拒绝再次发送邮件；
            Console.WriteLine("re_con to server:");
            string re_info = cmd_rec("HELO ME\r\n");
            if (!check(re_info, "250", 1)) return;
            re_info = cmd_rec("AUTH LOGIN\r\n");
            if (!check(re_info, "334", 1)) return;
            re_info = cmd_rec(encode64base(in_username.Text.Trim()) + "\r\n");
            if (!check(re_info, "334", 1)) return;
            re_info = cmd_rec(encode64base(in_password.Text.Trim()) + "\r\n");
            if (!check(re_info, "235", 1)) return;
        }
        private void bt_send_Click(object sender, EventArgs e)
        {
            if (bt_con.Text == "连接") { MessageBox.Show("先连接服务器", "提示信息"); return; }
            if (send_a_mail(in_sender.Text, in_rec.Text, in_subject.Text)) MessageBox.Show("send successfully", "提示信息");
            else
            {
                MessageBox.Show("error: fail to send", "提示信息");
                re_login(); // 重新连接服务器
            }
        }
        // 从“.\\contacts.txt”获取联系人列表并绑定显示信息的功能组件
        private void BindData_cont()
        {
            if (!System.IO.File.Exists(".\\contacts.txt")) return;           
            string[] lines = System.IO.File.ReadAllLines(".\\contacts.txt", Encoding.Default);
            if (lines != null)
            {
                Contacts = new List<contact>();
                for (int i = 0; i < lines.Length; i++)
                {
                    contact one_cont = new contact();
                    one_cont.contact_mail = lines[i];
                    Contacts.Add(one_cont);
                }
                show_contact.DataSource = Contacts;
            }
        }
        private void bt_addcontact_Click(object sender, EventArgs e)
        {
            //新建联系人，增加一行文本记录
            if (!System.IO.File.Exists(".\\contacts.txt"))
            {
                //没有则创建这个文件
                FileStream fs = new FileStream(".\\contacts.txt", FileMode.Create, FileAccess.Write);
                fs.Close();
            }
            if (in_rec.Text.Trim() == "") return;
            StreamWriter sw = new StreamWriter(".\\contacts.txt", true, Encoding.UTF8);
            sw.WriteLine(in_rec.Text.Trim());
            sw.Close();
            BindData_cont();
        }

        private void bt_deletecont_Click(object sender, EventArgs e)
        {
            //删除联系人，根据用户选择的对象索引文本记录并删除
            //获得当前选择行的索引
            int length = Contacts.ToArray().Length; 
            int index = show_contact.SelectedRows[0].Index;
            if (index < 0 || index >= length) return; 
            contact one_cont = Contacts[index];
            //在txt文本中删除匹配文本行
            //设置SelectionMode为DataGridViewSelectionMode.FullRowSelect，
            var lines = File.ReadAllLines(".\\contacts.txt");
            //var query = lines.Where(x => !x.Contains(one_cont.contact_mail)).ToArray();
            var query = lines.Where(x => x!=one_cont.contact_mail).ToArray();
            File.WriteAllLines(".\\contacts.txt", query);
            BindData_cont();
        }

        private void bt_tosendlist_Click(object sender, EventArgs e)
        {
            //添加到群发列表
            int length = Contacts.ToArray().Length;
            int index = show_contact.SelectedRows[0].Index;
            if (index < 0 || index >= length) return;
            contact one_cont = Contacts[index];
            //最好使用局部数据集和DataGridView控件绑定，避免出现bug；
            //操作在全局数据集上，再将它拷贝到局部数据集上；
            List<sendlist> Targets_tmp = new List<sendlist>();
            sendlist one_target = new sendlist();
            one_target.target_mail = one_cont.contact_mail;
            Targets.Add(one_target);
            Targets.ForEach(i => Targets_tmp.Add(i));
            sendlist_view.DataSource = Targets_tmp;
        }

        private void bt_clear_Click(object sender, EventArgs e)
        {
            //清空群发列表
            List<sendlist> Targets_tmp = new List<sendlist>();
            Targets_tmp.Clear();
            Targets.Clear();
            // Targets.ForEach(i => Targets_tmp.Add(i));
            sendlist_view.DataSource = Targets_tmp;
        }

        private void bt_sendall_Click(object sender, EventArgs e)
        {
            //群发邮件,采用循环的send_a_mail是为了方便统计错误发送的个数
            if (bt_con.Text == "连接") { MessageBox.Show("先连接服务器", "提示信息"); return; }
            string errorport = "";
            int errorcount = 0;
            foreach (sendlist one in Targets)
            {
                if (send_a_mail(in_sender.Text.Trim(), one.target_mail, in_subject.Text.Trim())) continue;
                else
                {
                    errorcount++;
                    errorport += "\r\n" + one.target_mail;
                    re_login();
                }
            }
            if(errorcount!=0) MessageBox.Show("can't send " + errorcount.ToString()+" mails:" + errorport, "提示信息");
            else MessageBox.Show("All sent successfully !", "提示信息");
        }


        private delegate string CallBack(); //声明线程委托
        //用一个线程来备份，读取in_mail使用线程委托的方法，被占用时回调 readmail().
        private string readmail()
        {
            if (this.in_mail.InvokeRequired)
            {
                CallBack bk = new CallBack(readmail);
                object result = this.Invoke(bk);
                return (string)result;
            }
            else
            {
                return this.in_mail.Text.Trim();
            }
        }
        void backup()
        {
            while (!stop_backup)
            {
                Thread.Sleep(5000);
                string mail = readmail();
                if (mail == "") continue;
                FileStream fs_backup = new FileStream(".\\backup.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw_backup = new StreamWriter(fs_backup);
                sw_backup.WriteLine(mail);
                sw_backup.Close();
                fs_backup.Close();
            }
            return;
        }
       
        private void bt_backup_Click(object sender, EventArgs e)
        {
            if (bt_backup.Text == "启用备份")
            {
                stop_backup = false;
                bt_backup.Text = "停用";
                thread_bk = new Thread(new ThreadStart(backup));
                thread_bk.Start();
            }
            else // bt_backup.Text == "停用"
            {
                stop_backup = true;
                bt_backup.Text = "启用备份";
                thread_bk.Abort();
            }
        }

        private void bt_restore_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(".\\backup.txt")) return;
            string[] lines = System.IO.File.ReadAllLines(".\\backup.txt", Encoding.UTF8);
            if (lines != null)
            {
                string restore_mess = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    restore_mess += lines[i];
                    restore_mess += "\n";
                }
                in_mail.Text = restore_mess;
            }
        }
    }
}

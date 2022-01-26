namespace SMPT
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.in_mailserver = new System.Windows.Forms.TextBox();
            this.邮件服务器 = new System.Windows.Forms.Label();
            this.in_username = new System.Windows.Forms.TextBox();
            this.用户名 = new System.Windows.Forms.Label();
            this.授权码 = new System.Windows.Forms.Label();
            this.in_password = new System.Windows.Forms.TextBox();
            this.bt_con = new System.Windows.Forms.Button();
            this.bt_save = new System.Windows.Forms.Button();
            this.发送邮箱 = new System.Windows.Forms.Label();
            this.in_sender = new System.Windows.Forms.TextBox();
            this.in_rec = new System.Windows.Forms.TextBox();
            this.收件邮箱 = new System.Windows.Forms.Label();
            this.bt_send = new System.Windows.Forms.Button();
            this.in_mail = new System.Windows.Forms.RichTextBox();
            this.邮件主题 = new System.Windows.Forms.Label();
            this.in_subject = new System.Windows.Forms.TextBox();
            this.show_contact = new System.Windows.Forms.DataGridView();
            this.mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_addcontact = new System.Windows.Forms.Button();
            this.bt_deletecont = new System.Windows.Forms.Button();
            this.bt_sendall = new System.Windows.Forms.Button();
            this.bt_tosendlist = new System.Windows.Forms.Button();
            this.sendlist_view = new System.Windows.Forms.DataGridView();
            this.sendlist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bt_clear = new System.Windows.Forms.Button();
            this.bt_backup = new System.Windows.Forms.Button();
            this.bt_restore = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.show_contact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendlist_view)).BeginInit();
            this.SuspendLayout();
            // 
            // in_mailserver
            // 
            this.in_mailserver.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.in_mailserver.Location = new System.Drawing.Point(197, 61);
            this.in_mailserver.Name = "in_mailserver";
            this.in_mailserver.Size = new System.Drawing.Size(200, 27);
            this.in_mailserver.TabIndex = 0;
            // 
            // 邮件服务器
            // 
            this.邮件服务器.AutoSize = true;
            this.邮件服务器.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.邮件服务器.Location = new System.Drawing.Point(49, 60);
            this.邮件服务器.Name = "邮件服务器";
            this.邮件服务器.Size = new System.Drawing.Size(126, 25);
            this.邮件服务器.TabIndex = 1;
            this.邮件服务器.Text = "邮件服务器：";
            // 
            // in_username
            // 
            this.in_username.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.in_username.Location = new System.Drawing.Point(197, 99);
            this.in_username.Name = "in_username";
            this.in_username.Size = new System.Drawing.Size(200, 27);
            this.in_username.TabIndex = 2;
            // 
            // 用户名
            // 
            this.用户名.AutoSize = true;
            this.用户名.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.用户名.Location = new System.Drawing.Point(87, 99);
            this.用户名.Name = "用户名";
            this.用户名.Size = new System.Drawing.Size(88, 25);
            this.用户名.TabIndex = 3;
            this.用户名.Text = "用户名：";
            this.用户名.Click += new System.EventHandler(this.label1_Click);
            // 
            // 授权码
            // 
            this.授权码.AutoSize = true;
            this.授权码.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.授权码.Location = new System.Drawing.Point(87, 138);
            this.授权码.Name = "授权码";
            this.授权码.Size = new System.Drawing.Size(88, 25);
            this.授权码.TabIndex = 4;
            this.授权码.Text = "授权码：";
            // 
            // in_password
            // 
            this.in_password.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.in_password.Location = new System.Drawing.Point(197, 138);
            this.in_password.Name = "in_password";
            this.in_password.Size = new System.Drawing.Size(200, 27);
            this.in_password.TabIndex = 5;
            // 
            // bt_con
            // 
            this.bt_con.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bt_con.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_con.Location = new System.Drawing.Point(441, 122);
            this.bt_con.Name = "bt_con";
            this.bt_con.Size = new System.Drawing.Size(130, 56);
            this.bt_con.TabIndex = 6;
            this.bt_con.Text = "连接";
            this.bt_con.UseVisualStyleBackColor = false;
            this.bt_con.Click += new System.EventHandler(this.bt_con_Click);
            // 
            // bt_save
            // 
            this.bt_save.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bt_save.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.bt_save.Location = new System.Drawing.Point(441, 58);
            this.bt_save.Name = "bt_save";
            this.bt_save.Size = new System.Drawing.Size(130, 52);
            this.bt_save.TabIndex = 7;
            this.bt_save.Text = "保存配置";
            this.bt_save.UseVisualStyleBackColor = false;
            this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
            // 
            // 发送邮箱
            // 
            this.发送邮箱.AutoSize = true;
            this.发送邮箱.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.发送邮箱.Location = new System.Drawing.Point(68, 180);
            this.发送邮箱.Name = "发送邮箱";
            this.发送邮箱.Size = new System.Drawing.Size(107, 25);
            this.发送邮箱.TabIndex = 8;
            this.发送邮箱.Text = "发送邮箱：";
            // 
            // in_sender
            // 
            this.in_sender.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.in_sender.Location = new System.Drawing.Point(197, 178);
            this.in_sender.Name = "in_sender";
            this.in_sender.Size = new System.Drawing.Size(200, 27);
            this.in_sender.TabIndex = 9;
            // 
            // in_rec
            // 
            this.in_rec.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.in_rec.Location = new System.Drawing.Point(197, 220);
            this.in_rec.Name = "in_rec";
            this.in_rec.Size = new System.Drawing.Size(200, 27);
            this.in_rec.TabIndex = 10;
            // 
            // 收件邮箱
            // 
            this.收件邮箱.AutoSize = true;
            this.收件邮箱.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.收件邮箱.Location = new System.Drawing.Point(68, 222);
            this.收件邮箱.Name = "收件邮箱";
            this.收件邮箱.Size = new System.Drawing.Size(107, 25);
            this.收件邮箱.TabIndex = 11;
            this.收件邮箱.Text = "收件邮箱：";
            // 
            // bt_send
            // 
            this.bt_send.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.bt_send.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_send.Location = new System.Drawing.Point(441, 193);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(130, 54);
            this.bt_send.TabIndex = 12;
            this.bt_send.Text = "发送";
            this.bt_send.UseVisualStyleBackColor = false;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click);
            // 
            // in_mail
            // 
            this.in_mail.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.in_mail.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10F);
            this.in_mail.Location = new System.Drawing.Point(654, 122);
            this.in_mail.Name = "in_mail";
            this.in_mail.Size = new System.Drawing.Size(465, 530);
            this.in_mail.TabIndex = 13;
            this.in_mail.Text = "";
            // 
            // 邮件主题
            // 
            this.邮件主题.AutoSize = true;
            this.邮件主题.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.邮件主题.Location = new System.Drawing.Point(649, 61);
            this.邮件主题.Name = "邮件主题";
            this.邮件主题.Size = new System.Drawing.Size(107, 25);
            this.邮件主题.TabIndex = 14;
            this.邮件主题.Text = "邮件主题：";
            // 
            // in_subject
            // 
            this.in_subject.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.in_subject.Font = new System.Drawing.Font("Microsoft JhengHei UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.in_subject.Location = new System.Drawing.Point(751, 60);
            this.in_subject.Name = "in_subject";
            this.in_subject.Size = new System.Drawing.Size(344, 29);
            this.in_subject.TabIndex = 15;
            // 
            // show_contact
            // 
            this.show_contact.AllowUserToResizeColumns = false;
            this.show_contact.AllowUserToResizeRows = false;
            this.show_contact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.show_contact.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.show_contact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.show_contact.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.show_contact.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.show_contact.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.show_contact.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.show_contact.ColumnHeadersHeight = 32;
            this.show_contact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.show_contact.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mail});
            this.show_contact.GridColor = System.Drawing.Color.SkyBlue;
            this.show_contact.Location = new System.Drawing.Point(183, 286);
            this.show_contact.MultiSelect = false;
            this.show_contact.Name = "show_contact";
            this.show_contact.RowHeadersVisible = false;
            this.show_contact.RowTemplate.Height = 27;
            this.show_contact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.show_contact.Size = new System.Drawing.Size(208, 366);
            this.show_contact.TabIndex = 16;
            // 
            // mail
            // 
            this.mail.DataPropertyName = "contact_mail";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.mail.DefaultCellStyle = dataGridViewCellStyle6;
            this.mail.HeaderText = "联系人邮箱";
            this.mail.Name = "mail";
            this.mail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // bt_addcontact
            // 
            this.bt_addcontact.AutoSize = true;
            this.bt_addcontact.BackColor = System.Drawing.Color.LightBlue;
            this.bt_addcontact.Font = new System.Drawing.Font("微軟正黑體", 10.2F);
            this.bt_addcontact.Location = new System.Drawing.Point(26, 286);
            this.bt_addcontact.Name = "bt_addcontact";
            this.bt_addcontact.Size = new System.Drawing.Size(131, 51);
            this.bt_addcontact.TabIndex = 17;
            this.bt_addcontact.Text = "添加联系人";
            this.bt_addcontact.UseVisualStyleBackColor = false;
            this.bt_addcontact.Click += new System.EventHandler(this.bt_addcontact_Click);
            // 
            // bt_deletecont
            // 
            this.bt_deletecont.BackColor = System.Drawing.Color.LightBlue;
            this.bt_deletecont.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_deletecont.Location = new System.Drawing.Point(26, 359);
            this.bt_deletecont.Name = "bt_deletecont";
            this.bt_deletecont.Size = new System.Drawing.Size(131, 52);
            this.bt_deletecont.TabIndex = 18;
            this.bt_deletecont.Text = "删除联系人";
            this.bt_deletecont.UseVisualStyleBackColor = false;
            this.bt_deletecont.Click += new System.EventHandler(this.bt_deletecont_Click);
            // 
            // bt_sendall
            // 
            this.bt_sendall.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bt_sendall.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_sendall.ForeColor = System.Drawing.Color.Black;
            this.bt_sendall.Location = new System.Drawing.Point(26, 593);
            this.bt_sendall.Name = "bt_sendall";
            this.bt_sendall.Size = new System.Drawing.Size(131, 59);
            this.bt_sendall.TabIndex = 19;
            this.bt_sendall.Text = "群发";
            this.bt_sendall.UseVisualStyleBackColor = false;
            this.bt_sendall.Click += new System.EventHandler(this.bt_sendall_Click);
            // 
            // bt_tosendlist
            // 
            this.bt_tosendlist.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bt_tosendlist.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_tosendlist.ForeColor = System.Drawing.Color.Black;
            this.bt_tosendlist.Location = new System.Drawing.Point(26, 435);
            this.bt_tosendlist.Name = "bt_tosendlist";
            this.bt_tosendlist.Size = new System.Drawing.Size(131, 57);
            this.bt_tosendlist.TabIndex = 20;
            this.bt_tosendlist.Text = "添加到群发";
            this.bt_tosendlist.UseVisualStyleBackColor = false;
            this.bt_tosendlist.Click += new System.EventHandler(this.bt_tosendlist_Click);
            // 
            // sendlist_view
            // 
            this.sendlist_view.AllowUserToResizeColumns = false;
            this.sendlist_view.AllowUserToResizeRows = false;
            this.sendlist_view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sendlist_view.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.sendlist_view.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sendlist_view.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.sendlist_view.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.sendlist_view.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sendlist_view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.sendlist_view.ColumnHeadersHeight = 32;
            this.sendlist_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.sendlist_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sendlist});
            this.sendlist_view.GridColor = System.Drawing.Color.SkyBlue;
            this.sendlist_view.Location = new System.Drawing.Point(410, 286);
            this.sendlist_view.MultiSelect = false;
            this.sendlist_view.Name = "sendlist_view";
            this.sendlist_view.RowHeadersVisible = false;
            this.sendlist_view.RowTemplate.Height = 27;
            this.sendlist_view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sendlist_view.Size = new System.Drawing.Size(209, 366);
            this.sendlist_view.TabIndex = 21;
            // 
            // sendlist
            // 
            this.sendlist.DataPropertyName = "target_mail";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sendlist.DefaultCellStyle = dataGridViewCellStyle8;
            this.sendlist.HeaderText = "待发送列表";
            this.sendlist.Name = "sendlist";
            // 
            // bt_clear
            // 
            this.bt_clear.BackColor = System.Drawing.Color.CornflowerBlue;
            this.bt_clear.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_clear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bt_clear.Location = new System.Drawing.Point(26, 514);
            this.bt_clear.Name = "bt_clear";
            this.bt_clear.Size = new System.Drawing.Size(131, 58);
            this.bt_clear.TabIndex = 22;
            this.bt_clear.Text = "清空群发列";
            this.bt_clear.UseVisualStyleBackColor = false;
            this.bt_clear.Click += new System.EventHandler(this.bt_clear_Click);
            // 
            // bt_backup
            // 
            this.bt_backup.Location = new System.Drawing.Point(1155, 514);
            this.bt_backup.Name = "bt_backup";
            this.bt_backup.Size = new System.Drawing.Size(130, 58);
            this.bt_backup.TabIndex = 23;
            this.bt_backup.Text = "启用备份";
            this.bt_backup.UseVisualStyleBackColor = true;
            this.bt_backup.Click += new System.EventHandler(this.bt_backup_Click);
            // 
            // bt_restore
            // 
            this.bt_restore.Location = new System.Drawing.Point(1155, 593);
            this.bt_restore.Name = "bt_restore";
            this.bt_restore.Size = new System.Drawing.Size(130, 59);
            this.bt_restore.TabIndex = 24;
            this.bt_restore.Text = "恢复备份";
            this.bt_restore.UseVisualStyleBackColor = true;
            this.bt_restore.Click += new System.EventHandler(this.bt_restore_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1318, 688);
            this.Controls.Add(this.bt_restore);
            this.Controls.Add(this.bt_backup);
            this.Controls.Add(this.bt_clear);
            this.Controls.Add(this.sendlist_view);
            this.Controls.Add(this.bt_tosendlist);
            this.Controls.Add(this.bt_sendall);
            this.Controls.Add(this.bt_deletecont);
            this.Controls.Add(this.bt_addcontact);
            this.Controls.Add(this.show_contact);
            this.Controls.Add(this.in_subject);
            this.Controls.Add(this.邮件主题);
            this.Controls.Add(this.in_mail);
            this.Controls.Add(this.bt_send);
            this.Controls.Add(this.收件邮箱);
            this.Controls.Add(this.in_rec);
            this.Controls.Add(this.in_sender);
            this.Controls.Add(this.发送邮箱);
            this.Controls.Add(this.bt_save);
            this.Controls.Add(this.bt_con);
            this.Controls.Add(this.in_password);
            this.Controls.Add(this.授权码);
            this.Controls.Add(this.用户名);
            this.Controls.Add(this.in_username);
            this.Controls.Add(this.邮件服务器);
            this.Controls.Add(this.in_mailserver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "邮件发送";
            ((System.ComponentModel.ISupportInitialize)(this.show_contact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendlist_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox in_mailserver;
        private System.Windows.Forms.Label 邮件服务器;
        private System.Windows.Forms.TextBox in_username;
        private System.Windows.Forms.Label 用户名;
        private System.Windows.Forms.Label 授权码;
        private System.Windows.Forms.TextBox in_password;
        private System.Windows.Forms.Button bt_con;
        private System.Windows.Forms.Button bt_save;
        private System.Windows.Forms.Label 发送邮箱;
        private System.Windows.Forms.TextBox in_sender;
        private System.Windows.Forms.TextBox in_rec;
        private System.Windows.Forms.Label 收件邮箱;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.RichTextBox in_mail;
        private System.Windows.Forms.Label 邮件主题;
        private System.Windows.Forms.TextBox in_subject;
        private System.Windows.Forms.DataGridView show_contact;
        private System.Windows.Forms.Button bt_addcontact;
        private System.Windows.Forms.Button bt_deletecont;
        private System.Windows.Forms.Button bt_sendall;
        private System.Windows.Forms.Button bt_tosendlist;
        private System.Windows.Forms.DataGridView sendlist_view;
        private System.Windows.Forms.Button bt_clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn sendlist;
        private System.Windows.Forms.Button bt_backup;
        private System.Windows.Forms.Button bt_restore;
    }
}


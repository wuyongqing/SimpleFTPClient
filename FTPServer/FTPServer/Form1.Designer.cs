namespace FTPServer
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
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.lb_IP = new System.Windows.Forms.Label();
            this.lb_port = new System.Windows.Forms.Label();
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.lsb_local = new System.Windows.Forms.ListBox();
            this.lsb_server = new System.Windows.Forms.ListBox();
            this.lsb_status = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_setPath = new System.Windows.Forms.Button();
            this.btn_conn = new System.Windows.Forms.Button();
            this.btn_upload = new System.Windows.Forms.Button();
            this.btn_download = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(47, 44);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(100, 21);
            this.tb_IP.TabIndex = 0;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(198, 44);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(100, 21);
            this.tb_port.TabIndex = 1;
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(380, 44);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(97, 21);
            this.tb_username.TabIndex = 2;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(574, 44);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(100, 21);
            this.tb_password.TabIndex = 3;
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Location = new System.Drawing.Point(18, 47);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(23, 12);
            this.lb_IP.TabIndex = 4;
            this.lb_IP.Text = "IP:";
            this.lb_IP.Click += new System.EventHandler(this.label1_Click);
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(153, 47);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(35, 12);
            this.lb_port.TabIndex = 5;
            this.lb_port.Text = "Port:";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Location = new System.Drawing.Point(315, 47);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(59, 12);
            this.lb_username.TabIndex = 6;
            this.lb_username.Text = "Username:";
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Location = new System.Drawing.Point(510, 46);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(59, 12);
            this.lb_password.TabIndex = 7;
            this.lb_password.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "本地:";
            // 
            // tb_path
            // 
            this.tb_path.Location = new System.Drawing.Point(59, 88);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(249, 21);
            this.tb_path.TabIndex = 9;
            // 
            // lsb_local
            // 
            this.lsb_local.FormattingEnabled = true;
            this.lsb_local.ItemHeight = 12;
            this.lsb_local.Location = new System.Drawing.Point(23, 123);
            this.lsb_local.Name = "lsb_local";
            this.lsb_local.Size = new System.Drawing.Size(350, 208);
            this.lsb_local.TabIndex = 10;
            // 
            // lsb_server
            // 
            this.lsb_server.FormattingEnabled = true;
            this.lsb_server.ItemHeight = 12;
            this.lsb_server.Location = new System.Drawing.Point(403, 123);
            this.lsb_server.Name = "lsb_server";
            this.lsb_server.Size = new System.Drawing.Size(368, 208);
            this.lsb_server.TabIndex = 11;
            // 
            // lsb_status
            // 
            this.lsb_status.FormattingEnabled = true;
            this.lsb_status.ItemHeight = 12;
            this.lsb_status.Location = new System.Drawing.Point(20, 382);
            this.lsb_status.Name = "lsb_status";
            this.lsb_status.Size = new System.Drawing.Size(545, 76);
            this.lsb_status.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 367);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "状态:";
            // 
            // btn_setPath
            // 
            this.btn_setPath.Location = new System.Drawing.Point(317, 86);
            this.btn_setPath.Name = "btn_setPath";
            this.btn_setPath.Size = new System.Drawing.Size(32, 23);
            this.btn_setPath.TabIndex = 14;
            this.btn_setPath.Text = "...";
            this.btn_setPath.UseVisualStyleBackColor = true;
            this.btn_setPath.Click += new System.EventHandler(this.btn_setPath_Click);
            // 
            // btn_conn
            // 
            this.btn_conn.Location = new System.Drawing.Point(696, 42);
            this.btn_conn.Name = "btn_conn";
            this.btn_conn.Size = new System.Drawing.Size(75, 23);
            this.btn_conn.TabIndex = 15;
            this.btn_conn.Text = "连接";
            this.btn_conn.UseVisualStyleBackColor = true;
            this.btn_conn.Click += new System.EventHandler(this.btn_conn_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(299, 337);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 23);
            this.btn_upload.TabIndex = 16;
            this.btn_upload.Text = "上传";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // btn_download
            // 
            this.btn_download.Location = new System.Drawing.Point(696, 336);
            this.btn_download.Name = "btn_download";
            this.btn_download.Size = new System.Drawing.Size(75, 23);
            this.btn_download.TabIndex = 17;
            this.btn_download.Text = "下载";
            this.btn_download.UseVisualStyleBackColor = true;
            this.btn_download.Click += new System.EventHandler(this.btn_download_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(401, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "目的服务器:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_download);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.btn_conn);
            this.Controls.Add(this.btn_setPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lsb_status);
            this.Controls.Add(this.lsb_server);
            this.Controls.Add(this.lsb_local);
            this.Controls.Add(this.tb_path);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.lb_username);
            this.Controls.Add(this.lb_port);
            this.Controls.Add(this.lb_IP);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.tb_IP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.ListBox lsb_local;
        private System.Windows.Forms.ListBox lsb_server;
        private System.Windows.Forms.ListBox lsb_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_setPath;
        private System.Windows.Forms.Button btn_conn;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Button btn_download;
        private System.Windows.Forms.Label label6;
    }
}


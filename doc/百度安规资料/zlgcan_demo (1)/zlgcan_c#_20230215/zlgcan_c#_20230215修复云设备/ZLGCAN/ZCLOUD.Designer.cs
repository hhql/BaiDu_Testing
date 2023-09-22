namespace ZLGCANDemo
{
    partial class ZCLOUD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.httpAddr = new System.Windows.Forms.TextBox();
            this.mqttAddr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.httpPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mqttPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.deviceList = new System.Windows.Forms.ListView();
            this.confirm = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "HTTP地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "MQTT地址";
            // 
            // httpAddr
            // 
            this.httpAddr.Location = new System.Drawing.Point(104, 18);
            this.httpAddr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.httpAddr.Name = "httpAddr";
            this.httpAddr.Size = new System.Drawing.Size(233, 25);
            this.httpAddr.TabIndex = 2;
            this.httpAddr.Text = "cans.zlgcloud.com";
            // 
            // mqttAddr
            // 
            this.mqttAddr.Location = new System.Drawing.Point(104, 55);
            this.mqttAddr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mqttAddr.Name = "mqttAddr";
            this.mqttAddr.Size = new System.Drawing.Size(233, 25);
            this.mqttAddr.TabIndex = 3;
            this.mqttAddr.Text = "cans.zlgcloud.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "HTTP端口";
            // 
            // httpPort
            // 
            this.httpPort.Location = new System.Drawing.Point(456, 16);
            this.httpPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.httpPort.MaxLength = 5;
            this.httpPort.Name = "httpPort";
            this.httpPort.Size = new System.Drawing.Size(69, 25);
            this.httpPort.TabIndex = 5;
            this.httpPort.Text = "443";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "MQTT端口";
            // 
            // mqttPort
            // 
            this.mqttPort.Location = new System.Drawing.Point(456, 54);
            this.mqttPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mqttPort.MaxLength = 5;
            this.mqttPort.Name = "mqttPort";
            this.mqttPort.Size = new System.Drawing.Size(69, 25);
            this.mqttPort.TabIndex = 7;
            this.mqttPort.Text = "443";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 99);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "用户名";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(89, 96);
            this.username.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(176, 25);
            this.username.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(303, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "密码";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(349, 96);
            this.password.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(176, 25);
            this.password.TabIndex = 11;
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(567, 32);
            this.connect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(109, 29);
            this.connect.TabIndex = 12;
            this.connect.Text = "连接";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(567, 81);
            this.disconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(109, 29);
            this.disconnect.TabIndex = 13;
            this.disconnect.Text = "断开";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // deviceList
            // 
            this.deviceList.FullRowSelect = true;
            this.deviceList.HideSelection = false;
            this.deviceList.Location = new System.Drawing.Point(25, 148);
            this.deviceList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deviceList.MultiSelect = false;
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(647, 232);
            this.deviceList.TabIndex = 14;
            this.deviceList.UseCompatibleStateImageBehavior = false;
            this.deviceList.SelectedIndexChanged += new System.EventHandler(this.deviceList_SelectedIndexChanged);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(172, 401);
            this.confirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(100, 29);
            this.confirm.TabIndex = 15;
            this.confirm.Text = "确认";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(404, 400);
            this.cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 29);
            this.cancel.TabIndex = 16;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // ZCLOUD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(812, 503);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mqttPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.httpPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mqttAddr);
            this.Controls.Add(this.httpAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ZCLOUD";
            this.Text = "ZCLOUD";
            this.Load += new System.EventHandler(this.ZCLOUD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox httpAddr;
        private System.Windows.Forms.TextBox mqttAddr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox httpPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mqttPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.ListView deviceList;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.Button cancel;
    }
}
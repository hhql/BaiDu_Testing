namespace SafetyTesting
{
    partial class LoginForm
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
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_username
            // 
            this.textBox_username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(78)))), ((int)(((byte)(75)))));
            this.textBox_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_username.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_username.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBox_username.Location = new System.Drawing.Point(324, 135);
            this.textBox_username.Multiline = true;
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(173, 19);
            this.textBox_username.TabIndex = 0;
            this.textBox_username.Text = "Username";
            this.textBox_username.Enter += new System.EventHandler(this.textBox_username_Enter);
            this.textBox_username.Leave += new System.EventHandler(this.textBox_username_Leave);
            this.textBox_username.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_username_MouseDown);
            // 
            // textBox_password
            // 
            this.textBox_password.AcceptsReturn = true;
            this.textBox_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(78)))), ((int)(((byte)(75)))));
            this.textBox_password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_password.Font = new System.Drawing.Font("Microsoft YaHei UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_password.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBox_password.Location = new System.Drawing.Point(325, 188);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(173, 14);
            this.textBox_password.TabIndex = 1;
            this.textBox_password.Text = "Password";
            this.textBox_password.WordWrap = false;
            this.textBox_password.Enter += new System.EventHandler(this.textBox_password_Enter);
            this.textBox_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_password_KeyPress);
            this.textBox_password.Leave += new System.EventHandler(this.textBox_password_Leave);
            // 
            // button_login
            // 
            this.button_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(148)))), ((int)(((byte)(148)))));
            this.button_login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button_login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button_login.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_login.ForeColor = System.Drawing.Color.White;
            this.button_login.Location = new System.Drawing.Point(316, 297);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(163, 45);
            this.button_login.TabIndex = 2;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = false;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(213, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 36);
            this.label1.TabIndex = 3;
            this.label1.Text = "新能源汽车安规综合检测系统";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SafetyTesting.Properties.Resources.login;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.textBox_password);
            this.Controls.Add(this.textBox_username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LoginForm_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Label label1;
    }
}
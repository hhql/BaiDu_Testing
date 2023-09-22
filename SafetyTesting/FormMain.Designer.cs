namespace SafetyTesting
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.timer_time = new System.Windows.Forms.Timer(this.components);
            this.pictureBox_home = new System.Windows.Forms.PictureBox();
            this.pictureBox_exit = new System.Windows.Forms.PictureBox();
            this.panel_exit = new System.Windows.Forms.Panel();
            this.panel_home = new System.Windows.Forms.Panel();
            this.label_home = new System.Windows.Forms.Label();
            this.panel_carModul = new System.Windows.Forms.Panel();
            this.label_carModul = new System.Windows.Forms.Label();
            this.pictureBox_carModul = new System.Windows.Forms.PictureBox();
            this.panel_device = new System.Windows.Forms.Panel();
            this.label_device = new System.Windows.Forms.Label();
            this.pictureBox_device = new System.Windows.Forms.PictureBox();
            this.panel_data = new System.Windows.Forms.Panel();
            this.label_data = new System.Windows.Forms.Label();
            this.pictureBox_data = new System.Windows.Forms.PictureBox();
            this.panel_setting = new System.Windows.Forms.Panel();
            this.label_setting = new System.Windows.Forms.Label();
            this.pictureBox_setting = new System.Windows.Forms.PictureBox();
            this.panel_about = new System.Windows.Forms.Panel();
            this.label_about = new System.Windows.Forms.Label();
            this.pictureBox_about = new System.Windows.Forms.PictureBox();
            this.panel_menu = new System.Windows.Forms.Panel();
            this.about1 = new SafetyTesting.Control.About();
            this.setting1 = new SafetyTesting.Control.setting();
            this.data1 = new SafetyTesting.Control.Data();
            this.device1 = new SafetyTesting.Control.Device();
            this.carModul1 = new SafetyTesting.Control.CarModul();
            this.home1 = new SafetyTesting.Control.home();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_exit)).BeginInit();
            this.panel_exit.SuspendLayout();
            this.panel_home.SuspendLayout();
            this.panel_carModul.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_carModul)).BeginInit();
            this.panel_device.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_device)).BeginInit();
            this.panel_data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_data)).BeginInit();
            this.panel_setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_setting)).BeginInit();
            this.panel_about.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_about)).BeginInit();
            this.panel_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("思源黑体 CN Bold", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.label1.Location = new System.Drawing.Point(752, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 58);
            this.label1.TabIndex = 0;
            this.label1.Text = "安规检测系统";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.BackColor = System.Drawing.Color.Transparent;
            this.label_time.Font = new System.Drawing.Font("思源黑体 CN Medium", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_time.ForeColor = System.Drawing.Color.White;
            this.label_time.Location = new System.Drawing.Point(12, 17);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(359, 48);
            this.label_time.TabIndex = 1;
            this.label_time.Text = "2022/10/30 21:43:00";
            // 
            // timer_time
            // 
            this.timer_time.Interval = 1000;
            this.timer_time.Tick += new System.EventHandler(this.timer_time_Tick);
            // 
            // pictureBox_home
            // 
            this.pictureBox_home.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_home.Image = global::SafetyTesting.Properties.Resources.homeLight;
            this.pictureBox_home.Location = new System.Drawing.Point(35, 28);
            this.pictureBox_home.Name = "pictureBox_home";
            this.pictureBox_home.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_home.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_home.TabIndex = 2;
            this.pictureBox_home.TabStop = false;
            this.pictureBox_home.Click += new System.EventHandler(this.panel_home_Click);
            this.pictureBox_home.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // pictureBox_exit
            // 
            this.pictureBox_exit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_exit.Image = global::SafetyTesting.Properties.Resources.exit1;
            this.pictureBox_exit.Location = new System.Drawing.Point(25, 24);
            this.pictureBox_exit.Name = "pictureBox_exit";
            this.pictureBox_exit.Size = new System.Drawing.Size(40, 40);
            this.pictureBox_exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_exit.TabIndex = 5;
            this.pictureBox_exit.TabStop = false;
            this.pictureBox_exit.Click += new System.EventHandler(this.panel_exit_Click);
            this.pictureBox_exit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_exit_MouseDown);
            this.pictureBox_exit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_exit_MouseUp);
            // 
            // panel_exit
            // 
            this.panel_exit.BackColor = System.Drawing.Color.Transparent;
            this.panel_exit.BackgroundImage = global::SafetyTesting.Properties.Resources.yuan;
            this.panel_exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_exit.Controls.Add(this.pictureBox_exit);
            this.panel_exit.Location = new System.Drawing.Point(1500, 0);
            this.panel_exit.Name = "panel_exit";
            this.panel_exit.Size = new System.Drawing.Size(92, 89);
            this.panel_exit.TabIndex = 6;
            this.panel_exit.Click += new System.EventHandler(this.panel_exit_Click);
            this.panel_exit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_exit_MouseDown);
            this.panel_exit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_exit_MouseUp);
            // 
            // panel_home
            // 
            this.panel_home.BackColor = System.Drawing.Color.Transparent;
            this.panel_home.BackgroundImage = global::SafetyTesting.Properties.Resources.yuanLight1;
            this.panel_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_home.Controls.Add(this.label_home);
            this.panel_home.Controls.Add(this.pictureBox_home);
            this.panel_home.Location = new System.Drawing.Point(267, 773);
            this.panel_home.Name = "panel_home";
            this.panel_home.Size = new System.Drawing.Size(120, 120);
            this.panel_home.TabIndex = 7;
            this.panel_home.Click += new System.EventHandler(this.panel_home_Click);
            this.panel_home.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // label_home
            // 
            this.label_home.AutoSize = true;
            this.label_home.BackColor = System.Drawing.Color.Transparent;
            this.label_home.Font = new System.Drawing.Font("思源黑体 CN Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_home.ForeColor = System.Drawing.Color.White;
            this.label_home.Location = new System.Drawing.Point(38, 77);
            this.label_home.Name = "label_home";
            this.label_home.Size = new System.Drawing.Size(42, 23);
            this.label_home.TabIndex = 8;
            this.label_home.Text = "主页";
            this.label_home.Click += new System.EventHandler(this.panel_home_Click);
            this.label_home.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // panel_carModul
            // 
            this.panel_carModul.BackColor = System.Drawing.Color.Transparent;
            this.panel_carModul.BackgroundImage = global::SafetyTesting.Properties.Resources.yuan;
            this.panel_carModul.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_carModul.Controls.Add(this.label_carModul);
            this.panel_carModul.Controls.Add(this.pictureBox_carModul);
            this.panel_carModul.Location = new System.Drawing.Point(454, 769);
            this.panel_carModul.Name = "panel_carModul";
            this.panel_carModul.Size = new System.Drawing.Size(120, 120);
            this.panel_carModul.TabIndex = 7;
            this.panel_carModul.Click += new System.EventHandler(this.panel_carModul_Click);
            this.panel_carModul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // label_carModul
            // 
            this.label_carModul.AutoSize = true;
            this.label_carModul.BackColor = System.Drawing.Color.Transparent;
            this.label_carModul.Font = new System.Drawing.Font("思源黑体 CN Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_carModul.ForeColor = System.Drawing.Color.White;
            this.label_carModul.Location = new System.Drawing.Point(38, 77);
            this.label_carModul.Name = "label_carModul";
            this.label_carModul.Size = new System.Drawing.Size(42, 23);
            this.label_carModul.TabIndex = 8;
            this.label_carModul.Text = "车型";
            this.label_carModul.Click += new System.EventHandler(this.panel_carModul_Click);
            this.label_carModul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // pictureBox_carModul
            // 
            this.pictureBox_carModul.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_carModul.Image = global::SafetyTesting.Properties.Resources.CarModul;
            this.pictureBox_carModul.Location = new System.Drawing.Point(34, 26);
            this.pictureBox_carModul.Name = "pictureBox_carModul";
            this.pictureBox_carModul.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_carModul.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_carModul.TabIndex = 2;
            this.pictureBox_carModul.TabStop = false;
            this.pictureBox_carModul.Click += new System.EventHandler(this.panel_carModul_Click);
            this.pictureBox_carModul.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // panel_device
            // 
            this.panel_device.BackColor = System.Drawing.Color.Transparent;
            this.panel_device.BackgroundImage = global::SafetyTesting.Properties.Resources.yuan;
            this.panel_device.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_device.Controls.Add(this.label_device);
            this.panel_device.Controls.Add(this.pictureBox_device);
            this.panel_device.Location = new System.Drawing.Point(641, 768);
            this.panel_device.Name = "panel_device";
            this.panel_device.Size = new System.Drawing.Size(120, 120);
            this.panel_device.TabIndex = 8;
            this.panel_device.Click += new System.EventHandler(this.panel_device_Click);
            this.panel_device.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // label_device
            // 
            this.label_device.AutoSize = true;
            this.label_device.BackColor = System.Drawing.Color.Transparent;
            this.label_device.Font = new System.Drawing.Font("思源黑体 CN Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_device.ForeColor = System.Drawing.Color.White;
            this.label_device.Location = new System.Drawing.Point(39, 77);
            this.label_device.Name = "label_device";
            this.label_device.Size = new System.Drawing.Size(42, 23);
            this.label_device.TabIndex = 8;
            this.label_device.Text = "设备";
            this.label_device.Click += new System.EventHandler(this.panel_device_Click);
            this.label_device.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // pictureBox_device
            // 
            this.pictureBox_device.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_device.Image = global::SafetyTesting.Properties.Resources.IO;
            this.pictureBox_device.Location = new System.Drawing.Point(34, 26);
            this.pictureBox_device.Name = "pictureBox_device";
            this.pictureBox_device.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_device.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_device.TabIndex = 2;
            this.pictureBox_device.TabStop = false;
            this.pictureBox_device.Click += new System.EventHandler(this.panel_device_Click);
            this.pictureBox_device.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // panel_data
            // 
            this.panel_data.BackColor = System.Drawing.Color.Transparent;
            this.panel_data.BackgroundImage = global::SafetyTesting.Properties.Resources.yuan;
            this.panel_data.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_data.Controls.Add(this.label_data);
            this.panel_data.Controls.Add(this.pictureBox_data);
            this.panel_data.Location = new System.Drawing.Point(825, 769);
            this.panel_data.Name = "panel_data";
            this.panel_data.Size = new System.Drawing.Size(120, 120);
            this.panel_data.TabIndex = 9;
            this.panel_data.Click += new System.EventHandler(this.panel_data_Click);
            this.panel_data.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // label_data
            // 
            this.label_data.AutoSize = true;
            this.label_data.BackColor = System.Drawing.Color.Transparent;
            this.label_data.Font = new System.Drawing.Font("思源黑体 CN Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_data.ForeColor = System.Drawing.Color.White;
            this.label_data.Location = new System.Drawing.Point(39, 77);
            this.label_data.Name = "label_data";
            this.label_data.Size = new System.Drawing.Size(42, 23);
            this.label_data.TabIndex = 8;
            this.label_data.Text = "数据";
            this.label_data.Click += new System.EventHandler(this.panel_data_Click);
            this.label_data.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // pictureBox_data
            // 
            this.pictureBox_data.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_data.Image = global::SafetyTesting.Properties.Resources.data;
            this.pictureBox_data.Location = new System.Drawing.Point(34, 26);
            this.pictureBox_data.Name = "pictureBox_data";
            this.pictureBox_data.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_data.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_data.TabIndex = 2;
            this.pictureBox_data.TabStop = false;
            this.pictureBox_data.Click += new System.EventHandler(this.panel_data_Click);
            this.pictureBox_data.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // panel_setting
            // 
            this.panel_setting.BackColor = System.Drawing.Color.Transparent;
            this.panel_setting.BackgroundImage = global::SafetyTesting.Properties.Resources.yuan;
            this.panel_setting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_setting.Controls.Add(this.label_setting);
            this.panel_setting.Controls.Add(this.pictureBox_setting);
            this.panel_setting.Location = new System.Drawing.Point(1013, 770);
            this.panel_setting.Name = "panel_setting";
            this.panel_setting.Size = new System.Drawing.Size(120, 120);
            this.panel_setting.TabIndex = 10;
            this.panel_setting.Click += new System.EventHandler(this.panel_setting_Click);
            this.panel_setting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // label_setting
            // 
            this.label_setting.AutoSize = true;
            this.label_setting.BackColor = System.Drawing.Color.Transparent;
            this.label_setting.Font = new System.Drawing.Font("思源黑体 CN Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_setting.ForeColor = System.Drawing.Color.White;
            this.label_setting.Location = new System.Drawing.Point(39, 77);
            this.label_setting.Name = "label_setting";
            this.label_setting.Size = new System.Drawing.Size(42, 23);
            this.label_setting.TabIndex = 8;
            this.label_setting.Text = "系统";
            this.label_setting.Click += new System.EventHandler(this.panel_setting_Click);
            this.label_setting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // pictureBox_setting
            // 
            this.pictureBox_setting.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_setting.Image = global::SafetyTesting.Properties.Resources.setting;
            this.pictureBox_setting.Location = new System.Drawing.Point(34, 26);
            this.pictureBox_setting.Name = "pictureBox_setting";
            this.pictureBox_setting.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_setting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_setting.TabIndex = 2;
            this.pictureBox_setting.TabStop = false;
            this.pictureBox_setting.Click += new System.EventHandler(this.panel_setting_Click);
            this.pictureBox_setting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // panel_about
            // 
            this.panel_about.BackColor = System.Drawing.Color.Transparent;
            this.panel_about.BackgroundImage = global::SafetyTesting.Properties.Resources.yuan;
            this.panel_about.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_about.Controls.Add(this.label_about);
            this.panel_about.Controls.Add(this.pictureBox_about);
            this.panel_about.Location = new System.Drawing.Point(1201, 769);
            this.panel_about.Name = "panel_about";
            this.panel_about.Size = new System.Drawing.Size(120, 120);
            this.panel_about.TabIndex = 10;
            this.panel_about.Click += new System.EventHandler(this.panel_about_Click);
            this.panel_about.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // label_about
            // 
            this.label_about.AutoSize = true;
            this.label_about.BackColor = System.Drawing.Color.Transparent;
            this.label_about.Font = new System.Drawing.Font("思源黑体 CN Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_about.ForeColor = System.Drawing.Color.White;
            this.label_about.Location = new System.Drawing.Point(39, 77);
            this.label_about.Name = "label_about";
            this.label_about.Size = new System.Drawing.Size(42, 23);
            this.label_about.TabIndex = 8;
            this.label_about.Text = "关于";
            this.label_about.Click += new System.EventHandler(this.panel_about_Click);
            this.label_about.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // pictureBox_about
            // 
            this.pictureBox_about.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_about.Image = global::SafetyTesting.Properties.Resources.about;
            this.pictureBox_about.Location = new System.Drawing.Point(34, 26);
            this.pictureBox_about.Name = "pictureBox_about";
            this.pictureBox_about.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_about.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_about.TabIndex = 2;
            this.pictureBox_about.TabStop = false;
            this.pictureBox_about.Click += new System.EventHandler(this.panel_about_Click);
            this.pictureBox_about.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.Color.Transparent;
            this.panel_menu.Controls.Add(this.about1);
            this.panel_menu.Controls.Add(this.setting1);
            this.panel_menu.Controls.Add(this.data1);
            this.panel_menu.Controls.Add(this.device1);
            this.panel_menu.Controls.Add(this.carModul1);
            this.panel_menu.Controls.Add(this.home1);
            this.panel_menu.Location = new System.Drawing.Point(0, 109);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(1600, 645);
            this.panel_menu.TabIndex = 11;
            // 
            // about1
            // 
            this.about1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.about1.Location = new System.Drawing.Point(1146, 197);
            this.about1.Name = "about1";
            this.about1.Size = new System.Drawing.Size(200, 300);
            this.about1.TabIndex = 5;
            // 
            // setting1
            // 
            this.setting1.BackColor = System.Drawing.Color.Chocolate;
            this.setting1.Location = new System.Drawing.Point(887, 175);
            this.setting1.Name = "setting1";
            this.setting1.Size = new System.Drawing.Size(200, 300);
            this.setting1.TabIndex = 4;
            // 
            // data1
            // 
            this.data1.BackColor = System.Drawing.Color.White;
            this.data1.Location = new System.Drawing.Point(670, 163);
            this.data1.Name = "data1";
            this.data1.Size = new System.Drawing.Size(200, 300);
            this.data1.TabIndex = 3;
            // 
            // device1
            // 
            this.device1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.device1.Location = new System.Drawing.Point(451, 163);
            this.device1.Name = "device1";
            this.device1.Size = new System.Drawing.Size(200, 300);
            this.device1.TabIndex = 2;
            // 
            // carModul1
            // 
            this.carModul1.BackColor = System.Drawing.Color.DarkRed;
            this.carModul1.Location = new System.Drawing.Point(229, 163);
            this.carModul1.Name = "carModul1";
            this.carModul1.Size = new System.Drawing.Size(200, 300);
            this.carModul1.TabIndex = 1;
            // 
            // home1
            // 
            this.home1.BackColor = System.Drawing.Color.Transparent;
            this.home1.Location = new System.Drawing.Point(12, 104);
            this.home1.Name = "home1";
            this.home1.numNG = 0;
            this.home1.numOK = 0;
            this.home1.Size = new System.Drawing.Size(200, 300);
            this.home1.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SafetyTesting.Properties.Resources.backImage2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.panel_menu);
            this.Controls.Add(this.panel_about);
            this.Controls.Add(this.panel_setting);
            this.Controls.Add(this.panel_data);
            this.Controls.Add(this.panel_device);
            this.Controls.Add(this.panel_carModul);
            this.Controls.Add(this.panel_home);
            this.Controls.Add(this.panel_exit);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DoubleClick += new System.EventHandler(this.FormMain_DoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_home)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_exit)).EndInit();
            this.panel_exit.ResumeLayout(false);
            this.panel_home.ResumeLayout(false);
            this.panel_home.PerformLayout();
            this.panel_carModul.ResumeLayout(false);
            this.panel_carModul.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_carModul)).EndInit();
            this.panel_device.ResumeLayout(false);
            this.panel_device.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_device)).EndInit();
            this.panel_data.ResumeLayout(false);
            this.panel_data.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_data)).EndInit();
            this.panel_setting.ResumeLayout(false);
            this.panel_setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_setting)).EndInit();
            this.panel_about.ResumeLayout(false);
            this.panel_about.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_about)).EndInit();
            this.panel_menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Timer timer_time;
        private System.Windows.Forms.PictureBox pictureBox_home;
        private System.Windows.Forms.PictureBox pictureBox_exit;
        private System.Windows.Forms.Panel panel_exit;
        private System.Windows.Forms.Panel panel_home;
        private System.Windows.Forms.Label label_home;
        private System.Windows.Forms.Panel panel_carModul;
        private System.Windows.Forms.Label label_carModul;
        private System.Windows.Forms.PictureBox pictureBox_carModul;
        private System.Windows.Forms.Panel panel_device;
        private System.Windows.Forms.Label label_device;
        private System.Windows.Forms.PictureBox pictureBox_device;
        private System.Windows.Forms.Panel panel_data;
        private System.Windows.Forms.Label label_data;
        private System.Windows.Forms.PictureBox pictureBox_data;
        private System.Windows.Forms.Panel panel_setting;
        private System.Windows.Forms.Label label_setting;
        private System.Windows.Forms.PictureBox pictureBox_setting;
        private System.Windows.Forms.Panel panel_about;
        private System.Windows.Forms.Label label_about;
        private System.Windows.Forms.PictureBox pictureBox_about;
        private System.Windows.Forms.Panel panel_menu;
        private Control.Device device1;
        private Control.CarModul carModul1;
        private Control.home home1;
        private Control.setting setting1;
        private Control.Data data1;
        private Control.About about1;
    }
}
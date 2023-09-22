namespace SafetyTesting.Control
{
    partial class setting
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_CurrentStation = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox_userName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.button_AddUser = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox_car = new System.Windows.Forms.CheckBox();
            this.checkBox_device = new System.Windows.Forms.CheckBox();
            this.checkBox_system = new System.Windows.Forms.CheckBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_mesAddress = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_mesTime = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button_userSave = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button_StationSave = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBox_data = new System.Windows.Forms.CheckBox();
            this.checkBox_IsIO = new System.Windows.Forms.CheckBox();
            this.panel_userSetting = new System.Windows.Forms.Panel();
            this.checkBox_IsPrint = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_MES = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel_userSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SafetyTesting.Properties.Resources.kuang;
            this.pictureBox2.Location = new System.Drawing.Point(57, 70);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(374, 494);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(219, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "系统配置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(119, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "当前工位";
            // 
            // comboBox_CurrentStation
            // 
            this.comboBox_CurrentStation.FormattingEnabled = true;
            this.comboBox_CurrentStation.Items.AddRange(new object[] {
            "SUV下线检测点",
            "轻卡下线检测点",
            "轻卡淋雨检测点",
            "整车涉水检测点",
            "轻卡等电位检测点",
            "SUV等电位检测点"});
            this.comboBox_CurrentStation.Location = new System.Drawing.Point(219, 194);
            this.comboBox_CurrentStation.Name = "comboBox_CurrentStation";
            this.comboBox_CurrentStation.Size = new System.Drawing.Size(121, 25);
            this.comboBox_CurrentStation.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(291, 340);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 20);
            this.label20.TabIndex = 9;
            this.label20.Text = "mΩ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(207, 335);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(81, 23);
            this.textBox2.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(143, 334);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 21);
            this.label19.TabIndex = 6;
            this.label19.Text = "补偿值";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SafetyTesting.Properties.Resources.kuang;
            this.pictureBox3.Location = new System.Drawing.Point(467, 70);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(402, 494);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(139, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 27);
            this.label8.TabIndex = 9;
            this.label8.Text = "用户设置";
            // 
            // comboBox_userName
            // 
            this.comboBox_userName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox_userName.FormattingEnabled = true;
            this.comboBox_userName.Location = new System.Drawing.Point(160, 177);
            this.comboBox_userName.Name = "comboBox_userName";
            this.comboBox_userName.Size = new System.Drawing.Size(121, 29);
            this.comboBox_userName.TabIndex = 10;
            this.comboBox_userName.SelectionChangeCommitted += new System.EventHandler(this.comboBox_userName_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(61, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 21);
            this.label9.TabIndex = 11;
            this.label9.Text = "选择用户";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(65, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "用户名称";
            // 
            // textBox_userName
            // 
            this.textBox_userName.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_userName.Location = new System.Drawing.Point(162, 68);
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(123, 28);
            this.textBox_userName.TabIndex = 13;
            // 
            // button_AddUser
            // 
            this.button_AddUser.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_AddUser.Location = new System.Drawing.Point(47, 407);
            this.button_AddUser.Name = "button_AddUser";
            this.button_AddUser.Size = new System.Drawing.Size(124, 42);
            this.button_AddUser.TabIndex = 14;
            this.button_AddUser.Text = "添加用户";
            this.button_AddUser.UseVisualStyleBackColor = true;
            this.button_AddUser.Click += new System.EventHandler(this.button_AddUser_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(15, 210);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 21);
            this.label11.TabIndex = 15;
            this.label11.Text = "用户权限";
            // 
            // checkBox_car
            // 
            this.checkBox_car.AutoSize = true;
            this.checkBox_car.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_car.ForeColor = System.Drawing.Color.White;
            this.checkBox_car.Location = new System.Drawing.Point(32, 271);
            this.checkBox_car.Name = "checkBox_car";
            this.checkBox_car.Size = new System.Drawing.Size(93, 25);
            this.checkBox_car.TabIndex = 16;
            this.checkBox_car.Text = "车型权限";
            this.checkBox_car.UseVisualStyleBackColor = true;
            // 
            // checkBox_device
            // 
            this.checkBox_device.AutoSize = true;
            this.checkBox_device.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_device.ForeColor = System.Drawing.Color.White;
            this.checkBox_device.Location = new System.Drawing.Point(190, 271);
            this.checkBox_device.Name = "checkBox_device";
            this.checkBox_device.Size = new System.Drawing.Size(93, 25);
            this.checkBox_device.TabIndex = 17;
            this.checkBox_device.Text = "设备权限";
            this.checkBox_device.UseVisualStyleBackColor = true;
            // 
            // checkBox_system
            // 
            this.checkBox_system.AutoSize = true;
            this.checkBox_system.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_system.ForeColor = System.Drawing.Color.White;
            this.checkBox_system.Location = new System.Drawing.Point(32, 341);
            this.checkBox_system.Name = "checkBox_system";
            this.checkBox_system.Size = new System.Drawing.Size(93, 25);
            this.checkBox_system.TabIndex = 17;
            this.checkBox_system.Text = "系统权限";
            this.checkBox_system.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::SafetyTesting.Properties.Resources.kuang;
            this.pictureBox4.Location = new System.Drawing.Point(919, 70);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(460, 494);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 18;
            this.pictureBox4.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1092, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 27);
            this.label12.TabIndex = 19;
            this.label12.Text = "MESS设置";
            // 
            // textBox_mesAddress
            // 
            this.textBox_mesAddress.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_mesAddress.Location = new System.Drawing.Point(962, 258);
            this.textBox_mesAddress.Multiline = true;
            this.textBox_mesAddress.Name = "textBox_mesAddress";
            this.textBox_mesAddress.Size = new System.Drawing.Size(383, 59);
            this.textBox_mesAddress.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(962, 215);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 21);
            this.label13.TabIndex = 20;
            this.label13.Text = "webServer Address";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(962, 341);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 21);
            this.label15.TabIndex = 20;
            this.label15.Text = "数据上传间隔时间";
            // 
            // textBox_mesTime
            // 
            this.textBox_mesTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_mesTime.Location = new System.Drawing.Point(1106, 337);
            this.textBox_mesTime.Name = "textBox_mesTime";
            this.textBox_mesTime.Size = new System.Drawing.Size(55, 28);
            this.textBox_mesTime.TabIndex = 21;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(1167, 340);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 21);
            this.label16.TabIndex = 22;
            this.label16.Text = "s";
            // 
            // button_userSave
            // 
            this.button_userSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_userSave.Location = new System.Drawing.Point(205, 407);
            this.button_userSave.Name = "button_userSave";
            this.button_userSave.Size = new System.Drawing.Size(124, 42);
            this.button_userSave.TabIndex = 24;
            this.button_userSave.Text = "修改权限";
            this.button_userSave.UseVisualStyleBackColor = true;
            this.button_userSave.Visible = false;
            this.button_userSave.Click += new System.EventHandler(this.button_userSave_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(1067, 493);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 42);
            this.button4.TabIndex = 25;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_StationSave
            // 
            this.button_StationSave.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_StationSave.Location = new System.Drawing.Point(162, 426);
            this.button_StationSave.Name = "button_StationSave";
            this.button_StationSave.Size = new System.Drawing.Size(132, 42);
            this.button_StationSave.TabIndex = 26;
            this.button_StationSave.Text = "保存";
            this.button_StationSave.UseVisualStyleBackColor = true;
            this.button_StationSave.Click += new System.EventHandler(this.button_StationSave_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_password.Location = new System.Drawing.Point(160, 129);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(123, 28);
            this.textBox_password.TabIndex = 28;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(63, 131);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 21);
            this.label17.TabIndex = 27;
            this.label17.Text = "用户密码";
            // 
            // checkBox_data
            // 
            this.checkBox_data.AutoSize = true;
            this.checkBox_data.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_data.ForeColor = System.Drawing.Color.White;
            this.checkBox_data.Location = new System.Drawing.Point(190, 340);
            this.checkBox_data.Name = "checkBox_data";
            this.checkBox_data.Size = new System.Drawing.Size(93, 25);
            this.checkBox_data.TabIndex = 29;
            this.checkBox_data.Text = "数据权限";
            this.checkBox_data.UseVisualStyleBackColor = true;
            // 
            // checkBox_IsIO
            // 
            this.checkBox_IsIO.AutoSize = true;
            this.checkBox_IsIO.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_IsIO.ForeColor = System.Drawing.Color.White;
            this.checkBox_IsIO.Location = new System.Drawing.Point(119, 265);
            this.checkBox_IsIO.Name = "checkBox_IsIO";
            this.checkBox_IsIO.Size = new System.Drawing.Size(109, 25);
            this.checkBox_IsIO.TabIndex = 30;
            this.checkBox_IsIO.Text = "使能继电器";
            this.checkBox_IsIO.UseVisualStyleBackColor = true;
            // 
            // panel_userSetting
            // 
            this.panel_userSetting.Controls.Add(this.textBox_password);
            this.panel_userSetting.Controls.Add(this.label8);
            this.panel_userSetting.Controls.Add(this.label10);
            this.panel_userSetting.Controls.Add(this.textBox_userName);
            this.panel_userSetting.Controls.Add(this.button_AddUser);
            this.panel_userSetting.Controls.Add(this.label17);
            this.panel_userSetting.Controls.Add(this.comboBox_userName);
            this.panel_userSetting.Controls.Add(this.label9);
            this.panel_userSetting.Controls.Add(this.label11);
            this.panel_userSetting.Controls.Add(this.checkBox_data);
            this.panel_userSetting.Controls.Add(this.checkBox_car);
            this.panel_userSetting.Controls.Add(this.checkBox_device);
            this.panel_userSetting.Controls.Add(this.checkBox_system);
            this.panel_userSetting.Controls.Add(this.button_userSave);
            this.panel_userSetting.Location = new System.Drawing.Point(482, 86);
            this.panel_userSetting.Name = "panel_userSetting";
            this.panel_userSetting.Size = new System.Drawing.Size(366, 463);
            this.panel_userSetting.TabIndex = 36;
            // 
            // checkBox_IsPrint
            // 
            this.checkBox_IsPrint.AutoSize = true;
            this.checkBox_IsPrint.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_IsPrint.ForeColor = System.Drawing.Color.White;
            this.checkBox_IsPrint.Location = new System.Drawing.Point(273, 265);
            this.checkBox_IsPrint.Name = "checkBox_IsPrint";
            this.checkBox_IsPrint.Size = new System.Drawing.Size(125, 25);
            this.checkBox_IsPrint.TabIndex = 43;
            this.checkBox_IsPrint.Text = "是否测完打印";
            this.checkBox_IsPrint.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 12000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_MES
            // 
            this.label_MES.AutoSize = true;
            this.label_MES.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_MES.ForeColor = System.Drawing.Color.White;
            this.label_MES.Location = new System.Drawing.Point(1218, 456);
            this.label_MES.Name = "label_MES";
            this.label_MES.Size = new System.Drawing.Size(66, 21);
            this.label_MES.TabIndex = 44;
            this.label_MES.Text = "********";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1253, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(26)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_MES);
            this.Controls.Add(this.checkBox_IsPrint);
            this.Controls.Add(this.panel_userSetting);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.checkBox_IsIO);
            this.Controls.Add(this.button_StationSave);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox_mesTime);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textBox_mesAddress);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.comboBox_CurrentStation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Name = "setting";
            this.Size = new System.Drawing.Size(1600, 645);
            this.Load += new System.EventHandler(this.setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel_userSetting.ResumeLayout(false);
            this.panel_userSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_CurrentStation;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox_userName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.Button button_AddUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox_car;
        private System.Windows.Forms.CheckBox checkBox_device;
        private System.Windows.Forms.CheckBox checkBox_system;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_mesAddress;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_mesTime;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button_userSave;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button_StationSave;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox checkBox_data;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox checkBox_IsIO;
        private System.Windows.Forms.Panel panel_userSetting;
        private System.Windows.Forms.CheckBox checkBox_IsPrint;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_MES;
        private System.Windows.Forms.Button button1;
    }
}

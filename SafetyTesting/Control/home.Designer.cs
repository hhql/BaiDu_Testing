namespace SafetyTesting.Control
{
    partial class home
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_User = new System.Windows.Forms.Panel();
            this.label_level = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_name = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox_carModules = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label_stop = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PressImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Choice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textBox_carmodle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_vin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ucobd1 = new SafetyTesting.Control.UCOBD();
            this.roundButton_io = new SafetyTesting.UI.RoundButton();
            this.label2 = new System.Windows.Forms.Label();
            this.roundButton_anConn = new SafetyTesting.UI.RoundButton();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_Message = new System.Windows.Forms.Label();
            this.timer_anguiConn = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_pass = new System.Windows.Forms.Label();
            this.label_fail = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_User.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_User
            // 
            this.panel_User.BackgroundImage = global::SafetyTesting.Properties.Resources.kuang;
            this.panel_User.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_User.Controls.Add(this.label_level);
            this.panel_User.Controls.Add(this.panel1);
            this.panel_User.Location = new System.Drawing.Point(23, 40);
            this.panel_User.Name = "panel_User";
            this.panel_User.Size = new System.Drawing.Size(222, 198);
            this.panel_User.TabIndex = 0;
            // 
            // label_level
            // 
            this.label_level.AutoSize = true;
            this.label_level.Font = new System.Drawing.Font("思源黑体 CN Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_level.ForeColor = System.Drawing.Color.White;
            this.label_level.Location = new System.Drawing.Point(80, 164);
            this.label_level.Name = "label_level";
            this.label_level.Size = new System.Drawing.Size(58, 23);
            this.label_level.TabIndex = 1;
            this.label_level.Text = "管理员";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SafetyTesting.Properties.Resources.USER;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label_name);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 148);
            this.panel1.TabIndex = 0;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("思源黑体 CN Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_name.ForeColor = System.Drawing.Color.White;
            this.label_name.Location = new System.Drawing.Point(77, 113);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(62, 23);
            this.label_name.TabIndex = 2;
            this.label_name.Text = "Admin";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::SafetyTesting.Properties.Resources.kuang1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.comboBox_carModules);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.textBox_carmodle);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.textBox_vin);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Font = new System.Drawing.Font("思源黑体 CN Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel3.Location = new System.Drawing.Point(260, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1129, 528);
            this.panel3.TabIndex = 2;
            // 
            // comboBox_carModules
            // 
            this.comboBox_carModules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_carModules.Font = new System.Drawing.Font("思源黑体 CN Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox_carModules.FormattingEnabled = true;
            this.comboBox_carModules.Location = new System.Drawing.Point(270, 83);
            this.comboBox_carModules.Name = "comboBox_carModules";
            this.comboBox_carModules.Size = new System.Drawing.Size(533, 45);
            this.comboBox_carModules.TabIndex = 8;
            this.comboBox_carModules.Visible = false;
            this.comboBox_carModules.SelectionChangeCommitted += new System.EventHandler(this.comboBox_carModules_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(30, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "XXX-XX";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(970, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 46);
            this.button2.TabIndex = 6;
            this.button2.Text = "放弃";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Location = new System.Drawing.Point(869, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 46);
            this.button1.TabIndex = 3;
            this.button1.Text = "启动";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.label_stop);
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Location = new System.Drawing.Point(21, 154);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1089, 374);
            this.panel5.TabIndex = 2;
            // 
            // label_stop
            // 
            this.label_stop.AutoSize = true;
            this.label_stop.BackColor = System.Drawing.Color.Transparent;
            this.label_stop.Font = new System.Drawing.Font("思源黑体 CN Heavy", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_stop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label_stop.Location = new System.Drawing.Point(328, 50);
            this.label_stop.Name = "label_stop";
            this.label_stop.Size = new System.Drawing.Size(420, 237);
            this.label_stop.TabIndex = 4;
            this.label_stop.Text = "急停";
            this.label_stop.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(29)))), ((int)(((byte)(71)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("思源黑体 CN Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.PressImg,
            this.Column5,
            this.Choice});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("思源黑体 CN Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("思源黑体 CN Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1086, 374);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "序号";
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "name";
            this.Column2.HeaderText = "名称";
            this.Column2.Name = "Column2";
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "fanwei";
            this.Column3.HeaderText = "合格值范围";
            this.Column3.Name = "Column3";
            this.Column3.Width = 150;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "value";
            this.Column4.HeaderText = "检测值";
            this.Column4.Name = "Column4";
            this.Column4.Width = 150;
            // 
            // PressImg
            // 
            this.PressImg.DataPropertyName = "PressImg";
            this.PressImg.HeaderText = "进度条";
            this.PressImg.Name = "PressImg";
            this.PressImg.Width = 280;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "result";
            this.Column5.HeaderText = "结果";
            this.Column5.Name = "Column5";
            this.Column5.Width = 92;
            // 
            // Choice
            // 
            this.Choice.DataPropertyName = "Choice";
            this.Choice.HeaderText = "选择";
            this.Choice.Name = "Choice";
            this.Choice.Width = 80;
            // 
            // textBox_carmodle
            // 
            this.textBox_carmodle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_carmodle.Font = new System.Drawing.Font("思源黑体 CN Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_carmodle.ForeColor = System.Drawing.Color.Black;
            this.textBox_carmodle.Location = new System.Drawing.Point(270, 82);
            this.textBox_carmodle.MaxLength = 500;
            this.textBox_carmodle.Name = "textBox_carmodle";
            this.textBox_carmodle.Size = new System.Drawing.Size(548, 47);
            this.textBox_carmodle.TabIndex = 2;
            this.textBox_carmodle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_carmodle.DoubleClick += new System.EventHandler(this.textBox_carmodle_DoubleClick);
            this.textBox_carmodle.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_vin_KeyUp);
            this.textBox_carmodle.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_carmodle_PreviewKeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("思源黑体 CN Medium", 25.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(128, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 48);
            this.label8.TabIndex = 0;
            this.label8.Text = "车型码";
            this.label8.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBox_vin
            // 
            this.textBox_vin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox_vin.Font = new System.Drawing.Font("思源黑体 CN Regular", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_vin.ForeColor = System.Drawing.Color.Black;
            this.textBox_vin.Location = new System.Drawing.Point(270, 30);
            this.textBox_vin.MaxLength = 17;
            this.textBox_vin.Name = "textBox_vin";
            this.textBox_vin.Size = new System.Drawing.Size(548, 47);
            this.textBox_vin.TabIndex = 1;
            this.textBox_vin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_vin.TextChanged += new System.EventHandler(this.textBox_vin_TextChanged);
            this.textBox_vin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_vin_KeyUp_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("思源黑体 CN Medium", 25.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(175, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 48);
            this.label3.TabIndex = 0;
            this.label3.Text = "VIN";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::SafetyTesting.Properties.Resources.kuang;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Controls.Add(this.ucobd1);
            this.panel4.Controls.Add(this.roundButton_io);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.roundButton_anConn);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(23, 244);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(222, 324);
            this.panel4.TabIndex = 3;
            // 
            // ucobd1
            // 
            this.ucobd1.BackColor = System.Drawing.Color.Transparent;
            this.ucobd1.Location = new System.Drawing.Point(3, 43);
            this.ucobd1.Name = "ucobd1";
            this.ucobd1.Size = new System.Drawing.Size(196, 57);
            this.ucobd1.TabIndex = 5;
            // 
            // roundButton_io
            // 
            this.roundButton_io.BorderWidth = 1;
            this.roundButton_io.ButtonCenterColorEnd = System.Drawing.Color.White;
            this.roundButton_io.ButtonCenterColorStart = System.Drawing.Color.Gray;
            this.roundButton_io.DistanceToBorder = 4;
            this.roundButton_io.IsShowIcon = false;
            this.roundButton_io.Location = new System.Drawing.Point(147, 178);
            this.roundButton_io.Name = "roundButton_io";
            this.roundButton_io.Size = new System.Drawing.Size(50, 50);
            this.roundButton_io.TabIndex = 3;
            this.roundButton_io.Text = "roundButton2";
            this.roundButton_io.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(49, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "IO连接";
            // 
            // roundButton_anConn
            // 
            this.roundButton_anConn.BorderWidth = 1;
            this.roundButton_anConn.ButtonCenterColorEnd = System.Drawing.Color.White;
            this.roundButton_anConn.ButtonCenterColorStart = System.Drawing.Color.Gray;
            this.roundButton_anConn.DistanceToBorder = 4;
            this.roundButton_anConn.IsShowIcon = false;
            this.roundButton_anConn.Location = new System.Drawing.Point(147, 106);
            this.roundButton_anConn.Name = "roundButton_anConn";
            this.roundButton_anConn.Size = new System.Drawing.Size(50, 50);
            this.roundButton_anConn.TabIndex = 1;
            this.roundButton_anConn.Text = "roundButton1";
            this.roundButton_anConn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(49, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "安规连接";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Font = new System.Drawing.Font("Microsoft YaHei UI", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_Message.ForeColor = System.Drawing.Color.White;
            this.label_Message.Location = new System.Drawing.Point(659, 581);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(0, 52);
            this.label_Message.TabIndex = 4;
            // 
            // timer_anguiConn
            // 
            this.timer_anguiConn.Interval = 5000;
            this.timer_anguiConn.Tick += new System.EventHandler(this.timer_anguiConn_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "今日生产数据";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(60, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "合格数量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(50, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "不合格数量";
            // 
            // label_pass
            // 
            this.label_pass.AutoSize = true;
            this.label_pass.Font = new System.Drawing.Font("华文琥珀", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_pass.ForeColor = System.Drawing.Color.White;
            this.label_pass.Location = new System.Drawing.Point(62, 171);
            this.label_pass.Name = "label_pass";
            this.label_pass.Size = new System.Drawing.Size(66, 41);
            this.label_pass.TabIndex = 4;
            this.label_pass.Text = "00";
            // 
            // label_fail
            // 
            this.label_fail.AutoSize = true;
            this.label_fail.Font = new System.Drawing.Font("华文琥珀", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_fail.ForeColor = System.Drawing.Color.White;
            this.label_fail.Location = new System.Drawing.Point(62, 363);
            this.label_fail.Name = "label_fail";
            this.label_fail.Size = new System.Drawing.Size(66, 41);
            this.label_fail.TabIndex = 5;
            this.label_fail.Text = "00";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::SafetyTesting.Properties.Resources.kuang;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.label_fail);
            this.panel2.Controls.Add(this.label_pass);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(1395, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(185, 525);
            this.panel2.TabIndex = 1;
            // 
            // home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(26)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.label_Message);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_User);
            this.Name = "home";
            this.Size = new System.Drawing.Size(1600, 645);
            this.Load += new System.EventHandler(this.home_Load);
            this.panel_User.ResumeLayout(false);
            this.panel_User.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_User;
        private System.Windows.Forms.Label label_level;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_vin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private UI.RoundButton roundButton_anConn;
        private System.Windows.Forms.Label label1;
        private UI.RoundButton roundButton_io;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_Message;
        private  System.Windows.Forms.Timer timer_anguiConn;
        private System.Windows.Forms.Label label_stop;
        private UCOBD ucobd1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_pass;
        private System.Windows.Forms.Label label_fail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_carModules;
        private System.Windows.Forms.TextBox textBox_carmodle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewImageColumn PressImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Choice;
    }
}

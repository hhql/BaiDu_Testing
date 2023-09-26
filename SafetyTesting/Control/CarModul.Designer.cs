namespace SafetyTesting.Control
{
    partial class CarModul
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView_carModul = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip_car = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_vin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_U = new System.Windows.Forms.TextBox();
            this.textBox_C = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_carName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarModuleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Testname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_carModul)).BeginInit();
            this.contextMenuStrip_car.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SafetyTesting.Properties.Resources.kuang1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.dataGridView_carModul);
            this.panel1.Location = new System.Drawing.Point(656, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 505);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView_carModul
            // 
            this.dataGridView_carModul.AllowUserToResizeColumns = false;
            this.dataGridView_carModul.AllowUserToResizeRows = false;
            this.dataGridView_carModul.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(26)))), ((int)(((byte)(67)))));
            this.dataGridView_carModul.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_carModul.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_carModul.ColumnHeadersHeight = 50;
            this.dataGridView_carModul.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.CarModuleCode,
            this.Testname,
            this.range,
            this.pass,
            this.Column3});
            this.dataGridView_carModul.ContextMenuStrip = this.contextMenuStrip_car;
            this.dataGridView_carModul.EnableHeadersVisualStyles = false;
            this.dataGridView_carModul.Location = new System.Drawing.Point(20, 31);
            this.dataGridView_carModul.Name = "dataGridView_carModul";
            this.dataGridView_carModul.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_carModul.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_carModul.RowTemplate.Height = 50;
            this.dataGridView_carModul.Size = new System.Drawing.Size(867, 453);
            this.dataGridView_carModul.TabIndex = 0;
            this.dataGridView_carModul.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_carModul_CellMouseUp);
            this.dataGridView_carModul.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView_carModul_KeyUp);
            // 
            // contextMenuStrip_car
            // 
            this.contextMenuStrip_car.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip_car.Name = "contextMenuStrip1";
            this.contextMenuStrip_car.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("思源黑体 CN Regular", 30.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(301, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "车型配置";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::SafetyTesting.Properties.Resources.kuang;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.textBox_vin);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(82, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 505);
            this.panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(26)))), ((int)(((byte)(67)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip_car;
            this.dataGridView1.Location = new System.Drawing.Point(20, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 50;
            this.dataGridView1.Size = new System.Drawing.Size(481, 396);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseUp);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "code";
            this.Column1.HeaderText = "车型码";
            this.Column1.Name = "Column1";
            this.Column1.Width = 260;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "carModuleCode";
            this.Column2.HeaderText = "车型";
            this.Column2.Name = "Column2";
            this.Column2.Width = 180;
            // 
            // textBox_vin
            // 
            this.textBox_vin.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_vin.Location = new System.Drawing.Point(164, 24);
            this.textBox_vin.Multiline = true;
            this.textBox_vin.Name = "textBox_vin";
            this.textBox_vin.Size = new System.Drawing.Size(227, 42);
            this.textBox_vin.TabIndex = 1;
            this.textBox_vin.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_vin_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(86, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "车型码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("思源黑体 CN Regular", 30.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(894, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 57);
            this.label4.TabIndex = 3;
            this.label4.Text = "检测项配置";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::SafetyTesting.Properties.Resources.kuang1;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.button_save);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.textBox_U);
            this.panel3.Controls.Add(this.textBox_C);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label_carName);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(1216, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(172, 96);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "压缩机",
            "电机",
            "充电机"});
            this.comboBox1.Location = new System.Drawing.Point(95, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 25);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(26, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "类型";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(79, 230);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(91, 29);
            this.button_save.TabIndex = 10;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(200, 175);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "V";
            // 
            // textBox_U
            // 
            this.textBox_U.Location = new System.Drawing.Point(96, 175);
            this.textBox_U.Name = "textBox_U";
            this.textBox_U.Size = new System.Drawing.Size(100, 23);
            this.textBox_U.TabIndex = 7;
            this.textBox_U.Text = "0";
            // 
            // textBox_C
            // 
            this.textBox_C.Location = new System.Drawing.Point(96, 124);
            this.textBox_C.Name = "textBox_C";
            this.textBox_C.Size = new System.Drawing.Size(100, 23);
            this.textBox_C.TabIndex = 6;
            this.textBox_C.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(20, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "最大电压";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "电容容值";
            // 
            // label_carName
            // 
            this.label_carName.AutoSize = true;
            this.label_carName.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_carName.ForeColor = System.Drawing.Color.White;
            this.label_carName.Location = new System.Drawing.Point(111, 33);
            this.label_carName.Name = "label_carName";
            this.label_carName.Size = new System.Drawing.Size(34, 24);
            this.label_carName.TabIndex = 1;
            this.label_carName.Text = "......";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "车型";
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "序号";
            this.code.Name = "code";
            // 
            // CarModuleCode
            // 
            this.CarModuleCode.DataPropertyName = "carModuleCode";
            this.CarModuleCode.HeaderText = "车型号";
            this.CarModuleCode.Name = "CarModuleCode";
            this.CarModuleCode.Visible = false;
            this.CarModuleCode.Width = 200;
            // 
            // Testname
            // 
            this.Testname.DataPropertyName = "TestName";
            this.Testname.HeaderText = "检测名称";
            this.Testname.Name = "Testname";
            this.Testname.Width = 400;
            // 
            // range
            // 
            this.range.DataPropertyName = "Range";
            this.range.HeaderText = "范围值";
            this.range.Name = "range";
            this.range.Width = 200;
            // 
            // pass
            // 
            this.pass.DataPropertyName = "Pass";
            this.pass.FillWeight = 200F;
            this.pass.HeaderText = "通道";
            this.pass.Items.AddRange(new object[] {
            "通道一",
            "通道二",
            "通道三",
            "通道四",
            "通道五",
            "通道六",
            "通道七",
            "通道八",
            "通道九",
            "通道十",
            "通道十一",
            "通道十二"});
            this.pass.Name = "pass";
            this.pass.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "id";
            this.Column3.HeaderText = "Column3";
            this.Column3.Name = "Column3";
            this.Column3.Visible = false;
            // 
            // CarModul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(26)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "CarModul";
            this.Size = new System.Drawing.Size(1600, 645);
            this.Load += new System.EventHandler(this.CarModul_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_carModul)).EndInit();
            this.contextMenuStrip_car.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_carModul;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_vin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_car;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_U;
        private System.Windows.Forms.TextBox textBox_C;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_carName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarModuleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Testname;
        private System.Windows.Forms.DataGridViewTextBoxColumn range;
        private System.Windows.Forms.DataGridViewComboBoxColumn pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}

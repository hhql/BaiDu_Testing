namespace SafetyTesting.Control
{
    partial class Data
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_excel = new System.Windows.Forms.Button();
            this.button_print = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeP_end = new System.Windows.Forms.DateTimePicker();
            this.dateTime_start = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_carCode = new System.Windows.Forms.TextBox();
            this.dataGridView_data = new System.Windows.Forms.DataGridView();
            print_data = new System.Drawing.Printing.PrintDocument();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarModuleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Testname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsUpload = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::SafetyTesting.Properties.Resources.kuang1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button_excel);
            this.panel1.Controls.Add(this.button_print);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimeP_end);
            this.panel1.Controls.Add(this.dateTime_start);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_carCode);
            this.panel1.Controls.Add(this.dataGridView_data);
            this.panel1.Location = new System.Drawing.Point(61, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1517, 604);
            this.panel1.TabIndex = 1;
            // 
            // button_excel
            // 
            this.button_excel.Location = new System.Drawing.Point(1276, 38);
            this.button_excel.Name = "button_excel";
            this.button_excel.Size = new System.Drawing.Size(112, 37);
            this.button_excel.TabIndex = 6;
            this.button_excel.Text = "导出Excel";
            this.button_excel.UseVisualStyleBackColor = true;
            this.button_excel.Click += new System.EventHandler(this.button_excel_Click);
            // 
            // button_print
            // 
            this.button_print.Location = new System.Drawing.Point(1146, 38);
            this.button_print.Name = "button_print";
            this.button_print.Size = new System.Drawing.Size(112, 37);
            this.button_print.TabIndex = 3;
            this.button_print.Text = "打印数据";
            this.button_print.UseVisualStyleBackColor = true;
            this.button_print.Click += new System.EventHandler(this.button_print_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(756, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "~";
            // 
            // dateTimeP_end
            // 
            this.dateTimeP_end.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeP_end.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTimeP_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeP_end.Location = new System.Drawing.Point(808, 38);
            this.dateTimeP_end.Name = "dateTimeP_end";
            this.dateTimeP_end.Size = new System.Drawing.Size(313, 41);
            this.dateTimeP_end.TabIndex = 4;
            this.dateTimeP_end.Tag = "";
            this.dateTimeP_end.ValueChanged += new System.EventHandler(this.dateTimeP_end_ValueChanged);
            // 
            // dateTime_start
            // 
            this.dateTime_start.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTime_start.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dateTime_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime_start.Location = new System.Drawing.Point(427, 38);
            this.dateTime_start.Name = "dateTime_start";
            this.dateTime_start.Size = new System.Drawing.Size(313, 41);
            this.dateTime_start.TabIndex = 3;
            this.dateTime_start.Tag = "";
            this.dateTime_start.ValueChanged += new System.EventHandler(this.dateTime_start_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(84, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "VIN";
            // 
            // textBox_carCode
            // 
            this.textBox_carCode.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_carCode.Location = new System.Drawing.Point(153, 38);
            this.textBox_carCode.Name = "textBox_carCode";
            this.textBox_carCode.Size = new System.Drawing.Size(251, 41);
            this.textBox_carCode.TabIndex = 1;
            this.textBox_carCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_carCode_KeyUp);
            // 
            // dataGridView_data
            // 
            this.dataGridView_data.AllowUserToAddRows = false;
            this.dataGridView_data.AllowUserToDeleteRows = false;
            this.dataGridView_data.AllowUserToResizeColumns = false;
            this.dataGridView_data.AllowUserToResizeRows = false;
            this.dataGridView_data.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(26)))), ((int)(((byte)(67)))));
            this.dataGridView_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_data.ColumnHeadersHeight = 50;
            this.dataGridView_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.Column1,
            this.CarModuleCode,
            this.Testname,
            this.range,
            this.value,
            this.result,
            this.Column2,
            this.StationName,
            this.IsUpload});
            this.dataGridView_data.EnableHeadersVisualStyles = false;
            this.dataGridView_data.Location = new System.Drawing.Point(21, 99);
            this.dataGridView_data.Name = "dataGridView_data";
            this.dataGridView_data.ReadOnly = true;
            this.dataGridView_data.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_data.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_data.RowTemplate.Height = 50;
            this.dataGridView_data.Size = new System.Drawing.Size(1459, 487);
            this.dataGridView_data.TabIndex = 0;
            // 
            // print_data
            // 
            print_data.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "序号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "vin";
            this.Column1.HeaderText = "VIN码";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 300;
            // 
            // CarModuleCode
            // 
            this.CarModuleCode.DataPropertyName = "carModuleCode";
            this.CarModuleCode.HeaderText = "车型号";
            this.CarModuleCode.Name = "CarModuleCode";
            this.CarModuleCode.ReadOnly = true;
            // 
            // Testname
            // 
            this.Testname.DataPropertyName = "TestName";
            this.Testname.HeaderText = "检测名称";
            this.Testname.Name = "Testname";
            this.Testname.ReadOnly = true;
            this.Testname.Width = 300;
            // 
            // range
            // 
            this.range.DataPropertyName = "Range";
            this.range.HeaderText = "范围值";
            this.range.Name = "range";
            this.range.ReadOnly = true;
            this.range.Width = 200;
            // 
            // value
            // 
            this.value.DataPropertyName = "value";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.value.DefaultCellStyle = dataGridViewCellStyle2;
            this.value.HeaderText = "检测值";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            this.value.Width = 130;
            // 
            // result
            // 
            this.result.DataPropertyName = "result";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.result.DefaultCellStyle = dataGridViewCellStyle3;
            this.result.HeaderText = "结果";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "CreateTime";
            this.Column2.HeaderText = "检测时间";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // StationName
            // 
            this.StationName.DataPropertyName = "StationName";
            this.StationName.HeaderText = "站点名称";
            this.StationName.Name = "StationName";
            this.StationName.ReadOnly = true;
            this.StationName.Width = 200;
            // 
            // IsUpload
            // 
            this.IsUpload.DataPropertyName = "IsUpload";
            this.IsUpload.HeaderText = "是否上传";
            this.IsUpload.Name = "IsUpload";
            this.IsUpload.ReadOnly = true;
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(26)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.panel1);
            this.Name = "Data";
            this.Size = new System.Drawing.Size(1600, 645);
            this.Load += new System.EventHandler(this.Data_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_carCode;
        private System.Windows.Forms.DataGridView dataGridView_data;
        private System.Windows.Forms.DateTimePicker dateTime_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeP_end;
        private System.Windows.Forms.Button button_print;
        private System.Windows.Forms.Button button_excel;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarModuleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Testname;
        private System.Windows.Forms.DataGridViewTextBoxColumn range;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsUpload;
        public static System.Drawing.Printing.PrintDocument print_data;
    }
}

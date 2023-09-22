
namespace SafetyTesting
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.ucobd1 = new SafetyTesting.Control.UCOBD();
            this.button4 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(0, 208);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(800, 242);
            this.listBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(323, 40);
            this.button1.TabIndex = 2;
            this.button1.Text = "整车绝缘打开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(61, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(323, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "整车绝缘关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(702, 154);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(77, 44);
            this.button7.TabIndex = 8;
            this.button7.Text = "清空";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // ucobd1
            // 
            this.ucobd1.BackColor = System.Drawing.Color.Transparent;
            this.ucobd1.Location = new System.Drawing.Point(569, 162);
            this.ucobd1.Name = "ucobd1";
            this.ucobd1.Size = new System.Drawing.Size(18, 22);
            this.ucobd1.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(61, 105);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(323, 41);
            this.button4.TabIndex = 10;
            this.button4.Text = "绝缘监测关闭";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(427, 105);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(323, 41);
            this.button8.TabIndex = 11;
            this.button8.Text = "绝缘监测打开";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(569, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 34);
            this.button3.TabIndex = 12;
            this.button3.Text = "打开CAN";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.ucobd1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button7;
        private Control.UCOBD ucobd1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button3;
    }
}
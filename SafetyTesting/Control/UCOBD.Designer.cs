﻿
namespace SafetyTesting.Control
{
    partial class UCOBD
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
            this.roundButton_CANConn = new SafetyTesting.UI.RoundButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // roundButton_CANConn
            // 
            this.roundButton_CANConn.BorderWidth = 1;
            this.roundButton_CANConn.ButtonCenterColorEnd = System.Drawing.Color.White;
            this.roundButton_CANConn.ButtonCenterColorStart = System.Drawing.Color.Gray;
            this.roundButton_CANConn.DistanceToBorder = 4;
            this.roundButton_CANConn.IsShowIcon = false;
            this.roundButton_CANConn.Location = new System.Drawing.Point(149, 3);
            this.roundButton_CANConn.Name = "roundButton_CANConn";
            this.roundButton_CANConn.Size = new System.Drawing.Size(50, 50);
            this.roundButton_CANConn.TabIndex = 4;
            this.roundButton_CANConn.Text = "roundButton1";
            this.roundButton_CANConn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "CAN连接";
            // 
            // UCOBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.roundButton_CANConn);
            this.Controls.Add(this.label1);
            this.Name = "UCOBD";
            this.Size = new System.Drawing.Size(221, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UI.RoundButton roundButton_CANConn;
        private System.Windows.Forms.Label label1;
    }
}

using SafetyTesting.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SafetyTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
           
        }
        Action<string, int> CANInfoAction;
        private void button1_Click(object sender, EventArgs e)
        {
            ucobd1.StartCAN(EFunctionType.VehicleRelay_OPEN,CarModuleType.GSE,false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CANInfoAction = new Action<string, int>(LearningResult);
        }
        public void LearningResult(string data, int num)
        {
           
            Invoke(new EventHandler(delegate
            {
                listBox1.Items.Add(data);

            }));



        }

        private void button2_Click(object sender, EventArgs e)
        {
            ucobd1.StartCAN(EFunctionType.VehicleRelay_CLOSE,CarModuleType.D180,false);
        }


        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ucobd1.CloseCAN();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ucobd1.InitializeCAN(CANInfoAction);//添加到委托
            ucobd1.StartCAN(EFunctionType.Insulation_CLOSE,CarModuleType.D180, false);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("没有开启绝缘监测指令");
           
           // ucobd1.StartCAN(EFunctionType.Insulation__OPEN, CarModuleType.D180, false);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //ucobd1.InitializeCAN(CANInfoAction,0,CarModuleType.D180);//添加到委托
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SafetyTesting
{
    public partial class CARMODEFrm : Form
    {
        public CARMODEFrm()
        {
            InitializeComponent();
        }
        string Carname = "";
        List<string> typenames= new List<string>();
        public void carmodelLabel(string carname,List<string> typename) 
        {
            Carname = carname;
            typenames= typename;
            label_carmodle.Text = carname;
            label_carmodle.ForeColor = Color.Green;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text!="")
            {
                Global.TypeCarModule = comboBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void CARMODEFrm_Load(object sender, EventArgs e)
        {
            label_carmodle.Text = Carname;
            label_carmodle.ForeColor = Color.Green;

            foreach (string item in typenames)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}

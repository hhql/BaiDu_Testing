using SafetyTesting.DB.Entity;
using SafetyTesting.DB.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafetyTesting.Control
{
    public partial class CarModul : UserControl
    {
        public  ISafetyDataRepository safetyDataRepository;
        public CarModul()
        {
            InitializeComponent();
        }

        private void CarModul_Load(object sender, EventArgs e)
        {
            

            dataGridView_carModul.Enabled = false;
            comboBox1.SelectedIndex = 0;


            if (home.LocadTitle() == "返修工位" || home.LocadTitle().Contains("整车"))
            {
               // panel3.Visible = true;
            }
            else
            {
              //  panel3.Visible = false;
            }

            if (home.LocadTitle()== "充电检测")
            {
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Clear();
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("直流口");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("交流口");

               // panel3.Visible = false;
            }
            else
            {
                if (safetyDataRepository!=null)
                {
                    List<db_IOModule> db_IOModules = safetyDataRepository.GetData<db_IOModule>().ToList();

                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Clear();
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[0].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[1].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[2].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[3].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[4].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[5].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[6].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[7].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[8].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[9].Pass);
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位一");
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位二");
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位三");
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位四");
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位五");
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位六");
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位七");
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位八");
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位九");
                    ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位十");
                }
                
            }
        }
       
        
        public void GetCarVin(string vin) 
        {

            List<db_IOModule> db_IOModules = safetyDataRepository.GetData<db_IOModule>().ToList();

            

            DataTable vinCodeData = new DataTable();
            vinCodeData.Columns.Add("code", typeof(string));
            vinCodeData.Columns.Add("carModuleCode", typeof(string));
            List<db_CarVinCode> db_CarModules = safetyDataRepository.GetData<db_CarVinCode>().Where(x => x.Vin.ToLower().Contains(vin.ToLower())).ToList();
            foreach (db_CarVinCode item in db_CarModules)
            {
                DataRow dataRow = vinCodeData.NewRow();
                dataRow["code"] = item.Vin;
                dataRow["carModuleCode"] = item.CarModuleName;
                vinCodeData.Rows.Add(dataRow);
            }

            dataGridView1.DataSource = vinCodeData;
        }
        public void GetCarModul(string carCode) 
        {
            if (home.LocadTitle() == "充电检测")
            {
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Clear();
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("直流口");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("交流口");
            }
            else
            {
                List<db_IOModule> db_IOModules = safetyDataRepository.GetData<db_IOModule>().ToList();

                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Clear();
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[0].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[1].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[2].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[3].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[4].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[5].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[6].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[7].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[8].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add(db_IOModules[9].Pass);
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位一");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位二");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位三");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位四");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位五");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位六");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位七");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位八");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位九");
                ((DataGridViewComboBoxColumn)dataGridView_carModul.Columns[4]).Items.Add("等电位十");
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("carModuleCode", typeof(string));
            dt.Columns.Add("TestName", typeof(string));
            dt.Columns.Add("Range", typeof(string));
            dt.Columns.Add("pass", typeof(string));




            List<db_CarModule> db_CarModules = safetyDataRepository.GetData<db_CarModule>().Where(x => x.CarModuleName.ToLower()==(carCode.ToLower())).ToList();

            foreach (db_CarModule item in db_CarModules)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["code"] = item.Code;
                dataRow["carModuleCode"] = item.CarModuleName;
                dataRow["TestName"] = item.TestName;
                dataRow["Range"] = item.Range;
                //((DataGridViewComboBoxColumn)dataRow["pass"]).Items.Add(item.Pass);

                dataRow["pass"] = item.Pass;
                dt.Rows.Add(dataRow);
            }

            dataGridView_carModul.DataSource = dt;
        }

        private void textBox_carCode_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            GetCarModul(textBox.Text);
        }

        private void dataGridView_carModul_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                DataGridViewRow viewrows = dataGridView_carModul.Rows[dataGridView_carModul.CurrentCell.RowIndex-1];

                if (viewrows != null)
                {
                    string code =viewrows.Cells[0].Value.ToString();
                   string carModule1=viewrows.Cells[1].Value.ToString();
                    string TestName = viewrows.Cells[2].Value.ToString();
                    string Range = viewrows.Cells[3].Value.ToString();
                    string pass = viewrows.Cells[4].Value.ToString();

                    if (code != ""  && TestName != "" && Range != "" && pass != "") 
                    {
                        db_CarModule db_Car = safetyDataRepository.GetData<db_CarModule>().Where(x =>x.CarModuleName== carModuleCode &&  x.Code == code).FirstOrDefault();
                        if (db_Car != null)
                        {
                            //更新数据
                            db_Car.Code = code;
                            db_Car.Range = Range;
                            db_Car.CarModuleName = carModuleCode;
                            db_Car.Pass = pass;
                            db_Car.TestName = TestName;
                            safetyDataRepository.Update<db_CarModule>(db_Car);
                        }
                        else
                        {
                            //添加数据

                            db_CarModule carModule = new db_CarModule
                            {
                                CarModuleName = carModuleCode,
                                TestName = TestName,
                                Code = code,
                                Range = Range,
                                Pass = pass
                            };
                            safetyDataRepository.Insert<db_CarModule>(carModule);
                        }

                        GetCarModul(carModuleCode);
                    }
                    else
                    {
                        GetCarModul(carModuleCode);
                    }
                    
                   
                }


            }
        }
        string carModuleCode=string.Empty;
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow viewrows = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex - 1];

                if (viewrows != null)
                {
                    string code = viewrows.Cells[0].Value.ToString();
                    string carModuleCode = viewrows.Cells[1].Value.ToString();

                    if (code != "" && carModuleCode != "")
                    {

                        db_CarVinCode db_CarVin = new db_CarVinCode()
                        {
                            CarModuleName = carModuleCode,
                            Vin = code
                        };
                        //db_CarVinCode db_Car = safetyDataRepository.GetData<db_CarVinCode>().Where(x => x.Vin == code).FirstOrDefault();
                        //if (db_Car != null)
                        //{
                        //    db_Car.Vin = code;
                        //    db_Car.CarModuleName = carModuleCode;
                        //    safetyDataRepository.Update<db_CarVinCode>(db_Car);
                        //}
                        //else
                        //{
                        //    safetyDataRepository.Insert(db_CarVin);
                        //}

                        safetyDataRepository.Insert(db_CarVin);
                        //textBox_vin.Text = code;
                        GetCarVin("");
                    }


                }


            }
        }

        private void textBox_vin_KeyUp(object sender, KeyEventArgs e)
        {
            GetCarVin(textBox_vin.Text);
        }

        public void GetCarNameF(string name) 
        {
            label_carName.Text = name;
            

            db_TestingConfig db_Testings = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == name+"压缩机").FirstOrDefault();
            if (db_Testings!=null)
            {
                string[] strs = db_Testings.Value.Split(';');
                textBox_C.Text = strs[0];
                textBox_U.Text = strs[1];
            }
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex==-1)
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value==null)
            {
                return;
            }
           string carmodul= dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (carmodul!="") 
            {
                dataGridView_carModul.Enabled = true;
                carModuleCode=carmodul;
                
                GetCarModul(carmodul);
                GetCarNameF(carmodul);
            }
        }

        string carmoduleName=string.Empty;
        string vinName=string.Empty;
        private void dataGridView_carModul_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView_carModul.ClearSelection();
                    dataGridView_carModul.Rows[e.RowIndex].Selected = true;
                    dataGridView_carModul.CurrentCell = dataGridView_carModul.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip_car.Show(MousePosition.X, MousePosition.Y);
                    vinName = "";
                    carmoduleName = dataGridView_carModul.Rows[dataGridView_carModul.CurrentRow.Index].Cells[2].Value == null ? "":dataGridView_carModul.Rows[dataGridView_carModul.CurrentRow.Index].Cells[2].Value.ToString();
                }
            }
        }


        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip_car.Show(MousePosition.X, MousePosition.Y);
                    carmoduleName = "";
                    vinName = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value == null ? "" : dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();

                }
            }
        }

        private void 删除ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (vinName != "")
            {
                db_CarVinCode _CarModule = safetyDataRepository.GetData<db_CarVinCode>().Where(x => x.Vin == vinName).FirstOrDefault();
                if (_CarModule != null)
                {
                    safetyDataRepository.Delete(_CarModule);
                }
                vinName = "";
                List<db_CarVinCode> _CarModulees = safetyDataRepository.GetData<db_CarVinCode>().Where(x => x.CarModuleName == _CarModule.CarModuleName).ToList();
                if (_CarModulees.Count==0)
                {
                    List<db_CarModule> _CarModules = safetyDataRepository.GetData<db_CarModule>().Where(x => x.CarModuleName == _CarModule.CarModuleName).ToList();
                    foreach (db_CarModule item in _CarModules)
                    {

                        safetyDataRepository.Delete(item);
                    }
                }
               
                GetCarVin("");
            }
            else if (carmoduleName != "")
            {
                    db_CarModule _CarModule = safetyDataRepository.GetData<db_CarModule>().Where(x => x.TestName == carmoduleName).FirstOrDefault();
                    if (_CarModule != null)
                    {
                        safetyDataRepository.Delete(_CarModule);
                    }
                    GetCarModul(carModuleCode);
                carmoduleName = "";

            }
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (label_carName.Text== "......")
                return;

            if (safetyDataRepository.GetData<db_TestingConfig>().Any(x => x.SettingName == label_carName.Text+ comboBox1.Text))
            {
                db_TestingConfig testingConfig = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == label_carName.Text+ comboBox1.Text).FirstOrDefault();
                testingConfig.Value = textBox_C.Text + ";" + textBox_U.Text;
                safetyDataRepository.Update(testingConfig);
            }
            else
            {

                db_TestingConfig testingConfig = new db_TestingConfig();
                testingConfig.SettingName = label_carName.Text+ comboBox1.Text;
                testingConfig.Value = textBox_C.Text + ";" + textBox_U.Text;
                safetyDataRepository.Insert(testingConfig);
            }
            
            MessageBox.Show("保存成功");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (safetyDataRepository!=null)
            {
                db_TestingConfig testingConfig = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == label_carName.Text + comboBox1.Text).FirstOrDefault();
                if (testingConfig != null)
                {
                    string[] strs = testingConfig.Value.Split(';');
                    textBox_C.Text = strs[0];
                    textBox_U.Text = strs[1];
                }
            }
            

        }
    }
}

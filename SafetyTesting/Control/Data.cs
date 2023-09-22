using OfficeOpenXml;
using OfficeOpenXml.Style;
using SafetyTesting.DB.Entity;
using SafetyTesting.DB.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafetyTesting.Control
{
    public partial class Data : UserControl
    {
        public ISafetyDataRepository safetyDataRepository;

        public static string VIN = string.Empty;
        public static string Names = string.Empty;
        public static string CreateTime = string.Empty;
        public static List<listsen> listsens = new List<listsen>();
        public Data()
        {
            InitializeComponent();

        }




        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Bitmap bit = new Bitmap(300, 300);
            //Graphics g = Graphics.FromImage(bit);

            e.Graphics.DrawString("          新能源安规检测", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 0));
            e.Graphics.DrawString("艾诺检测仪        " + Names, new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 30));

            //else if (Convert.ToInt32(ConfigurationManager.AppSettings["Station_ID"]) == 2)
            //{
            //    e.Graphics.DrawString("          电位均衡检测2", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 0));
            //    e.Graphics.DrawString("日置检测仪        组装二线1工位", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 30));

            //}
            //else if (Convert.ToInt32(ConfigurationManager.AppSettings["Station_ID"]) == 1)
            //{
            //    e.Graphics.DrawString("          电位均衡检测1", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 0));
            //    e.Graphics.DrawString("日置检测仪        底盘二线13工位左侧", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 30));
            //}

            e.Graphics.DrawString("-------------------------------------------", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 50));
            e.Graphics.DrawString("打印时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 70));
            e.Graphics.DrawString("测试时间：" + CreateTime, new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 90));
            e.Graphics.DrawString("VIN：" + VIN, new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 110));

            e.Graphics.DrawString("********************************************", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 140));
            e.Graphics.DrawString("序号   名称       阻值    标准  合格", new Font("宋体", 10), new SolidBrush(Color.Black), new PointF(0, 160));
            int i = 1;
            string str = "";
            //不不
            //  不
            foreach (var item in listsens)
            {
                string nok = item.state == "合格" ? "√" : "×";
                int count = 7 - item.descName.Length < 0 ? 0 : 7 - item.descName.Length;
                string descName = item.descName;
                for (int y = 0; y < count; y++)
                {
                    descName += "  ";
                }
                str = "  " + i.ToString() + "   " + descName + " " + item.parameter_value + "   " + item.range_value + "   " + nok;

                if (item.state == "不合格")
                {
                    e.Graphics.DrawString(str, new Font("宋体", 8), new SolidBrush(Color.Red), new PointF(0, 160 + i * 20));
                }
                else
                {
                    e.Graphics.DrawString(str, new Font("宋体", 8), new SolidBrush(Color.Black), new PointF(0, 160 + i * 20));
                }
                i++;
            }
          

            //imagedata.Save("G:\\Manager\\Security specifications\\Safety_DZ\\src\\SafetyTesting\\SafetyTesting\\bin\\Debug\\netcoreapp3.1\\Excel\\1.jpg");
        }


        private void Data_Load(object sender, EventArgs e)
        {


        }
        public static void PrintData(List<listsen> datas)
        {
            listsens = new List<listsen>();
            listsens = datas;
            print_data.Print();

        }
        private void textBox_carCode_KeyUp(object sender, KeyEventArgs e)
        {

            QueryData(textBox_carCode.Text.Trim(), dateTime_start.Value, dateTimeP_end.Value);
        }

        public void QueryData(string vin, DateTime startTime, DateTime endTime)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("vin", typeof(string));
            dt.Columns.Add("carModuleCode", typeof(string));
            dt.Columns.Add("TestName", typeof(string));
            dt.Columns.Add("Range", typeof(string));
            dt.Columns.Add("value", typeof(string));
            dt.Columns.Add("result", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("StationName", typeof(string));
            dt.Columns.Add("IsUpload", typeof(string));
            List<db_TestingData> testingDatas = safetyDataRepository.GetData<db_TestingData>().Where(
                x => x.Vin.ToLower().Contains(vin.ToLower())
            && Convert.ToDateTime(x.CreateTime) > startTime
            && Convert.ToDateTime(x.CreateTime) < endTime).ToList();

            foreach (db_TestingData data in testingDatas)
            {
                DataRow dr = dt.NewRow();
                dr["code"] = data.Id;
                dr["vin"] = data.Vin;
                dr["carModuleCode"] = data.carModuleCode;
                dr["TestName"] = data.TestingName;
                //if (data.TestingName.Contains("绝缘") || data.TestingName.Contains("充电口"))
                //{
                //    dr["Range"] = ">"+data.Range+"MΩ";
                //    dr["value"] = data.value+"MΩ";
                //}
                //else
                //{
                //    dr["Range"] = "<" + data.Range + "mΩ";
                //    dr["value"] = data.value + "mΩ";
                //}
                dr["Range"] = data.Range;
                dr["value"] = data.value;

                dr["result"] = data.result;
                dr["CreateTime"] = data.CreateTime;
                dr["StationName"] = data.StationName;
                dr["IsUpload"] = data.IsUpload;
                dt.Rows.Add(dr);
            }
            dataGridView_data.DataSource = dt;
        }

        private void dateTime_start_ValueChanged(object sender, EventArgs e)
        {
            QueryData(textBox_carCode.Text.Trim(), dateTime_start.Value, dateTimeP_end.Value);
        }

        private void dateTimeP_end_ValueChanged(object sender, EventArgs e)
        {
            QueryData(textBox_carCode.Text.Trim(), dateTime_start.Value, dateTimeP_end.Value);
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            if (dataGridView_data.Rows.Count > 0)
            {

                listsens = new List<listsen>();
                foreach (DataGridViewRow row in dataGridView_data.Rows)
                {
                    VIN = row.Cells[1].Value.ToString();
                    CreateTime = row.Cells[7].Value.ToString();
                    Name = home.CurrentStation;
                    listsen listsen = new listsen
                    {
                        descName = row.Cells[3].Value.ToString(),
                        range_value = row.Cells[4].Value.ToString(),
                        parameter_value = row.Cells[5].Value.ToString(),
                        state = row.Cells[6].Value.ToString()
                    };
                    listsens.Add(listsen);
                }

                print_data.Print();
                MessageBox.Show("已发送打印");
            }
            else
            {
                MessageBox.Show("数据为空,打印失败");
            }
        }
        private void button_excel_Click(object sender, EventArgs e)
        {
            if (dataGridView_data.Rows.Count > 0)
            {
                DataTable dt = new DataTable(" Datas ");
                dt.Columns.Add("编号", typeof(string));
                dt.Columns.Add("VIN码", typeof(string));
                dt.Columns.Add("车型号", typeof(string));
                dt.Columns.Add("检测名称", typeof(string));
                dt.Columns.Add("范围值", typeof(string));
                dt.Columns.Add("检测值", typeof(string));
                dt.Columns.Add("结果", typeof(string));
                dt.Columns.Add("检测时间", typeof(string));
                dt.Columns.Add("站点名称", typeof(string));
                dt.Columns.Add("是否上传", typeof(string));
                for (int i = 0; i < dataGridView_data.Rows.Count; i++)
                {
                    DataRow newRow=dt.NewRow();
                    newRow["编号"]= dataGridView_data.Rows[i].Cells[0].Value;
                    newRow["VIN码"] = dataGridView_data.Rows[i].Cells[1].Value;
                    newRow["车型号"] = dataGridView_data.Rows[i].Cells[2].Value;
                    newRow["检测名称"] = dataGridView_data.Rows[i].Cells[3].Value;
                    newRow["范围值"] = dataGridView_data.Rows[i].Cells[4].Value;
                    newRow["检测值"] = dataGridView_data.Rows[i].Cells[5].Value;
                    newRow["结果"] = dataGridView_data.Rows[i].Cells[6].Value;
                    newRow["检测时间"] = dataGridView_data.Rows[i].Cells[7].Value;
                    newRow["站点名称"] = dataGridView_data.Rows[i].Cells[8].Value;
                    newRow["是否上传"] = dataGridView_data.Rows[i].Cells[9].Value;
                    dt.Rows.Add(newRow);
                }

                
                string path = Application.StartupPath.ToString() + "Excel\\Data " + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".xlsx";


                SaveXml(dt, path);

                

            }


        }
        public  void SaveXml(DataTable dt, string path)
        {
            var filename = "demo.xlsx";
           // FileStream newfile = File.Create(path);
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.SetValue($"B3", "AAA");// 设置值
                worksheet.InsertRow(6, 2, 6); // 插入行， 参数1：在第几行插入，参数2：插入几行，参数3：从第几行赋值格式
              //  worksheet.Cells[$"B2:D2"].Merge = true; // 合并从B2到D2的单元格
               // var logo = Image.FromFile($@"{Environment.CurrentDirectory}/1.jpg");  // 读取图片
                //var picture = worksheet.Drawings.AddPicture("logo", logo); // 添加图片
                //picture.SetSize(130, 32);  // 设置图片大小
                //picture.SetPosition(1, 3, 1, 3); // 插入图片，参数1：插入的行，参数2：行偏移量，参数3：插入的列，参数4：列偏移量
                //worksheet.Cells.Style.ShrinkToFit = true;//单元格自动适应大小
                //worksheet.Row(1).Height = 15;//设置行高
                //worksheet.Row(1).CustomHeight = true;//自动调整行高
               ///* worksheet.Col*/umn(1).Width = 15;//设置列宽
                worksheet.Cells.Style.WrapText = true;//自动换行




                for (int i = 1; i < dt.Columns.Count+1; i++)
                {
                    worksheet.Column(i).Width = 30;
                    worksheet.Row(i).Height = 20;//设置行高
                    worksheet.Cells[1, i].Style.Font.Bold = true;//字体为粗体
                    worksheet.Cells[1, i].Style.Font.Color.SetColor(Color.White);//字体颜色
                    worksheet.Cells[1, i].Style.Font.Name = "微软雅黑";//字体
                    worksheet.Cells[1, i].Style.Font.Size = 12;//字体大小
                    worksheet.Cells[1, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(128, 128, 128));

                    worksheet.Cells[1, i].Hyperlink = new ExcelHyperLink("https:\\www.cjavapy.com", UriKind.Relative); //单元格超链接
                    worksheet.Cells[1, i].Value = dt.Columns[i-1].ColumnName;
                    //worksheet.Cells[1, 2].Value = "price";
                    //worksheet.Cells[1, 3].Value = "volume";
                    for (int y = 1; y < dt.Rows.Count+1; y++)
                    {
                        worksheet.Cells[y+1 , i].Value =dt.Rows[y-1][i-1].ToString();
                    }

                }
                //var random = new Random();
                //for (int i = 0; i < 10; i++)
                //{
                    
                //    worksheet.Cells[i + 2, 2].Value = random.NextDouble() * 1e3;
                //    worksheet.Cells[i + 2, 3].Value = random.Next() / 1e3;
                //}
                //worksheet.Cells[2, 1, 11, 1].Style.Numberformat.Format = "dd/MM/yyyy";
                //worksheet.Cells[2, 2, 11, 2].Style.Numberformat.Format = "#,##0.111111";
                //worksheet.Cells[2, 3, 11, 3].Style.Numberformat.Format = "#,##0";
                //worksheet.Column(1).AutoFit();
                //worksheet.Column(2).AutoFit();
                //worksheet.Column(3).AutoFit();
                package.Save();

                
                MessageBox.Show("已导出Excel");
            }


        }
    }
}

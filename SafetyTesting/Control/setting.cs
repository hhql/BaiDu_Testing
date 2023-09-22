using Microsoft.Win32;
using SafetyTesting.DB.Entity;
using SafetyTesting.DB.Interface;
using SafetyTesting.Tool;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using WebSocket4Net;

namespace SafetyTesting.Control
{
    //
    public partial class setting : UserControl
    {
        public ISafetyDataRepository safetyDataRepository;
        Action<string> action;
        bool IsENTERSET = false;
        bool IsButtonMain = true;
        public static WebSocket webSocket4Net = null;
        string MESAddress="";//MES 地址
        string CurrentStation = "";//当前工位
        public setting()
        {
            InitializeComponent();
            action = (data) => 
            {
                if (!Global.IsSettingComm)
                {
                    return;
                }
                if (Global.IsStop)
                {
                    return;
                }

                LogHelper.Info("设置回复数据" + data);
                if (data.Contains("RETURN-MAIN"))
                {
                    if (IsENTERSET)
                    {
                        home.serialPortTest1.Write("ENTER-TEST" + "\r\n");
                        IsButtonMain = false;
                    }
                    else
                    {
                        home.serialPortTest1.Write("ENTER-SET" + "\r\n");
                        IsButtonMain = false;
                    }

                }
                else if (data.Contains("CanntExecute"))
                {
                    if (IsButtonMain)
                    {
                        if (IsENTERSET)
                        {
                            home.serialPortTest1.Write("ENTER-TEST" + "\r\n");
                            IsButtonMain = false;
                        }
                        else
                        {
                            home.serialPortTest1.Write("ENTER-SET" + "\r\n");
                            IsButtonMain = false;
                        }
                    }
                }
                else if (data.Contains("ENTER-SET"))
                {
                    IsENTERSET = true;
                    home.serialPortTest1.Write("DELI-ALL" + "\r\n");
                    IsButtonMain = false;
                }
                else if (data.Contains("DELI-ALL"))
                {
                    home.serialPortTest1.Write("FN Test1" + "\r\n");
                    IsButtonMain = false;
                }
                else if (data.Contains("FN"))
                {
                    home.serialPortTest1.Write("100.0,1.0,2.0,0.0,0,0," + "\r\n");

                    IsButtonMain = false;
                }
                else if (data.Contains("SET"))
                {
                    LogHelper.Info("设置完成检测=" + data);
                    home.serialPortTest1.Write("FS" + "\r\n");
                    IsButtonMain = false;
                }
                else if (data.Contains("FS"))
                {
                    home.serialPortTest1.Write("RETURN-MAIN" + "\r\n");
                    IsButtonMain = true;
                }
                else if (data.Contains("ENTER-TEST"))
                {
                    IsENTERSET = false;
                    //开始测试
                    home.serialPortTest1.Write("TEST" + "\r\n");
                    IsButtonMain = false;

                }
                else if (data.Contains("TEST"))
                {
                    db_TestingConfig db_TestingTime = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "读取时间").FirstOrDefault();
                    if (db_TestingTime != null)
                    {
                        int numberTime = Convert.ToInt32(Convert.ToDouble(db_TestingTime.Value) * 1000);
                        Thread.Sleep(numberTime);
                    }
                    else
                    {
                        Thread.Sleep(2500);
                    }

                    home.serialPortTest1.Write("TD?" + "\r\n");
                    IsButtonMain = false;
                    LogHelper.Info("发送： TD?");
                }
                else if (data.Contains("TD"))
                {
                    LogHelper.Info("返回检测结果：" + data);
                    string str = string.Empty;
                    //data=

                    string[] strs = data.Split(",");
                    string result = System.Text.RegularExpressions.Regex.Replace(strs[1], @"[^0-9]+", "");
                    Invoke(new EventHandler(delegate
                    {
                        textBox2.Text = result;
                    }));
                    Global.IsSettingComm = false;

                }

            };
        }

        private void button_StationSave_Click(object sender, EventArgs e)
        {
            if (comboBox_CurrentStation.Text!="")
            {
                //textBox_numTime
                
                db_TestingConfig db_Testing = safetyDataRepository.GetData<db_TestingConfig>().Where(x=>x.SettingName== "当前工位").FirstOrDefault();
                if (db_Testing!=null)
                {
                    db_Testing.Value = comboBox_CurrentStation.Text + "," + checkBox_IsIO.Checked;
                    safetyDataRepository.Update(db_Testing);
                }
                else
                {
                    db_TestingConfig db_Testings = new db_TestingConfig()
                    {
                        SettingName = "当前工位",
                        Value = comboBox_CurrentStation.Text + "," + checkBox_IsIO.Checked
                    };
                    safetyDataRepository.Insert(db_Testings);
                }
                //checkBox_IsPrint
                db_TestingConfig db_Testingprint = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "是否测完打印").FirstOrDefault();
                if (db_Testingprint != null)
                {
                    db_Testingprint.Value = checkBox_IsPrint.Checked.ToString().ToLower();
                    safetyDataRepository.Update(db_Testingprint);
                }
                else
                {
                    db_TestingConfig db_Testingprinta = new db_TestingConfig()
                    {
                        SettingName = "是否测完打印",
                        Value = checkBox_IsPrint.Checked.ToString().ToLower()
                    };
                    safetyDataRepository.Insert(db_Testingprinta);
                }


                db_TestingConfig db_Testingbc = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "补偿值").FirstOrDefault();
                if (db_Testingbc != null)
                {
                    db_Testingbc.Value =  textBox2.Text;
                    safetyDataRepository.Update(db_Testingbc);
                }
                else
                {
                    db_TestingConfig db_Testings = new db_TestingConfig()
                    {
                        SettingName = "补偿值",
                        Value =  textBox2.Text
                    };
                    safetyDataRepository.Insert(db_Testings);
                }

               

                MessageBox.Show("重启软件生效");

            }
        }

        private void setting_Load(object sender, EventArgs e)
        {
            if (Global.UserName == "Admin")
            {

                comboBox_userName.Visible = true;
                label9.Visible = true;
                button_userSave.Visible = true;
                PowerManage(Global.Level, "Admin");
            }
            else
            {
                PowerManage(Global.Level, "");
            }



            //BroadCast.AddBroadCast("AnguiCOMM",action);

            if (safetyDataRepository.GetData<User>() != null)
            {
                List<User> users = safetyDataRepository.GetData<User>().Where(x => x.UserName != "Admin").ToList();
                foreach (User item in users)
                {
                    comboBox_userName.Items.Add(item.UserName);
                }
            }
            //if (safetyDataRepository.GetData<db_TestingConfig>()!=null)
            //{
            db_TestingConfig db_Testing = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "当前工位").FirstOrDefault();
            if (db_Testing != null)
            {
                string[] datas = db_Testing.Value.Split(",");
                comboBox_CurrentStation.Text = datas[0];
                CurrentStation= datas[0];
                //if (comboBox_CurrentStation.Text != "充电检测") 
                //{

                //}
                checkBox_IsIO.Checked = bool.Parse(datas[1]);
            }



            db_TestingConfig db_Testingbc = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "补偿值").FirstOrDefault();
            if (db_Testingbc != null)
            {
                textBox2.Text = db_Testingbc.Value;
            }


            db_TestingConfig db_Testingmesadd = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "MES上传地址").FirstOrDefault();
            if (db_Testingmesadd != null)
            {
                textBox_mesAddress.Text = db_Testingmesadd.Value;
                MESAddress=db_Testingmesadd.Value;
            }

            db_TestingConfig db_Testingmestime = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "MES上传间隔时间").FirstOrDefault();
            if (db_Testingmestime != null)
            {
                textBox_mesTime.Text = db_Testingmestime.Value;
                timer1.Interval = Convert.ToInt32(Convert.ToDouble(db_Testingmestime.Value) * 1000);
            }

            db_TestingConfig db_Testingbcprint = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "是否测完打印").FirstOrDefault();
            if (db_Testingbcprint != null)
            {
                checkBox_IsPrint.Checked = db_Testingbcprint.Value == "true" ? true : false;
            }


            //}
            checkBox_IsIO.Visible = true;

            timer1.Start();
          //  websocketServerTest();
        }

        

        private void button_userSave_Click(object sender, EventArgs e)
        {
            if (comboBox_userName.Text!="")
            {
                StringBuilder sb =new StringBuilder();
                sb.Append(checkBox_car.Checked ? "1" : "0");
                sb.Append(checkBox_device.Checked ? "1" : "0");
                sb.Append(checkBox_system.Checked ? "1" : "0");
                sb.Append(checkBox_data.Checked ? "1" : "0");
                string levels = sb.ToString();

                User user = safetyDataRepository.GetData<User>().Where(x => x.UserName == comboBox_userName.Text).FirstOrDefault();
                user.level = Convert.ToInt32(levels, 2);

                safetyDataRepository.Update(user);

                MessageBox.Show("保存成功");
            }
        }

         
        private void button_AddUser_Click(object sender, EventArgs e)
        {
            if (textBox_userName.Text!="")
            {
                if (textBox_userName.Text.ToLower() == "admin")
                {
                    MessageBox.Show("用户名不可为admin");
                    return;
                }
                if (safetyDataRepository.GetData<User>()!=null)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(checkBox_car.Checked ? "1" : "0");
                    sb.Append(checkBox_device.Checked ? "1" : "0");
                    sb.Append(checkBox_system.Checked ? "1" : "0");
                    sb.Append(checkBox_data.Checked ? "1" : "0");
                    string levels = sb.ToString();


                    MessageBox.Show("保存成功");
                    bool isUser = safetyDataRepository.GetData<User>().Where(x => x.UserName == textBox_userName.Text).Any();
                    if (!isUser)
                    {
                        User user = new User()
                        {
                            UserName = textBox_userName.Text,
                            UserPassword = textBox_password.Text,
                            level = Convert.ToInt32(levels, 2)
                    };
                        safetyDataRepository.Insert(user);

                        textBox_userName.Text = "";
                        textBox_password.Text = "";

                        List<User> users = safetyDataRepository.GetData<User>().Where(x => x.UserName != "Admin").ToList();
                        foreach (User item in users)
                        {
                            comboBox_userName.Items.Add(item.UserName);
                        }
                    }
                }
                
            }
        }

        private void comboBox_userName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            User user = safetyDataRepository.GetData<User>().Where(x => x.UserName == comboBox_userName.SelectedItem.ToString()).FirstOrDefault();
            if (user!=null)
            {
                PowerManage(user.level,"Admin");
            }
            
        }
        /// <summary>
        /// 权限管理
        /// </summary>
        public void PowerManage(int levels,string username) 
        {
            string level = Convert.ToString(levels, 2).PadLeft(4, '0');
            checkBox_car.Checked = level.Substring(0, 1) == "0" ? false : true;
            checkBox_device.Checked = level.Substring(1, 1) == "0" ? false : true;
            checkBox_system.Checked = level.Substring(2, 1) == "0" ? false : true;
            checkBox_data.Checked = level.Substring(3, 1) == "0" ? false : true;

            if (username!="Admin")
            {
                checkBox_car.Enabled = level.Substring(0, 1) == "0" ? false : true;
                checkBox_device.Enabled = level.Substring(1, 1) == "0" ? false : true;
                checkBox_system.Enabled = level.Substring(2, 1) == "0" ? false : true;
                checkBox_data.Enabled = level.Substring(3, 1) == "0" ? false : true;
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Global.IsStop)
            {
                return;
            }
            Global.IsSettingComm = true;
            BroadCast.SendBroadCast("监听连接状态false");

            home.serialPortTest1.Write("RESET" + "\r\n");
            Thread.Sleep(500);
            home.serialPortTest1.Write("RETURN-MAIN" + "\r\n");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox_mesAddress.Text!="")
            {
                db_TestingConfig db_Testingprint = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "MES上传地址").FirstOrDefault();
                if (db_Testingprint != null)
                {
                    db_Testingprint.Value = textBox_mesAddress.Text.ToString();
                    safetyDataRepository.Update(db_Testingprint);
                }
                else
                {
                    db_TestingConfig db_Testingprinta = new db_TestingConfig()
                    {
                        SettingName = "MES上传地址",
                        Value = textBox_mesAddress.Text.ToString().ToLower()
                    };
                    safetyDataRepository.Insert(db_Testingprinta);
                }


                 db_Testingprint = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "MES上传间隔时间").FirstOrDefault();
                if (db_Testingprint != null)
                {
                    db_Testingprint.Value = textBox_mesTime.Text.ToString();
                    safetyDataRepository.Update(db_Testingprint);
                }
                else
                {
                    db_TestingConfig db_Testingprinta = new db_TestingConfig()
                    {
                        SettingName = "MES上传间隔时间",
                        Value = textBox_mesTime.Text.ToString().ToLower()
                    };
                    safetyDataRepository.Insert(db_Testingprinta);
                }

                MessageBox.Show("保存成功,重启软件生效");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                label_MES.Text = "执行MES上传";
                label_MES.ForeColor = Color.Lime;

                //查询前20 条未上传数据
                List<db_TestingData> db_TestingDatas = safetyDataRepository.GetData<db_TestingData>().Where(x => x.IsUpload == "否").ToList();
                db_TestingDatas = db_TestingDatas.Where((x, i) => db_TestingDatas.FindIndex(z => z.CreateTime == x.CreateTime) == i).Take(20).ToList();//添加时间去重

                LogHelper.Info("查询数据：" + db_TestingDatas.Count+" 条");
                foreach (db_TestingData item in db_TestingDatas)
                {
                    //HttpClient httpClient = new HttpClient() { };
                    //StringBuilder contentString = new StringBuilder();
                    //String meothName = "saveAG";   //服务的方法名
                    Dictionary<string, string> args = new Dictionary<string, string>(); //方法的参数

                    List<db_TestingData> db_TestingData = safetyDataRepository.GetData<db_TestingData>().Where(x => x.CreateTime == item.CreateTime && x.Vin == item.Vin).ToList();

                    LogHelper.Info("查询数据db_TestingData：" + db_TestingData.Count + " 条");
                    #region 上传数据

                    bool IsOK = true;
                    string DDWVal = "?";
                    string DCBDDWZ = "?";
                    string SHYDDWZ = "?";
                    string DQDDDWZ = "?";
                    string YSJDDWZ = "?";
                    string PTCDDWZ = "?";
                    string JLCDQDDWZ = "?";
                    string ZLCDQDDWZ = "?";
                    string KMCJYBZ = "?";
                    string KCJYZ = "?";
                    string MCJYZ = "?";
                    string Kcjyzz = "?";
                    string ZCJY1BZ = "?";
                    string ZCJY1Z = "?";
                    string BAK2 = "?";
                    string Kcjyzf = "?";
                    foreach (db_TestingData testingData in db_TestingData)
                    {
                        args["VIN"] = testingData.Vin;
                        args["CAR_MODEL"] = testingData.carModuleCode;
                        args["DEVICE_ID"] = CurrentStation;
                        args["create_date"] = testingData.CreateTime;
                        if (testingData.result == "不合格")
                        {
                            IsOK = false;
                        }
                        if (testingData.TestingName.Contains("等电位"))
                        {
                            DDWVal = testingData.Range;//等电位标准
                        }

                        if (testingData.TestingName.Contains("动力电池"))
                        {
                            DCBDDWZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("三合一"))
                        {
                            SHYDDWZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("驱动"))
                        {
                            DQDDDWZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("压缩机"))
                        {
                            YSJDDWZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("PTC"))
                        {
                            PTCDDWZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("PTC"))
                        {
                            PTCDDWZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("交流充电枪等电位"))
                        {
                            JLCDQDDWZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("直流充电枪等电位"))
                        {
                            ZLCDQDDWZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("直流充电口正极绝缘"))
                        {
                            KMCJYBZ = testingData.Range;
                            Kcjyzz = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("快充绝缘"))
                        {
                            KCJYZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("慢充绝缘"))
                        {
                            MCJYZ = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("整车绝缘"))
                        {
                            ZCJY1BZ = testingData.Range;
                            ZCJY1Z = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("HPIU"))
                        {
                            BAK2 = testingData.value;
                        }
                        else if (testingData.TestingName.Contains("直流充电口负绝缘"))
                        {
                            Kcjyzf = testingData.value;
                        }
                    }
                    args["CAR_STATUS"] = IsOK ? "OK" : "NG";//是否合格
                    args["DDWBZ"] = DDWVal;//等电位标准
                    args["DCBDDWZ"] = DCBDDWZ;
                    args["SHYDDWZ"] = SHYDDWZ;
                    args["DQDDDWZ"] = DQDDDWZ;
                    args["YSJDDWZ"] = YSJDDWZ;
                    args["PTCDDWZ"] = PTCDDWZ;
                    args["JLCDQDDWZ"] = JLCDQDDWZ;
                    args["ZLCDQDDWZ"] = ZLCDQDDWZ;
                    args["KMCJYBZ"] = KMCJYBZ;
                    args["KCJYZ"] = KCJYZ;
                    args["MCJYZ"] = MCJYZ;
                    args["ZCJY1BZ"] = ZCJY1BZ;
                    args["ZCJY1Z"] = ZCJY1Z;
                    args["ZCJY2Z"] = "?";
                    args["BAK1"] = "?";
                    args["BAK2"] = BAK2;
                    args["BAK3"] = "?";
                    args["BAK4"] = "?";
                    args["BAK5"] = "?";
                    args["GYX"] = "?";
                    args["DJKZQ1"] = "?";

                    args["DJ"] = "?";
                    args["JSQ"] = "?";
                    args["GYYTJ"] = "?";
                    args["Kcjyzz"] = Kcjyzz;
                    args["Kcjyzf"] = Kcjyzf;
                    args["mcjyzz"] = "?";
                    args["mcjyzf"] = "?";
                    args["Zcjy1zz"] = "?";
                    args["Zcjy1zf"] = "?";
                    args["Zcjy2zz"] = "?";
                    args["Zcjy2zf"] = "?";
                    #endregion


                    StringBuilder sb=  GetXMLStringBuilder(args);

                    //XmlDocument doc = new XmlDocument();
                    //doc.LoadXml();

                   // LogHelper.Info("上传数据：" + sb.ToString());
                    string _returnstr = "";
                    //发起请求
                    WebRequest webRequest = WebRequest.Create(MESAddress);
                    webRequest.ContentType = "text/xml; charset=utf-8";
                    webRequest.Method = "POST";
                    using (Stream requestStream = webRequest.GetRequestStream())
                    {
                        byte[] paramBytes = Encoding.UTF8.GetBytes(sb.ToString());
                        requestStream.Write(paramBytes, 0, paramBytes.Length);
                    }
                    //响应
                    try
                    {
                        WebResponse webResponse = webRequest.GetResponse();
                        using (StreamReader myStreamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.UTF8))
                        {
                            _returnstr = myStreamReader.ReadToEnd();
                        }
                    }
                    catch (WebException ex)
                    {
                        _returnstr = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                    }
                    LogHelper.warning("回调结果：" + _returnstr);


                    if (_returnstr.Contains("<ax211:type>S</ax211:type>"))
                    {
                        foreach (db_TestingData data in db_TestingData)
                        {
                            data.IsUpload = "是";
                            safetyDataRepository.Update<db_TestingData>(data);
                        }
                    }
                    else 
                    {
                        foreach (db_TestingData data in db_TestingData)
                        {
                            data.IsUpload = "否";
                            safetyDataRepository.Update<db_TestingData>(data);
                        }
                    }


                    
                }
                }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

           



        }

        public StringBuilder GetXMLStringBuilder(Dictionary<string, string> args) 
        {
            StringBuilder soap = new StringBuilder();
            // soap.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
            //<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:impl="http://impl.webservice.mes.com" xmlns:xsd="http://client.webservice.mes.com/xsd">

            soap.Append("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:impl=\"http://impl.webservice.mes.com\" xmlns:xsd=\"http://client.webservice.mes.com/xsd \" >");
            soap.Append("<soapenv:Header />");
            soap.Append("<soapenv:Body>");
            soap.Append("<impl:saveAG>");
            soap.Append("<impl:request>");

            foreach (var item in args)
            {
                if (item.Value.Contains(">"))
                {
                    soap.AppendFormat($"<xsd:{item.Key}>{item.Value.Replace(">", "大于")}</xsd:{item.Key}>");
                }
                else if (item.Value.Contains("<"))
                {
                    soap.AppendFormat($"<xsd:{item.Key}>{item.Value.Replace("<", "小于")}</xsd:{item.Key}>");
                }
                else
                {
                    soap.AppendFormat($"<xsd:{item.Key}>{item.Value}</xsd:{item.Key}>");
                }

            }


            soap.Append("</impl:request>");
            soap.Append("</impl:saveAG>");
            soap.Append("</soapenv:Body>");
            soap.Append("</soapenv:Envelope>");





            return soap;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            label_MES.Text = "启动MES上传";
            label_MES.ForeColor = Color.Yellow;
            timer1.Start();



        }
    }
}

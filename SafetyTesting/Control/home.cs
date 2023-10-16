using SafetyTesting.DB.Entity;
using SafetyTesting.DB.Interface;
using SafetyTesting.Tool;
using SpeechLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafetyTesting.Control
{
    public partial class home : UserControl
    {
        public static ISafetyDataRepository safetyDataRepository;
        public static System.IO.Ports.SerialPort serialPortTest1;
        public static System.IO.Ports.SerialPort serialPortTest2;
        public static System.IO.Ports.SerialPort serialPortVIN;
        public  AutoResetEvent autoResetEvent = new AutoResetEvent(false);
        public System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        public static string CurrentStation = string.Empty;
        public static bool IsOpenIO = true;
        public double TestingTime = 0;
        public db_IOModule IOConn;
        public string carModuleName = string.Empty;
        public Action<string> action;
        public string lmlDO = string.Empty;
        public string GreenDo = string.Empty;
        public string yellowDo=string.Empty;
        public string redDo = string.Empty;
        public string redLightDo = string.Empty;
        public string GreenLightDo = string.Empty;
        public bool IsTest = false;
        public bool AnGuiConn = false;
        public bool CONNCOMM = true;
        public double Timeout = 30;//检测超时时间
        bool IsDirect = false;
        bool IsENTERSET = false;//是否安规当前是设置界面
        bool IsButtonMain = true;//点击了安规跳转主界面上
        bool IsENDTest = true;//结束测试了
        bool IsEnd = true;
        bool IsWait = false;//是否需要等待
        int RDindex = 0;//读取序列
        db_TestingConfig db_Testing2;
        bool IsTestEnd = false;

        bool IsStartCAN = true;//是否启动CAN

        FactoryType factoryType = FactoryType.JMC;
        public enum FactoryType
        {
            /// <summary>
            /// 不需要用到
            /// </summary>
            NULL,
            /// <summary>
            /// 长安汽车
            /// </summary>
            CHANAN,
            /// <summary>
            /// 江铃汽车
            /// </summary>
            JMC
            
        }
        Action<string, int> CANInfoAction;
        public int numOK
        {
            get; set;
        }
        public int numNG
        {
            get; set;
        }

        int[] datas = { 0, 0, 0, 0, 0, 0, 0 };//柱状图数据
        public home()
        {
            InitializeComponent();
            action = (sender) =>
            {
                Invoke(new EventHandler( delegate
                {
                    if (sender == "IO_conn")
                    {
                        if (roundButton_io.ButtonCenterColorStart!= Color.Lime)
                        {
                            roundButton_io.ButtonCenterColorStart = Color.Lime;
                            roundButton_io.Refresh();
                        }
                        
                    }
                    else if (sender == "IO_exit")
                    {
                        if(roundButton_io.ButtonCenterColorStart != Color.Red)
                        {
                            roundButton_io.ButtonCenterColorStart = Color.Red;
                            roundButton_io.Refresh();
                        }
                    }
                    else if (sender=="IO触发")
                    {
                        Invoke(new EventHandler(delegate
                        {
                            button1_Click_1(null,null);
                        }));
                    }
                    else if (sender=="stopComm")
                    {
                        LogHelper.Info("1");
                        Device.OutputDO(redDo, true);
                        Thread.Sleep(50);
                        Device.OutputDO(lmlDO, true);
                        Global.IsStop = true;
                        Invoke(new EventHandler(delegate 
                        {
                            label_stop.Visible = true;
                        }));
                    }
                    else if (sender== "stopRecovery")
                    {
                        Device.OutputDO(redDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(lmlDO, false);
                        Global.IsStop = false;
                        Invoke(new EventHandler(delegate
                        {
                            label_stop.Visible = false;
                            textBox_vin.Enabled = true;
                            button1.Enabled = true;
                        }));
                    }
                    else if (sender.Contains("监听连接状态"))
                    {
                        string str = sender.Replace("监听连接状态", "");
                        Invoke(new EventHandler(delegate
                        {
                            if (str=="true")
                            {
                              //  timer_anguiConn.Enabled = true;
                            }
                            else
                            {
                                timer_anguiConn.Enabled = false;
                            }
                            
                        }));
                    }
                }));
                
            };

            BroadCast.AddBroadCast("DeviceReset", action);
            CANInfoAction = new Action<string, int>(LearningResult);
            

            
        }

        public void close() 
        {
            Device.OutputDO(redDo, true);
            Thread.Sleep(50);
            Device.OutputDO(lmlDO, false);
            Thread.Sleep(50);
            Device.OutputDO(GreenDo, false);
            Thread.Sleep(50);
            Device.OutputDO(yellowDo, false);



        }
        /// <summary>
        /// 界面刷新
        /// </summary>
        /// <param name="p"></param>
        protected override void OnPaintBackground(PaintEventArgs p)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            base.OnPaintBackground(p);
        }

        public static string LocadTitle() 
        {
            if (safetyDataRepository!=null)
            {
                db_TestingConfig db_Testing = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "当前工位").FirstOrDefault();
                string[] strTesting = db_Testing.Value.Split(",");
                CurrentStation = strTesting[0];
                IsOpenIO = Convert.ToBoolean(strTesting[1]);
                return strTesting[0];
            }
            return "";
        }

        private void home_Load(object sender, EventArgs e)
        {

            //dataGridView1.DefaultCellStyle = new DataGridViewCellStyle() { ForeColor = Color.Blue, Font = new Font("Arial", 11F, FontStyle.Bold) };
            
            try
            {
                Task.Run(() =>
                {
                    SpVoice voice = new SpVoice();
                    voice.SetRate(2);//语速
                    voice.SetVolume(100);//音量
                    uint lll = 0;
                    voice.Speak("安规软件已启动", 0, out lll);
                });
               


                #region 柱状图数据

                 //柱状图
                 DateTime dateTime = Convert.ToDateTime(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"));
                List<db_TestingData> db_TestingDatas = safetyDataRepository.GetData<db_TestingData>().Where(x => Convert.ToDateTime(x.CreateTime) > dateTime).ToList();
                //int adsf= db_TestingDatas.Where(x => Convert.ToDateTime(x.CreateTime) > Convert.ToDateTime("2023/3/13 00:00:00")).Count();

                int front1Day = db_TestingDatas.Where(x => Convert.ToDateTime(x.CreateTime) > Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))).Count();
                int front2Day = db_TestingDatas.Where(x => Convert.ToDateTime(x.CreateTime) > Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")) &&
                Convert.ToDateTime(x.CreateTime) < Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))).Count();
                int front3Day = db_TestingDatas.Where(x => Convert.ToDateTime(x.CreateTime) > Convert.ToDateTime(DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd")) &&
                Convert.ToDateTime(x.CreateTime) < Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"))).Count();
                int front4Day = db_TestingDatas.Where(x => Convert.ToDateTime(x.CreateTime) > Convert.ToDateTime(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")) &&
                Convert.ToDateTime(x.CreateTime) < Convert.ToDateTime(DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd"))).Count();
                int front5Day = db_TestingDatas.Where(x => Convert.ToDateTime(x.CreateTime) > Convert.ToDateTime(DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd")) &&
                Convert.ToDateTime(x.CreateTime) < Convert.ToDateTime(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"))).Count();
                int front6Day = db_TestingDatas.Where(x => Convert.ToDateTime(x.CreateTime) > Convert.ToDateTime(DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd")) &&
                Convert.ToDateTime(x.CreateTime) < Convert.ToDateTime(DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd"))).Count();
                int front7Day = db_TestingDatas.Where(x => Convert.ToDateTime(x.CreateTime) > Convert.ToDateTime(DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd")) &&
                Convert.ToDateTime(x.CreateTime) < Convert.ToDateTime(DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd"))).Count();
                datas[6] = front1Day;
                datas[5] = front2Day;
                datas[4] = front3Day;
                datas[3] = front4Day;
                datas[2] = front5Day;
                datas[1] = front6Day;
                datas[0] = front7Day;

                if (!safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "合格数").Any())
                {
                    db_TestingConfig db_TestingConfig1 = new db_TestingConfig()
                    {
                        SettingName = "合格数",
                        Value="0"
                    };
                    safetyDataRepository.Insert(db_TestingConfig1);
                }
                if (!safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "失败数").Any())
                {
                    db_TestingConfig db_TestingConfig2 = new db_TestingConfig()
                    {
                        SettingName = "失败数",
                        Value = "0"
                    };
                    safetyDataRepository.Insert(db_TestingConfig2);
                }

                db_TestingConfig db_TestingTime = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "读取时间").FirstOrDefault();
                if (db_TestingTime != null)
                {
                    Timeout =Convert.ToDouble( db_TestingTime.Value);
                }

                db_TestingConfig _TestingConfigOK = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "合格数").FirstOrDefault();
                db_TestingConfig _TestingConfigNG = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "失败数").FirstOrDefault();
                if (front1Day==0)
                {
                    numOK = 0;
                    numNG = 0;
                }
                else
                {
                    numOK = Convert.ToInt32(_TestingConfigOK.Value);
                    numNG = Convert.ToInt32(_TestingConfigNG.Value);
                }


                #endregion




                PassNumber();
                if (CurrentStation=="充电检测")
                {
                   button1.Visible = false;
                    

                    roundButton_anConn.Visible = false;
                    label1.Visible = false;
                    ucobd1.Visible = false;
                    button2.Visible = false;
                }
                else
                {
                    
                    
                    
                    db_TestingConfig db_Testing = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "安规配置").FirstOrDefault();
                    if (db_Testing != null)
                    {
                        string[] data = db_Testing.Value.Split(';');
                        serialPortTest1 = new System.IO.Ports.SerialPort();
                        serialPortTest1.DataReceived += SerialPortTest_DataReceived1;
                        serialPortTest1.BaudRate = Convert.ToInt32(data[1]);
                        serialPortTest1.PortName = data[0];
                        serialPortTest1.Open();


                       // serialPortTest1.Write("RESET" + "\r\n");

                        roundButton_anConn.ButtonCenterColorStart = Color.Lime;
                        CONNCOMM = true;
                        timer_anguiConn.Enabled = true;
                    }
                    db_Testing2 = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "安规配置2").FirstOrDefault();
                    if (db_Testing2 != null)
                    {
                        string[] data = db_Testing2.Value.Split(';');
                        serialPortTest2 = new System.IO.Ports.SerialPort();
                        serialPortTest2.DataReceived += SerialPortTest_DataReceived1;
                        serialPortTest2.BaudRate = Convert.ToInt32(data[1]);
                        serialPortTest2.PortName = data[0];
                        serialPortTest2.Open();

                    }
                }


                //serialPortVIN = new SerialPort();
                //serialPortVIN.DataReceived += SerialPortVIN_DataReceived;
                //serialPortVIN.BaudRate = 9600;
                //serialPortVIN.PortName = "COM1";
                //serialPortVIN.Open();



                label_level.Text = Global.UserName.ToLower() == "admin" ? "管理员" : "操作员";
                label_name.Text = Global.UserName;


                #region  亮灯

                db_IOModule db_IO = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Pass == "fml").FirstOrDefault();
                lmlDO = db_IO.IOModule1;
                db_IOModule db_io1 = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Pass == "green").FirstOrDefault();
                GreenDo = db_io1.IOModule1;
                db_IOModule db_io2 = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Pass == "yellow").FirstOrDefault();
                yellowDo = db_io2.IOModule1;
                db_IOModule db_io3 = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Pass == "red").FirstOrDefault();
                redDo = db_io3.IOModule1;

                db_IOModule db_io4 = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Pass == "RedLight").FirstOrDefault();
                redLightDo = db_io4.IOModule1;
                db_IOModule db_io5 = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Pass == "GreenLight").FirstOrDefault();
                GreenLightDo = db_io5.IOModule1;


                Device.OutputDO(lmlDO, false);
                Thread.Sleep(50);
                Device.OutputDO(yellowDo, false);
                Thread.Sleep(50);
                Device.OutputDO(redDo, false);
                Thread.Sleep(50);
                Device.OutputDO(GreenDo, true);
                Thread.Sleep(50);

                

                db_IOModule IOConn = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Id == 1).FirstOrDefault();
                byte addressID = 0x01;

                if (CurrentStation.Contains("内饰"))
                {
                    addressID = 0x02;
                }

                if (CurrentStation=="充电检测")
                {
                    

                    //Device.OutputDO(IOConn.IOModule1, true, addressID);
                    //Thread.Sleep(50);
                    //Device.OutputDO(IOConn.IOModule2, true, addressID);
                    //Thread.Sleep(50);
                }



                //if (!IsOpenIO)
                //{
                //    db_IOModule IOConn = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Id == 1).FirstOrDefault();
                //    byte addressID = 0x01;

                //    if (CurrentStation.Contains("内饰"))
                //    {
                //        addressID = 0x02;
                //    }

                //    Device.OutputDO(IOConn.IOModule1, true, addressID);
                //    Thread.Sleep(50);
                //    Device.OutputDO(IOConn.IOModule2, true, addressID);
                //    Thread.Sleep(50);
                //}

                #endregion

                //CAN
                if (factoryType == FactoryType.CHANAN || factoryType==FactoryType.JMC)
                {
                  //  ucobd1.Visible = true;
                    label_Message.Visible = true;
                }

            }
            catch (Exception ex)
            {
                roundButton_anConn.ButtonCenterColorStart = Color.Gray;
                CONNCOMM = false;
                LogHelper.Error(ex.ToString());


            }

        }
        
        private void SerialPortVIN_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(100);  //（毫秒）等待一定时间，确保数据的完整性 int len        
            int len = serialPortVIN.BytesToRead;
            if (len != 0)
            {
                byte[] buff = new byte[len];
                serialPortVIN.Read(buff, 0, len);

                string data = Encoding.Default.GetString(buff);

                Invoke(new EventHandler(delegate
                {
                    textBox_vin.Text = data.Trim();
                    ScenVIn();

                }));
            }
        }
        bool IsSerialPort2 = false;
        private void SerialPortTest_DataReceived1(object sender, SerialDataReceivedEventArgs e)
        {

            try
            {
                Thread.Sleep(100);  //（毫秒）等待一定时间，确保数据的完整性 int len        
                int len = serialPortTest1.BytesToRead;
                IsSerialPort2 = false;
                //if (len>1024)
                //{
                //    return;
                //}
                 
                if (db_Testing2!=null)
                {
                    if (len==0)
                    {
                        len= serialPortTest2.BytesToRead;
                        IsSerialPort2 = true;
                    }
                }

                if (len != 0)
                {
                    byte[] buff = new byte[len];
                    if (IsSerialPort2)
                    {
                        serialPortTest2.Read(buff, 0, len);
                    }
                    else
                    {
                        serialPortTest1.Read(buff, 0, len);
                    }

                    string AnkuiData = Encoding.Default.GetString(buff);
                   
                    if (timer_anguiConn.Enabled)
                    {
                        //安规心跳
                       // LogHelper.warning("安规回复通讯数据：" + AnkuiData);
                        if (AnkuiData.Contains("Unkown") ) //长安
                        {
                            CONNCOMM = true;
                           // LogHelper.warning("CONNCOMM：" + CONNCOMM);
                            Invoke(new EventHandler(delegate
                            {
                                roundButton_anConn.ButtonCenterColorStart = Color.Lime;
                                roundButton_anConn.Refresh();
                            }));
                           
                            
                            
                        }
                        else if (AnkuiData.Contains("GWINSTEK")) //长城的安规
                        {
                            CONNCOMM = true;
                            LogHelper.warning("CONNCOMM：" + CONNCOMM);
                            Invoke(new EventHandler(delegate
                            {
                                roundButton_anConn.ButtonCenterColorStart = Color.Lime;
                                roundButton_anConn.Refresh();
                            }));
                        }
                        else if (AnkuiData.Contains("CanntExecute"))
                        {
                            CONNCOMM = true;
                           // LogHelper.warning("CONNCOMM：" + CONNCOMM);
                            Invoke(new EventHandler(delegate
                            {
                                roundButton_anConn.ButtonCenterColorStart = Color.Lime;
                                roundButton_anConn.Refresh();
                            }));
                        }
                        return;
                    }
                    //内饰TL-12
                    //内饰二层
                    LogHelper.Info("安规回复数据：" + AnkuiData);
                    if (Global.IsStop)
                    {
                        return;
                    }

                   // LogHelper.Info("IsSettingComm：" + Global.IsSettingComm);
                    if (!Global.IsSettingComm)
                    {
                        if (CurrentStation== "整车安规检测工位-最终线" || CurrentStation == "整车安规检测工位-淋雨线")
                        {
                            Invoke(new EventHandler(delegate
                            {
                                AN1622H(AnkuiData);
                            }));
                        }
                       
                    }
                    else
                    {
                        LogHelper.Info("安规发送数据：" + AnkuiData+"长度："+AnkuiData.Length);
                        BroadCast.SendBroadCast(AnkuiData);
                    }




                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
               // MessageBox.Show(ex.ToString());
            }
            
        }
        
        bool IsDengdianwei = false;
        

        float Meterdata = 0;
        

        public  void TimeoutConn(bool isConn) 
        {
            
            
            LogHelper.warning("打开安规连接检测"+ timer_anguiConn.Enabled);
        }

       

       
        CarModuleType carModuleType = CarModuleType.D180;
        public void AN1622HQuickMode() 
        {
            Thread.Sleep(1000);
            Device.OutputDO(lmlDO, false);
            Thread.Sleep(50);
            Device.OutputDO(lmlDO, false);
            db_CarModule db_Car = DBCarModules.Where(x => x.TestName == dataGridView1.Rows[RowIndex].Cells[1].Value.ToString()).FirstOrDefault();
            
            if (db_Car == null)
            {
                MessageBox.Show("数据库错误");
                return;
            }
            LogHelper.Info("检测项 ：" + db_Car.TestName);
            IOConn = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Pass == db_Car.Pass).FirstOrDefault();
            // LogHelper.Info("IOConn"+ IOConn.IOModule1);
            //打开继电器
            Thread.Sleep(50);
            IsDengdianwei = false;
            if (IsOpenIO)
            {
                if (!db_Car.TestName.Contains("监测") || !db_Car.TestName.Contains("电容耦合"))
                {
                    Device.OutputDO(IOConn.IOModule1, true);
                    Thread.Sleep(50);
                    Device.OutputDO(IOConn.IOModule2, true);
                    Thread.Sleep(50);
                    Device.OutputDO(IOConn.IOModule1, true);
                    Thread.Sleep(50);
                    Device.OutputDO(IOConn.IOModule2, true);
                    LogHelper.Info("开启继电器 IOModule1" + IOConn.IOModule1 + ",2:" + IOConn.IOModule2);
                    Thread.Sleep(1000);
                }

            }

            if (db_Car.TestName.Contains("绝缘监测"))
            {
                ErrCount = 0;
                Progressdisplay(100, RowIndex);
                //吸合快充继电器,开绝缘
                Thread.Sleep(2000);
                label_Message.Text = "正在进行绝缘监测";
                //ucobd1.InitializeCAN(CANInfoAction);//添加到委托
              //  ucobd1.Sendcomm(EFunctionType.Insulation__OPEN);


                //还需要读取ECU信息
            }
            else if (db_Car.TestName.Contains("整车绝缘"))
            {
                ErrCount = 0;
                Progressdisplay(100, RowIndex);
                //打开快充正继电器
                
                if (carModuleName.Contains("RT6"))
                {
                    carModuleType = CarModuleType.RT6;
                }
                else if(carModuleName.Contains("D180"))
                {
                    carModuleType = CarModuleType.D180;
                }
                else if (carModuleName.Contains("E300N"))
                {
                    carModuleType = CarModuleType.E300N;
                }
                else if (carModuleName.Contains("GSE"))
                {
                    carModuleType = CarModuleType.GSE;
                }

                ucobd1.InitializeCAN(CANInfoAction, 0, carModuleType);//添加到委托
                ucobd1.StartCAN(EFunctionType.Insulation_CLOSE,carModuleType);
            }
            else if (db_Car.TestName.Contains("绝缘"))
            {
                 Progressdisplay(110, RowIndex);

                DBTestingConfig = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "IR配置").FirstOrDefault();
                string[] strs = DBTestingConfig.Value.Split(';');

                IsDengdianwei = false;



                //SET-IR 500,0,1,1.0,0.1,0,0,0,1,1,0,HXXXXXXX,
                //SET-IR 500,0,2,1.0,1,1,0,0,1,1,0,1,
                //最后一位是 通道，字节第1-8位对应第1-8的高压通道
                serialPortTest1.Write("SET-IR " + strs[0] + ",0,2," + strs[1] + ",1,1,0,0,1,1,0,HXXXXXXX," + "\r\n");
                 Progressdisplay(130, RowIndex);
                LogHelper.Info("设置绝缘检测：" + db_Car.TestName + "SET-IR " + strs[0] + ",0,2," + strs[1] + ",1,0,0,0,1,1,0,HXXXXXXX," + "\r\n");
            }
            else if (db_Car.TestName.Contains("电容耦合"))
            {
                
                Progressdisplay(130, RowIndex);
                //∫n 1  C*U^2/2  积分求和
                // C*U^2/2(n-1)
                List<db_TestingConfig> db_Testings = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName.Contains(db_Car.CarModuleName)).ToList();

                double num = 0;
                if (db_Testings.Count > 0)
                {
                    foreach (db_TestingConfig item in db_Testings)
                    {
                        string[] strs = item.Value.Split(';');
                        if (strs[0].Contains("uf"))
                        {
                            num += (double.Parse(strs[0].Replace("uf", "")) / Math.Pow(10, 6)) * Math.Pow(double.Parse(strs[1]), 2);

                        }
                        else if (strs[0].Contains("nf"))
                        {
                            num += (double.Parse(strs[0].Replace("nf", "")) / Math.Pow(10, 9)) * Math.Pow(double.Parse(strs[1]), 2);
                        }
                        else
                        {
                            MessageBox.Show("参数错误");
                            textBox_vin.Enabled = true;
                            button1.Enabled = true;
                            return;
                        }
                    }
                    LogHelper.Info("电容耦合值 ：" + num/2+"J");
                    dataGridView1.Rows[RowIndex].Cells[3].Value = (num / 2).ToString("0.000")+"J";
                    if (Convert.ToDouble(dataGridView1.Rows[RowIndex].Cells[2].Value.ToString().Replace("<", "").Replace("J", "")) > (num / 2))
                    {
                        dataGridView1.Rows[RowIndex].Cells[5].Value = "合格";
                        dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Lime;
                    }
                    else
                    {
                        dataGridView1.Rows[RowIndex].Cells[5].Value = "不合格";
                        dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Red;
                    }
                    Progressdisplay(250, RowIndex);
                    TestEnd();
                }
               
            }
            else
            {
                //等电位
                IsDengdianwei = true;
                  Progressdisplay(110, RowIndex);

                DBTestingConfig = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "GB配置").FirstOrDefault();
                string[] strs = DBTestingConfig.Value.Split(';');
                int pass = ToDigit(db_Car.Pass.Substring(db_Car.Pass.Length - 1));
                serialPortTest1.Write("SET-DCR " + strs[0] + "," + strs[1] + "," + strs[2] + $",0,0,{pass}," + "\r\n");
                  Progressdisplay(130, RowIndex);
                LogHelper.Info("设置等电位检测：" + db_Car.TestName + "SET-DCR " + strs[0] + "," + strs[1] + "," + strs[2] + $",0,0,{pass}," + "\r\n");
            }
        }

        int TestIndex = 0;//配置测试项
        bool IsDELI = false;//是否删除了
        public void AN1622H(string data) 
        {
            try
            {
                if (IsInit)
                {
                    return;
                }
                if (data==null)
                {
                    return;
                }
                LogHelper.Info("安规回复数据：" + data);
                //  LogHelper.Info("当前RowIndex" + RowIndex);


                Task.Run(() =>
                {
                    Device.OutputDO(GreenDo, true);
                    Thread.Sleep(80);
                    Device.OutputDO(GreenDo, true);
                    Thread.Sleep(80);
                    Device.OutputDO(redDo, false);
                    Thread.Sleep(80);
                    Device.OutputDO(redDo, false);
                    Thread.Sleep(80);
                    Device.OutputDO(yellowDo, false);
                    Thread.Sleep(80);
                    Device.OutputDO(yellowDo, false);
                });
                string[] strs = data.Split(",");


                if (data.Contains("SET-DCR"))
                {
                    return;
                }
                else if (strs[0].Contains("16"))
                {
                    //这个是绝缘监测
                    return;
                }
                else if (data.Contains("SET-IRM"))
                {

                    //db_TestingConfig db_TestingTime = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "读取时间").FirstOrDefault();

                    //if (db_TestingTime != null)
                    //{
                    //    int numberTime = Convert.ToInt32(Convert.ToDouble(db_TestingTime.Value) * 1000);
                    //    Console.WriteLine("等待时间：" + numberTime + "ms");
                    //    Thread.Sleep(numberTime);

                    //}
                    //else
                    //{
                    //    Thread.Sleep(2500);
                    //}
                    label_Message.Text = "读取故障码....";
                    label_Message.BackColor = Color.Navy;
                    label_Message.Refresh();
                  // Thread.Sleep(30000);
                    Delay(30000);

                    //读取故障代码
                    //请求CAN
                  // ucobd1.Sendcomm(EFunctionType.Insulation__OPEN);


                    //button_IRMNG.Visible = true;
                    //button_IRMOK.Visible = true;
                    Progressdisplay(180, RowIndex);


                    return;
                }
                else if (data.Contains("SET-IR"))
                {
                    return;
                }
                else if (data.Contains("SET-BAT"))
                {
                    return;
                }
                else if (data.Contains("IRM-RESU"))
                {
                    return;
                }
                else if (data.Length>9)
                {

                }
                else { return; }

                RDindex += 2;
                LogHelper.Info("返回检测结果：" + data);
                string str = string.Empty;
                db_CarModule db_Car = DBCarModules.Where(x => x.TestName == dataGridView1.Rows[RowIndex].Cells[1].Value.ToString()).FirstOrDefault();
                
                 if (db_Car.TestName.Contains("整车绝缘"))
                {
                    ucobd1.Sendcomm(EFunctionType.VehicleRelay_CLOSE, carModuleType);
                }


                if (true)//!IsDengdianwei
                {

                    IOConn = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Pass == db_Car.Pass).FirstOrDefault();


                    Thread.Sleep(50);
                    if (IsOpenIO)
                    {
                        if (!db_Car.TestName.Contains("监测") || !db_Car.TestName.Contains("电容耦合"))
                        {
                            Device.OutputDO(IOConn.IOModule1, false);
                            Thread.Sleep(50);
                            Device.OutputDO(IOConn.IOModule2, false);
                            Thread.Sleep(50);
                            Device.OutputDO(IOConn.IOModule1, false);
                            Thread.Sleep(50);
                            Device.OutputDO(IOConn.IOModule2, false);
                            Thread.Sleep(50);
                            LogHelper.Info("关闭继电器 IOModule1" + IOConn.IOModule1 + ",2:" + IOConn.IOModule2);
                        }

                    }
                }
                string result = string.Empty;
                //RD 0,15,1,0.0s,,0.0mOhm
                result = Regex.Replace(strs[1], @"[^\d.\d]", "");
                if (data.Contains("G"))
                {
                    str = result + "GΩ";
                }
                else if (data.Contains("M"))
                {
                    str = result + "MΩ";
                    //str = data.Substring(data.IndexOf('V') + 1, data.Length - (data.IndexOf("M")) - 1).Replace(",", "")+"MΩ";
                }
                else if (data.Contains("m"))
                {
                    str = result + "mΩ";
                }

                LogHelper.Info("检测结果为：" + str);
                Progressdisplay(250, RowIndex);
                
                //Device.OutputDO(lmlDO, true);
                //Thread.Sleep(50);
                //Device.OutputDO(lmlDO, true);
                //Thread.Sleep(80);
                //Device.OutputDO(lmlDO, false);
                //Thread.Sleep(50);
                //Device.OutputDO(lmlDO, false);


                //检测完成
                dataGridView1.Rows[RowIndex].Cells[3].Value = str;
                if (str.Contains("G"))
                {
                    dataGridView1.Rows[RowIndex].Cells[5].Value = "合格";
                    dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Lime;

                }
                else
                {

                    //RDD 0,2,0,0.3s,500V,3.228G??
                    str = str.Replace("MΩ", "").Replace("GΩ", "").Replace("mΩ", "");

                    if (IsDengdianwei)
                    {
                        db_TestingConfig DBTestingConfig = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "补偿值").FirstOrDefault();


                        double cont = (Convert.ToDouble(str) - Convert.ToDouble(DBTestingConfig.Value)) < 0 ? 0 : (Convert.ToDouble(str) - Convert.ToDouble(DBTestingConfig.Value));
                        if (db_Car.TestName.Contains("流口"))
                        {
                            cont = (Convert.ToDouble(str) - Convert.ToDouble(0)) < 0 ? 0 : (Convert.ToDouble(str) - Convert.ToDouble(0));
                        }
                        if (cont>900)
                        {
                            dataGridView1.Rows[RowIndex].Cells[3].Value = ">1000mΩ";
                            dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            string valu = cont.ToString("0.0");
                            dataGridView1.Rows[RowIndex].Cells[3].Value = valu + "mΩ";
                        }
                        string fanweiValue = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString().Replace(">", "").Replace("<", "").Replace("MΩ", "").Replace("mΩ", "");
                        if (Convert.ToDouble(fanweiValue) >= cont)
                        {
                            dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Lime;
                            dataGridView1.Rows[RowIndex].Cells[5].Value = "合格";
                        }
                        else
                        {
                            dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Red;
                            dataGridView1.Rows[RowIndex].Cells[5].Value = "不合格";
                        }
                    }
                    else
                    {
                        string fanweiValue = dataGridView1.Rows[RowIndex].Cells[2].Value.ToString().Replace(">", "").Replace("<", "").Replace("MΩ", "");
                        if (Convert.ToDouble(fanweiValue) <= Convert.ToDouble(str))
                        {
                            dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Lime;
                            dataGridView1.Rows[RowIndex].Cells[5].Value = "合格";
                        }
                        else
                        {
                            dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Red;
                            dataGridView1.Rows[RowIndex].Cells[5].Value = "不合格";
                        }

                    }


                }
                if (db_Car.TestName.Contains("整车绝缘"))
                {
                    IsZCJY = true;
                }

                if (dataGridView1.Rows[RowIndex].Cells[5].Value == "不合格")
                {
                   // Thread.Sleep(50);
                   // Device.OutputDO(lmlDO, true);

                   

                    //重测
                    if (TestingNG<2)
                    {
                        if (db_Car.TestName.Contains("直流口"))
                        {
                            LogHelper.Info(db_Car.TestName);
                        }
                        else if (db_Car.TestName!="整车绝缘" )
                        {
                            //AN1622HQuickMode();

                            Task.Run(() =>
                            {
                                Thread.Sleep(50);
                                Device.OutputDO(redLightDo, true);
                                Thread.Sleep(50);
                                Device.OutputDO(redLightDo, true);

                                LogHelper.Info("触发探笔红灯亮");
                            });

                            Task.Run(() =>
                            {
                                SpVoice voice = new SpVoice();
                                voice.SetRate(1);//语速
                                voice.SetVolume(100);//音量
                                uint lll = 0;
                                voice.Speak($"请重新测试", 0, out lll);
                            });
                            button1.Enabled = true;
                            TestingNG = 2;
                            return;
                        }
                       
                    }
                    else
                    {
                        TestingNG = 1;
                    }
                    IsOk = false;
                }
                else
                {
                    IsOk = true;
                    TestingNG = 1;
                }

                TestEnd();


            }
            catch (Exception ex)
            {
                LogHelper.Error("AN1662H  错误信息："+ex.ToString());
            }
        }
        bool IsZCJY = false;
        int TestingNG=1;
        bool IsOk=false;
        public static void Delay(int mm)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }
        public void TestEnd() 
        {
            try
            {


                RowIndex++;
                LogHelper.Info("检测完成" + dataGridView1.Rows.Count + "," + RowIndex);
                if (dataGridView1.Rows.Count == RowIndex)
                {

                    TestEndSave();
                    return;
                }
                bool isChoice = false;

                
                for (int i = RowIndex; i < dataGridView1.Rows.Count; i++)
                {
                    if (bool.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()))
                    {
                        isChoice = true;
                        break;
                    }
                    RowIndex++;
                }
                this.dataGridView1.CurrentCell = this.dataGridView1.Rows[RowIndex].Cells[0]; //滚动

                if (!isChoice)
                {
                    TestEndSave();
                    return;
                }

                db_CarModule db_Car = DBCarModules.Where(x => x.TestName == dataGridView1.Rows[RowIndex].Cells[1].Value.ToString()).FirstOrDefault();

                string mesageeData = string.Empty;
                

                IsENDTest = false;
                if (db_Car.TestName.Contains("绝缘") || db_Car.TestName.Contains("直流口") || db_Car.TestName.Contains("交流口") || db_Car.TestName.Contains("直流充电口") || db_Car.TestName.Contains("交流充电口"))//
                {
                    mesageeData = $"正在进行{db_Car.TestName}检测";

                    Progressdisplay(100, RowIndex);
                    Thread.Sleep(3000);

                    IsDengdianwei = false;
                   // serialPortTest1.Write("TEST" + "\r\n");
                    IsButtonMain = true;

                    if (db_Car.TestName.Contains("电容耦合"))
                    {
                        Progressdisplay(130, RowIndex);
                        //∫n 1  C*U^2/2  积分求和
                        // C*U^2/2(n-1)
                        List<db_TestingConfig> db_Testings = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName.Contains(db_Car.CarModuleName)).ToList();
                        
                        double num = 0;
                        if (db_Testings.Count > 0)
                        {
                            foreach (db_TestingConfig item in db_Testings)
                            {
                                LogHelper.Info("db_Testings" + item.Value);
                                string[] strs = item.Value.Split(';');
                                if (strs[0].Contains("uf"))
                                {
                                    num += (double.Parse(strs[0].Replace("uf", "")) / Math.Pow(10, 6)) * Math.Pow(double.Parse(strs[1]), 2);

                                }
                                else if (strs[0].Contains("nf"))
                                {
                                    num += (double.Parse(strs[0].Replace("nf", "")) / Math.Pow(10, 9)) * Math.Pow(double.Parse(strs[1]), 2);
                                }
                                else
                                {
                                    MessageBox.Show("参数错误");
                                    textBox_vin.Enabled = true;
                                    button1.Enabled = true;
                                    return;
                                }
                            }
                            LogHelper.Info("电容耦合值 ：" + num / 2 + "J");
                            dataGridView1.Rows[RowIndex].Cells[3].Value = (num / 2).ToString("0.00000") + "J";
                            if (Convert.ToDouble(dataGridView1.Rows[RowIndex].Cells[2].Value.ToString().Replace("<", "").Replace("J", "")) > (num / 2))
                            {
                                dataGridView1.Rows[RowIndex].Cells[5].Value = "合格";
                                dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Lime;
                            }
                            else
                            {
                                dataGridView1.Rows[RowIndex].Cells[5].Value = "不合格";
                                dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Red;
                            }
                            Progressdisplay(250, RowIndex);
                            TestEnd();
                        }
                    }
                    //LogHelper.Info("发送安规数据：" + "TEST");
                    else if (CurrentStation=="返修工位")
                    {
                        serialPortTest1.Write("ENTER-SET" + "\r\n");
                    }
                    else
                    {
                        AN1622HQuickMode();
                    }
                   
                }
                else
                {
                    button1.Enabled = true;
                    IsDengdianwei = true;

                    mesageeData = $"请进行{db_Car.TestName}检测";
                }
                LogHelper.Info(mesageeData);

                if (IsOk)
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(30);
                        Device.OutputDO(GreenLightDo, true);
                        Thread.Sleep(50);

                        Device.OutputDO(GreenLightDo, true);

                        LogHelper.Info("触发探笔绿灯亮");
                    });

                    Task.Run(() =>
                    {
                        SpVoice voice = new SpVoice();
                        voice.SetRate(1);//语速
                        voice.SetVolume(100);//音量
                        uint lll = 0;
                        voice.Speak($"合格", 0, out lll);


                        Thread.Sleep(300);
                        voice.SetRate(1);//语速
                        voice.SetVolume(100);//音量
                        voice.Speak(mesageeData, 0, out lll);

                        

                    });
                }
                else
                {
                    Task.Run(() =>
                    {
                        Thread.Sleep(30);
                        Device.OutputDO(redLightDo, true);
                        Thread.Sleep(50);
                        Device.OutputDO(redLightDo, true);

                        LogHelper.Info("触发探笔红灯亮");
                    });

                    Task.Run(() =>
                    {
                        SpVoice voice = new SpVoice();
                        voice.SetRate(1);//语速
                        voice.SetVolume(100);//音量
                        uint lll = 0;
                        voice.Speak($"不合格", 0, out lll);


                        Thread.Sleep(300);
                        voice.SetRate(1);//语速
                        voice.SetVolume(100);//音量
                        voice.Speak(mesageeData, 0, out lll);
                       

                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error("TestEnd" + ex.ToString());
            }
           
        }

        public void TestEndSave() 
        {
            try
            {
                
                LogHelper.Info("---------------检测结束-----------------------");
                byte addressID = 0x01;
                timer1.Enabled = false;
                
                if (CurrentStation.Contains("内饰"))
                {
                    addressID = 0x02;
                }
                if (IsOpenIO)
                {
                    Thread.Sleep(50);
                    Device.OutputDO(IOConn.IOModule1, false, addressID);
                    Thread.Sleep(100);
                    Device.OutputDO(IOConn.IOModule2, false, addressID);
                }
                IsENDTest = true;
                //检测完成

                textBox_vin.Enabled = true;
                button1.Enabled = true;

                Device.OutputDO(yellowDo, false);
                Thread.Sleep(50);
                Device.OutputDO(yellowDo, false);
                IsTest = true;
                RowIndex = 0;
                if (CurrentStation.Contains("充电检测"))
                {
                    timer1.Enabled = false;
                    label_Message.Text = "检测结束,驶离工位";
                    label_Message.ForeColor = Color.Lime;
                    //Thread.Sleep(80);
                    //Device.HVDCClose(false);

                }
                else
                {
                    timer_anguiConn.Enabled = true;
                }
                
                List<listsen> listsens = new List<listsen>();
                bool isPass = true;
                List<db_TestingData> db_Testings = new List<db_TestingData>();
                
                foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                {
                    if (bool.Parse(viewRow.Cells[6].Value.ToString()))
                    {
                        // float 
                        bool isDouble = true;
                        string val = viewRow.Cells[3].Value.ToString();
                        double strdou = 0;
                        if (!val.Contains("正常"))
                        {
                            val = val.Replace("MΩ", "").Replace("GΩ", "").Replace("mΩ", "").Replace(">", "").Replace("W", "").Replace("J","");
                            if (val== "0.0W")
                            {
                                strdou = 0;
                            }
                            else
                            {
                                strdou = Convert.ToDouble(val);
                                
                            }
                            if (viewRow.Cells[3].Value.ToString().Contains(">"))
                            {
                                isDouble = false;
                            }
                        }



                        //保存至数据库
                        db_TestingData TestingData = new db_TestingData();
                        TestingData.carModuleCode = carModuleName;
                        TestingData.Vin = textBox_vin.Text;
                        TestingData.TestingName = viewRow.Cells[1].Value.ToString();
                        TestingData.Range = viewRow.Cells[2].Value.ToString();
                        if (viewRow.Cells[3].Value.ToString()=="正常")
                        {
                            TestingData.value = viewRow.Cells[3].Value.ToString();
                        }
                        else if (viewRow.Cells[3].Value.ToString() == "0.0W")
                        {
                            TestingData.value = "0W";
                        }
                        else
                        {
                            TestingData.value = isDouble ? strdou.ToString("0.0") + viewRow.Cells[3].Value.ToString().Substring(viewRow.Cells[3].Value.ToString().Length - 2) : viewRow.Cells[3].Value.ToString();
                        }

                        TestingData.result = viewRow.Cells[5].Value.ToString();
                        TestingData.StationName = CurrentStation;
                        TestingData.IsUpload = "否";
                        safetyDataRepository.Insert(TestingData);

                        db_Testings.Add(TestingData);
                        if (viewRow.Cells[5].Value.ToString().Contains("不合格"))
                        {
                            isPass = false;


                           
                        }

                        Data.VIN = textBox_vin.Text;
                        Data.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        Data.Names = home.CurrentStation;
                        listsen listsen = new listsen
                        {
                            descName = viewRow.Cells[1].Value.ToString(),
                            range_value = viewRow.Cells[2].Value.ToString(),
                            parameter_value = viewRow.Cells[3].Value.ToString()== "0.0W" ? "0W" : viewRow.Cells[3].Value.ToString(),
                            state = viewRow.Cells[5].Value.ToString()
                        };
                        listsens.Add(listsen);
                    }

                }
                if (isPass)
                {
                    db_TestingConfig db_Testingbcprint = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "是否测完打印").FirstOrDefault();
                    if (db_Testingbcprint != null)
                    {
                        if (db_Testingbcprint.Value == "true")
                        {
                            Data.PrintData(listsens);
                            LogHelper.Info("开始打印");
                        }
                    }
                }

                string datal = isPass ? "合格" : "不合格";
                Task.Run(() =>
                {
                    SpVoice voice = new SpVoice();
                    voice.SetRate(1);//语速
                    voice.SetVolume(100);//音量
                    uint lll = 0;
                    voice.Speak($"检测结束  " + datal, 0, out lll);
                    LogHelper.Info("检测结束");
                });
                //计数
                if (isPass) 
                {
                    numOK += 1;

                    Task.Run(() =>
                    {
                        Device.OutputDO(GreenDo, true);
                        Thread.Sleep(50);
                        Device.OutputDO(GreenDo, true);
                        Thread.Sleep(80);

                        Device.OutputDO(yellowDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(yellowDo, false);
                        Thread.Sleep(50);

                        Device.OutputDO(redDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(redDo, false);
                    });
                    
                    
                }
                else
                {

                    numNG += 1;

                    Task.Run(() =>
                    {

                        Device.OutputDO(GreenDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(GreenDo, false);
                        Thread.Sleep(50);

                        Device.OutputDO(yellowDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(yellowDo, false);
                        Thread.Sleep(50);

                        Device.OutputDO(redDo, true);
                        Thread.Sleep(50);
                        Device.OutputDO(redDo, true);
                        Thread.Sleep(80);

                        Device.OutputDO(lmlDO, true);
                        Thread.Sleep(2000);
                        Device.OutputDO(lmlDO, false);
                    });
                }
                PassNumber();


                label_Message.Text = "检测结束,请驶离工位";
                label_Message.ForeColor = Color.Lime;

                Thread.Sleep(1000);
                //上传 淋雨后
                
                Task.Run(() =>
                {

                    
                    MesUpload(db_Testings);


                });
               

            }
            catch (Exception ex)
            {
                LogHelper.Error("TestEndSave:"+ex.ToString());
            }
            

        }
        public void MesUpload(List<db_TestingData> db_TestingData) 
        {
            #region 上传数据
            Dictionary<string, string> args = new Dictionary<string, string>(); //方法的参数
            bool IsOK = true;
            string DDWVal = "";
            string DCBDDWZ = "";
            string SHYDDWZ = "";
            string DQDDDWZ = "";
            string YSJDDWZ = "";
            string PTCDDWZ = "";
            string JLCDQDDWZ = "";
            string ZLCDQDDWZ = "";
            string KMCJYBZ = "";
            string KCJYZ = "";
            string MCJYZ = "";
            string Kcjyzz = "";
            string ZCJY1BZ = "";
            string ZCJY1Z = "";
            string BAK2 = "";
            string Kcjyzf = "";
            foreach (db_TestingData testingData in db_TestingData)
            {
                args["VIN"] = testingData.Vin;
                args["CAR_MODEL"] = testingData.carModuleCode;
                if (CurrentStation.Contains("淋雨"))
                {
                    args["DEVICE_ID"] = "3";
                }
                else
                {
                    args["DEVICE_ID"] = "2";
                }
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
            args["ZCJY2Z"] = "";
            args["BAK1"] = "";
            args["BAK2"] = BAK2;
            args["BAK3"] = "";
            args["BAK4"] = "";
            args["BAK5"] = "";
            args["GYX"] = "";
            args["DJKZQ1"] = "";

            args["DJ"] = "";
            args["JSQ"] = "";
            args["GYYTJ"] = "";
            args["Kcjyzz"] = Kcjyzz;
            args["Kcjyzf"] = Kcjyzf;
            args["mcjyzz"] = "";
            args["mcjyzf"] = "";
            args["Zcjy1zz"] = "";
            args["Zcjy1zf"] = "";
            args["Zcjy2zz"] = "";
            args["Zcjy2zf"] = "";
            #endregion


            StringBuilder sb = setting.GetXMLStringBuilder(args);

            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml();

            // LogHelper.Info("上传数据：" + sb.ToString());
            string _returnstr = "";
            Ping pingSender = new Ping();
            PingReply reply = pingSender.Send("10.209.0.110");
            if (reply.Status == IPStatus.Success)
            {

                //发起请求
                WebRequest webRequest = WebRequest.Create(setting.MESAddress);
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

                if (_returnstr.Contains("<ax211:type>S</ax211:type>"))
                {
                    foreach (db_TestingData data in db_TestingData)
                    {
                        data.IsUpload = "是";
                        safetyDataRepository.Update<db_TestingData>(data);
                    }

                    label_Message.Text = "数据上传MES成功";
                    label_Message.ForeColor = Color.Lime;
                }
                else
                {
                    foreach (db_TestingData data in db_TestingData)
                    {
                        data.IsUpload = "否";
                        safetyDataRepository.Update<db_TestingData>(data);
                    }

                    label_Message.Text = "数据上传MES失败";
                    label_Message.ForeColor = Color.Lime;
                }
            }


            //Thread.Sleep(3000);
            textBox_vin.Text = "";
            textBox_carmodle.Text = "";
            //DataTable dt = new DataTable();
            //dt.Columns.Add("id", typeof(string));
            //dt.Columns.Add("name", typeof(string));
            //dt.Columns.Add("fanwei", typeof(string));
            //dt.Columns.Add("value", typeof(string));
            //dt.Columns.Add("PressImg", typeof(Image));
            //dt.Columns.Add("result", typeof(string));
            //dt.Columns.Add("Choice", typeof(bool));
            //dataGridView1.DataSource = dt;

        }

        int ErrCount = 0;//错误次数
        public void LearningResult(string data, int num)
        {
            if (IsInit)
            {
                return;
            }
            
            LogHelper.Info("CAN:" + data);
            Invoke(new EventHandler(delegate
            {

                label_Message.Text = data;
                label_Message.BackColor = Color.Navy;
                if (data == "读取故障码")
                {
                   
                }
                else if (data.Contains("错误响应"))
                {
                    ucobd1.IsEndss = true;
                    ucobd1.CloseCAN();//关闭CAN
                    ErrCount = 0;
                    textBox_vin.Enabled = true;
                    button1.Enabled = true;
                    label_Message.Text = "错误响应,请重新扫码检测";
                    label_Message.BackColor = Color.Red;
                    label_Message.Refresh();

                    //ErrCount++;
                    //if (ErrCount > 2)
                    //{
                    //    ucobd1.CloseCAN();//关闭CAN
                    //    ErrCount = 0;
                    //    textBox_vin.Enabled = true;
                    //    button1.Enabled = true;
                    //    label_Message.Text = "错误响应,请重新扫码检测";
                    //    label_Message.BackColor = Color.Red;
                    //    label_Message.Refresh();
                    //}
                    //else
                    //{

                    //    string TestingName = dataGridView1.Rows[RowIndex].Cells[1].Value.ToString();
                    //    //重试
                    //    if (TestingName.Contains("整车绝缘"))
                    //    {
                    //        Thread.Sleep(200);
                    //        Progressdisplay(50, RowIndex);
                    //        label_Message.Text = "正在进行整车绝缘检测";
                    //        label_Message.BackColor = Color.Lime;
                    //        label_Message.Refresh();
                    //        Progressdisplay(100, RowIndex);
                    //        //打开快充正继电器
                    //        ucobd1.StartCAN(EFunctionType.BAT_OPEN);
                    //    }
                    //    else if (TestingName.Contains("绝缘监测"))
                    //    {
                    //        Thread.Sleep(200);
                    //        serialPortTest1.Write("IRM-RESULT 1" + "\r\n");

                    //        Progressdisplay(100, RowIndex);
                    //        //吸合快充继电器,开绝缘
                    //        Thread.Sleep(2000);
                    //        label_Message.Text = "正在进行绝缘监测";
                    //        label_Message.BackColor = Color.Lime;
                    //        label_Message.Refresh();
                    //        //ucobd1.InitializeCAN(CANInfoAction);//添加到委托
                    //     //   ucobd1.Sendcomm(EFunctionType.IRM_OPEN);
                    //    }



                    //}



                }
                else if (data.Contains("返回默认模式成功"))
                {
                    IsZCJY = true;
                }
                else if (data.Contains("ECU通讯超时"))
                {
                    if (!IsZCJY)
                    {
                        label_Message.Text = "通讯超时,请重新扫码检测";
                        label_Message.BackColor = Color.Red;
                        dataGridView1.Rows[RowIndex].Cells[5].Value = "不合格";
                        dataGridView1.Rows[RowIndex].Cells[3].Value = "0MΩ";
                        dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Red;

                        Progressdisplay(250, RowIndex);
                        IsOk = false;

                        TestEnd();

                        ucobd1.IsEndss = true;
                        ucobd1.CloseCAN();
                    }
                    
                    //下一项检测
                }
                else if (data.Contains("完成闭合快充继电器"))
                {
                    //开始测试

                    //发送检测
                    Progressdisplay(170, RowIndex);

                    IsDengdianwei = false;
                    DBTestingConfig = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "BAT配置").FirstOrDefault();
                    string[] strs = DBTestingConfig.Value.Split(';');

                    // Progressdisplay(110, RowIndex);
                    home.serialPortTest1.Write("SET-BAT 0.00,1.0," + strs[0] + ".0,500,200," + "\r\n");
                    // Progressdisplay(130, RowIndex);
                    LogHelper.Info("设置整车绝缘检测：SET-BAT 0.00,1.00," + strs[0] + ",500,200," + "\r\n");

                }
                else if (data.Contains("闭合快充继电器失败"))
                {
                    label_Message.BackColor = Color.Red;
                    dataGridView1.Rows[RowIndex].Cells[5].Value = "不合格";
                    dataGridView1.Rows[RowIndex].Cells[3].Value = "0MΩ";
                    dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = Color.Red;

                    Progressdisplay(250, RowIndex);
                    IsOk = false;

                    TestEnd();
                }
                else if (data == "完成开启绝缘继电器")
                {

                    IsDengdianwei = false;
                    Progressdisplay(110, RowIndex);
                    home.serialPortTest1.Write("SET-IRM 3" + "\r\n");
                    Progressdisplay(130, RowIndex);
                    LogHelper.Info("设置监测：SET-IRM 3" + "\r\n");

                }
                else if (data == "有故障码")
                {
                    serialPortTest1.Write("IRM-RESULT 1" + "\r\n");
                    IRMTestEnd(true);

                }
                else if (data == "没有故障码")
                {

                    serialPortTest1.Write("IRM-RESULT 0" + "\r\n");

                    IRMTestEnd(false);
                }

            }));



        }

        public static double NextDouble(Random ran, double minValue, double maxValue, int decimalPlace)
        {
            double randNum = ran.NextDouble() * (maxValue - minValue) + minValue;
            return Convert.ToDouble(randNum.ToString("f" + decimalPlace));
        }
        /// <summary>
        /// 绝缘监测
        /// </summary>
        /// <param name="isOK"></param>
        public void IRMTestEnd(bool isOK) 
        {
            Progressdisplay(250, RowIndex);
            LogHelper.Info("19sdsd");
            Device.OutputDO(lmlDO, true);
            Thread.Sleep(50);
            Device.OutputDO(lmlDO, true);
            Thread.Sleep(80);
            Device.OutputDO(lmlDO, false);
            Thread.Sleep(50);
            Device.OutputDO(lmlDO, false);

            dataGridView1.Rows[RowIndex].Cells[3].Value = isOK? "正常" : "不正常";
            dataGridView1.Rows[RowIndex].Cells[5].Value = isOK ? "合格" : "不合格";
            dataGridView1.Rows[RowIndex].Cells[3].Style.BackColor = isOK ? Color.Lime:Color.Red;

            TestEnd();

        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.Font = new Font("Verdana", 11, FontStyle.Bold);
            }

        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
           dataGridView1.ClearSelection();
        }

        public void PassNumber() 
        {
            label_pass.Text = numOK.ToString().PadLeft(2,'0');
            label_fail.Text = numNG.ToString().PadLeft(2, '0');
            db_TestingConfig db_Testingconfigpass= safetyDataRepository.GetData<db_TestingConfig>().Where(x=>x.SettingName=="合格数").FirstOrDefault();
            db_Testingconfigpass.Value = numOK.ToString();
            safetyDataRepository.Update<db_TestingConfig>(db_Testingconfigpass);
            db_TestingConfig db_Testingconfigfail = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "失败数").FirstOrDefault();
            db_Testingconfigfail.Value = numNG.ToString();
            safetyDataRepository.Update<db_TestingConfig>(db_Testingconfigfail);

            datas[0] += 1;

           // HistogramImage(panel_Histogram, datas); //柱状图

        }

        int RowIndex = 0;
        List<db_CarModule> DBCarModules;
        db_TestingConfig DBTestingConfig;


        /// <summary>
        /// 将中文数字转换成阿拉伯数字 
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        static int ToDigit(string cn) 
        {
            switch (cn)
            {
                case "一":
                    return 0;
                case "二":
                    return 1;
                case "三":
                    return 2;
                case "四":
                    return 3;
                case "五":
                    return 4;
                case "六":
                    return 5;
                case "七":
                    return 6;
                case "八":
                    return 7;
                case "九":
                    return 8;
                case "十":
                    return 9;
            }
            return 1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                
                ErrCount = 0;
                IsInit = false;
                IsZCJY = false;
                if (Global.IsStop)
                {
                    return;
                }
                if (IsTest)
                {
                    return;
                }
                bool Ischoice = false;

                if (dataGridView1.Rows.Count > RowIndex)
                {
                    for (int i = RowIndex; i < dataGridView1.Rows.Count; i++)
                    {
                        if (bool.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()))
                        {
                            Ischoice = true;
                            break;
                        }
                        RowIndex++;
                    }
                    if (!Ischoice)
                    {
                        return;
                    }


                    Task.Run(() => {
                        Device.OutputDO(GreenDo, true);
                        Thread.Sleep(50);
                        Device.OutputDO(GreenDo, true);
                        Thread.Sleep(50);
                        Device.OutputDO(redDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(redDo, false);
                        Thread.Sleep(50);

                        Device.OutputDO(yellowDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(yellowDo, false);

                        Thread.Sleep(50);
                        Device.OutputDO(GreenLightDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(GreenLightDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(redLightDo, false);
                        Thread.Sleep(50);
                        Device.OutputDO(redLightDo, false);
                    });
                   

                    label_Message.Text = "";

                    DBCarModules = safetyDataRepository.GetData<db_CarModule>().Where(x => x.CarModuleName == carModuleName).ToList();



                    db_CarModule db_Car = DBCarModules.Where(x => x.TestName == dataGridView1.Rows[RowIndex].Cells[1].Value.ToString()).FirstOrDefault();
                    
                    if (db_Car == null)
                    {
                        MessageBox.Show("数据库错误");
                        return;
                    }

                    if (db_Car.TestName.Contains("绝缘"))
                    {
                        IsDengdianwei = false;
                    }
                    else
                    {
                        IsDengdianwei = true;
                    }
                    
                    textBox_vin.Enabled = false;
                    button1.Enabled = false;

                    timer_anguiConn.Enabled = false;

                    byte addressID = 0x01;

                    if (CurrentStation.Contains("内饰"))
                    {
                        addressID = 0x02;
                    }

                    


                    if (CurrentStation == "整车安规检测工位-最终线" || CurrentStation == "整车安规检测工位-淋雨线")
                    {
                        db_CarModule db_Caraaa = DBCarModules.Where(x => x.TestName == dataGridView1.Rows[RowIndex].Cells[1].Value.ToString()).FirstOrDefault();

                        Task.Run(() =>
                        {
                            SpVoice voice = new SpVoice();
                            voice.SetRate(1);//语速
                            voice.SetVolume(100);//音量
                            uint lll = 0;
                            voice.Speak($"请进行{db_Caraaa.TestName}检测", 0, out lll);
                        });

                        AN1622HQuickMode();
                        
                    }
                   
                    
                   

                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }

        }

        /// <summary>
        /// 进度条动态展示
        /// </summary>
        public void Progressdisplay(int a,int id) 
        {
            
            Invoke(new EventHandler(delegate
            {
                UserInfo.Press =  a;
                dataGridView1.Rows[id].Cells[4].Value = UserInfo.PressImg;
            }));
            
            

           // dataGridView1.DataSource = dt;
        }
        /// <summary>
        /// 柱状图
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="num"></param>
        public void HistogramImage(Panel panel, int[] num)
        {
            int panelHeight = panel.Height;
            int panelWidth = panel.Width;
            //创建新的画布
            Bitmap bitM = new Bitmap(panelWidth, panelHeight);

            Graphics g = Graphics.FromImage(bitM);
            g.Clear(Color.FromArgb(6, 28, 65));
            //g.GetNearestColor(Color.Blue);
            //设置字体
            Font font = new Font("Arial", 9, FontStyle.Regular);
            Font fontSong = new Font("宋体", 20, FontStyle.Regular);

            Brush brush1 = new SolidBrush(Color.White);


            //边框
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bitM.Width, bitM.Height), Color.Lime, Color.Blue, 1.2f, true);
            //g.FillRectangle(Brushes.WhiteSmoke, 0, 0, panelWidth, panelHeight);

            g.DrawString("生产数量走势", fontSong, brush1, new PointF(100, 50));
            //画图片的边框线
            //g.DrawRectangle(new Pen(Color.Blue), 0, 0, panelWidth - 4, panelHeight - 4);
            // bitM.Save("D:\\iamge1.jpeg");
            Pen mypen = new Pen(brush, 1f);
            //绘制纵向线条
            int x = 40;
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(mypen, x, 121, x, 370);
                x += 40;
            }
            // 绘制横向线条
            int y = 121;  //上下调整

            for (int i = 0; i < 11; i++)
            {
                g.DrawLine(mypen, 40, y, 320, y); //画点A到点B的直线段
                y += 25;
            }
            string Date7day = DateTime.Now.ToString("MM/dd");
            string Date6day = DateTime.Now.AddDays(-1).ToString("MM/dd");
            string Date5day = DateTime.Now.AddDays(-2).ToString("MM/dd");
            string Date4day = DateTime.Now.AddDays(-3).ToString("MM/dd");
            string Date3day = DateTime.Now.AddDays(-4).ToString("MM/dd");
            string Date2day = DateTime.Now.AddDays(-5).ToString("MM/dd");
            string Date1day = DateTime.Now.AddDays(-6).ToString("MM/dd");
            //绘制X轴月份
            string[] strX = { Date1day, Date2day, Date3day, Date4day, Date5day, Date6day, Date7day };
            x = 40;
            for (int i = 0; i < strX.Length; i++)
            {
                g.DrawString(strX[i].ToString(), font, Brushes.Red, x, panelHeight-20);
                x += 40;
            }
            //绘制Y轴数量
            string[] StrY = { "0", "50", "100", "150", "200", "250", "300", "350", "400", "450","500" };
            y = 115;////上下调整
            for (int i = 0; i < StrY.Length; i++)
            {
                g.DrawString(StrY[StrY.Length - i - 1].ToString(), font, Brushes.Red, 10, y);
                y += 25;
            }
            //填充数据
            Random ran = new Random();
            x = 45;
            y = 283;
            int h = 0;
            // int[] num = { 50, 100, 150, 160, 260, 16, 290};

            for (int i = 0; i < num.Length; i++)
            {
                SolidBrush sb = new SolidBrush(Color.FromArgb(150, 0, 0));
                g.FillRectangle(sb, x + i * 30, y - num[i]/2 + 88, 30, num[i]/2);
                g.DrawString(num[i].ToString(), font, Brushes.Lime, x + i * 30+5, y - num[i] / 2 + 58);
                x += 10;
            }


            


            //for (int i = 0; i < strX.Length; i++)
            //{
            //    int ranNum = ran.Next(0, 800);
            //    SolidBrush sb = new SolidBrush(Color.FromArgb(150, 0, 0));
            //    h = ranNum / 4;
            //    g.FillRectangle(sb, x + i * 30, y - h + 88, 30, h);
            //    x += 20;
            //}

            //bitM.Save("D:\\iamge.jpeg");
            panel.BackgroundImage = bitM;
        }
        
        private void textBox_vin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                
                ScenVIn();
            }
        }

        /// <summary>
        /// 扫码
        /// </summary>
        public void ScenVIn(string carName="") 
        {

            Task.Run(() =>
            {
                Device.OutputDO(GreenDo, false);
                Thread.Sleep(50);
                Device.OutputDO(GreenDo, false);
                Thread.Sleep(80);

                Device.OutputDO(yellowDo, true);
                Thread.Sleep(50);
                Device.OutputDO(yellowDo, true);
                Thread.Sleep(50);

                Device.OutputDO(redDo, false);
                Thread.Sleep(50);
                Device.OutputDO(redDo, false);
                Thread.Sleep(50);
                Device.OutputDO(redLightDo, false);
                Thread.Sleep(50);
                Device.OutputDO(redLightDo, false);
                Thread.Sleep(50);
                Device.OutputDO(GreenLightDo, false);
                Thread.Sleep(50);
                Device.OutputDO(GreenLightDo, false);
            });


            if (textBox_carmodle.Text.Length > 17)
            {
                return;
            }

            IsDirect = true;

            
             RowIndex = 0;
            IsTest = false;
            IsEnd = false;
            timer1.Enabled = false;
            Thread.Sleep(1000);
             IsDengdianwei = false;
            IsEnd = true;
            bool isVin = false;
            List<db_CarVinCode> db_CarVins = safetyDataRepository.GetData<db_CarVinCode>();
            foreach (db_CarVinCode item in db_CarVins)
            {
                if (textBox_carmodle.Text.Length==item.Vin.Length)
                {
                    for (int i = 0; i < item.Vin.Length; i++)
                    {
                        if (item.Vin.Substring(i, 1) == "*") { }
                        else if (textBox_carmodle.Text.Substring(i, 1) != item.Vin.Substring(i, 1))
                        {
                            isVin = false;
                            break;

                        }
                        else
                        {
                            carModuleName = item.CarModuleName;
                            isVin = true;
                        }
                    }

                    if (isVin)
                    {
                        break;
                    }
                }
               

            }
            if (isVin)
            {
                //string[] carmodels = carModuleName.Split("-");
                //if (carmodels.Length!=2)
                //{
                //    label_Message.Text = "没有找到对应车型";
                //    label_Message.ForeColor = Color.Red;
                //    return;
                //}

                //CARMODEFrm cARMODEFrm = new CARMODEFrm();
                //List<db_CarVinCode> db_naems = safetyDataRepository.GetData<db_CarVinCode>().Where(x => x.CarModuleName.Contains(carmodels[0])).ToList();
                //List<string> names = new List<string>();
                //foreach (db_CarVinCode item in db_naems)
                //{
                //    string[] strnames = item.CarModuleName.Split("-");
                //    names.Add(strnames[1]);

                //}

               // cARMODEFrm.carmodelLabel(carmodels[0], names);
                if (carModuleName!="")
                {
                    //carModuleName = carmodels[0]+"-"+Global.TypeCarModule;

                    label7.Text = carModuleName;
                    //vin 码匹配
                    List<db_CarModule> db_Cars = safetyDataRepository.GetData<db_CarModule>().Where(x => x.CarModuleName == carModuleName).ToList();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(string));
                    dt.Columns.Add("name", typeof(string));
                    dt.Columns.Add("fanwei", typeof(string));
                    dt.Columns.Add("value", typeof(string));
                    dt.Columns.Add("PressImg", typeof(Image));
                    dt.Columns.Add("result", typeof(string));
                    dt.Columns.Add("Choice", typeof(bool));
                    if (db_Cars.Count == 0)
                    {
                        return;
                    }
                    foreach (db_CarModule carModule in db_Cars)
                    {
                        UserInfo.Press = 1; //进度条

                        DataRow dataRow = dt.NewRow();
                        dataRow["id"] = carModule.Code;
                        dataRow["name"] = carModule.TestName;
                        if (CurrentStation == "充电检测")
                        {
                            dataRow["fanwei"] = ">" + carModule.Range + "W";
                        }
                        else if (carModule.TestName.Contains("绝缘") || carModule.TestName.Contains("充电口"))
                        {
                            if (carModule.TestName.Contains("绝缘监测"))
                            {
                                dataRow["fanwei"] = carModule.Range;
                            }
                            else
                            {
                                dataRow["fanwei"] = ">" + carModule.Range + "MΩ";
                            }

                        }
                        else if (carModule.TestName.Contains("电容耦合"))
                        {
                            dataRow["fanwei"] = "<" + carModule.Range + "J";
                        }
                        else
                        {
                            dataRow["fanwei"] = "<" + carModule.Range + "mΩ";
                        }

                        dataRow["value"] = "";
                        dataRow["PressImg"] = UserInfo.PressImg;
                        dataRow["result"] = "";
                        dataRow["Choice"] = true;
                        dt.Rows.Add(dataRow);

                    }

                    // dt.DefaultView.Sort = "id asc";
                    dataGridView1.DataSource = LinqSortDataTable(dt);

                    bool Ischoice = false;
                    foreach (DataGridViewRow item in dataGridView1.Rows)
                    {
                        if (bool.Parse(item.Cells[6].Value.ToString()))
                        {
                            Ischoice = true;
                            break;
                        }
                        RowIndex++;
                    }
                    if (!Ischoice)
                    {
                        return;
                    }


                    if (CurrentStation == "充电检测")
                    {
                        label_Message.Visible = true;
                        // textBox_vin.Enabled = false;
                        button1.Visible = false;
                        db_CarModule db_Car = db_Cars.Where(x => x.TestName == dataGridView1.Rows[RowIndex].Cells[1].Value.ToString()).FirstOrDefault();
                        IsDirect = db_Car.Pass == "直流口" ? true : false;
                        Device.OutputDO(yellowDo, true);


                        RowIndex = 0;
                        // Device.HVDCClose(true);
                        //  ucobd1.Visible = false;
                        Thread.Sleep(80);
                        timer1.Enabled = true;
                        // Progressdisplay(10, RowIndex);
                    }
                    else
                    {
                        foreach (DataGridViewRow item in dataGridView1.Rows)
                        {
                            if (bool.Parse(item.Cells[6].Value.ToString()))
                            {
                                Ischoice = true;
                                break;
                            }
                            RowIndex++;
                        }

                        DBCarModules = safetyDataRepository.GetData<db_CarModule>().Where(x => x.CarModuleName == carModuleName).ToList();
                        timer_anguiConn.Enabled = false;
                        IsButtonMain = false;
                        IsENTERSET = false;
                        //serialPortTest1.Write("RESET" + "\r\n");
                        //IsButtonMain = true;
                        //Thread.Sleep(300);
                        //serialPortTest1.Write("RETURN-MAIN" + "\r\n");
                        //LogHelper.Info("发送安规数据：" + "RETURN-MAIN");

                    }


                    
                }
                else
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("id", typeof(string));
                    dt.Columns.Add("name", typeof(string));
                    dt.Columns.Add("fanwei", typeof(string));
                    dt.Columns.Add("value", typeof(string));
                    dt.Columns.Add("PressImg", typeof(Image));
                    dt.Columns.Add("result", typeof(string));
                    dt.Columns.Add("Choice", typeof(bool));
                    dataGridView1.DataSource = dt;

                    label_Message.Text = "没有找到对应车型";
                    label_Message.ForeColor = Color.Red;
                }
            }

               
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="tmpDt"></param>
        /// <returns></returns>
        public DataTable LinqSortDataTable(DataTable tmpDt)
        {
            DataTable dtsort = tmpDt.Clone();
            dtsort = tmpDt.Rows.Cast<DataRow>().OrderBy(r => Convert.ToDecimal( r["id"])).CopyToDataTable();
            return dtsort;
        }
        /// <summary>
        /// 科学计算转换
        /// </summary>
        /// <param name="strData"></param>
        /// <returns></returns>
        public static Decimal ChangeDataToD(string strData)
        {
            Decimal dData = 0.0M;
            if (strData.Contains("E"))
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            return dData;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Timeout--;
            Device.ResetPower(IsDirect);
        }

        private void timer_anguiConn_Tick(object sender, EventArgs e)
        {
           // LogHelper.warning("启动监听");
            if (serialPortTest1.IsOpen)
            {
                CONNCOMM = false;
                // LogHelper.warning("发送RESET");
                serialPortTest1.Write("*idn?" + "\r\n");
                
                

                Thread.Sleep(1000);
                //LogHelper.warning("CONNCOMM:"+CONNCOMM);
                if (!CONNCOMM)
                {
                    LogHelper.warning("安规连接断了");
                    Invoke(new EventHandler(delegate
                    {
                        roundButton_anConn.ButtonCenterColorStart = Color.Red;
                        roundButton_anConn.Refresh();
                    }));
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }




        bool IsInit = false;//是否初始化
        private void button2_Click_2(object sender, EventArgs e)
        {
            IsInit = true;
            label_Message.Text = "";
            label_Message.BackColor = Color.Transparent;
            label_Message.Refresh();
            ucobd1.IsEndss = true;
            ucobd1.CloseCAN();
            timer1.Stop();
            textBox_vin.Enabled = true;
            button1.Enabled = true;
            TestingNG = 1;
            Device.OutputDO(lmlDO, false);
            Thread.Sleep(50);
            Device.OutputDO(lmlDO, false);
           
            RowIndex = 0;

            ScenVIn();

            
            LogHelper.Info("复位");
        }

        private void button_auto_Click(object sender, EventArgs e)
        {
            List<db_CarVinCode> db_CarVinCodes=safetyDataRepository.GetData<db_CarVinCode>().ToList();
            comboBox_carModules.Items.Clear();
            foreach (db_CarVinCode item in db_CarVinCodes)
            {

                comboBox_carModules.Items.Add(item.Vin+"/"+item.CarModuleName);
            }

            comboBox_carModules.SelectedIndex = 0;

            comboBox_carModules.Visible = true;
            textBox_carmodle.Visible = false;




        }

        private void comboBox_carModules_SelectionChangeCommitted(object sender, EventArgs e)
        {
            comboBox_carModules.Visible = false;
            textBox_carmodle.Visible = true;

            string[] names = comboBox_carModules.SelectedItem.ToString().Split("/");
            textBox_carmodle.Text=names[0];
            label7.Text=names[1];
            ScenVIn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void textBox_carmodle_DoubleClick(object sender, EventArgs e)
        {
            List<db_CarVinCode> db_CarVinCodes = safetyDataRepository.GetData<db_CarVinCode>().ToList();
            comboBox_carModules.Items.Clear();
            foreach (db_CarVinCode item in db_CarVinCodes)
            {

                comboBox_carModules.Items.Add(item.Vin + "/" + item.CarModuleName);
            }

            comboBox_carModules.SelectedIndex = 0;

            comboBox_carModules.Visible = true;
            textBox_carmodle.Visible = false;
        }

        private void textBox_carmodle_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
    public static class UserInfo 
    {
        public static int Press { get; set; }
        //进度条图片属性
        public static Image PressImg
        {
            get
            {
                Bitmap bmp = new Bitmap(280, 30); //这里给104是为了左边和右边空出2个像素，剩余的100就是百分比的值
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.White); //背景填白色
                //g.FillRectangle(Brushes.Red, 2, 2, this.Press, 26);  //普通效果
                //填充渐变效果
                g.FillRectangle(new LinearGradientBrush(new Point(30, 2), new Point(30, 30), Color.Lime, Color.Gray), 2, 2, Press, 26);
                return bmp;
            }
        }
    }
    public class listsen
    {
        /// <summary>
        /// 状态
        /// </summary>
        public string state { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string descName { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public string parameter_value { get; set; }
        /// <summary>
        /// 范围值
        /// </summary>
        public string range_value { get; set; }
    }
}

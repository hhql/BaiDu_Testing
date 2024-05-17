using Microsoft.Win32;
using SafetyTesting.DB.Entity;
using SafetyTesting.DB.Interface;
using SafetyTesting.Tool;
using SafetyTesting.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafetyTesting.Control
{
    public partial class Device : UserControl
    {
        private static System.IO.Ports.SerialPort serialPortTest;
        public ISafetyDataRepository safetyDataRepository;
        public bool StateIO=false;
        public bool StopIO = false;
        public bool IsdirectConn = false;
        public bool IscommConn = false;
        public bool IsIOConn = false;//IO 状态
        public Device()
        {
            InitializeComponent();

        }

        public  void Close() 
        {
            byte[] dataIO = new byte[] { 0x06, 0x06, 0x00, 0x10, 0xAA, 0xAA, 0x77, 0x67 };


            serialPortTest.Write(dataIO, 0, dataIO.Length);

            Thread.Sleep(100);


            byte[] dataIO1 = new byte[] { 0x05, 0x06, 0x00, 0x10, 0xAA, 0xAA, 0x77, 0x54 };

            serialPortTest.Write(dataIO1, 0, dataIO1.Length);



        }

        public static void HVDCClose(bool isopen) 
        {
            if (isopen)
            {
                byte[] dataIO = new byte[] { 0x06, 0x06, 0x00, 0x10, 0xAA, 0xAA, 0x77, 0x67 };

                dataIO[4] = 0x55;
                dataIO[5] = 0x55;
                dataIO[6] = 0x76;
                dataIO[7] = 0xD7;



                serialPortTest.Write(dataIO, 0, dataIO.Length);
            }
            else
            {
                byte[] dataIO = new byte[] { 0x06, 0x06, 0x00, 0x10, 0xAA, 0xAA, 0x77, 0x67 };


                serialPortTest.Write(dataIO, 0, dataIO.Length);
            }
            
        }
        private void Device_Load(object sender, EventArgs e)
        {
            try
            {

                GetIOmodule();

                panel1.Visible = true;
                panel2.Visible = true;

                db_TestingConfig db_Testing = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "IO配置").FirstOrDefault();
                string[] data = db_Testing.Value.Split(';');
                serialPortTest = new System.IO.Ports.SerialPort();
                serialPortTest.DataReceived += SerialPortTest_DataReceived;
                serialPortTest.BaudRate = Convert.ToInt32(data[1]);
                serialPortTest.PortName = data[0];
                LogHelper.Info(db_Testing.Value);
                serialPortTest.Open();
                BroadCast.SendBroadCast("IO_conn");

                if (home.LocadTitle().Contains("内饰"))
                {
                    tabControl1.Visible = false;
                }


                timer1.Enabled = true;
                timer2.Enabled = true;


                InitConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                BroadCast.SendBroadCast("IO_exit");
            }
            
        }

        public void InitConfig() 
        {
            //串口配置初始化
            string[] strs = GetPort();
           
            comboBox_TestCom.Items.AddRange(strs);
            comboBox_IoCom.Items.AddRange(strs);

            db_TestingConfig db_Testing = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "安规配置").FirstOrDefault();
            if (db_Testing != null)
            {
                string[] datas = db_Testing.Value.Split(';');
                comboBox_TestCom.Text = datas[0];
                textBox_TestBaudRate.Text = datas[1];
            }

           

            db_Testing = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "IO配置").FirstOrDefault();
            if (db_Testing != null)
            {
                string[] datas = db_Testing.Value.Split(';');
                comboBox_IoCom.Text = datas[0];
                textBox_ioBaudRate.Text = datas[1];
            }

            

            db_Testing = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "BAT配置").FirstOrDefault();
            if (db_Testing != null)
            {
                string[] datas = db_Testing.Value.Split(';');
                textBox_batTime.Text = datas[0];
                textBox_batReadTime.Text = datas[1];
            }


            db_Testing = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "GB配置").FirstOrDefault();
            if (db_Testing != null)
            {
                string[] datas = db_Testing.Value.Split(';');
                textBox1.Text = datas[0];
                textBox2.Text = datas[1];
                textBox3.Text = datas[2];
            }
        }

        /// <summary>
        /// 获取当前串口列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetPort()
        {
            try
            {
                RegistryKey hklm = Registry.LocalMachine;

                RegistryKey software11 = hklm.OpenSubKey("HARDWARE");

                //打开"HARDWARE"子健
                RegistryKey software = software11.OpenSubKey("DEVICEMAP");

                RegistryKey sitekey = software.OpenSubKey("SERIALCOMM");

                //获取当前子健
                String[] Str2 = sitekey.GetValueNames();

                //获得当前子健下面所有健组成的字符串数组
                int ValueCount = sitekey.ValueCount;
                //获得当前子健存在的健值
                int i;
                string[] rtn = new string[ValueCount];
                for (i = 0; i < ValueCount; i++)
                {
                    rtn[i] = (string)sitekey.GetValue(Str2[i]);
                }
                return rtn;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /// <summary>
        ///  读取 IO 配置数据库
        /// </summary>
        public void GetIOmodule() 
        {
            List<db_IOModule> iomodules = safetyDataRepository.GetData<db_IOModule>();
            foreach (db_IOModule iOModule in iomodules)
            {
                switch (iOModule.Id)
                {
                    case 1:
                        label1.Text = iOModule.Pass;
                        comboBox1.SelectedItem = iOModule.IOModule1;
                        comboBox2.SelectedItem = iOModule.IOModule2;
                        break;
                    case 2:
                        label2.Text = iOModule.Pass;
                        comboBox3.SelectedItem = iOModule.IOModule1;
                        comboBox4.SelectedItem = iOModule.IOModule2;
                        break;
                    case 3:
                        label3.Text = iOModule.Pass;
                        comboBox5.SelectedItem = iOModule.IOModule1;
                        comboBox6.SelectedItem = iOModule.IOModule2;
                        break;
                    case 4:
                        label4.Text = iOModule.Pass;
                        comboBox7.SelectedItem = iOModule.IOModule1;
                        comboBox8.SelectedItem = iOModule.IOModule2;
                        break;
                    case 5:
                        label5.Text = iOModule.Pass;
                        comboBox9.SelectedItem = iOModule.IOModule1;
                        comboBox10.SelectedItem = iOModule.IOModule2;
                        break;
                    case 6:
                        label6.Text = iOModule.Pass;
                        comboBox11.SelectedItem = iOModule.IOModule1;
                        comboBox12.SelectedItem = iOModule.IOModule2;
                        break;
                    case 7:
                        label7.Text = iOModule.Pass;
                        comboBox13.SelectedItem = iOModule.IOModule1;
                        comboBox14.SelectedItem = iOModule.IOModule2;
                        break;
                    case 8:
                        label8.Text = iOModule.Pass;
                        comboBox15.SelectedItem = iOModule.IOModule1;
                        comboBox16.SelectedItem = iOModule.IOModule2;
                        break;
                    case 9:
                        label9.Text = iOModule.Pass;
                        comboBox17.SelectedItem = iOModule.IOModule1;
                        comboBox18.SelectedItem = iOModule.IOModule2;
                        break;
                    case 10:
                        label10.Text = iOModule.Pass;
                        comboBox19.SelectedItem = iOModule.IOModule1;
                        comboBox20.SelectedItem = iOModule.IOModule2;
                        break;
                    case 11:
                        comboBox_red.SelectedItem = iOModule.IOModule1;
                        break;
                    case 12:
                        comboBox_yellow.SelectedItem = iOModule.IOModule1;
                        break;
                    case 13:
                        comboBox_green.SelectedItem = iOModule.IOModule1;
                        break;
                    case 14:
                        comboBox_fml.SelectedItem = iOModule.IOModule1;
                        break;
                    case 15:
                        comboBox_RedLight.SelectedItem = iOModule.IOModule1;
                        break;
                    case 16:
                        comboBox_GreenLight.SelectedItem = iOModule.IOModule1;
                        break;
                }
            }

        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (Global.UserName.ToLower()=="admin")
            {
                FormPassword password = new FormPassword();

                if (password.ShowDialog() == DialogResult.OK)
                {
                    safetyDataRepository.Updates(IoModuleDatas());
                    MessageBox.Show("更新完成");
                }
                else
                {
                    MessageBox.Show("密码错误,更新失败");
                }
            }
            else
            {
                MessageBox.Show("权限不足,保存失败");
            }

            

           
        }

        /// <summary>
        /// IO List 数据
        /// </summary>
        /// <returns></returns>
        public List<db_IOModule> IoModuleDatas() 
        {
            List<db_IOModule> db_IOModules = new List<db_IOModule>();
            

            db_IOModules.Add(new db_IOModule
            {
                Pass = label1.Text,
                IOModule1 = comboBox1.Text==""?"0": comboBox1.Text,
                IOModule2 = comboBox2.Text == "" ? "0" : comboBox2.Text,
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = label2.Text,
                IOModule1 = comboBox3.Text == "" ? "0" : comboBox3.Text,
                IOModule2 = comboBox4.Text == "" ? "0" : comboBox4.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = label3.Text,
                IOModule1 = comboBox5.Text == "" ? "0" : comboBox5.Text,
                IOModule2 = comboBox6.Text == "" ? "0" : comboBox6.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = label4.Text,
                IOModule1 = comboBox7.Text == "" ? "0" : comboBox7.Text,
                IOModule2 = comboBox8.Text == "" ? "0" : comboBox8.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = label5.Text,
                IOModule1 = comboBox9.Text == "" ? "0" : comboBox9.Text,
                IOModule2 = comboBox10.Text == "" ? "0" : comboBox10.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = label6.Text,
                IOModule1 = comboBox11.Text == "" ? "0" : comboBox11.Text,
                IOModule2 = comboBox12.Text == "" ? "0" : comboBox12.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = label7.Text,
                IOModule1 = comboBox13.Text == "" ? "0" : comboBox13.Text,
                IOModule2 = comboBox14.Text == "" ? "0" : comboBox14.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = label8.Text,
                IOModule1 = comboBox15.Text == "" ? "0" : comboBox15.Text,
                IOModule2 = comboBox16.Text == "" ? "0" : comboBox16.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = label9.Text,
                IOModule1 = comboBox17.Text == "" ? "0" : comboBox17.Text,
                IOModule2 = comboBox18.Text == "" ? "0" : comboBox18.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = label10.Text,
                IOModule1 = comboBox19.Text == "" ? "0" : comboBox19.Text,
                IOModule2 = comboBox20.Text == "" ? "0" : comboBox20.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = "red",
                IOModule1 = comboBox_red.Text == "" ? "0" : comboBox_red.Text,
                IOModule2 = comboBox_red.Text == "" ? "0" : comboBox_red.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = "yellow",
                IOModule1 = comboBox_yellow.Text == "" ? "0" : comboBox_yellow.Text,
                IOModule2 = comboBox_yellow.Text == "" ? "0" : comboBox_yellow.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = "green",
                IOModule1 = comboBox_green.Text == "" ? "0" : comboBox_green.Text,
                IOModule2 = comboBox_green.Text == "" ? "0" : comboBox_green.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = "fml",
                IOModule1 = comboBox_fml.Text == "" ? "0" : comboBox_fml.Text,
                IOModule2 = comboBox_fml.Text == "" ? "0" : comboBox_fml.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = "RedLight",
                IOModule1 = comboBox_RedLight.Text == "" ? "0" : comboBox_RedLight.Text,
                IOModule2 = comboBox_RedLight.Text == "" ? "0" : comboBox_RedLight.Text
            });
            db_IOModules.Add(new db_IOModule
            {
                Pass = "GreenLight",
                IOModule1 = comboBox_GreenLight.Text == "" ? "0" : comboBox_GreenLight.Text,
                IOModule2 = comboBox_GreenLight.Text == "" ? "0" : comboBox_GreenLight.Text
            });
            //db_IOModules.Add(new db_IOModule
            //{
            //    Pass = "通道十二",
            //    IOModule1 = comboBox23.Text == "" ? "0" : comboBox23.Text,
            //    IOModule2 = comboBox24.Text == "" ? "0" : comboBox24.Text
            //});
            return db_IOModules;
        }

        /// <summary>
        /// IO 监听数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialPortTest_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(50);
            int len = serialPortTest.BytesToRead;
           
            if (len >0)
            {
                IsIOConn = true;
                string sb = "";
                byte[] buff = new byte[len];
                serialPortTest.Read(buff, 0, len);
              //  LogHelper.warning("收到的DI数据长度" + len);
                foreach (var item in buff)
                {
                    sb += (Convert.ToString(item, 16)).PadLeft(2, '0') + " ";
                }
              //  LogHelper.warning("收到的DI数据=" + sb);

                if (home.CurrentStation == "充电检测")
                {
                    //06 04 04 00 00 00 00 8d
                    //06 04 04 45 DB B3 33 DD 56  读取到的值
                    if (buff.Length>6)
                    {
                        if (buff[1] == 4)
                        {
                            int[] intData = { buff[3], buff[4], buff[5], buff[6] };
                            float num = ScientificToFloat(intData);
                           // LogHelper.warning("功率"+num);
                            BroadCast.SendBroadCast("功率" + num);
                        }
                    }
                    

                }
                else
                {
                    // LogHelper.Info("IO状态值回复 IsIOConn= TRUE");
                    if (buff.Length!=6)
                    {
                        return;
                    }

                    if (buff[1] == 2)
                    {
                        if (buff[3] == 1)
                        {
                            if (!StopIO)
                            {
                                StopIO = true;
                                LogHelper.Info("急停");
                                BroadCast.SendBroadCast("stopComm");
                            }
                        }
                        else if (buff[3] == 2)
                        {
                            if (!StateIO)
                            {
                                StateIO = true;
                                LogHelper.Info("IO触发检测");
                                BroadCast.SendBroadCast("IO触发");

                            }
                        }
                        else if (buff[3] == 3)
                        {
                            if (!StopIO)
                            {
                                StopIO = true;
                                LogHelper.Info("急停");
                                BroadCast.SendBroadCast("stopComm");
                            }
                            if (!StateIO)
                            {
                                StateIO = true;
                                LogHelper.Info("IO触发检测");
                                BroadCast.SendBroadCast("IO触发");

                            }
                        }
                        else
                        {
                            StateIO = false;
                            if (StopIO)
                            {
                                LogHelper.Info("急停恢复");
                                BroadCast.SendBroadCast("stopRecovery");
                            }
                            StopIO = false;
                        }

                      

                    }
                }
                

            }
        }

        private void DO_Click(object sender, EventArgs e)
        {
            RoundButton roundButton = (RoundButton)sender;
            bool IsOn=false;
            if (roundButton.ButtonCenterColorStart == Color.Lime)
            {
                
                roundButton.ButtonCenterColorStart = Color.Gray;

            }
            else
            {
                IsOn = true;
                roundButton.ButtonCenterColorStart = Color.Lime;
            }
            roundButton.Refresh();
            byte addressId = 0x01;
            switch (roundButton.Name)
            {
                
                case "DO1":
                    OutputDO(comboBox1.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox2.Text, IsOn);
                    
                    break;
                case "DO2":
                    OutputDO(comboBox3.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox4.Text, IsOn);
                    break;
                case "DO3":
                    OutputDO(comboBox5.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox6.Text, IsOn);
                    break;
                case "DO4":
                    OutputDO(comboBox7.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox8.Text, IsOn);
                    break;
                case "DO5":
                    OutputDO(comboBox9.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox10.Text, IsOn);
                    break;
                case "DO6":
                    OutputDO(comboBox11.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox12.Text, IsOn);
                    break;
                case "DO7":
                    OutputDO(comboBox13.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox14.Text, IsOn);
                    break;
                case "DO8":
                    OutputDO(comboBox15.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox16.Text, IsOn);
                    break;
                case "DO9":
                    OutputDO(comboBox17.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox18.Text, IsOn);
                    break;
                case "DO10":
                    OutputDO(comboBox19.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox20.Text, IsOn);
                    break;
                case "REDL":
                    OutputDO(comboBox_red.Text,IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox_red.Text, IsOn);
                    break;
                case "YellowL":
                    OutputDO(comboBox_yellow.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox_yellow.Text, IsOn);
                    break;
                case "GreenL":
                    OutputDO(comboBox_green.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox_green.Text, IsOn);
                    break;
                case "FML":
                    OutputDO(comboBox_fml.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox_fml.Text, IsOn);
                    break;
                case "RedLight":
                    OutputDO(comboBox_RedLight.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox_RedLight.Text, IsOn);
                    break;
                case "GreenLight":
                    OutputDO(comboBox_GreenLight.Text, IsOn);
                    Thread.Sleep(50);
                    OutputDO(comboBox_GreenLight.Text, IsOn);
                    break;
                    //case "DO11":
                    //    OutputDO(comboBox21.Text, IsOn);
                    //    Thread.Sleep(50);
                    //    OutputDO(comboBox22.Text, IsOn);
                    //    break;
                    //case "DO12":
                    //    OutputDO(comboBox23.Text, IsOn);
                    //    Thread.Sleep(50);
                    //    OutputDO(comboBox24.Text, IsOn);
                    //    break;
            }


            
        }

        public static void ResetPower(bool IsDirect) 
        {
            //06 04 00 12 00 02 D0 79 读取寄存器值
            //06 04 04 45 DB B3 33 DD 56  读取到的值
            if (IsDirect)
            {
                byte[] dataIO = new byte[] { 0x06, 0x04, 0x00, 0x12, 0x00, 0x02,0xD0,0x79 };
               // LogHelper.Info("发送直流口检测功率");
                serialPortTest.Write(dataIO, 0, dataIO.Length);
            }
            else
            {
                byte[] dataIO = new byte[] { 0x05, 0x04, 0x00, 0x12, 0x00, 0x02, 0xD0, 0x4A };
               // LogHelper.Info("发送交流口检测功率");
                serialPortTest.Write(dataIO, 0, dataIO.Length);
            }
            
        }
        static Object obj = new Object();
        public void ResetDI( byte addressID=0x01) 
        {
            byte[] data = new byte[8];
            
            byte[] dataIO = new byte[] {0x01,0x02,0x00,0x00,0x00,0x02 };
            dataIO[0] = addressID;
            byte[] crc = ToModbusCRC(dataIO);



            data[0] = dataIO[0];
            data[1] = dataIO[1];
            data[2] = dataIO[2];
            data[3] = dataIO[3];
            data[4] = dataIO[4];
            data[5] = dataIO[5];
            data[6] = crc[0];
            data[7] = crc[1];
            serialPortTest.Write(data, 0, data.Length);
            
            
        }
        /// <summary>
        /// 输出DO信号
        /// </summary>
        /// <param name="val">寄存器值</param>
        /// <param name="Isopen">开关</param>
        /// <param name="addressId">地址ID</param>
        public static void OutputDO(string val,bool Isopen,byte addressId = 0x01) 
        {
            if (val == "")
            {

                return;
            }
            int v = Convert.ToInt32(val);
            byte[] data = new byte[8];

            byte[] dataIO = new byte[] { 0x01, 0x05, 0x00, 0x00, 0xFF, 0x00 };
            if (!Isopen)
            {
                dataIO[4] = 0x00;
            }
            dataIO[0] = addressId;

            dataIO[3] = (byte)v;
            byte[] crc = ToModbusCRC(dataIO);
            data[0] = dataIO[0];
            data[1] = dataIO[1];
            data[2] = dataIO[2];
            data[3] = dataIO[3];
            data[4] = dataIO[4];
            data[5] = dataIO[5];
            data[6] = crc[0];
            data[7] = crc[1];
            //StringBuilder stringBuilder = new StringBuilder();
            //foreach (var item in data)
            //{
            //    stringBuilder.Append(Convert.ToString(item, 16));
            //}
           // LogHelper.Info("发送IO：" + stringBuilder);
            serialPortTest.Write(data, 0, data.Length);


        }
        /// <summary>
        /// Modbus CRC 校验
        /// </summary>
        /// <param name="byteData"></param>
        /// <returns></returns>
        public static byte[] ToModbusCRC(byte[] byteData)
        {
            byte[] CRC = new byte[2];

            UInt16 wCrc = 0xFFFF;
            for (int i = 0; i < byteData.Length; i++)
            {
                wCrc ^= Convert.ToUInt16(byteData[i]);
                for (int j = 0; j < 8; j++)
                {
                    if ((wCrc & 0x0001) == 1)
                    {
                        wCrc >>= 1;
                        wCrc ^= 0xA001;//异或多项式
                    }
                    else
                    {
                        wCrc >>= 1;
                    }
                }
            }

            CRC[1] = (byte)((wCrc & 0xFF00) >> 8);//高位在后
            CRC[0] = (byte)(wCrc & 0x00FF);       //低位在前
            return CRC;

        }

        /// <summary>
        /// 十六进制转浮点数
        /// </summary>
        /// <param name="datas"></param>
        /// <returns></returns>
        public static float ScientificToFloat(int[] datas)
        {
            int data = datas[0] << 24 | datas[1] << 16 | datas[2] << 8 | datas[3];

            int nSign;
            if ((data & 0x80000000) > 0)
            {
                nSign = -1;
            }
            else
            {
                nSign = 1;
            }
            int nExp = data & (0x7F800000);
            nExp = nExp >> 23;
            float nMantissa = data & (0x7FFFFF);

            if (nMantissa != 0)
                nMantissa = 1 + nMantissa / 8388608;

            float value = nSign * nMantissa * (2 << (nExp - 128));
            return value;
        }

        /// <summary>
        /// 读取 急停，按笔信号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (home.CurrentStation == "充电检测")
            {
                ResetDI(0x01);
            }
            else
            {
                if (home.CurrentStation.Contains("内饰"))
                {
                    ResetDI(0x02);
                }
                else
                {
                    ResetDI(0x01);
                }
               
            }
            
        }

       

        private void textBox_Module1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textBox = (TextBox)sender;
                string moduleName = string.Empty;
                switch (textBox.Name)
                {
                    case "textBox_Module1":
                        moduleName = label1.Text;
                        label1.Text = textBox.Text;
                        break;
                    case "textBox_Module2":
                        moduleName = label2.Text;
                        label2.Text = textBox.Text;
                        break;
                    case "textBox_Module3":
                        moduleName = label3.Text;
                        label3.Text = textBox.Text;
                        break;
                    case "textBox_Module4":
                        moduleName = label4.Text;
                        label4.Text = textBox.Text;
                        break;
                    case "textBox_Module5":
                        moduleName = label5.Text;
                        label5.Text = textBox.Text;
                        break;
                    case "textBox_Module6":
                        moduleName = label6.Text;
                        label6.Text = textBox.Text;
                        break;
                    case "textBox_Module7":
                        moduleName = label7.Text;
                        label7.Text = textBox.Text;
                        break;
                    case "textBox_Module8":
                        moduleName = label8.Text;
                        label8.Text = textBox.Text;
                        break;
                    case "textBox_Module9":
                        moduleName = label9.Text;
                        label9.Text = textBox.Text;
                        break;
                    case "textBox_Module10":
                        moduleName = label10.Text;
                        label10.Text = textBox.Text;
                        break;
                }
                db_IOModule _IOModule = safetyDataRepository.GetData<db_IOModule>().Where(x => x.Pass == moduleName).FirstOrDefault();
                _IOModule.Pass = textBox.Text;
                safetyDataRepository.Update(_IOModule);


               List<db_CarModule> db_CarModuls = safetyDataRepository.GetData<db_CarModule>().Where(x => x.Pass == moduleName).ToList();
                if (db_CarModuls.Count>0)
                {
                    foreach (db_CarModule item in db_CarModuls)
                    {
                        item.Pass = textBox.Text;
                        safetyDataRepository.Update(item);
                    }
                }
                

                textBox.Visible = false;

            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            switch (label.Name)
            {
                case "label1":
                    textBox_Module1.Visible = true;
                    break;
                case "label2":
                    textBox_Module2.Visible = true;
                    break;
                case "label3":
                    textBox_Module3.Visible = true;
                    break;
                case "label4":
                    textBox_Module4.Visible = true;
                    break;
                case "label5":
                    textBox_Module5.Visible = true;
                    break;
                case "label6":
                    textBox_Module6.Visible = true;
                    break;
                case "label7":
                    textBox_Module7.Visible = true;
                    break;
                case "label8":
                    textBox_Module8.Visible = true;
                    break;
                case "label9":
                    textBox_Module9.Visible = true;
                    break;
                case "label10":
                    textBox_Module10.Visible = true;
                    break;
            }
        }

        int IOcount = 0;

        /// <summary>
        /// IO心跳
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {

            IsIOConn = false;

            bool resetIO = true;
            bool asdf = true;
            IOcount = 0;
            Task.Run(() =>
            {
                while (resetIO)
                {
                    if (IOcount > 10)
                    {
                        IOcount = 0;
                        resetIO = false;
                    }
                    Thread.Sleep(100);
                   // LogHelper.Info("读取到IO状态值：" + IsIOConn);
                    if (IsIOConn == false)
                    {

                        asdf = false;
                    }
                    else
                    {
                        asdf = true;

                        resetIO = false;
                    }
                    IOcount++;

                }


                if (!asdf)
                {

                   // LogHelper.Info("IO连接断开");
                    BroadCast.SendBroadCast("IO_exit");
                }
                else
                {
                    BroadCast.SendBroadCast("IO_conn");
                }
            });
                
            
        }

        /// <summary>
        /// 保存设备内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_DeviceSave_Click(object sender, EventArgs e)
        {
            if (Global.UserName.ToLower()=="admin")
            {
                if (safetyDataRepository.GetData<db_TestingConfig>() != null)
                {
                    db_TestingConfig db_AnguiTesting = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "安规配置").FirstOrDefault();
                    if (db_AnguiTesting != null)
                    {
                        db_AnguiTesting.Value = comboBox_TestCom.Text + ";" + textBox_TestBaudRate.Text;
                        safetyDataRepository.Update(db_AnguiTesting);
                    }
                   

                    db_TestingConfig db_IOTesting = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "IO配置").FirstOrDefault();
                    if (db_IOTesting != null)
                    {
                        db_IOTesting.Value = comboBox_IoCom.Text + ";" + textBox_ioBaudRate.Text;
                        safetyDataRepository.Update(db_IOTesting);
                    }

                    db_TestingConfig db_BATTesting = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "BAT配置").FirstOrDefault();
                    if (db_BATTesting != null)
                    {
                        db_BATTesting.Value = textBox_batTime.Text + ";" + textBox_batReadTime.Text;
                        safetyDataRepository.Update(db_BATTesting);
                    }

                    db_TestingConfig db_GBTesting = safetyDataRepository.GetData<db_TestingConfig>().Where(x => x.SettingName == "GB配置").FirstOrDefault();
                    if (db_GBTesting != null)
                    {
                        db_GBTesting.Value = textBox1.Text + ";" + textBox2.Text+";"+ textBox3.Text;
                        safetyDataRepository.Update(db_GBTesting);
                    }

                    MessageBox.Show("重启系统生效");
                }
            }
            else
            {
                MessageBox.Show("权限不足，保存失败");
            }
            
        }
    }
}

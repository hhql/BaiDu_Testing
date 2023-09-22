using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SafetyTesting.Tool;

namespace ECAN
{
    public enum EFunctionType
    {
        FaultCode,
        Charge
    }

    public partial class UCTPMOBD : UserControl
    {
        private Action<string, Color, int> learningResultAction;

        bool IsSendCode = false;
        byte m_connect = 0;
        ComProc mCan = new ComProc();
        string[] ReadVin = new string[3];
        string writeVin = "";

        bool isCANBusy = false;
        bool isRead = false;
        EFunctionType status = EFunctionType.FaultCode;//0 故障，1：充电
        public string message;

        private int eCUTimeout = 80;

        public string vinCode = "12345678901234567";

        //进入扩展模式
        const string ENTER_EXTENDED = "02 10 03 00 00 00 00 00";
        const string ENTER_EXTENDED_ACK = "5003"; // 02 50 03

        //请求种子
        const string REQUEST_SEED = "02 27 01 00 00 00 00 00";
        const string REQUEST_SEED_ACK = "066701"; //06 67 01 00 00 XX XX 00

        //发送Key
        const string SEND_KEY = "06 27 02 "; //06 27 02 YY YY YY YY 00
        const string SEND_KEY_ACK = "026702"; //02 67 02 00 00 00 00 00

        //发送模式
        const string SEND_EPB_DATA1 = "04 2E 01 02"; //04 2E 01 02
        const string SEND_EPB_DATA1_ACK = "036E0102"; //03 6E 01 02 00 00 00 00 

        const string SEND_EPB_DATA2 = "04 31 01 60"; //21 00 00 00 00 00 00 00
        const string SEND_EPB_DATA2_ACK = "05710160"; //05 71 01 60 04 01 00 00 


        //发送诊断查看命令
        const string SEND_EPB_DIAGNOSIS = "19 02 FF 00 00 00 00 00";//03 22 01 02 00 00 00 00
        const string SEND_EPB_DIAGNOSIS_ACK = "0462010200";//04 62 01 02 00 00 00 00
        const string SEND_EPB_DIAGNOSIS1_ACK = "0462010202";//04 62 01 02 02 00 00 00


        private int timeOutCount = 0;
        bool Iswhite20 = false;
        private System.Timers.Timer OBDWatchingTimer;

        private System.Timers.Timer ProcessTimeOutTimer;

        public UCTPMOBD()
        {
            InitializeComponent();

            ProcessTimeOutTimer = new System.Timers.Timer(1000);
            ProcessTimeOutTimer.Elapsed += new ElapsedEventHandler(ProcessTimeOut_Tick);
            ProcessTimeOutTimer.Enabled = false;

            OBDWatchingTimer = new System.Timers.Timer(4000);
            OBDWatchingTimer.Elapsed += new ElapsedEventHandler(OBDWatchingt_Tick);
            OBDWatchingTimer.Enabled = false;

            // eCUTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["ECU_Time_Out"]);

        }



        //Open CAN
        public void InitializeCAN(Action<string, Color, int> resultAction, string typeCan)
        {

            if (m_connect == 1)
            {
                CloseCAN();
            }
            learningResultAction = resultAction;

            INIT_CONFIG init_config = new INIT_CONFIG();

            init_config.AccCode = 0;
            init_config.AccMask = 0xffffff;
            init_config.Filter = 0;
            //Baudrate 125
            if (typeCan == "0")
            {
                init_config.Timing0 = 0x00;
                init_config.Timing1 = 0x1C;
            }
            else
            {
                init_config.Timing0 = 0x01;
                init_config.Timing1 = 0x1C;
            }


            init_config.Mode = 0;
            if (ECANDLL.OpenDevice(1, 0, 0) != ECAN.ECANStatus.STATUS_OK)
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                //  Status_OBD_Connection.Image = Image.FromFile("Resources\\light_red_1.png");
                LogHelper.warning("打开CAN模块失败，请重新启动系统。");
                message = "打开CAN模块失败";
                learningResultAction(message, Color.Maroon, 1);
                return;
            }
            //Set can1 baud
            if (ECANDLL.InitCAN(1, 0, 0, ref init_config) != ECAN.ECANStatus.STATUS_OK)
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                // Status_OBD_Connection.Image = Image.FromFile("Resources\\light_red_1.png");
                ECANDLL.CloseDevice(1, 0);
                LogHelper.warning("初始化CAN模块失败，请重新启动系统。");
                message = "初始化CAN模块失败";
                learningResultAction(message, Color.Maroon, 1);
                return;
            }

            m_connect = 1;
            mCan.EnableProc = true;

            //Start Can1
            if (ECANDLL.StartCAN(1, 0, 0) == ECAN.ECANStatus.STATUS_OK)
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Lime;
                // Status_OBD_Connection.Image = Image.FromFile("Resources\\light_on_1.png");
                LogHelper.warning("启动CAN模块成功！");
                message = "启动CAN模块成功";

                learningResultAction(message, Color.Navy, 10);
                timer_Receive.Enabled = true;
            }
            else
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                // Status_OBD_Connection.Image = Image.FromFile("Resources\\light_red_1.png");
                LogHelper.warning("启动CAN模块失败。");
                message = "启动CAN模块失败";
                learningResultAction(message, Color.Maroon, 1);
            }
        }


        private void OBDWatchingt_Tick(object source, ElapsedEventArgs e)
        {
            try
            {

                timeOutCount = 0;
                if (status == EFunctionType.FaultCode)
                {
                    //string strCmd = "02 10 03 00 00 00 00 00";
                    SendCommand(ENTER_EXTENDED, "7A1");
                }
                else if (status == EFunctionType.Charge)
                {
                    //string strCmd = "03 22 01 02 00 00 00 00";
                    SendCommand(SEND_EPB_DIAGNOSIS, "684");
                }
                else
                {
                    //string strCmd = "02 10 03 00 00 00 00 00";
                    SendCommand(ENTER_EXTENDED, "684");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

        /// <summary>
        /// Start TPM learning
        /// </summary>
        public void StartEPBLearning(EFunctionType type, string strvin = "12345678901234567", bool IsRead = false)
        {
            status = type;
            vinCode = strvin;
            OBDWatchingTimer.Enabled = true;
            isRead = IsRead;
        }


        //发送命令
        public bool SendCommand(string strData, string sendframe)
        {
            try
            {
                isCANBusy = true;

                if (m_connect == 0)
                {
                    roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                    // Status_OBD_Connection.Image = Image.FromFile("Resources\\light_red_1.png");
                    LogHelper.warning("初始化CAN模块失败，请重新启动系统。");
                    message = "初始化CAN模块失败";
                    learningResultAction(message, Color.Maroon, 1);
                    return false;
                }
                strData = strData.Trim();
                string[] dataArr = strData.Split(' ');
                if (dataArr.Length != 8)
                {
                    LogHelper.Error($"发送数据长度不对{dataArr.Length}.数据{strData}");
                    return false;
                }
                //创建发送到CAN的数据帧

                CAN_OBJ frameinfo = new CAN_OBJ();


                // create a TPCANMsg message structure
                frameinfo.SendType = 0;
                if (sendframe == "684")
                {
                    frameinfo.ExternFlag = 0;//是否是扩展帧
                }
                else
                {
                    frameinfo.ExternFlag = 1;//是否是扩展帧
                }

                frameinfo.RemoteFlag = 0;

                frameinfo.data = new byte[8];
                frameinfo.Reserved = null;

                // We configurate the Message.  The ID (max 0x1FF),
                // ID 0x602 is used for sending TPMS learning commands to ECU
                // frameinfo.ID = Convert.ToUInt32("684", 16);
                frameinfo.ID = Convert.ToUInt32(sendframe, 16); //EPB 684   VIN 18DA00F1
                LogHelper.warning("帧ID->" + frameinfo.ID);
                frameinfo.DataLen = (byte)8; //Convert.ToByte(dataArr.Length);

                for (int i = 0; i <= frameinfo.DataLen - 1; i++)
                {
                    frameinfo.data[i] = Convert.ToByte(dataArr[i], 16);
                }

                // sysLog.Info("Sending data->" + strData);

                if (ECANDLL.Transmit(1, 0, 0, ref frameinfo, (ushort)1) != ECANStatus.STATUS_OK)
                {

                    LogHelper.warning("发送数据失败（failed）:" + frameinfo.ID + ":" + strData);
                    message = "请检查OBD连接";
                    learningResultAction(message, Color.Maroon, 20);
                    ReadError();

                    return false;
                }
                LogHelper.warning("Sending data->" + strData);

                return true;
            }

            catch (Exception ex)
            {
                LogHelper.warning("发送数据错误消息:" + ex.Message);
                LogHelper.Error(ex.ToString());
                return false;
            }
            finally
            {
                isCANBusy = false;
            }
        }

        public void ReadError()
        {
            CAN_ERR_INFO mErrInfo = new CAN_ERR_INFO();
            if (ECANDLL.ReadErrInfo(1, 0, 0, out mErrInfo) == ECANStatus.STATUS_OK)
            {
                LogHelper.Error(string.Format("错误ErroCode: {0:X4}h", mErrInfo.ErrCode));
            }
            else
            {
            }
        }

        //Close CAN device
        public void CloseCAN()
        {
            status = 0;
            isCANBusy = false;
            OBDWatchingTimer.Enabled = false;
            timer_Receive.Enabled = false;
            ProcessTimeOutTimer.Enabled = false;
            ReadVin = new string[3];

            if (m_connect == 1)
            {
                m_connect = 0;
                mCan.EnableProc = false;

                ECANDLL.CloseDevice(1, 0);
            }
        }

        private void Timer_Receive_Tick_1(object sender, EventArgs e)
        {
            CAN_OBJ frameinfo = new CAN_OBJ();
            int mCount = 0;
            while (this.mCan.gRecMsgBufHead != this.mCan.gRecMsgBufTail)
            {
                string tmpstr;
                string strData = "";
                frameinfo = this.mCan.gRecMsgBuf[this.mCan.gRecMsgBufTail];
                this.mCan.gRecMsgBufTail += 1;
                if (this.mCan.gRecMsgBufTail >= ComProc.REC_MSG_BUF_MAX)
                {
                    this.mCan.gRecMsgBufTail = 0;
                }
                string str = "Rec: ";
                if (frameinfo.TimeFlag == 0)
                {
                    tmpstr = "Time:  ";
                }
                else
                {
                    tmpstr = "Time:" + string.Format("{0:X8}h", frameinfo.TimeStamp);
                }
                str = str + tmpstr;
                tmpstr = "  ID:" + string.Format("{0:X8}h", frameinfo.ID);
                str = str + tmpstr + " Format:";
                if (frameinfo.RemoteFlag == 0)
                {
                    tmpstr = "Data ";
                }
                else
                {
                    tmpstr = "Romte ";
                }
                str = str + tmpstr + " Type:";
                if (frameinfo.ExternFlag == 1)
                {
                    tmpstr = "Stand ";
                }
                else
                {
                    tmpstr = "Exten ";
                }
                str = str + tmpstr;
                //if (frameinfo.RemoteFlag == 0)
                //{
                str = str + " Data:";
                if (frameinfo.DataLen > 8)
                {
                    frameinfo.DataLen = 8;
                }
                int mlen = frameinfo.DataLen - 1;
                for (int j = 0; j <= mlen; j++)
                {
                    tmpstr = string.Format("{0:X2}", frameinfo.data[j]);
                    str = str + tmpstr;
                    strData += tmpstr;
                }

                string strID = string.Format("{0:X3}", frameinfo.ID);

                LogHelper.warning("Data received ID= ->" + strID + "--------------" + "DATA = ->" + strData);

                //如果是TPM发过来的数据，进行处理
                if (strID == "7A9") //
                {
                    //处理收到的数据
                    LogHelper.warning("Data received(ID=7A9) ->" + strData);

                    ParseReceived(strData);
                }
                else if (strID == "18DAF100")
                {
                    //Vin处理收到的数据
                    LogHelper.warning("Data received(ID=18DAF100) ->" + strData);

                    ParseVINReceived(strData);
                }
                //else
                //{
                //    //处理收到的数据
                //    ParseReceived(strData);

                //    sysLog.Info("Data received(ID=61B) ->" + strData);
                //}
                //}

                //errorLog.LogError(str, null, null);

                mCount++;
                if (mCount >= 50)
                {
                    break;
                }
                Application.DoEvents();
            }
        }

        private void ParseReceived(string strData)
        {
            if (strData.Length < 16)
                return;

            timeOutCount = 0;

            if (strData.Contains(ENTER_EXTENDED_ACK))//02 50 03 00 00 00 00 00
            {

                OBDWatchingTimer.Enabled = false;

                message = "开始写入...";
                ProcessTimeOutTimer.Enabled = true;
                //1, Request seed
                SendCommand(REQUEST_SEED, "684");//02 27 01 00 00 00 00 00
                learningResultAction(message, Color.Navy, 30);

            }

            else if (strData.Contains(REQUEST_SEED_ACK))//06 67 01 XX XX XX XX 00
            {
                message = "请求种子";
                learningResultAction(message, Color.Navy, 50);

                string str = string.Empty;
                uint seed = Convert.ToUInt32(strData.Substring(6, 8), 16);
                uint ukey = seedTokey(seed);
                string strKey = ukey.ToString("X2");
                string normalizedKeys = string.Join(" ", Regex.Matches(strKey, @"..").Cast<Match>().ToList());

                string strKeyCmd = SEND_KEY + normalizedKeys;

                SendCommand(strKeyCmd + " 00", "684");//06 27 02 YY YY YY YY 00

            }

            else if (strData.Contains(SEND_KEY_ACK))//02 67 02 00 00 00 00 00
            {

                string str = "";
                if (status == EFunctionType.FaultCode)
                {
                    //工厂模式
                    str = SEND_EPB_DATA1 + " 00 00 00 00";
                    message = "工厂模式写入中....";
                    learningResultAction(message, Color.Navy, 80);
                    SendCommand(str, "684");
                }
                else if (status == EFunctionType.Charge)
                {
                    //客户模式
                    str = SEND_EPB_DATA1 + " 02 00 00 00";
                    message = "客户模式写入中....";
                    learningResultAction(message, Color.Navy, 80);
                    SendCommand(str, "684");
                }
                else
                {
                    CloseCAN();
                    return;
                }

            }

            else if (strData.Contains(SEND_EPB_DATA1_ACK) || strData.Contains(SEND_EPB_DATA2_ACK))//03 6E 01 02 00 00 00 00    05 71 01 60 04 01 00 00   写入结束确认
            {
                
                ProcessTimeOutTimer.Enabled = false;
                learningResultAction(message, Color.DarkGoldenrod, 100);
                CloseCAN();

            }

            else if (strData.Contains(SEND_EPB_DIAGNOSIS_ACK))//04 62 01 02 00 00 00 00   
            {
                message = "当前为工厂模式";
                learningResultAction(message, Color.Navy, 100);
                CloseCAN();
            }

            else if (strData.Contains(SEND_EPB_DIAGNOSIS1_ACK))//04 62 01 02 02 00 00 00 
            {
                message = "当前为客户模式";
                learningResultAction(message, Color.Navy, 100);
                CloseCAN();
            }

        }
        private void ParseVINReceived(string strData)
        {

            if (strData.Length < 16)
                return;

            if (strData.Trim().Substring(0, 2) == "22")
            {
                string str = strData.Replace("22", "");
                string data = "";
                for (int i = 0; i < str.Length / 2; i++)
                {
                    data += str.Substring(i * 2, 2) + " ";
                }
                data = data.Trim();
                ReadVin[2] = GetHexCodeStr(data);

                if (isRead)
                {
                    message = "读取成功:" + (ReadVin[0] + ReadVin[1] + ReadVin[2]).Replace("?", "");
                    learningResultAction(message, Color.Navy, 100);
                    LogHelper.warning($"读取VIN码为:{ReadVin[0] + ReadVin[1] + ReadVin[2]}");
                    CloseCAN();
                    return;
                }
                else if (vinCode == (ReadVin[0] + ReadVin[1] + ReadVin[2]).Replace("?", ""))
                {
                    message = "写入成功" + (ReadVin[0] + ReadVin[1] + ReadVin[2]).Replace("?", "");
                    learningResultAction(message, Color.Navy, 100);
                }
                else
                {
                    message = "写入失败";
                    learningResultAction(message, Color.Maroon, 100);
                }
                CloseCAN();
                LogHelper.warning($"写入VIN码为:{vinCode}。读取VIN码为:{message}");

            }
            if (strData.Contains(ENTER_EXTENDED_ACK))//02 50 03 00 00 00 00 00
            {

                OBDWatchingTimer.Enabled = false;

                message = "开始写入...";
                ProcessTimeOutTimer.Enabled = true;
                //1, Request seed
                SendCommand(REQUEST_SEED, "18DA00F1");//02 27 01 00 00 00 00 00
                learningResultAction(message, Color.Navy, 30);

            }

            else if (strData.Contains(REQUEST_SEED_ACK))//06 67 01 XX XX XX XX 00
            {
                message = "请求种子";
                learningResultAction(message, Color.Navy, 50);

                uint seed = Convert.ToUInt32(strData.Substring(6, 8), 16);
                uint ukey = seddvinkey(seed);
                string strKey = ukey.ToString("X2");
                string normalizedKeys = string.Join(" ", Regex.Matches(strKey, @"..").Cast<Match>().ToList());


                if (normalizedKeys.Length != 11)
                {
                    normalizedKeys = "00 " + normalizedKeys;
                }
                string strKeyCmd = SEND_KEY + normalizedKeys;
                SendCommand(strKeyCmd + " 00", "18DA00F1");//06 27 02 YY YY YY YY 00
            }
            else if (strData.Contains(SEND_KEY_ACK))//02 67 02 00 00 00 00 00
            {
                if (isRead)
                {
                    //读取VIN码模式
                    IsSendCode = true;
                    message = "读取VIN码模式....";
                    learningResultAction(message, Color.Navy, 60);
                    SendCommand("03 22 F1 90 00 00 00 00", "18DA00F1");//读取VIN请求

                }
                else
                {
                    //写入VIN码模式
                    string str = string.Empty;
                    string codes = GetStrCodeHex(vinCode.Substring(0, 1)) + " " +
                                   GetStrCodeHex(vinCode.Substring(1, 1)) + " " +
                                   GetStrCodeHex(vinCode.Substring(2, 1));
                    str = "10 14 2E F1 90 " + codes;
                    message = "写入VIN码模式....";
                    learningResultAction(message, Color.Navy, 60);
                    IsSendCode = true;
                    SendCommand(str, "18DA00F1");//14 2E F1 90 XX XX XX XX
                    Iswhite20 = true;
                    Thread.Sleep(30);
                }


            }
            else if (strData.Contains("300032"))//30 00 00 00 00 00 00 00
            {
                if (IsSendCode)
                {
                    string str1 = string.Empty;
                   // sysLog.Info("发送21数据");
                    string codes1 = GetStrCodeHex(vinCode.Substring(3, 1)) + " " +
                                  GetStrCodeHex(vinCode.Substring(4, 1)) + " " +
                                  GetStrCodeHex(vinCode.Substring(5, 1)) + " " +
                                  GetStrCodeHex(vinCode.Substring(6, 1)) + " " +
                                  GetStrCodeHex(vinCode.Substring(7, 1)) + " " +
                                  GetStrCodeHex(vinCode.Substring(8, 1)) + " " +
                                  GetStrCodeHex(vinCode.Substring(9, 1));
                    str1 = "21 " + codes1;
                    message = "写入VIN码中....";
                    learningResultAction(message, Color.Navy, 70);
                    SendCommand(str1, "18DA00F1");//20 XX XX XX XX XX XX XX

                    IsSendCode = false;
                    LogHelper.warning("发送22数据");
                    //写入VIN码
                    string str2 = string.Empty;
                    string codes2 =
                                   GetStrCodeHex(vinCode.Substring(10, 1)) + " " +
                                   GetStrCodeHex(vinCode.Substring(11, 1)) + " " +
                                   GetStrCodeHex(vinCode.Substring(12, 1)) + " " +
                                   GetStrCodeHex(vinCode.Substring(13, 1)) + " " +
                                   GetStrCodeHex(vinCode.Substring(14, 1)) + " " +
                                   GetStrCodeHex(vinCode.Substring(15, 1)) + " " +
                                   GetStrCodeHex(vinCode.Substring(16, 1));
                    str2 = "22 " + codes2;
                    learningResultAction(message, Color.Navy, 80);
                    SendCommand(str2, "18DA00F1");//21 XX XX XX XX XX XX XX


                }
            }
            else if (strData.Contains("036EF190"))//03 6E F1 90 00 00 00 00
            {
                //写入VIN码成功
                message = $"写入成功:{vinCode}";
                learningResultAction(message, Color.Navy, 100);
                CloseCAN();
                //SendCommand("03 22 F1 90 00 00 00 00", "18DA00F1");//读取VIN请求
                //    message = "读取VIN请求";
                //    learningResultAction(message, Color.Navy, 30);


            }
            else if (strData.Contains("101462"))//读取VIN码
            {
                string str = strData.Replace("101462F1", "");
                string data = "";
                for (int i = 0; i < str.Length / 2; i++)
                {
                    data += str.Substring(i * 2, 2) + " ";
                }
                data = data.Trim();
                ReadVin[0] = GetHexCodeStr(data);


                message = "正在读取中...";
                learningResultAction(message, Color.Navy, 50);
                SendCommand("30 00 00 00 00 00 00 00", "18DA00F1");//读取到
            }
            else if (strData.Substring(0, 2) == "21")
            {
               // sysLog.Info("21接受到数据");
                string str = strData.Replace("21", "");
                string data = "";
                for (int i = 0; i < str.Length / 2; i++)
                {
                    data += str.Substring(i * 2, 2) + " ";
                }
                data = data.Trim();
                ReadVin[1] = GetHexCodeStr(data);

            }





        }
        uint MASK = 0x62A3553D;
        public uint seedTokey(uint seed)
        {
            uint key = 0;
            if (seed != 0)
            {
                for (int i = 0; i < 35; i++)
                {
                    if ((seed & 0x80000000) != 0)
                    {
                        seed = seed << 1;
                        seed = seed ^ MASK;
                    }
                    else
                    {
                        seed = seed << 1;
                    }
                }
                key = seed;
            }

            return key;
        }

        public uint seddvinkey(uint seed)
        {
            uint key = 0;

            key = (((seed >> 3) ^ seed) << 2) ^ seed;
            return key;
        }
        public string GetStrCodeHex(string str)
        {
            byte[] data = new ASCIIEncoding().GetBytes(str);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.AppendFormat("{0:x2} ", data[i]);
            }
            return sb.ToString().Trim().ToUpper();
        }
        public string GetHexCodeStr(string str)
        {
            string[] HexStr = str.Trim().Split(' ');
            var strtop = new byte[HexStr.Length];
            for (int i = 0; i < HexStr.Length; i++)
            {
                strtop[i] = (byte)(Convert.ToInt32(HexStr[i], 16));
            }
            return new ASCIIEncoding().GetString(strtop);

        }
        private void ProcessTimeOut_Tick(object source, ElapsedEventArgs e)
        {
            try
            {
                timeOutCount++;
                if (timeOutCount > eCUTimeout) //20s not feedback from ECU, then trigger timeout event
                {
                    learningResultAction("错误，和ECU通讯超时。", Color.Maroon, 2);
                    CloseCAN();

                    LogHelper.Error("Communication to ECU time out.");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex.ToString());
            }
        }

    }
}

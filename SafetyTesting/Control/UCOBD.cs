
using SafetyTesting.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ZLGCAN;

namespace SafetyTesting.Control
{
    public enum EFunctionType
    {
        NULL,
        FaultCode,
        /// <summary>
        /// 绝缘打开
        /// </summary>
        Insulation__OPEN,
        /// <summary>
        /// 绝缘关闭
        /// </summary>
        Insulation_CLOSE,
        /// <summary>
        /// 整车端继电器打开
        /// </summary>
        VehicleRelay_OPEN,
        /// <summary>
        /// 整车端继电器关闭
        /// </summary>
        VehicleRelay_CLOSE,
    }
    public enum CarModuleType
    {
        D180,
        E300N,
        GSE,
        RT6
    }
    /// <summary>
    /// 长安凯程工厂
    /// </summary>
    public partial class UCOBD : UserControl
    {
        private Action<string, int> learningResultAction;

        byte m_connect = 0;
        EFunctionType status = EFunctionType.FaultCode;//0 故障，1：充电
        public string message;
        CarModuleType type1 = CarModuleType.D180;
        private int eCUTimeout = 3;
        string RevertID = "7E8";
        string SendID = "7E0";

        //进入扩展模式
        const string ENTER_EXTENDED = "02 10 03 00 00 00 00 00";
        const string ENTER_EXTENDED_ACK = "50 03"; // 50 03

        //请求种子
        const string REQUEST_SEED = "02 27 01 00 00 00 00 00";
        const string REQUEST_SEED_ACK = "06 67 01"; //06 67 01 00 00 XX XX 00

        //发送Key
        const string SEND_KEY = "06 27 02 "; //06 27 02 YY YY YY YY 00
        const string SEND_KEY_ACK = "02 67 02"; //02 67 02 00 00 00 00 00

        //发送模式
        const string SEND_BAT_DATA_OPEN = "04 31 01 51 00 00 00 00"; //绝缘监测关闭请求
        const string SEND_BAT_DATA_CLOSE = " 04 31 02 51 00 00 00 00"; //绝缘监测打开请求
        const string SEND_BAT_DATA_OPEN_ACK = "05 71 01"; //


        
        const string SEND_IRM_DATA_OPEN = "04 31 01 51 02 55 55 55"; //整车端继电器闭合
        const string SEND_IRM_DATA_CLOSE = "04 31 02 51 02 55 55 55"; //整车端继电器断开



        //发送清除故障代码命令
        const string SEND_DTCClear = "04 14 FF FF FF 00 00 00";//清除故障码 回复03 7F 14 78 00 00 00 00 接着    01 54 00 00 00 00 00 00
        const string SEND_DTCClear_OKACK = "54";//
        const string SEND_DTCClear_NGACK = "7F14";//

        const string SEND_FaultCode = "03 19 02 FF 00 00 00 00";//回复 07 59 02 09 1B 41 05 09
        const string SEND_FaultCode_OKACK = "59 02";//
        const string SEND_FaultCode_NGACK = "7F 19";//

        string SendData = "02 10 03 00 00 00 00 00";



        private int timeOutCount = 0;
        bool Iswhite20 = false;
        private System.Timers.Timer OBDWatchingTimer;

        private System.Timers.Timer ProcessTimeOutTimer;


        uint device_type_index_;//设备类型
        uint device_index_;//设备索引
        IntPtr device_handle_;//设备
        IntPtr channel_handle_;//初始化
        bool m_bOpen;//设备是否打开
        bool m_bCloud;//CAN 是否打开
        int channel_index_;//通道
        bool m_bStart;//启动CAN
        const uint CAN_EFF_FLAG = 0x80000000U; /* EFF/SFF is set in the MSB */
        const uint CAN_RTR_FLAG = 0x40000000U; /* remote transmission request */
        const uint CAN_ERR_FLAG = 0x20000000U; /* error message frame */
        const uint CAN_ID_FLAG = 0x1FFFFFFFU; /* id */

        recvdatathread recv_data_thread_;
        DeviceInfo[] kDeviceType =
       {
            new DeviceInfo(Define.ZCAN_USBCAN1, 1),
            new DeviceInfo(Define.ZCAN_USBCAN2, 2),
            new DeviceInfo(Define.ZCAN_USBCAN_E_U, 1),
            new DeviceInfo(Define.ZCAN_USBCAN_2E_U, 2),
            new DeviceInfo(Define.ZCAN_PCIECANFD_100U, 1),
            new DeviceInfo(Define.ZCAN_PCIECANFD_200U, 2),
            new DeviceInfo(Define.ZCAN_PCIECANFD_200U_EX,2),
            new DeviceInfo(Define.ZCAN_PCIECANFD_400U, 4),
            new DeviceInfo(Define.ZCAN_USBCANFD_200U, 2),
            new DeviceInfo(Define.ZCAN_USBCANFD_100U, 1),
            new DeviceInfo(Define.ZCAN_USBCANFD_MINI, 1),
            new DeviceInfo(Define.ZCAN_CANETTCP, 1),
            new DeviceInfo(Define.ZCAN_CANETUDP, 1),
            new DeviceInfo(Define.ZCAN_CANFDNET_200U_TCP, 2),
            new DeviceInfo(Define.ZCAN_CANFDNET_200U_UDP, 2),
            new DeviceInfo(Define.ZCAN_CANFDNET_400U_TCP, 4),
            new DeviceInfo(Define.ZCAN_CANFDNET_400U_UDP, 4),
            new DeviceInfo(Define.ZCAN_CANFDNET_800U_TCP, 8),
            new DeviceInfo(Define.ZCAN_CANFDNET_800U_UDP, 8),
            new DeviceInfo(Define.ZCAN_CLOUD, 1)
        };
        uint[] kUSBCANFDAbit =
       {
            1000000, // 1Mbps
            800000, // 800kbps
            500000, // 500kbps
            250000, // 250kbps
            125000, // 125kbps
            100000, // 100kbps
            50000, // 50kbps
            800000, // 800kbps
        };
        uint[] kUSBCANFDDbit =
        {
            5000000, // 5Mbps
            4000000, // 4Mbps
            2000000, // 2Mbps
            1000000, // 1Mbps
            800000, // 800kbps
            500000, // 500kbps
            250000, // 250kbps
            125000, // 125kbps
            100000, // 100kbps
        };
        uint[] kBaudrate =
        {
            1000000,//1000kbps
            800000,//800kbps
            500000,//500kbps
            250000,//250kbps
            125000,//125kbps
            100000,//100kbps
            50000,//50kbps
            20000,//20kbps
            10000,//10kbps
            5000 //5kbps
        };


        bool IsAuto = true;//是否自动
        public UCOBD()
        {
            InitializeComponent();

            ProcessTimeOutTimer = new System.Timers.Timer(1000);
            ProcessTimeOutTimer.Elapsed += new ElapsedEventHandler(ProcessTimeOut_Tick);
            ProcessTimeOutTimer.Enabled = false;
            OBDWatchingTimer = new System.Timers.Timer(3000);
            OBDWatchingTimer.Elapsed += new ElapsedEventHandler(OBDWatchingt_Tick);
            OBDWatchingTimer.Enabled = false;

            // eCUTimeout = Convert.ToInt32(ConfigurationManager.AppSettings["ECU_Time_Out"]);

        }



        //Open CAN
        /// <summary>
        /// Open CAN
        /// </summary>
        /// <param name="resultAction"></param>
        /// <param name="deviceindex">设备编号</param>
        public void InitializeCAN(Action<string, int> resultAction,uint deviceindex, CarModuleType carModuleType)
        {
            type1 = carModuleType;

            
            learningResultAction = resultAction;
            device_type_index_ = 10;
            channel_index_ = 0;
            device_index_ = deviceindex;

            device_handle_ = Method.ZCAN_OpenDevice(kDeviceType[device_type_index_].device_type, device_index_, 0);
            if (0 == (int)device_handle_)
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                roundButton_CANConn.Refresh();
                LogHelper.Info("打开设备错误！");
                message = "打开设备错误";

                learningResultAction(message, 10);
                return;
            }
            IsEndss = false;


            m_bOpen = true; //设备打开


            uint type = kDeviceType[device_type_index_].device_type;
            bool netDevice = type == Define.ZCAN_CANETTCP || type == Define.ZCAN_CANETUDP ||
                type == Define.ZCAN_CANFDNET_400U_TCP || type == Define.ZCAN_CANFDNET_400U_UDP ||
                type == Define.ZCAN_CANFDNET_200U_TCP || type == Define.ZCAN_CANFDNET_200U_UDP || type == Define.ZCAN_CANFDNET_800U_TCP ||
                type == Define.ZCAN_CANFDNET_800U_UDP;
            bool canfdnetDevice = type == Define.ZCAN_CANFDNET_400U_TCP || type == Define.ZCAN_CANFDNET_400U_UDP ||
                type == Define.ZCAN_CANFDNET_200U_TCP || type == Define.ZCAN_CANFDNET_200U_UDP || type == Define.ZCAN_CANFDNET_800U_TCP ||
                type == Define.ZCAN_CANFDNET_800U_UDP;
            bool pcieCanfd = type == Define.ZCAN_PCIECANFD_100U ||
                type == Define.ZCAN_PCIECANFD_200U ||
                type == Define.ZCAN_PCIECANFD_400U ||
                type == Define.ZCAN_PCIECANFD_200U_EX;
            bool usbCanfd = type == Define.ZCAN_USBCANFD_100U ||
                type == Define.ZCAN_USBCANFD_200U ||
                type == Define.ZCAN_USBCANFD_MINI;
            bool canfdDevice = usbCanfd || pcieCanfd;

            if (usbCanfd)
            {
                if (!setCANFDStandard(0)) //设置CANFD标准
                {
                    roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                    roundButton_CANConn.Refresh();
                    LogHelper.Info("设置CANFD标准失败！");
                    message = "设置CANFD标准失败";

                    learningResultAction(message, 10);
                    return;
                }
            }
            bool result = true;
            if (type1==CarModuleType.RT6) 
            {
                result = setFdBaudrate(kUSBCANFDAbit[2], kUSBCANFDDbit[2]); //设置波特率
            }
            else
            {
                result = setFdBaudrate(kUSBCANFDAbit[2], kUSBCANFDDbit[5]); //设置波特率
            }    
           


            if (!result) //
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                roundButton_CANConn.Refresh();
                LogHelper.Info("设置波特率失败！");
                message = "设置波特率失败";

                learningResultAction(message, 10);
                return;
            }

            ZCAN_CHANNEL_INIT_CONFIG config_ = new ZCAN_CHANNEL_INIT_CONFIG();
            if (!m_bCloud && !netDevice)
            {
                config_.canfd.mode = (byte)0;//正常模式
                if (usbCanfd)
                {
                    config_.can_type = Define.TYPE_CANFD;
                }
                else if (pcieCanfd)
                {
                    config_.can_type = Define.TYPE_CANFD;
                    config_.can.filter = 0;
                    config_.can.acc_code = 0;
                    config_.can.acc_mask = 0xFFFFFFFF;
                    config_.can.mode = 0;
                }
                else
                {
                    config_.can_type = Define.TYPE_CAN;
                    config_.can.filter = 0;
                    config_.can.acc_code = 0;
                    config_.can.acc_mask = 0xFFFFFFFF;
                    config_.can.mode = 0;
                }
            }
            IntPtr pConfig = Marshal.AllocHGlobal(Marshal.SizeOf(config_));
            Marshal.StructureToPtr(config_, pConfig, true);

            //int size = sizeof(ZCAN_CHANNEL_INIT_CONFIG);
            //IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(size);
            //System.Runtime.InteropServices.Marshal.StructureToPtr(config_, ptr, true);
            channel_handle_ = Method.ZCAN_InitCAN(device_handle_, (uint)channel_index_, pConfig);
            Marshal.FreeHGlobal(pConfig);

            //Marshal.FreeHGlobal(ptr);

            if (0 == (int)channel_handle_)
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                roundButton_CANConn.Refresh();
                LogHelper.Info("初始化CAN模块失败！");
                message = "初始化CAN模块失败";

                learningResultAction(message, 10);

                return;
            }

            if (!setResistanceEnable(true))//使能
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                roundButton_CANConn.Refresh();
                LogHelper.Info("使能终端电阻失败！");
                message = "使能终端电阻失败";

                learningResultAction(message, 10);

                return;
            }

            if (type1==CarModuleType.RT6)
            {
                SendID = "720";
                RevertID = "799";
            }
            else 
            {
                SendID = "7E0";
                RevertID = "7E8";
            }


            if (!setFilter(SendID,RevertID))
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                roundButton_CANConn.Refresh();
                LogHelper.Info("设置滤波失败！");
                message = "设置滤波失败";

                learningResultAction(message, 10);

                return;
            }



            if (Method.ZCAN_StartCAN(channel_handle_) != Define.STATUS_OK)
            {
                roundButton_CANConn.ButtonCenterColorStart = Color.Red;
                roundButton_CANConn.Refresh();
                LogHelper.Info("启动CAN失败！");
                message = "启动CAN失败";

                learningResultAction(message, 10);

                return;
            }

            m_bStart = true;
            if (null == recv_data_thread_)
            {
                recv_data_thread_ = new recvdatathread();
                recv_data_thread_.setChannelHandle(channel_handle_);
                recv_data_thread_.setStart(m_bStart);
                recv_data_thread_.RecvCANData += this.AddData;
                recv_data_thread_.RecvFDData += this.AddData;
            }
            else
            {
                recv_data_thread_.setChannelHandle(channel_handle_);
            }

            roundButton_CANConn.ButtonCenterColorStart = Color.Lime;
            roundButton_CANConn.Refresh();
            LogHelper.Info("启动CAN模块成功！");
            message = "启动CAN模块成功";

            learningResultAction(message, 10);


           
        }


        private void OBDWatchingt_Tick(object source, ElapsedEventArgs e)
        {
            try
            {
                if (type1==CarModuleType.RT6)
                {
                    SendCommand("02 3E 00 00 00 00 00 00", "720");
                    Thread.Sleep(20);
                    SendCommand("02 3E 00 00 00 00 00 00", "791");
                }
                else
                {
                    SendCommand("02 3E 00 00 00 00 00 00", "7DF");
                }
                


                //  LogHelper.CANInfo("发送数据"+ ENTER_EXTENDED);
            }
            catch (Exception ex)
            {
                LogHelper.CANInfo(ex.ToString());
            }
        }

        /// <summary>
        /// Start 
        /// </summary>
        public void StartCAN(EFunctionType type,CarModuleType cartype= CarModuleType.D180,bool auto=true)
        {
            IsAuto = auto;
            IsEnd = false;
            status = type;
            type1 = cartype;
            SendData = ENTER_EXTENDED;
            Isextend = false;
            IsError = true;
            OBDWatchingTimer.Enabled = true;
            if (cartype==CarModuleType.RT6)
            {
                SendCommand(SendData, "720");
                Isvcu = false;
            }
            else
            {
                SendCommand(SendData,SendID);
            }
            

            learningResultAction("请求进入扩展模式", 0);
            
        }

        public void Sendcomm( EFunctionType type,CarModuleType carModuleType)
        {
            status = type;

            type1 = carModuleType;


            if (type1==CarModuleType.RT6)
            {
                if (status ==EFunctionType.VehicleRelay_CLOSE)
                {
                    SendCommand("05 2F D0 10 03 00 AA AA", "791");
                }
            }
            else
            {
                if (status == EFunctionType.VehicleRelay_CLOSE)
                {
                    SendCommand("04 31 02 51 02 55 55 55", SendID);
                }
            }

            OBDWatchingTimer.Enabled = true;
        }
        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="strData">数据</param>
        /// <param name="sendframe">0：CAN  1：CANFD</param>
        public void SendCommand(string strData, string SendId)
        {
            

            uint id = (uint)System.Convert.ToInt32(SendId, 16);
            string data = strData;
            int frame_type_index = 0;
            int sendframe = 0;
            if (type1==CarModuleType.RT6)
            {
                sendframe = 1;
            }

            int protocol_index = sendframe;//0:CAN  1:CANFD
            int send_type_index =0;//0 正常发送  1：
            int canfd_exp_index = 0;
            uint result; //发送的帧数

            if (0 == protocol_index) //can
            {

                ZCAN_Transmit_Data can_data = new ZCAN_Transmit_Data();
                can_data.frame.can_id = MakeCanId(id, frame_type_index, 0, 0);
                can_data.frame.data = new byte[8];
                can_data.frame.can_dlc = (byte)SplitData(data, ref can_data.frame.data, 8);
                can_data.transmit_type = (uint)send_type_index;
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(can_data));
                Marshal.StructureToPtr(can_data, ptr, true);
                result = Method.ZCAN_Transmit(channel_handle_, ptr, 1);
                Marshal.FreeHGlobal(ptr);
            }
            else //canfd
            {

                ZCAN_TransmitFD_Data canfd_data = new ZCAN_TransmitFD_Data();
                canfd_data.frame.can_id = MakeCanId(id, frame_type_index, 0, 0);
                canfd_data.frame.data = new byte[64];
                canfd_data.frame.len = (byte)SplitData(data, ref canfd_data.frame.data, 8);
                canfd_data.transmit_type = (uint)send_type_index;
                canfd_data.frame.flags = (byte)((canfd_exp_index != 0) ? 0x01 : 0);
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(canfd_data));
                Marshal.StructureToPtr(canfd_data, ptr, true);
                result = Method.ZCAN_TransmitFD(channel_handle_, ptr, 1);
                Marshal.FreeHGlobal(ptr);
            }

            if (SendId != "7DF")
            {
                if (strData.Contains("02 3E 00"))
                {

                }
                else
                {
                    
                    LogHelper.CANInfo($"Data CAN  Send(ID = {SendId})->" + strData);
                    ProcessTimeOutTimer.Enabled = true;
                }

            }

            if (result != 1)
            {
                LogHelper.CANInfo("发送数据失败： "+ strData);


            }
            else
            {
                //Data CAN  Send(ID = 7E8)->02 7E 00 55 55 55 55 55
               
                
            }

        }

        //Close CAN device

       public  bool IsEndss = false;
        public void CloseCAN()
        {
            status = EFunctionType.NULL;
            if (IsEndss)
            {
                ProcessTimeOutTimer.Stop();
                OBDWatchingTimer.Enabled = false;
            }
            
           
            ProcessTimeOutTimer.Enabled = false;

            Method.ZCAN_CloseDevice(device_handle_);
            LogHelper.CANInfo("关闭CAN");
            //if (m_connect == 1)
            //{
            //    LogHelper.CANInfo("关闭CAN");

            //}
        }

        private void AddData(ZCAN_Receive_Data[] data, uint len)
        {
            string text = "";
            for (uint i = 0; i < len; ++i)
            {
                ZCAN_Receive_Data can = data[i];
                uint id = data[i].frame.can_id;
                string eff = IsEFF(id) ? "扩展帧" : "标准帧";
                string rtr = IsRTR(id) ? "远程帧" : "数据帧";
               // text = String.Format(" {1:G} {2:G} 长度:{3:D1} 数据:", eff, rtr, can.frame.can_dlc);

                for (uint j = 0; j < can.frame.can_dlc; ++j)
                {
                    text = String.Format("{0:G}{1:X2} ", text, can.frame.data[j]);
                }
                if (text.Contains("02 7E 00"))
                {
                    return;
                }
                message = $"Data CAN  received(ID={ GetId(id).ToString("X2")}) ->" + text;
                LogHelper.CANInfo(message);
                ProcessTimeOutTimer.Enabled = false;
                ParseReceived(text);


               // learningResultAction(message, 10);
                // LogHelper.CANInfo("Data:"+ can.frame.data);
            }

           
        }

        private void AddData(ZCAN_ReceiveFD_Data[] data, uint len)
        {
            string text = "";
            for (uint i = 0; i < len; ++i)
            {
                ZCAN_ReceiveFD_Data canfd = data[i];
                uint id = data[i].frame.can_id;
                string eff = IsEFF(id) ? "扩展帧" : "标准帧";
                string rtr = IsRTR(id) ? "远程帧" : "数据帧";
                //text = String.Format(canfd.frame.len);
                for (uint j = 0; j < canfd.frame.len; ++j)
                {
                    text = String.Format("{0:G}{1:X2} ", text, canfd.frame.data[j]);
                }
                if (text.Contains("02 7E 00"))
                {
                    return;
                }

                message = $"Data CANFD  received(ID={ GetId(id).ToString("X2")}) ->" + text;

                ProcessTimeOutTimer.Enabled = false;
                LogHelper.CANInfo(message);

                ParseReceived(text);



                //learningResultAction(message, 10);


            }

        }


        bool IsSendkey = false;
        bool Isextend = false;
        bool IsOKOK = false;
        bool IsABC = false;
        bool IsError=true;
        bool IsEnd = false;//是否结束
        bool Isvcu=false;//是否是VCU
        bool IsBHOK=false;//闭合应答
        
        private void ParseReceived(string strData)
        {
            //
            //if (strData.Length < 16)
            //    return;


            //if (IsEnd)
            //{
            //    return;
            //}
            // learningResultAction("接收：" + strData, 10);
           // strData = strData.Replace(" ", "");



            if (strData.Contains(ENTER_EXTENDED_ACK))//06 50 03 00 00 00 00 00
            {
               
                // OBDWatchingTimer.Enabled = false;

                message = "进入扩展会话...";

                //1, Request seed


                if (type1==CarModuleType.RT6)
                {
                    if (Isvcu)
                    {
                        SendID = "791";
                    }
                    else
                    {
                        SendID = "720";
                    }
                }
                

                SendCommand(REQUEST_SEED, SendID);//02 27 01 00 00 00 00 00
                IsError = true;
                IsSendkey = false;

                Isextend = false;

                learningResultAction("请求种子",  30);

            }
            else if (strData.Contains(REQUEST_SEED_ACK))//06 67 01 XX XX XX XX 00
            {
               
                IsSendkey = false;
                message = "请求种子";

                //5B 1E CE 35
                string str = string.Empty;
                //066701XXXXXXXX00
                strData = strData.Replace(" ", "");

                uint seed = Convert.ToUInt32(strData.Substring(6, 8), 16);
                uint ukey = canculate_app_security_access_xxx(seed);
                string strKey = ukey.ToString("X8");//12202320
               
                string normalizedKeys = string.Join(" ", Regex.Matches(strKey, @"..").Cast<Match>().ToList());
                string strKeyCmd = SEND_KEY + normalizedKeys;
                learningResultAction("发送密钥", 50);

                if (type1==CarModuleType.RT6)
                {
                    if (Isvcu)
                    {
                        SendID = "791";
                    }
                    else
                    {
                        SendID = "720";
                    }
                }
               
                SendCommand(strKeyCmd + " 00", SendID);//06 27 02 YY YY YY YY 00
                IsError = true;
                IsABC = true;


            }
            else if (strData.Contains(SEND_KEY_ACK))//02 67 02 00 00 00 00 00
            {
                string str = "";
                if (status == EFunctionType.FaultCode)
                {
                    //读取故障码
                    str = SEND_FaultCode;
                    message = "读取故障码....";
                    learningResultAction(message, 80);
                    SendCommand(str, "7A1");
                    IsError = true;
                }
                
                else if (status == EFunctionType.Insulation_CLOSE)
                {
                    str = SEND_BAT_DATA_OPEN;
                    if (type1==CarModuleType.RT6)
                    {
                        str = "05 31 01 A2 01 03 00 00";
                        SendCommand(str, "720");
                    }
                    else
                    {

                        SendCommand(str, SendID);
                    }
                    
                    message = "发送关绝缘";
                    learningResultAction(message,  80);

                    
                    IsError = true;
                }
                else if (status==EFunctionType.Insulation__OPEN)
                {

                    str = SEND_BAT_DATA_CLOSE;

                    if (type1 == CarModuleType.RT6)
                    {
                        str = "04 31 A2 01 01 55 55 55";
                        SendCommand(str, "720");
                    }
                    else
                    {
                        SendCommand(str, SendID);
                    }

                    message = "发送开绝缘";
                    learningResultAction(message , 80);
                    message = str;
                    learningResultAction("发送开绝缘", 80);

                    
                    IsError = true;
                }
                else if (status == EFunctionType.VehicleRelay_CLOSE)
                {
                    //绝缘监测继电器关闭
                    str = SEND_IRM_DATA_CLOSE;

                    if (type1==CarModuleType.RT6)
                    {
                        str = "04 2F 10 03 00 00 00 00";
                        SendCommand(str, "799");
                    }
                    else
                    {
                        SendCommand(str, SendID);

                    }
                    message = "发送关闭断开快充继电器";
                    learningResultAction("发送关闭断开快充继电器", 80);
                    IsError = true;
                }
                else if (status == EFunctionType.VehicleRelay_OPEN)
                {
                    //绝缘监测继电器关闭
                    str = SEND_IRM_DATA_OPEN;
                    SendCount = 1;
                    if (type1 == CarModuleType.RT6)
                    {
                        str = "05 2F D0 10 03 01 AA AA";
                        SendCommand(str, "791");
                    }
                    else
                    {
                        SendCommand(str, SendID);

                    }

                    message = "发送闭合快充继电器";
                    learningResultAction(message, 80);
                    IsError = true;
                }

                IsOKOK = true;

            }

            else if (strData.Contains(SEND_FaultCode_OKACK))//  5902
            {
                message = "有故障码";
                learningResultAction(message, 100);
                CloseCAN();
            }
            else if (strData.Contains(SEND_FaultCode_NGACK))//7F19
            {
                message = "没有故障码";
                learningResultAction(message, 100);
                CloseCAN();
            }
            else if (strData.Contains("71 01 51 02 00"))
            {
                //快充接触器闭合失败

                Thread.Sleep(1000);
                SendCount++;
                if (SendCount<5)
                {
                    string str = SEND_IRM_DATA_OPEN;
                    SendCommand(str, SendID);
                }
               

            }

            else if (strData.Contains("71 01 A2 01 00") || strData.Contains("71 01 51 00 00"))
            {
                //RT6 关闭绝缘成功  接着闭合快充继电器
                Isvcu = true;
                if (status == EFunctionType.Insulation__OPEN)
                {
                    //继续发送开绝缘

                    message = "绝缘打开成功";
                    learningResultAction(message, 80);

                    string str = "02 10 01 00 00 00 00 00";
                    SendCommand(str, "720");
                    Isextend = true;
                }
                else
                {
                    message = "关闭绝缘成功";
                    learningResultAction(message, 80);
                    status = EFunctionType.VehicleRelay_OPEN;
                    if (type1==CarModuleType.RT6)
                    {
                        SendCommand(SendData, "791");
                    }
                    else
                    {
                        SendCommand("04 31 01 51 02 55 55 55", SendID);
                        //5s之后再次发送相同服务
                        //计数 5s 后有没有收到闭合成功或者闭合失败指令
                        IsBHOK = false;
                        Task.Run(() =>
                        {
                            Thread.Sleep(5000);
                            if (IsBHOK)
                            {
                                SendCommand("04 31 01 51 02 55 55 55", SendID);
                            }
                        });
                    }

                }
            }//关闭绝缘成功  接着闭合快充继电器
            else if (strData.Contains("6F D0 10 03 01") || strData.Contains("71 01 51 02 01"))//01：整车端继电器闭合成功；00：整车端继电器闭合失败
            {
                if (type1 != CarModuleType.RT6) 
                {
                    //RT6 快充接触器闭合成功
                    Delay(10000);//等待10s检测整车绝缘
                }
                IsBHOK = true;
                message = "完成闭合快充继电器";
                learningResultAction(message, 80);
            }//快充接触器闭合成功
            else if (strData.Contains("71 01 51 03 00"))
            {
                IsBHOK = true;
                message = "闭合快充继电器失败";
                learningResultAction(message, 80);
            }//快充接触器闭合失败
            else if (strData.Contains("6F D0 10 03 00") || strData.Contains("71 02 51 02 00"))
            {
                message = "完成断开快充继电器";
                learningResultAction(message, 80);

                if (type1 == CarModuleType.RT6)
                {
                    string str = "02 10 01 AA AA AA AA AA";
                    SendCommand(str, "791");
                }
                else 
                {
                    string str = "02 10 01 00 00 00 00 00";
                    SendCommand(str, "7E0");
                }
                
                
                status = EFunctionType.NULL;
                IsSendkey = true;
                IsEndss = true;
                message = "切换默认会话";
                learningResultAction(message, 80);
                //
            }//完成断开快充继电器 接着发送返回默认会话
            else if (strData.Contains("02 50 01"))
            {
                //结束
                message = "返回默认模式成功";
                learningResultAction(message, 80);
               // CloseCAN();
            }//接收默认会话切换成功
            else if (strData.Contains("06 50 01 00 32 01 F4"))
            {
                //接收默认会话切换成功

                //结束
                message = "返回默认模式成功";
                learningResultAction(message, 80);
                IsEndss= true;
                CloseCAN();
            }
            else if (strData.Contains("06 50 01"))
            {
                if (status==EFunctionType.NULL)
                {
                    message = "返回默认模式成功";
                    learningResultAction(message, 80);
                    timeOutCount = 0;
                    CloseCAN();
                }
                else
                {
                    Isvcu = false;
                    status = EFunctionType.Insulation__OPEN;
                    string str = "05 31 01 A2 01 00 00 00";
                    SendCommand(str, "720");

                    message = "发送绝缘打开";
                    learningResultAction(message, 80);
                }
                
            }





        }


        int SendCount = 1;
        uint MASK = 0x113289D7;

        int BATTimeCount = 0;
        /// <summary>
        /// 长安安规安全算法
        /// </summary>
        /// <param name="wSeed"></param>
        /// <param name="MASK"></param>
        /// <returns></returns>
        public uint Lx_seedToKey(uint wSeed)
        {
            MASK = 0x70F27304;
            if (wSeed == 0)
            {
                return wSeed;
            }

            uint tmpseed = wSeed;

            //Step2
            uint key_1 = tmpseed ^ MASK;

            //Step3
            uint seed_2 = tmpseed;
            seed_2 = (seed_2 & 0x55555555) << 1 | (seed_2 & 0xAAAAAAAA) >> 1;
            seed_2 = (seed_2 & 0x33333333) << 2 | (seed_2 & 0xCCCCCCCC) >> 2;
            seed_2 = (seed_2 & 0x0F0F0F0F) << 4 | (seed_2 & 0xF0F0F0F0) >> 4;
            seed_2 = (seed_2 & 0x00FF00FF) << 8 | (seed_2 & 0xFF00FF00) >> 8;
            seed_2 = (seed_2 & 0x0000FFFF) << 16 | (seed_2 & 0xFFFF0000) >> 16;

            uint key_2 = seed_2 ^ MASK;

            uint key = key_1 + key_2;

            return key;
        }


        public uint canculate_app_security_access_xxx(uint seed)
        {

            //VCU  0x113289D7
            //BMS  0x1101D43A

            if (type1==CarModuleType.RT6)
            {
                if (status == EFunctionType.Insulation_CLOSE)
                {
                    MASK = 0x1101D43A;
                }
                else if (status == EFunctionType.Insulation__OPEN)
                {
                    MASK = 0x1101D43A;
                }
                else
                {
                    MASK = 0x113289D7;
                }
            }
            else
            {
                MASK = 0x113289D7;
            }
            

            uint tmpseed = seed;
            uint key_1 = tmpseed ^ MASK;
            uint seed_2 = tmpseed;
            seed_2 = (seed_2 ^ 0x66666666) << 1 ^ (seed_2 ^ 0xBBBBBBBB) >> 1;
            seed_2 = (seed_2 ^ 0x44444444) << 2 ^ (seed_2 ^ 0xDDDDDDDD) >> 2;
            seed_2 = (seed_2 ^ 0x0F0F0F0F) << 4 ^ (seed_2 ^ 0xF0F0F0F0) >> 4;
            seed_2 = (seed_2 ^ 0x00FF00FF) << 8 ^ (seed_2 ^ 0xFF00FF00) >> 8;
            seed_2 = (seed_2 ^ 0x0000FFFF) << 16 ^ (seed_2 ^ 0xFFFF0000) >> 16;
            uint key_2 = seed_2 & MASK;
            uint key = key_1 + key_2;
            return key;
        }

        //拆分text到发送data数组
        private int SplitData(string data, ref byte[] transData, int maxLen)
        {
            string[] dataArray = data.Split(' ');
            for (int i = 0; (i < maxLen) && (i < dataArray.Length); i++)
            {
                transData[i] = Convert.ToByte(dataArray[i].Substring(0, 2), 16);
            }

            return dataArray.Length;
        }

        public uint MakeCanId(uint id, int eff, int rtr, int err)//1:extend frame 0:standard frame
        {
            uint ueff = (uint)(!!(Convert.ToBoolean(eff)) ? 1 : 0);
            uint urtr = (uint)(!!(Convert.ToBoolean(rtr)) ? 1 : 0);
            uint uerr = (uint)(!!(Convert.ToBoolean(err)) ? 1 : 0);
            return id | ueff << 31 | urtr << 30 | uerr << 29;
        }
        public bool IsEFF(uint id)//1:extend frame 0:standard frame
        {
            return !!Convert.ToBoolean((id & CAN_EFF_FLAG));
        }
        public uint GetId(uint id)
        {
            return id & CAN_ID_FLAG;
        }
        public bool IsRTR(uint id)//1:remote frame 0:data frame
        {
            return !!Convert.ToBoolean((id & CAN_RTR_FLAG));
        }
        //设置CANFD标准
        private bool setCANFDStandard(int canfd_standard)
        {
            string path = channel_index_ + "/canfd_standard";
            string value = canfd_standard.ToString();
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            return 1 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
        }
        //设置波特率
        private bool setFdBaudrate(UInt32 abaud, UInt32 dbaud)
        {
            string path = channel_index_ + "/canfd_abit_baud_rate";
            string value = abaud.ToString();
            if (1 != Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }
            path = channel_index_ + "/canfd_dbit_baud_rate";
            value = dbaud.ToString();
            if (1 != Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }
            return true;
        }
        //设置终端电阻使能
        private bool setResistanceEnable(bool resistance)
        {
            string path = channel_index_ + "/initenal_resistance";
            string value = resistance  ? "1" : "0";
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            return 1 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
        }
        //设置滤波
        private bool setFilter(string startid,string endid)
        {
            string path = channel_index_ + "/filter_clear";//清除滤波
            string value = "0";
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            if (0 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }

            path = channel_index_ + "/filter_mode";
            value = 0.ToString();
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            if (value == "2")
            {
                return true;
            }
            if (0 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }

            path = channel_index_ + "/filter_start";
            value = startid;
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            if (0 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }

            path = channel_index_ + "/filter_end";
            value = endid;
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            if (0 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }

            path = channel_index_ + "/filter_ack";//滤波生效
            value = "0";
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            if (0 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }

            //如果要设置多条滤波，在清除滤波和滤波生效之间设置多条滤波即可
            return true;
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

        /// <summary>
        /// 等待
        /// </summary>
        /// <param name="mm"></param>
        public static void Delay(int mm)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(mm) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }
        private void ProcessTimeOut_Tick(object source, ElapsedEventArgs e)
        {
            try
            {
               
                timeOutCount++;
                if (timeOutCount > eCUTimeout) //20s not feedback from ECU, then trigger timeout event
                {
                    ProcessTimeOutTimer.Stop();
                    if (!IsEndss)
                    {
                        learningResultAction("ECU通讯超时", 2);

                       
                    }
                    
                    IsEndss = true;
                    CloseCAN();
                    

                }
            }
            catch (Exception ex)
            {
                LogHelper.CANInfo(ex.ToString());
            }

        }

    }
}

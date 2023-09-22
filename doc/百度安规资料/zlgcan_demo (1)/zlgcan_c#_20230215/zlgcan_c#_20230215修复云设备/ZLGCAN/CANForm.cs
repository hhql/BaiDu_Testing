﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Collections;
using ZLGCAN;

namespace ZLGCANDemo
{
    //窗口类文件
    public partial class CANForm : Form
    {
        const int NULL = 0;
        const int CANFD_BRS = 0x01; /* bit rate switch (second bitrate for payload data) */
        const int CANFD_ESI = 0x02; /* error state indicator of the transmitting node */

        /* CAN payload length and DLC definitions according to ISO 11898-1 */
        const int CAN_MAX_DLC = 8;
        const int CAN_MAX_DLEN = 8;

        /* CAN FD payload length and DLC definitions according to ISO 11898-7 */
        const int CANFD_MAX_DLC = 15;
        const int CANFD_MAX_DLEN = 64;

        const uint CAN_EFF_FLAG = 0x80000000U; /* EFF/SFF is set in the MSB */
        const uint CAN_RTR_FLAG = 0x40000000U; /* remote transmission request */
        const uint CAN_ERR_FLAG = 0x20000000U; /* error message frame */
        const uint CAN_ID_FLAG = 0x1FFFFFFFU; /* id */

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
        uint[] kPCIECANFDAbit = 
        {
            1000000, // 1Mbps
            800000, // 800kbps
            500000, // 500kbps
            250000, // 250kbps
        };
        uint[] kPCIECANFDDbit = 
        {
            8000000, // 8Mbps
            4000000, // 4Mbps
            2000000, // 2Mbps
        };

        int channel_index_;
        IntPtr device_handle_;
        IntPtr channel_handle_;
        IProperty property_;
        recvdatathread recv_data_thread_;
        List<string> list_box_data_ = new List<string>();
        static object lock_obj = new object();

        bool m_bOpen = false;
        bool m_bStart = false;
        bool m_bCloud = false;

        public CANForm()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        }

        //初始化界面控件
        private void CANForm_Load(object sender, EventArgs e)
        {
            comboBox_device.SelectedIndex = 0;
            comboBox_standard.SelectedIndex = 0;
            comboBox_mode.SelectedIndex = 0;
            comboBox_ABIT.SelectedIndex = 0;
            comboBox_DBIT.SelectedIndex = 0;
            comboBox_standard2.SelectedIndex = 2;
            comboBox_frametype.SelectedIndex = 0;
            comboBox_protocol.SelectedIndex = 1;
            comboBox_canfd_exp.SelectedIndex = 0;
            comboBox_sendtype.SelectedIndex = 0;
            comboBox_baud.SelectedIndex = 0;

            checkBox_ABIT.Checked = false;
            checkBox_resistance.Checked = true;

            textBox_startid.Text = "00000000";
            textBox_endid.Text = "FFFFFFFF";
            textBox_ID.Text = "00000001";
            textBox_senddata.Text = "00 11 22 33 44 55 66 77";
            textBox_auto_index.Text = "0";
            textBox_auto_interval.Text = "1000";
            comboBox_netmode.SelectedIndex = 0;
            textBox_localport.Text = "1080";
            textBox_remoteaddr.Text = "192.168.28.222";
            textBox_remoteport.Text = "4001";

            setComboboxIndex(0, 32, 0);
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

        public bool IsRTR(uint id)//1:remote frame 0:data frame
        {
            return !!Convert.ToBoolean((id & CAN_RTR_FLAG));
        }

        public bool IsERR(uint id)//1:error frame 0:normal frame
        {
            return !!Convert.ToBoolean((id & CAN_ERR_FLAG));
        }

        public uint GetId(uint id)
        {
            return id & CAN_ID_FLAG;
        }

        private void CANForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bOpen)
            {
                Method.ZCAN_CloseDevice(device_handle_);
            }
            if (Method.ZCLOUD_IsConnected())
            {
                Method.ZCLOUD_DisconnectServer();
            }
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            uint device_type_index_ = (uint)comboBox_device.SelectedIndex;
            uint device_index_;
            if (kDeviceType[device_type_index_].device_type == Define.ZCAN_CLOUD) // CLOUD
            {
                ZCLOUD dlg = new ZCLOUD();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    device_index_ = dlg.deviceIndex();
                    m_bCloud = true;
                }
                else
                {
                    return;
                }
            }
            else
            {
                device_index_ = (uint)comboBox_index.SelectedIndex;
            }
            device_handle_ = Method.ZCAN_OpenDevice(kDeviceType[device_type_index_].device_type, device_index_, 0);
            if (NULL == (int)device_handle_)
            {
                MessageBox.Show("打开设备失败,请检查设备类型和设备索引号是否正确", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            m_bOpen = true;
            EnableCtrl(true);
        }

        private void button_init_Click(object sender, EventArgs e)
        {
            if (!m_bOpen)
            {
                MessageBox.Show("设备还没打开", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            uint type = kDeviceType[comboBox_device.SelectedIndex].device_type;
            bool netDevice = type == Define.ZCAN_CANETTCP || type == Define.ZCAN_CANETUDP ||
                type == Define.ZCAN_CANFDNET_400U_TCP || type == Define.ZCAN_CANFDNET_400U_UDP ||
                type == Define.ZCAN_CANFDNET_200U_TCP || type == Define.ZCAN_CANFDNET_200U_UDP || type == Define.ZCAN_CANFDNET_800U_TCP ||
                type == Define.ZCAN_CANFDNET_800U_UDP;
            bool canfdnetDevice = type == Define.ZCAN_CANFDNET_400U_TCP || type == Define.ZCAN_CANFDNET_400U_UDP ||
                type == Define.ZCAN_CANFDNET_200U_TCP || type == Define.ZCAN_CANFDNET_200U_UDP || type == Define.ZCAN_CANFDNET_800U_TCP ||
                type == Define.ZCAN_CANFDNET_800U_UDP;
            bool pcieCanfd = type == Define.ZCAN_PCIECANFD_100U ||
                type == Define.ZCAN_PCIECANFD_200U ||
                type == Define.ZCAN_PCIECANFD_400U||
                type == Define.ZCAN_PCIECANFD_200U_EX;
            bool usbCanfd = type == Define.ZCAN_USBCANFD_100U ||
                type == Define.ZCAN_USBCANFD_200U ||
                type == Define.ZCAN_USBCANFD_MINI;
            bool canfdDevice = usbCanfd || pcieCanfd;

           


            if (!m_bCloud)
            {


                if (netDevice)
                {
                    bool tcpDevice = type == Define.ZCAN_CANETTCP || type == Define.ZCAN_CANFDNET_400U_TCP || type == Define.ZCAN_CANFDNET_200U_TCP || type == Define.ZCAN_CANFDNET_800U_TCP;
                    bool server = tcpDevice && comboBox_netmode.SelectedIndex == 0;
                    if (tcpDevice)
                    {
                        setNetMode();
                        if (server)
                        {
                            setLocalPort();
                        }
                        else
                        {
                            setRemoteAddr();
                            setRemotePort();
                        }
                    }
                    else
                    {
                        setLocalPort();
                        setRemoteAddr();
                        setRemotePort();
                    }
                }
                else
                {
                    if (usbCanfd)
                    {
                        if (!setCANFDStandard(comboBox_standard.SelectedIndex)) //设置CANFD标准
                        {
                            MessageBox.Show("设置CANFD标准失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    if (checkBox_ABIT.Checked)//设置波特率
                    {
                        if (!setCustomBaudrate())
                        {
                            MessageBox.Show("设置自定义波特率失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        if (!canfdDevice)
                        {
                            if (!setBaudrate(kBaudrate[comboBox_baud.SelectedIndex]))
                            {
                                MessageBox.Show("设置波特率失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        } else {
                            bool result = true;
                            if (usbCanfd)
                            {
                                if (type == Define.ZCAN_USBCANFD_200U)
                                {
                                    MessageBox.Show("0");
                                    string path = "0/set_device_recv_merge";
                                    string value = "0";
                                    Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
                                }
                                MessageBox.Show("00");
                                result = setFdBaudrate(kUSBCANFDAbit[comboBox_ABIT.SelectedIndex], kUSBCANFDDbit[comboBox_DBIT.SelectedIndex]);
                            }
                            else if (pcieCanfd)
                            {
                               
                                result = setFdBaudrate(kPCIECANFDAbit[comboBox_ABIT.SelectedIndex], kPCIECANFDDbit[comboBox_DBIT.SelectedIndex]);
                                if (type == Define.ZCAN_PCIECANFD_400U||type == Define.ZCAN_PCIECANFD_200U_EX)
                                {
                                    MessageBox.Show("1");
                                    string path = "0/set_device_recv_merge";
                                    string value = "0";
                                    Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)); 
                                }
                                MessageBox.Show("11");
                            }
                            if (!result)
                            {
                                MessageBox.Show("设置波特率失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                    }
                }
            }

            ZCAN_CHANNEL_INIT_CONFIG config_ = new ZCAN_CHANNEL_INIT_CONFIG();
            if (!m_bCloud && !netDevice)
            {
                config_.canfd.mode = (byte)comboBox_mode.SelectedIndex;
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

            if (NULL == (int)channel_handle_)
            {
                MessageBox.Show("初始化CAN失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!m_bCloud && !netDevice)
            {
                if (usbCanfd && checkBox_resistance.Checked)
                {
                    if (!setResistanceEnable())
                    {
                        MessageBox.Show("使能终端电阻失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (usbCanfd && !setFilter())
                {
                    MessageBox.Show("设置滤波失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (type == Define.ZCAN_USBCAN_2E_U || type == Define.ZCAN_USBCAN_E_U)
                {
                    if (!setFilter())
                    {
                        MessageBox.Show("设置滤波失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }

            }

            button_init.Enabled = false;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (Method.ZCAN_StartCAN(channel_handle_) != Define.STATUS_OK)
            {
                MessageBox.Show("启动CAN失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            button_start.Enabled = false;
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
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            string path = channel_index_ + "/clear_auto_send";
            string value = "0";
            uint result = Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
            if (Method.ZCAN_ResetCAN(channel_handle_) != Define.STATUS_OK)
            {
                MessageBox.Show("复位失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            button_start.Enabled = true;
            m_bOpen = false;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Method.ZCAN_CloseDevice(device_handle_);
            m_bOpen = false;
            m_bCloud = false;
            EnableCtrl(false);
            button_start.Enabled = true;
            button_init.Enabled = true;
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            if (textBox_senddata.Text.Length == 0)
            {
                MessageBox.Show("数据为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            uint id = (uint)System.Convert.ToInt32(textBox_ID.Text, 16);
            string data = textBox_senddata.Text;
            int frame_type_index = comboBox_frametype.SelectedIndex;
            int protocol_index = comboBox_protocol.SelectedIndex;
            int send_type_index = comboBox_sendtype.SelectedIndex;
            int canfd_exp_index = comboBox_canfd_exp.SelectedIndex;
            uint result; //发送的帧数

            if (0 == protocol_index) //can
            {

                ZCAN_Transmit_Data can_data = new ZCAN_Transmit_Data();
                can_data.frame.can_id = MakeCanId(id, frame_type_index, 0, 0);
                can_data.frame.data = new byte[8];
                can_data.frame.can_dlc = (byte)SplitData(data, ref can_data.frame.data, CAN_MAX_DLEN);
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
                canfd_data.frame.len = (byte)SplitData(data, ref canfd_data.frame.data, CANFD_MAX_DLEN);
                canfd_data.transmit_type = (uint)send_type_index;
                canfd_data.frame.flags = (byte)((canfd_exp_index != 0) ? CANFD_BRS : 0);
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(canfd_data));
                Marshal.StructureToPtr(canfd_data, ptr, true);
                result = Method.ZCAN_TransmitFD(channel_handle_, ptr, 1);
                Marshal.FreeHGlobal(ptr);
            }

            if (result != 1)
            {
                MessageBox.Show("发送数据失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AddErr();
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }

        private void comboBox_device_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_channel.Items.Clear();
            setChannelCombobox(0, (int)kDeviceType[comboBox_device.SelectedIndex].channel_count, 0);
            uint type = kDeviceType[comboBox_device.SelectedIndex].device_type;
            bool pcieCanfd = type == Define.ZCAN_PCIECANFD_100U ||
                type == Define.ZCAN_PCIECANFD_200U ||
                type == Define.ZCAN_PCIECANFD_400U;
            bool usbCanfd = type == Define.ZCAN_USBCANFD_100U ||
                type == Define.ZCAN_USBCANFD_200U ||
                type == Define.ZCAN_USBCANFD_MINI;
            if (pcieCanfd)
            {
                comboBox_ABIT.Items.Clear();
                comboBox_ABIT.Items.AddRange(new object[] {
                    "1Mbps 80%",
                    "800kbps 80%",
                    "500kbps 80%",
                    "250kbps 80%"});
                comboBox_ABIT.SelectedIndex = 0;
                comboBox_DBIT.Items.Clear();
                comboBox_DBIT.Items.AddRange(new object[] {
                    "8Mbps 75%",
                    "4Mbps 75%",
                    "2Mbps 75%"});
                comboBox_DBIT.SelectedIndex = 0;
            }
            else if (usbCanfd)
            {
                comboBox_ABIT.Items.Clear();
                comboBox_ABIT.Items.AddRange(new object[] {
                    "1Mbps 80%",
                    "800kbps 80%",
                    "500kbps 80%",
                    "250kbps 80%",
                    "125kbps 80%",
                    "100kbps 80%",
                    "50kbps 80%"});
                comboBox_ABIT.SelectedIndex = 0;
                comboBox_DBIT.Items.Clear();
                comboBox_DBIT.Items.AddRange(new object[] {
                    "5Mbps 75%",
                    "4Mbps 75%",
                    "2Mbps 75%",
                    "1Mbps 75%",
                    "800kbps 75%",
                    "500kbps 75%",
                    "250kbps 75%",
                    "125kbps 75%",
                    "100kbps 75%",
                });
                comboBox_DBIT.SelectedIndex = 0;
            }
            EnableSet();
        }

        private void comboBox_channel_SelectedIndexChanged(object sender, EventArgs e)
        {
            channel_index_ = comboBox_channel.SelectedIndex;
        }

        private void setComboboxIndex(int start, int end, int current)
        {
            for (int i = start; i < end; ++i)
            {
                comboBox_index.Items.Add(i);
            }

            comboBox_index.SelectedIndex = current;
        }

        private void setChannelCombobox(int start, int end, int current)
        {
            for (int i = start; i < end; ++i)
            {
                comboBox_channel.Items.Add(i);
            }

            comboBox_channel.SelectedIndex = current;
            channel_index_ = comboBox_channel.SelectedIndex;
        }

        //设置波特率
        private bool setBaudrate(UInt32 baud)
        {
            string path = channel_index_ + "/baud_rate";
            string value = baud.ToString();
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            return 1 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
        }

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

        //设置CANFD标准
        private bool setCANFDStandard(int canfd_standard)
        {
            string path = channel_index_ + "/canfd_standard";
            string value = canfd_standard.ToString();
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            return 1 ==Method.ZCAN_SetValue(device_handle_,path, Encoding.ASCII.GetBytes(value));
        }

        //设置自定义波特率, 需要从CANMaster目录下的baudcal生成字符串
        private bool setCustomBaudrate()
        {
            string path = channel_index_ + "/baud_rate_custom";
            string baudrate = textBox_ABIT.Text;
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(baudrate).ToPointer();
            return 1 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(baudrate));
        }

        //设置终端电阻使能
        private bool setResistanceEnable()
        {
            string path = channel_index_ + "/initenal_resistance";
            string value = (checkBox_resistance.Checked ? "1" : "0");
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            return 1 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
        }

        //设置滤波
        private bool setFilter()
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
            value = comboBox_standard2.SelectedIndex.ToString();
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
            value = textBox_startid.Text;
            //char* pathCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(path).ToPointer();
            //char* valueCh = (char*)System.Runtime.InteropServices.Marshal.StringToHGlobalAnsi(value).ToPointer();
            if (0 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }

            path = channel_index_ + "/filter_end";
            value = textBox_endid.Text;
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

        private bool setFilterCode()
        {
            string path = channel_index_ + "/filter";
            string value = "0";
            if (0 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }
            path = channel_index_ + "/acc_code";
            value = "0x0000";
            if (0 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }
            path = channel_index_ + "/acc_mask";
            value = "0xFFFFFFFF";
            if (0 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value)))
            {
                return false;
            }
            return true;
        }

        //设置网络工作模式
        private bool setNetMode()
        {
            string path = channel_index_ + "/work_mode";
            string value = comboBox_netmode.SelectedIndex == 0 ? "1" : "0";
            return 1 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
        }

        //设置本地端口
        private bool setLocalPort()
        {
            string path = channel_index_ + "/local_port";
            string value = textBox_localport.Text;
            return 1 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
        }

        //设置远程地址
        private bool setRemoteAddr()
        {
            string path = channel_index_ + "/ip";
            string value = textBox_remoteaddr.Text;
            return 1 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
        }

        //设置远程端口
        private bool setRemotePort()
        {
            string path = channel_index_ + "/work_port";
            string value = textBox_remoteport.Text;
            return 1 == Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));
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
                text = String.Format("接收到CAN ID:0x{0:X8} {1:G} {2:G} 长度:{3:D1} 数据:", GetId(id), eff, rtr, can.frame.can_dlc);

                for (uint j = 0; j < can.frame.can_dlc; ++j)
                {
                    text = String.Format("{0:G}{1:X2} ", text, can.frame.data[j]);
                }
                lock (lock_obj)
                {
                    list_box_data_.Add(text);
                }
            }

            Object[] list = { this, System.EventArgs.Empty };
            this.listBox.BeginInvoke(new EventHandler(SetListBox), list);
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
                text = String.Format("接收到CANFD ID:0x{0:X8} {1:G} {2:G} 长度:{3:D1} 数据:", GetId(id), eff, rtr, canfd.frame.len);
                for (uint j = 0; j < canfd.frame.len; ++j)
                {
                    text = String.Format("{0:G}{1:X2} ", text, canfd.frame.data[j]);
                }
                lock (lock_obj)
                {
                    list_box_data_.Add(text);
                }
            }

            Object[] list = { this, System.EventArgs.Empty };
            this.listBox.BeginInvoke(new EventHandler(SetListBox), list);
        }

        private void AddErr()
        {
            ZCAN_CHANNEL_ERROR_INFO pErrInfo = new ZCAN_CHANNEL_ERROR_INFO();
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(pErrInfo));
            Marshal.StructureToPtr(pErrInfo, ptr, true);
            if (Method.ZCAN_ReadChannelErrInfo(channel_handle_, ptr) != Define.STATUS_OK)
            {
                MessageBox.Show("获取错误信息失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Marshal.FreeHGlobal(ptr);

            string errorInfo = String.Format("错误码：{0:D1}", pErrInfo.error_code);
            int index = listBox.Items.Add(errorInfo);
            listBox.SelectedIndex = index;
        }

        private void SetListBox(object sender, EventArgs e)
        {
            int index = 0;
            lock (lock_obj)
            {
                foreach (string text in list_box_data_)
                {
                    index = listBox.Items.Add(text);
                }
                list_box_data_.Clear();
            }
            listBox.SelectedIndex = index;
        }

        private void EnableCtrl(bool opened)
        {
            comboBox_device.Enabled = !opened;
            comboBox_index.Enabled = !opened;
            comboBox_channel.Enabled = !opened;
            button_open.Enabled = !opened;
        }

        private void EnableSet()
        {
            uint type = kDeviceType[comboBox_device.SelectedIndex].device_type;
            bool cloudDevice = type == Define.ZCAN_CLOUD;
            bool netDevice = type == Define.ZCAN_CANETTCP || type == Define.ZCAN_CANETUDP ||
                type == Define.ZCAN_CANFDNET_400U_TCP || type == Define.ZCAN_CANFDNET_400U_UDP ||
                type == Define.ZCAN_CANFDNET_200U_TCP || type == Define.ZCAN_CANFDNET_200U_UDP || type == Define.ZCAN_CANFDNET_800U_TCP ||
                type == Define.ZCAN_CANFDNET_800U_UDP;
            bool canfdnetDevice = type == Define.ZCAN_CANFDNET_400U_TCP || type == Define.ZCAN_CANFDNET_400U_UDP ||
                type == Define.ZCAN_CANFDNET_800U_TCP || type == Define.ZCAN_CANFDNET_800U_UDP ||
                type == Define.ZCAN_CANFDNET_200U_TCP || type == Define.ZCAN_CANFDNET_200U_UDP;
            bool pcieCanfd = type == Define.ZCAN_PCIECANFD_100U ||
                type == Define.ZCAN_PCIECANFD_200U ||
                type == Define.ZCAN_PCIECANFD_400U||
                type == Define.ZCAN_PCIECANFD_200U_EX;
            bool usbCanfd = type == Define.ZCAN_USBCANFD_100U ||
                type == Define.ZCAN_USBCANFD_200U ||
                type == Define.ZCAN_USBCANFD_MINI;
            bool canfdDevice = usbCanfd || pcieCanfd;
            bool usbCAN = type == Define.ZCAN_USBCAN1 || type == Define.ZCAN_USBCAN2;
            bool accFilter = usbCAN || pcieCanfd;

            comboBox_mode.Enabled = !cloudDevice && !netDevice;
            comboBox_standard.Enabled = canfdDevice;
            comboBox_ABIT.Enabled = canfdDevice;
            comboBox_DBIT.Enabled = canfdDevice;
            checkBox_ABIT.Enabled = !cloudDevice && !netDevice;
            textBox_ABIT.Enabled = !cloudDevice && !netDevice;
            comboBox_baud.Enabled = !canfdDevice && !cloudDevice && !netDevice;
            checkBox_resistance.Enabled = usbCanfd;
            comboBox_standard2.Enabled = !cloudDevice && !netDevice && !accFilter;
            textBox_startid.Enabled = !cloudDevice && !netDevice && !accFilter;
            textBox_endid.Enabled = !cloudDevice && !netDevice&& !accFilter;
            comboBox_index.Enabled = !cloudDevice && !netDevice;
            label_baudprompt.Enabled = !cloudDevice && !netDevice;
            label_standard.Enabled = canfdDevice;
            label_mode.Enabled = !cloudDevice && !netDevice;
            label_ABIT.Enabled = canfdDevice;
            label_ABIT2.Enabled = canfdDevice;
            label_ABIT.Enabled = canfdDevice;
            label_ABIT.Enabled = canfdDevice;
            label_baud.Enabled = !canfdDevice && !cloudDevice && !netDevice;
            label_standard2.Enabled = !cloudDevice && !netDevice && !accFilter;
            label_startid.Enabled = !cloudDevice && !netDevice && !accFilter;
            label_endid.Enabled = !cloudDevice && !netDevice && !accFilter;
            label_index.Enabled = !cloudDevice && !netDevice;
            label_auto_interval.Enabled = !cloudDevice && !accFilter && !netDevice || canfdnetDevice || pcieCanfd;
            label_auto_index.Enabled = !cloudDevice && !accFilter && !netDevice || canfdnetDevice || pcieCanfd;
            button_add_autosend.Enabled = !cloudDevice && !accFilter && !netDevice || canfdnetDevice || pcieCanfd;
            button_apply_autosend.Enabled = !cloudDevice && !accFilter && !netDevice && !(type == Define.ZCAN_USBCAN_2E_U || type == Define.ZCAN_USBCAN_E_U) || canfdnetDevice  ;
            button_clear_autosend.Enabled = !cloudDevice && !accFilter && !netDevice || canfdnetDevice || pcieCanfd;
            button_disable_autosend.Enabled = !cloudDevice && !accFilter && !netDevice || canfdnetDevice || pcieCanfd;

            bool tcpDevice = type == Define.ZCAN_CANETTCP || type == Define.ZCAN_CANFDNET_400U_TCP || type == Define.ZCAN_CANFDNET_200U_TCP || type == Define.ZCAN_CANFDNET_800U_TCP;
            bool udpDevice = type == Define.ZCAN_CANETUDP || type == Define.ZCAN_CANFDNET_400U_UDP || type == Define.ZCAN_CANFDNET_800U_UDP || type == Define.ZCAN_CANFDNET_200U_UDP;
            bool server = tcpDevice && comboBox_netmode.SelectedIndex == 0;
            bool client = tcpDevice && comboBox_netmode.SelectedIndex == 1;

            comboBox_netmode.Enabled = tcpDevice;
            textBox_localport.Enabled = udpDevice || server;
            textBox_remoteaddr.Enabled = udpDevice || client;
            textBox_remoteport.Enabled = udpDevice || client;
            label_netmode.Enabled = tcpDevice;
            label_localport.Enabled = udpDevice || server;
            label_remoteaddr.Enabled = udpDevice || client;
            label_remoteport.Enabled = udpDevice || client;
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

        private void comboBox_netmode_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableSet();
        }

        //定时发送相关代码
        //添加单条定时发送报文
        private void button_add_autosend_Click(object sender, EventArgs e)
        {
            if (textBox_senddata.Text.Length == 0)
            {
                MessageBox.Show("数据为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            uint id = (uint)System.Convert.ToInt32(textBox_ID.Text, 16);
            string data = textBox_senddata.Text;
            int frame_type_index = comboBox_frametype.SelectedIndex;
            int protocol_index = comboBox_protocol.SelectedIndex;
            int send_type_index = comboBox_sendtype.SelectedIndex;
            int canfd_exp_index = comboBox_canfd_exp.SelectedIndex;
            uint result; //发送的帧数

            if (0 == protocol_index) //can
            {
                ZCAN_AUTO_TRANSMIT_OBJ auto_can = new ZCAN_AUTO_TRANSMIT_OBJ();                                     //定时发送CAN
                auto_can.enable = 1;                                                                                //0-禁用 ，1-使能 此报文
                auto_can.index = (ushort)System.Convert.ToInt32(textBox_auto_index.Text, 10);                       //索引 0  
                auto_can.interval = (uint)System.Convert.ToInt32(textBox_auto_interval.Text, 10);                   //周期单位，ms
                auto_can.obj.frame.can_id = MakeCanId(id, frame_type_index, 0, 0);
                auto_can.obj.frame.data = new byte[8];
                auto_can.obj.frame.can_dlc = (byte)SplitData(data, ref auto_can.obj.frame.data, CAN_MAX_DLEN);
                auto_can.obj.transmit_type = (uint)send_type_index;
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(auto_can));
                Marshal.StructureToPtr(auto_can, ptr, true);
                string path = channel_index_ + "/auto_send";
                result = Method.ZCAN_SetValue(device_handle_, path, ptr);                               //添加CAN定时条目
                Marshal.FreeHGlobal(ptr);
                if (result == 1)
                {
                    string text = "";
                    text = String.Format("添加CAN定时发送成功");
                    lock (lock_obj)
                    {
                        list_box_data_.Add(text);
                    }
                }

            }
            else //canfd
            {
                ZCANFD_AUTO_TRANSMIT_OBJ auto_canfd = new ZCANFD_AUTO_TRANSMIT_OBJ();                   //定时发送CAN
                auto_canfd.enable = 1;
                auto_canfd.index = (ushort)System.Convert.ToInt32(textBox_auto_index.Text, 10);         //报文索引 1 ，根据需求可以自行增加定时条目
                auto_canfd.interval = (uint)System.Convert.ToInt32(textBox_auto_interval.Text, 10);     //周期单位，ms
                auto_canfd.obj.frame.can_id = MakeCanId(id, frame_type_index, 0, 0);
                auto_canfd.obj.frame.data = new byte[64];
                auto_canfd.obj.frame.len = (byte)SplitData(data, ref auto_canfd.obj.frame.data, CANFD_MAX_DLEN);
                auto_canfd.obj.transmit_type = (uint)send_type_index;
                auto_canfd.obj.frame.flags = (byte)((canfd_exp_index != 0) ? CANFD_BRS : 0);
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(auto_canfd));
                Marshal.StructureToPtr(auto_canfd, ptr, true);
                string path = channel_index_ + "/auto_send_canfd";
                result = Method.ZCAN_SetValue(device_handle_, path, ptr);                              //添加CANFD定时条目
                Marshal.FreeHGlobal(ptr);
                if (result == 1)
                {
                    string text = "";
                    text = String.Format("添加CANFD定时发送成功");
                    lock (lock_obj)
                    {
                        list_box_data_.Add(text);
                    }
                }
            }
            if (result != 1)
            {
                MessageBox.Show("添加定时发送失败，请检查设备型号以及当前设备状态", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AddErr();
            }
            Object[] list = { this, System.EventArgs.Empty };
            this.listBox.BeginInvoke(new EventHandler(SetListBox), list);
        }




        //禁用单条定时发送报文
        private void button_disable_autosend_Click(object sender, EventArgs e)
        {
            if (textBox_senddata.Text.Length == 0)
            {
                MessageBox.Show("数据为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            uint id = (uint)System.Convert.ToInt32(textBox_ID.Text, 16);
            string data = textBox_senddata.Text;
            int frame_type_index = comboBox_frametype.SelectedIndex;
            int protocol_index = comboBox_protocol.SelectedIndex;
            int send_type_index = comboBox_sendtype.SelectedIndex;
            int canfd_exp_index = comboBox_canfd_exp.SelectedIndex;
            uint result; //发送的帧数

            if (0 == protocol_index) //can
            {
                ZCAN_AUTO_TRANSMIT_OBJ auto_can = new ZCAN_AUTO_TRANSMIT_OBJ();                                     //定时发送CAN
                auto_can.enable = 0;                                                                                //0-禁用 ，1-使能 此报文
                auto_can.index = (ushort)System.Convert.ToInt32(textBox_auto_index.Text, 10);                       //索引 0  
                auto_can.interval = (uint)System.Convert.ToInt32(textBox_auto_interval.Text, 10);                   //周期单位，ms
                auto_can.obj.frame.can_id = MakeCanId(id, frame_type_index, 0, 0);
                auto_can.obj.frame.data = new byte[8];
                auto_can.obj.frame.can_dlc = (byte)SplitData(data, ref auto_can.obj.frame.data, CAN_MAX_DLEN);
                auto_can.obj.transmit_type = (uint)send_type_index;
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(auto_can));
                Marshal.StructureToPtr(auto_can, ptr, true);
                string path = channel_index_ + "/auto_send";
                result = Method.ZCAN_SetValue(device_handle_, path, ptr);                               //添加CAN定时条目
                Marshal.FreeHGlobal(ptr);
                if (result == 1)
                {
                    string text = "";
                    text = String.Format("禁用CAN定时发送成功");
                    lock (lock_obj)
                    {
                        list_box_data_.Add(text);
                    }
                }

            }
            else //canfd
            {
                ZCANFD_AUTO_TRANSMIT_OBJ auto_canfd = new ZCANFD_AUTO_TRANSMIT_OBJ();                   //定时发送CAN
                auto_canfd.enable = 0;                                                                  //0-禁用，1-使能
                auto_canfd.index = (ushort)System.Convert.ToInt32(textBox_auto_index.Text, 10);         //报文索引 1 ，根据需求可以自行增加定时条目
                auto_canfd.interval = (uint)System.Convert.ToInt32(textBox_auto_interval.Text, 10);     //周期单位，ms
                auto_canfd.obj.frame.can_id = MakeCanId(id, frame_type_index, 0, 0);
                auto_canfd.obj.frame.data = new byte[64];
                auto_canfd.obj.frame.len = (byte)SplitData(data, ref auto_canfd.obj.frame.data, CANFD_MAX_DLEN);
                auto_canfd.obj.transmit_type = (uint)send_type_index;
                auto_canfd.obj.frame.flags = (byte)((canfd_exp_index != 0) ? CANFD_BRS : 0);
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(auto_canfd));
                Marshal.StructureToPtr(auto_canfd, ptr, true);
                string path = channel_index_ + "/auto_send_canfd";
                result = Method.ZCAN_SetValue(device_handle_, path, ptr);                              //添加CANFD定时条目
                Marshal.FreeHGlobal(ptr);
                if (result == 1)
                {
                    string text = "";
                    text = String.Format("禁用CANFD定时发送成功");
                    lock (lock_obj)
                    {
                        list_box_data_.Add(text);
                    }
                }
            }
            if (result != 1)
            {
                MessageBox.Show("禁用定时发送失败，请检查设备型号以及当前设备状态", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                AddErr();
            }
            Object[] list = { this, System.EventArgs.Empty };
            this.listBox.BeginInvoke(new EventHandler(SetListBox), list);
        }

        //使能所有定时发送报文，仅个别型号支持，如CANFDNET系列，USBCANFD系列
        private void button_apply_autosend_Click(object sender, EventArgs e)
        {
            string path = channel_index_ + "/apply_auto_send";                                           
            string value = "0";
            uint result = Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));  //开启定时发送功能
            string text = "";
            if (result == 1)
            {
                text = String.Format("使能所有定时报文成功");
                lock (lock_obj)
                {
                    list_box_data_.Add(text);
                }
            }
            else
            {
                text = String.Format("使能所有定时发送失败");
                lock (lock_obj)
                {
                    list_box_data_.Add(text);
                }
            }
            Object[] list = { this, System.EventArgs.Empty };
            this.listBox.BeginInvoke(new EventHandler(SetListBox), list);
        }



        //清空定时发送报文
        private void button_clear_autosend_Click(object sender, EventArgs e)
        {
            string path = channel_index_ + "/clear_auto_send";                                           
            string value = "0";
            uint result = Method.ZCAN_SetValue(device_handle_, path, Encoding.ASCII.GetBytes(value));  //开启定时发送功能
            string text = "";
            if (result == 1)
            {
                text = String.Format("清空所有定时发送成功");
                lock (lock_obj)
                {
                    list_box_data_.Add(text);
                }
            }
            else
            {
                text = String.Format("清空所有定时发送失败");
                lock (lock_obj)
                {
                    list_box_data_.Add(text);
                }
            }
            Object[] list = { this, System.EventArgs.Empty };
            this.listBox.BeginInvoke(new EventHandler(SetListBox), list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox_baud.SelectedIndex.ToString());
        }
    }
}

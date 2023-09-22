using log4net.Config;
using SafetyTesting.DB.Entity;
using SafetyTesting.DB.Interface;
using SafetyTesting.Tool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SafetyTesting
{
    public partial class FormMain : Form
    {
       // ISafetyDataRepository safetyDataRepository;
        public FormMain(ISafetyDataRepository _safetyDataRepository)
        {
            InitializeComponent();

            carModul1.safetyDataRepository = _safetyDataRepository;
            device1.safetyDataRepository = _safetyDataRepository;
            Control.home.safetyDataRepository = _safetyDataRepository;
            setting1.safetyDataRepository = _safetyDataRepository;
            data1.safetyDataRepository = _safetyDataRepository;

            InfoConfig();

        }

        private Panel panelMenu = null;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public void InfoConfig()
        {
            XmlConfigurator.Configure(new FileInfo(Application.StartupPath + "log4net.config"));
        }

        #region 窗口拖动
        private Point mouseLocation;
        private bool isDragging;
        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLocation = new Point(-e.X, -e.Y);
                isDragging = true;
            }
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newMouselocation = MousePosition;
                newMouselocation.Offset(mouseLocation.X, mouseLocation.Y);
                Location = newMouselocation;
            }
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
            }
        }
        #endregion

        private void FormMain_DoubleClick(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {

            timer_time.Enabled = true;
            panelMenu = panel_home;
            
            
            home1.Dock = DockStyle.Fill;
            home1.BringToFront();
            string name= Control.home.CurrentStation;
            label1.Text = name;
            LogHelper.Info("start");


        }
        private void timer_time_Tick(object sender, EventArgs e)
        {
            timer_time.Enabled = false;

            label_time.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            timer_time.Enabled = true;
        }

        private void panel_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出系统","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                device1.Close();
                home1.close();
                Application.Exit();
            }
        }

        private void panel_exit_MouseDown(object sender, MouseEventArgs e)
        {
            panel_exit.BackgroundImage = Properties.Resources.yuanLight1;
            pictureBox_exit.Image = Properties.Resources.exitLight;
        }

        private void panel_exit_MouseUp(object sender, MouseEventArgs e)
        {
            panel_exit.BackgroundImage = Properties.Resources.yuan;
            pictureBox_exit.Image = Properties.Resources.exit1;
        }

        

        private void panel_MouseDown(object sender, MouseEventArgs e) 
        {
            MenuClickDisplay(panelMenu, false);
            MenuClickDisplay(sender,true);
            
            
        }
        
        private void MenuClickDisplay(object sender,bool isMenu)
        {
            string name = string.Empty;
            if (sender is Panel)
            {
                Panel panelmenu = (Panel)sender;

                string[] names = panelmenu.Name.Split('_');
                name = names[1];
            }
            else if (sender is Label)
            {
                Label label = (Label)sender;
                string[] names = label.Name.Split('_');
                name = names[1];

            }
            else if (sender is PictureBox)
            {
                PictureBox pictureBox = (PictureBox)sender;
                string[] names = pictureBox.Name.Split('_');
                name = names[1];
            }
            switch (name)
            {
                case "home":
                    panelMenu = panel_home;
                    if (isMenu)
                    {
                        panel_home.BackgroundImage = Properties.Resources.yuanLight1;
                        pictureBox_home.Image = Properties.Resources.homeLight;
                    }
                    else
                    {
                        panel_home.BackgroundImage = Properties.Resources.yuan;
                        pictureBox_home.Image = Properties.Resources.home;
                    }
                    
                    
                    break;
                case "carModul":
                    panelMenu = panel_carModul;
                    if (isMenu)
                    {
                        panel_carModul.BackgroundImage = Properties.Resources.yuanLight1;
                        pictureBox_carModul.Image = Properties.Resources.carModulLight;
                    }
                    else
                    {
                        panel_carModul.BackgroundImage = Properties.Resources.yuan;
                        pictureBox_carModul.Image = Properties.Resources.CarModul;
                    }
                    
                    
                    break;
                case "device":
                    panelMenu = panel_device;
                    if (isMenu)
                    {
                        device1.GetIOmodule();
                        panel_device.BackgroundImage = Properties.Resources.yuanLight1;
                        pictureBox_device.Image = Properties.Resources.IOLight;
                    }
                    else
                    {
                        panel_device.BackgroundImage = Properties.Resources.yuan;
                        pictureBox_device.Image = Properties.Resources.IO;
                    }
                    
                    
                    break;
                case "data":
                    panelMenu = panel_data;
                    if (isMenu)
                    {
                        panel_data.BackgroundImage = Properties.Resources.yuanLight1;
                        pictureBox_data.Image = Properties.Resources.dataLight;
                    }
                    else
                    {
                        panel_data.BackgroundImage = Properties.Resources.yuan;
                        pictureBox_data.Image = Properties.Resources.data;
                    }
                    
                    
                    break;
                case "setting":
                    panelMenu = panel_setting;
                    if (isMenu)
                    {
                        panel_setting.BackgroundImage = Properties.Resources.yuanLight1;
                        pictureBox_setting.Image = Properties.Resources.settingLight;
                    }
                    else
                    {
                        panel_setting.BackgroundImage = Properties.Resources.yuan;
                        pictureBox_setting.Image = Properties.Resources.setting;
                    }
                    
                    
                    break;
                case "about":
                    panelMenu = panel_about;
                    if (isMenu)
                    {
                        panel_about.BackgroundImage = Properties.Resources.yuanLight1;
                        pictureBox_about.Image = Properties.Resources.aboutLight;
                    }
                    else
                    {
                        panel_about.BackgroundImage = Properties.Resources.yuan;
                        pictureBox_about.Image = Properties.Resources.about;
                    }
                    break;
            }
        }


        private void panel_home_Click(object sender, EventArgs e)
        {
            home1.Dock = DockStyle.Fill;
            home1.BringToFront();
        }
        private void panel_carModul_Click(object sender, EventArgs e)
        {
            // User user= safetyDataRepository.GetData<User>().Where(x=>x.UserName)
            string data = Convert.ToString(Global.Level, 2).PadLeft(4, '0');
            if (Global.UserName.ToLower() == "admin") { }
            else if (data.Substring(0, 1) != "1")
            {
                return;
            }

            carModul1.Dock = DockStyle.Fill;
            carModul1.BackColor = Color.Transparent;

            carModul1.BringToFront();

        }

        private void panel_device_Click(object sender, EventArgs e)
        {
            string data = Convert.ToString(Global.Level, 2).PadLeft(4, '0');
            if (Global.UserName.ToLower() == "admin") { }
            else if (data.Substring(1, 1) != "1")
            {
                return;
            }

            device1.Dock = DockStyle.Fill;
            device1.BackColor = Color.Transparent;
            device1.BringToFront();
        }

        private void panel_data_Click(object sender, EventArgs e)
        {
            string data = Convert.ToString(Global.Level, 2).PadLeft(4, '0');
            if (Global.UserName.ToLower() == "admin") { }
            else if (data.Substring(3, 1) != "1")
            {
                return;
            }
            data1.Dock = DockStyle.Fill;
            data1.BackColor = Color.Transparent;
            data1.BringToFront();
        }

        private void panel_setting_Click(object sender, EventArgs e)
        {
            string data = Convert.ToString(Global.Level, 2).PadLeft(4, '0');
            if (Global.UserName.ToLower() == "admin") { }
            else if (data.Substring(2, 1) != "1")
            {
                return;
            }
            setting1.Dock = DockStyle.Fill;
            setting1.BackColor = Color.Transparent;
            setting1.BringToFront();
        }

        private void panel_about_Click(object sender, EventArgs e)
        {
            about1.Dock = DockStyle.Fill;
            about1.BackColor = Color.Transparent;
            about1.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }
    }
}

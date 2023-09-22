using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SafetyTesting
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isAppRunning = false;
            Mutex mutex = new Mutex(true, System.Diagnostics.Process.GetCurrentProcess().ProcessName, out isAppRunning);
            if (!isAppRunning)
            {
                MessageBox.Show("程序已运行，不能再次打开！");
                Environment.Exit(1);
            }


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           //Application.Run(new Form1());

            if (true)
            {
                //创建服务容器
                var services = new ServiceCollection();
                //添加服务注册
                ConfigureServices(services);

                //构建ServiceProvider对象
                ServiceProviderHelper.InitServiceProvider(services.BuildServiceProvider());

                //获取指定服务
                var login = ServiceProviderHelper.ServiceProvider.GetRequiredService<LoginForm>();
                login.ShowDialog();
                //LoginForm login=new LoginForm();
                //login.ShowDialog();
                if (login.DialogResult == DialogResult.OK)
                {

                    //Application.Run(main);
                    var main = ServiceProviderHelper.ServiceProvider.GetRequiredService<FormMain>();
                    //FormMain formMain = new FormMain();
                    Global.UserName = login.UserName;
                    Global.Level = login.Level;
                    Application.Run(main);
                }
            }
            

            
        }

        public static void ConfigureServices(IServiceCollection services)
        {

            //批量注入
            services.AddScoped<DB.Interface.ISafetyDataRepository, DB.Realization.SafetyDataRepository>();

            ////其他的窗体也可以注入在此处
            services.AddSingleton(typeof(LoginForm));
            services.AddSingleton(typeof(FormMain));
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            string message = string.Format("{0}\r\n操作发生错误，您需要退出系统么？", ex.Exception.Message);
            if (DialogResult.Yes == MessageBox.Show(message, "系统错误", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
        }
    }
}

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
                MessageBox.Show("���������У������ٴδ򿪣�");
                Environment.Exit(1);
            }


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           //Application.Run(new Form1());

            if (true)
            {
                //������������
                var services = new ServiceCollection();
                //��ӷ���ע��
                ConfigureServices(services);

                //����ServiceProvider����
                ServiceProviderHelper.InitServiceProvider(services.BuildServiceProvider());

                //��ȡָ������
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

            //����ע��
            services.AddScoped<DB.Interface.ISafetyDataRepository, DB.Realization.SafetyDataRepository>();

            ////�����Ĵ���Ҳ����ע���ڴ˴�
            services.AddSingleton(typeof(LoginForm));
            services.AddSingleton(typeof(FormMain));
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs ex)
        {
            string message = string.Format("{0}\r\n����������������Ҫ�˳�ϵͳô��", ex.Exception.Message);
            if (DialogResult.Yes == MessageBox.Show(message, "ϵͳ����", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
        }
    }
}

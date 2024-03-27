using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string applicationName = Path.GetFileName(Application.ExecutablePath);
            _ = new Mutex(false, applicationName, out var createdNew);
            if (createdNew)
            {
                Logger.WriteSystemLog("�������!");
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandleException;  // ��־��¼������δ������쳣��
                Application.ThreadException += Application_ThreadException;

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("Ӧ���������������ظ�������");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// ����UI�߳��쳣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string msg = $"��������쳣��{e.Exception.Message},������Error��־";
            Logger.WriteErrorLog(e.Exception);
            MessageBox.Show(msg);   // ���������UI�߳��쳣��������windowsϵͳ������ʾδ�����쳣��
        }
        /// <summary>
        /// �����UI�߳��쳣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandleException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            string msg = $"��������쳣:{ex.Message},������Error��־";
            Logger.WriteErrorLog(ex);
            if (e.IsTerminating) Logger.WriteSystemLog(msg);  // ����쳣�������п���ֹ�����¼��ϵͳ��־��
            MessageBox.Show(msg);
        }
    }
}

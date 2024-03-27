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
                Logger.WriteSystemLog("软件启动!");
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandleException;  // 日志记录程序中未捕获的异常。
                Application.ThreadException += Application_ThreadException;

                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                MessageBox.Show("应用已启动，请勿重复启动！");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 处理UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string msg = $"软件出现异常：{e.Exception.Message},详情检查Error日志";
            Logger.WriteErrorLog(e.Exception);
            MessageBox.Show(msg);   // 如果不捕获UI线程异常，则会出现windows系统弹窗提示未捕获异常。
        }
        /// <summary>
        /// 处理非UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandleException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            string msg = $"软件出现异常:{ex.Message},详情检查Error日志";
            Logger.WriteErrorLog(ex);
            if (e.IsTerminating) Logger.WriteSystemLog(msg);  // 如果异常导致运行库终止，则记录到系统日志。
            MessageBox.Show(msg);
        }
    }
}

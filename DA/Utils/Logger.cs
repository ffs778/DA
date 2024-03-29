using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DA
{
    public class Logger
    {
        private static readonly object lockObject = new object();
        private static string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;   //存储在本程序目录下.exe文件所在目录中
        private static string previousErrorMsg = string.Empty;
        private static string previousExceptionMsg = string.Empty;
        private static string previousSystempMsg = string.Empty;
        private static string previousOperateMsg = string.Empty;

        #region 错误日志
        /// <summary>
        /// 记录到错误消息日志
        /// </summary>
        /// <param name="error">错误消息</param>
        public static void WriteErrorLog(string message)
        {
            WriteToLog(path, "Error", LogMsgCompare(message, ref previousErrorMsg));
        }
        public static void WriteErrorLog(Exception ex)
        {
            string message = "{" + ex.TargetSite + "}\r\n" + ex;
            WriteErrorLog(message);
        }
        #endregion

        #region 异常日志
        /// <summary>
        /// 记录到异常日志
        /// </summary>
        /// <param name="message"></param>
        public static void WriteExceptionLog(string message)
        {
            WriteToLog(path, "Exception", LogMsgCompare(message, ref previousExceptionMsg));
        }
        /// <summary>
        /// 记录到异常日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteExceptionLog(Exception ex)
        {
            string message = "{" + ex.TargetSite + "}\r\n" + ex;
            WriteExceptionLog(message);
        }
        #endregion

        #region 系统日志
        /// <summary>
        /// 记录到系统日志
        /// </summary>
        /// <param name="message">系统操作消息</param>
        public static void WriteSystemLog(string message)
        {
            WriteToLog(path, "System", LogMsgCompare(message, ref previousSystempMsg));
        }
        #endregion

        #region 操作日志
        /// <summary>
        /// 记录到操作日志
        /// </summary>
        /// <param name="message">操作日志</param>
        public static void WriteOperateLog(string message)
        {
            WriteToLog(path, "Operate", LogMsgCompare(message, ref previousOperateMsg));
        }
        #endregion

        #region 数据采集日志
        /// <summary>
        /// 记录到采集日志
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="message"></param>
        public static void WriteCollectLog(string fileName, string message)
        {
            WriteToLog(path, fileName, message);
        }
        #endregion

        /// <summary>
        /// 日志写入方法
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="message">日志内容</param>
        private static void WriteToLog(string filePath, string fileName, string message)
        {
            if (string.IsNullOrEmpty(filePath) || filePath.Trim() == "")
            {
                filePath = System.AppDomain.CurrentDomain.BaseDirectory;
            }
            // 可能存在多线程对同一资源进行操作的情况，添加同步锁，确保每一个操作都有效。
            lock (lockObject)
            {
                string logDirectory = filePath + "log\\" + DateTime.Now.Year.ToString() + "\\" + DateTime.Now.Month.ToString() + "\\" + DateTime.Now.Day.ToString();
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }
                string path = logDirectory + "\\" + fileName + "_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss:fff") + "]\r\n" + message);
                    sw.Flush();
                    sw.Dispose();
                }
            }
        }
        /// <summary>
        /// 对写入相同文件的消息进行比较，如果相同则简化记录
        /// </summary>
        /// <param name="currentMsg">当前消息</param>
        /// <param name="previousMsg">上一次记录的消息</param>
        /// <returns></returns>
        public static string LogMsgCompare(string currentMsg, ref string previousMsg)
        {
            if (!previousMsg.Equals(currentMsg))
            {
                previousMsg = currentMsg;
            }
            else
            {
                currentMsg = "...";
            }
            return currentMsg;
        }
    }
}
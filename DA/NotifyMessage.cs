using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    public class NotifyMessage
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public static void ShowSuccess(string msg)
        {
            NotifyIcon notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.cranesIcon;
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(2000, "Success", msg, ToolTipIcon.Info);
        }
    }
}

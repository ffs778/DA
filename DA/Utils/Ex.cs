using System;
using System.Reflection;
using System.Windows.Forms;

namespace DA
{
    public static class Ex
    {
        /// <summary>
        /// 双缓冲
        /// </summary>
        /// <param name="dgv"></param>
        public static void DoubleBuffer(this DataGridView dgv)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, true, null);
        }
        /// <summary>
        /// 在panel中显示子界面
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="form"></param>
        public static void ShowInnerForm(this Panel panel, Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.RemoveAllControls();
            panel.Controls.Add(form);
            form.Show();
        }
        /// <summary>
        /// 移除当前控件中的全部控件，释放控件资源，避免出现用户对象或句柄溢出（10000）错误
        /// 特殊控件不可用：datagirdview等
        /// </summary>
        /// <param name="containerControl">可能存在子控件的控件</param>
        public static void RemoveAllControls(this Control containerControl)
        {
            while (containerControl.Controls.Count > 0)
            {
                Control ct = containerControl.Controls[0];
                if (ct is Form)
                {
                    containerControl.Controls.Remove(ct);
                    ct.Dispose();
                }
                ct.RemoveAllControls();
                if (ct.IsDisposed) break;
                containerControl.Controls.Remove(ct);
                ct.Dispose();
            }
        }
    }
}

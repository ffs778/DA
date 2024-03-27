using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    public class MaskLayer
    {
        /// <summary>
        /// 功能加载
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="businessLogic"></param>
        /// <param name="UILogic"></param>
        public static void LoadingFunction(Form parent, Action businessLogic, Action UILogic)
        {
            Task.Run(async () =>
            {
                await Task.Run(businessLogic);  // 逻辑加载
                parent.Invoke(UILogic);         // UI加载
                parent.Invoke(HideMask(parent));// UI中隐藏遮罩层
            });
        }
        /// <summary>
        /// 往窗体中添加遮罩层
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="location"></param>
        /// <param name="size"></param>
        public static void CreateMask(Form parent, Point location, Size size)
        {
            Panel loadingPanel = new Panel
            {
                Name = "loadingPanel",
                Location = location,//new Point(0, flowLayoutPanel1.Height),
                Size = size,// new Size(form.Width, form.Height - flowLayoutPanel1.Height),
                BackColor = parent.BackColor,
                Parent = parent
            };
            PictureBox pictureBox = new PictureBox
            {
                Image = Properties.Resources.Loading,
                SizeMode = PictureBoxSizeMode.CenterImage,
                Dock = DockStyle.Fill,
                Parent = loadingPanel,
            };
            loadingPanel.BringToFront();
        }
        /// <summary>
        /// 从窗体中移除遮罩层
        /// </summary>
        /// <param name="parent"></param>
        public static Action HideMask(Form parent)
        {
            var action = new Action(() =>
            {
                foreach (Control control in parent.Controls)
                {
                    if (control.Name == "loadingPanel")
                    {
                        parent.Controls.Remove(control);
                        break;
                    }
                }
            });
            return action;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    public class SizeChange
    {
        //控件大小随窗体变化
        private float X;//定义当前窗体的宽度
        private float Y;//定义当前窗体的高度

        public float RatioX { get; set; } // 缩放比例
        public float RatioY { get; set; } // 缩放比例
        Control _thisCon;

        public SizeChange(Control con)
        {
            _thisCon = con;
            X = _thisCon.Width;//赋值初始窗体宽度
            Y = _thisCon.Height;//赋值初始窗体高度
            SetTag(_thisCon);
        }
        
        //添加窗体事件Resize（调整控件大小时）
        public void ControlResize(object sender, EventArgs e)
        {
            if (_thisCon == null) return;
            RatioX = _thisCon.Width / X;//获取当前宽度与初始宽度的比例
            RatioY = _thisCon.Height / Y;//获取当前高度与初始高度的比例
            SetControls(RatioX, RatioY, _thisCon);
        }
        //自定义方法setTag（获取控件的width、height、left、top、字体大小等信息的值）
        public void SetTag(Control cons)
        {
            //遍历窗体中的控件
            foreach (Control con in cons.Controls)
            {
                ControlModel model = new ControlModel();
                model.controlWidth = con.Width;
                model.controlHeight = con.Height;
                model.controlLeft = con.Left;
                model.controlTop = con.Top;
                model.controlFontSize = con.Font.Size;
                con.Tag = model;
                if (con.Controls.Count > 0)
                {
                    SetTag(con);
                }
            }
        }
        //自定义方法setControls（根据窗体大小调整控件大小）
        private void SetControls(float ratioX, float ratioY, Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                var model = (ControlModel)con.Tag;
                if (model == null) continue;
                float a = Convert.ToSingle(model.controlWidth) * ratioX;//根据窗体缩放比例确定控件的值，宽度//89*300
                con.Width = (int)(a);//宽度

                a = Convert.ToSingle(model.controlHeight) * ratioY;//根据窗体缩放比例确定控件的值，高度//12*300
                con.Height = (int)(a);//高度

                a = Convert.ToSingle(model.controlLeft) * ratioX;//根据窗体缩放比例确定控件的值，左边距离//
                con.Left = (int)(a);//左边距离

                a = Convert.ToSingle(model.controlTop) * ratioY;//根据窗体缩放比例确定控件的值，上边缘距离
                con.Top = (int)(a);//上边缘距离

                float currentSize = Convert.ToSingle(model.controlFontSize) * ratioY * ratioX;//根据窗体缩放比例确定控件的值，字体大小
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);//字体大小 

                if (con.Controls.Count > 0)
                {
                    SetControls(ratioX, ratioY, con);
                }

                //控件当前宽度=控件初始宽度*(窗体当前宽度/窗体初始宽度)
            }
        }
        public class ControlModel
        {
            public int controlWidth { get; set; }
            public int controlHeight { get; set; }
            public int controlLeft { get; set; }
            public int controlTop { get; set; }
            public float controlFontSize { get; set; }
        }

    }

}

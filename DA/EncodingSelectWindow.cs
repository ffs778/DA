using DA.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DA
{
    /// <summary>
    /// 选择csv的编码格式
    /// </summary>
    public partial class EncodingSelectWindow : Form
    {
        private EncodingType _encodingType;
        public EncodingType EncodingType { get => _encodingType; }
        public EncodingSelectWindow()
        {
            InitializeComponent();
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            if (GB2312_radio.Checked) _encodingType = EncodingType.GB2312;
            else if (UTF8_radio.Checked) _encodingType = EncodingType.UTF8;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

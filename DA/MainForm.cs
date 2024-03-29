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
    public partial class MainForm : Form
    {
        /// <summary>
        ///  初始化读取所有数据表
        ///  选择第一张表
        ///  判断当前数据表是否有配方，筛选数据
        ///  如果配方可用，选择第一个配方
        ///  将配方进行分组
        ///  选择全部数据分组
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.SizeChanged += new SizeChange(this).ControlResize;
        }
        SingleRecipeAnalysisForm _singleDAForm;
        CompareSameTimeForm _multiDAForm;
        private void MainForm_Shown(object sender, EventArgs e)
        {
            OpenSingleDAForm();
            ChangeBackColorStateForm(singleDA_tsmi);
        }
        /// <summary>
        /// 单开单工艺分析窗口
        /// </summary>
        private void OpenSingleDAForm()
        {
            if (_singleDAForm != null && !_singleDAForm.IsDisposed)
            {
                if (showForm_panel.Controls[0].Name != _singleDAForm.Name) showForm_panel.ShowInnerForm(_singleDAForm);
                return;
            }
            MaskLayer.CreateMask(this, new Point(0, menuStrip1.Height), this.Size);   // 添加遮罩层
            MaskLayer.LoadingFunction(this,
                new Action(() => { _singleDAForm = new SingleRecipeAnalysisForm(); }),
                new Action(() => { showForm_panel.ShowInnerForm(_singleDAForm); }));
        }
        /// <summary>
        /// 打开多步骤分析窗口
        /// </summary>
        private void OpenMultiDAForm()
        {
            if (_multiDAForm != null && !_multiDAForm.IsDisposed)
            {
                if (showForm_panel.Controls[0].Name != _multiDAForm.Name) showForm_panel.ShowInnerForm(_multiDAForm);
                return;
            }
            MaskLayer.CreateMask(this, new Point(0, menuStrip1.Height), this.Size);   // 添加遮罩层
            MaskLayer.LoadingFunction(this,
                new Action(() => { _multiDAForm = new CompareSameTimeForm(); }),
                new Action(() => { showForm_panel.ShowInnerForm(_multiDAForm); }));
        }
        /// <summary>
        /// 数据导入
        /// </summary>
        private void Import()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DAL.ImportCsvFile(openFileDialog.FileName);
            }
        }
        /// <summary>
        /// 切换颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="form"></param>
        private void ChangeBackColorStateForm(object sender)
        {
            var contorl = sender as ToolStripMenuItem;
            for (int i = 0; i < menuStrip1.Items.Count; i++)
            {
                menuStrip1.Items[i].BackColor =
                    menuStrip1.Items[i].Text == contorl.Text ?
                    Color.FromKnownColor(KnownColor.HotTrack) :     // 选中
                    Color.FromKnownColor(KnownColor.MenuHighlight); // 未选中
            }
        }
        private void SingleDA_tsmi_Click(object sender, EventArgs e)
        {
            OpenSingleDAForm();
            ChangeBackColorStateForm(sender);
        }
        private void MultiDA_tsmi_Click(object sender, EventArgs e)
        {
            OpenMultiDAForm();
            ChangeBackColorStateForm(sender);
        }
        private void Import_tsmi_Click(object sender, EventArgs e) => Import();
        #region 减少闪烁
        /// <summary>
        /// 减少界面闪烁
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion
    }
}

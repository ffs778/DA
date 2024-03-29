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
    public partial class CompareSameTimeForm : Form
    {
        /// <summary>
        ///  初始化读取所有数据表
        ///  选择第一张表
        ///  判断当前数据表是否有配方，筛选数据
        ///  如果配方可用，选择第一个配方
        ///  查询配方的所有历史数据，选择第一步，第一秒
        /// </summary>
        public CompareSameTimeForm()
        {
            InitializeComponent();
            collectData_dgv.DoubleBuffer();
            pager1.PagerDgv = collectData_dgv;
        }
        #region 下拉框初始化
        /// <summary>
        /// 初始化表下拉框
        /// </summary>
        private void InitailFuncComboBox()
        {
            func_cmb.Items.Clear();
            func_cmb.Items.AddRange(DAL.GetTableName());
            func_cmb.SelectedIndex = 0;
        }
        /// <summary>
        /// 初始化配方下拉框
        /// </summary>
        private void InitialRecipeComboBox()
        {
            recipe_cmb.Items.Clear();
            recipe_cmb.Items.AddRange(DAL.GetRecipes(func_cmb.SelectedItem.ToString()));
            recipe_cmb.SelectedIndex = 0;
        }
        /// <summary>
        /// 初始化步数下拉框
        /// </summary>
        private void InitialStepComboBox()
        {
            step_cmb.Items.Clear();
            step_cmb.Items.AddRange(DAL.GetDistinctStep(func_cmb.SelectedItem.ToString(), recipe_cmb.SelectedItem.ToString()));
            step_cmb.SelectedIndex = 0;
        }
        /// <summary>
        /// 初始化时间下拉框
        /// </summary>
        private void InitialTimeComboBox()
        {
            time_cmb.Items.Clear();
            time_cmb.Items.AddRange(DAL.GetDistinctTime(func_cmb.SelectedItem.ToString(), recipe_cmb.SelectedItem.ToString(), step_cmb.SelectedItem.ToString()));
            time_cmb.SelectedIndex = 0;
        }
        #endregion

        private void CompareSameTimeForm_Shown(object sender, EventArgs e)
        {
            InitailFuncComboBox();
        }
        /// <summary>
        /// 切换数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Func_cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            InitialRecipeComboBox();
        }
        /// <summary>
        /// 切换配方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recipe_cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            InitialStepComboBox();
        }
        /// <summary>
        /// 切换工艺步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Step_cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            InitialTimeComboBox();
        }
        /// <summary>
        /// 切换时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Time_cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            GetData();
            InitialDataGridViewColumnWidth();
        }
        /// <summary>
        /// 初始化筛选框
        /// </summary>

        private void InitialDataGridViewColumnWidth()
        {
            for (int i = 0; i < collectData_dgv.Columns.Count; i++)
            {
                collectData_dgv.Columns[i].Width = 200;
            }
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        private void GetData()
        {
            pager1.ConditionQueryText = $"select * from [{func_cmb.SelectedItem}] where [配方名称] = '{recipe_cmb.SelectedItem}' and [当前工艺步] = '{step_cmb.SelectedItem}' and [当前工艺时间] = '{time_cmb.SelectedItem}'";
            pager1.RefreshData();
            // 刷新图表
            RefreshPlot(chartform);
        }
        #region 图表切换

        #region 历史数据图表
        HistoryChartForm chartform;
        private void Graph_Switch_Click(object sender, EventArgs e)
        {
            if (chartform != null && !chartform.IsDisposed) return;
            // 生成历史数据图表
            formData_picb.Image = Properties.Resources.form;
            chart1Data_picb.Image = Properties.Resources.chart2Selected;
            pager1.Visible = false;
            collectData_dgv.Visible = false;
            MaskLayer.CreateMask(this, new Point(0, flowLayoutPanel1.Height), this.Size);   // 添加遮罩层
            MaskLayer.LoadingFunction(this,
                new Action(() => { chartform = new HistoryChartForm(GetChartFormParamModel()); }),
                new Action(() => ShowChartForm(chartform)));
        }
        #endregion

        #region 数据表
        private void FormData_picb_Click(object sender, EventArgs e)
        {
            if (collectData_dgv.Visible) return;
            formData_picb.Image = Properties.Resources.formSelected;
            chart1Data_picb.Image = Properties.Resources.chart2;
            collectData_dgv.Visible = true;
            pager1.Visible = true;

            RemovePlot(chartform);
        }
        #endregion
        /// <summary>
        /// 获得图表对象实参
        /// </summary>
        /// <returns></returns>
        private ChartFormParamModel GetChartFormParamModel()
        {
            DataTable pagedData = collectData_dgv.DataSource as DataTable;
            // X轴标签
            var chartLabels = pagedData.AsEnumerable().Select(x => x.Field<string>("数据采集时间")).Select(x => x.ToString()).Reverse().ToArray();
            var pagedDataNew = pagedData.Copy();
            List<ChartDataModel> chartDataModels = new List<ChartDataModel>();
            //列名切换为中文
            for (int i = 0; i < pagedData.Columns.Count; i++)
            {
                if (collectData_dgv.Columns[i].HeaderText.Contains("工艺步") ||
                    collectData_dgv.Columns[i].HeaderText.Contains("时间") ||
                    collectData_dgv.Columns[i].HeaderText.Contains("倒计时")) continue;
                double[] data;
                try
                {
                    data = pagedDataNew.AsEnumerable().Select(x => x.Field<string>(collectData_dgv.Columns[i].HeaderText)).Select(y => double.Parse(y)).Reverse().ToArray();
                }
                catch
                {
                    continue;
                }
                ChartDataModel dataModel = new ChartDataModel();
                dataModel.Description = collectData_dgv.Columns[i].HeaderText;
                dataModel.Data = data;
                chartDataModels.Add(dataModel);
            }

            ChartFormParamModel model = new()
            {
                ChartDataModels = chartDataModels,
                Labels = chartLabels,
                Tag = func_cmb.SelectedItem.ToString()
            };
            return model;
        }
        /// <summary>
        /// 添加图表
        /// </summary>
        private void ShowChartForm(HistoryChartForm plotForm)
        {
            plotForm.TopLevel = false;
            plotForm.FormBorderStyle = FormBorderStyle.None;
            plotForm.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Controls.Add(plotForm);
            plotForm.Show();
        }
        /// <summary>
        /// 移除图表
        /// </summary>
        private void RemovePlot(HistoryChartForm plotForm)
        {
            if (plotForm == null || plotForm.IsDisposed) return;
            this.tableLayoutPanel1.Controls.Remove(plotForm);
            plotForm.Dispose();
        }
        private void RefreshPlot(HistoryChartForm plotForm)
        {
            if (plotForm == null || plotForm.IsDisposed) return;
            plotForm.RefreshDataInPlot(GetChartFormParamModel());
        }
        #endregion


    }
}

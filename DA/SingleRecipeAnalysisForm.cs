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
    public partial class SingleRecipeAnalysisForm : Form
    {
        /// <summary>
        ///  初始化读取所有数据表
        ///  选择第一张表
        ///  判断当前数据表是否有配方，筛选数据
        ///  如果配方可用，选择第一个配方
        ///  将配方进行分组
        ///  选择全部数据分组
        /// </summary>
        public SingleRecipeAnalysisForm()
        {
            InitializeComponent();
            collectData_dgv.DoubleBuffer();
            pager1.PagerDgv = collectData_dgv;

        }
        private void SingleRecipeAnalysisForm_Shown(object sender, EventArgs e)
        {
            InitailComboBox();
            InitialDataGridViewColumnWidth();
        }
        /// <summary>
        /// 初始化筛选框
        /// </summary>
        private void InitailComboBox()
        {
            dataTable_cmb.Items.AddRange(DAL.GetTableName());
            dataTable_cmb.SelectedIndex = 0;
            JudgeRecipe();
        }
        private void InitialDataGridViewColumnWidth()
        {
            for (int i = 0; i < collectData_dgv.Columns.Count; i++)
            {
                collectData_dgv.Columns[i].Width = 200;
            }
        }
        /// <summary>
        /// 查找数据
        /// </summary>
        private void GetData()
        {
            pager1.ConditionQueryText = recipe_cmb.Enabled ? $"select * from [{dataTable_cmb.SelectedItem}] where [配方名称] = '{recipe_cmb.SelectedItem}' order by 数据采集时间 Desc" : $"select * from [{dataTable_cmb.SelectedItem}] order by 数据采集时间 Desc";
            pager1.RefreshData();
            // 刷新图表
            RefreshPlot(chartform);
        }
        /// <summary>
        /// 配方筛选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recipe_cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            GetData();
            InitialGroup();
        }
        /// <summary>
        /// 切换数据表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Func_cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            JudgeRecipe();
            GetData();
            InitialDataGridViewColumnWidth();
        }
        /// <summary>
        /// 判断是否存在配方字段
        /// </summary>
        private void JudgeRecipe()
        {
            recipe_cmb.Items.Clear();
            // 如果存在配方字段
            if (DAL.ExistRecipe(dataTable_cmb.SelectedItem.ToString()))
            {
                recipe_cmb.Enabled = true;
                recipe_cmb.Items.AddRange(DAL.GetRecipes(dataTable_cmb.SelectedItem.ToString()));
                recipe_cmb.SelectedIndex = 0;
            }
            else
            {
                recipe_cmb.Enabled = false;
            }
        }
        List<string> _timeFlagList;
        /// <summary>
        /// 获得单次分组信息
        /// </summary>
        private void InitialGroup()
        {
            _timeFlagList = GetTimeFlag();
            // 1. 根据时间节点得到分组信息： 组数=  节点 -1 ；
            int groupCount = _timeFlagList.ToArray().Length - 1;
            group_cmb.Items.Clear();
            group_cmb.Items.Add("全部");
            group_cmb.Items.AddRange(GetRange(groupCount));
            group_cmb.SelectedIndex = 0;
        }
        /// <summary>
        /// 获得分组范围
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string[] GetRange(int num)
        {
            List<string> list = new List<string>(num);
            for (int i = 1; i <= num; i++)
            {
                list.Add(i.ToString());
            }
            return list.ToArray();
        }
        /// <summary>
        /// 获得时间节点信息
        /// </summary>
        /// <returns></returns>
        private List<string> GetTimeFlag()
        {
            // 1. 得到时间、工艺步
            var data = DAL.GetTimeAndCraftStep(dataTable_cmb.SelectedItem.ToString(), recipe_cmb.SelectedItem.ToString());
            int flagStep = Convert.ToInt32(data.Rows[0][1]);
            string endTime = data.Rows[0][0].ToString();   // 第一个时间
            string startTime = data.Rows[data.Rows.Count - 1][0].ToString();  // 最后一个时间
            List<string> timeFlagList = new List<string>();
            timeFlagList.Add(endTime);
            // 2. 得到时间节点信息。
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (flagStep == Convert.ToInt32(data.Rows[i][1])) { }
                else if (flagStep == Convert.ToInt32(data.Rows[i][1]) + 1)
                {
                    flagStep = Convert.ToInt32(data.Rows[i][1]);    // 替换新值
                }
                else
                {
                    flagStep = Convert.ToInt32(data.Rows[i][1]);    // 替换新值
                    timeFlagList.Add(data.Rows[i][0].ToString());   // 记录时间标记
                }
            }
            timeFlagList.Add(startTime);
            return timeFlagList;
        }
        /// <summary>
        /// 切换分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Group_cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            if (group_cmb.SelectedItem.ToString() == "全部")
            {
                pager1.ConditionQueryText = $"select * from [{dataTable_cmb.SelectedItem}] where [配方名称] = '{recipe_cmb.SelectedItem}' order by 数据采集时间 Desc";
            }
            else
            {
                var timeFlags = _timeFlagList.ToArray();
                string endTime = timeFlags[Convert.ToInt32(group_cmb.SelectedItem) - 1];
                string startTime = timeFlags[Convert.ToInt32(group_cmb.SelectedItem)];
                pager1.ConditionQueryText = $"select * from [{dataTable_cmb.SelectedItem}] where [数据采集时间] > '{startTime}' and [数据采集时间] <= '{endTime}' and [配方名称] = '{recipe_cmb.SelectedItem}' order by 数据采集时间 Desc";
            }
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
            DataTable pagedData = null;
            DataTable pagedDataNew = null;
            string cavityName = string.Empty;
            this.Invoke(new Action(() =>
            {
                pagedData = collectData_dgv.DataSource as DataTable;
                cavityName = dataTable_cmb.SelectedItem.ToString();
                pagedDataNew = pagedData.Copy();
                //列名切换为中文
                for (int i = 0; i < pagedDataNew.Columns.Count; i++)
                {
                    pagedDataNew.Columns[i].ColumnName = collectData_dgv.Columns[i].HeaderText;
                }
            }));

            // X轴标签
            var chartLabels = pagedData.AsEnumerable().Select(x => x.Field<string>("数据采集时间")).Select(x => x.ToString()).Reverse().ToArray();
            var recipes = pagedData.AsEnumerable().Select(x => x.Field<string>("配方名称")).Select(x => x.ToString()).Reverse().ToArray();
            List<ChartDataModel> chartDataModels = new List<ChartDataModel>();

            for (int i = 0; i < pagedDataNew.Columns.Count; i++)
            {
                if (pagedDataNew.Columns[i].ColumnName.Contains("工艺步") ||
                    pagedDataNew.Columns[i].ColumnName.Contains("时间") ||
                    pagedDataNew.Columns[i].ColumnName.Contains("倒计时") ||
                    pagedDataNew.Columns[i].ColumnName.Contains("载板编号")||
                    pagedDataNew.Columns[i].ColumnName.Contains("配方名称")
                    ) continue;
                ChartDataModel dataModel = new ChartDataModel();
                dataModel.Description = pagedDataNew.Columns[i].ColumnName;
                dataModel.Data = pagedDataNew.AsEnumerable().Select(x => x.Field<string>(pagedDataNew.Columns[i].ColumnName)).Select(y => double.Parse(y)).Reverse().ToArray(); ;
                chartDataModels.Add(dataModel);
            }

            ChartFormParamModel model = new()
            {
                ChartDataModels = chartDataModels,
                Labels = chartLabels,
                CavityName = cavityName,
                Recipe = recipes
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

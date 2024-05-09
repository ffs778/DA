using DA;
using ScottPlot;
using ScottPlot.Plottable;
using ScottPlot.Renderable;
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
    /// 历史数据转图表
    /// </summary>
    public partial class HistoryChartForm : Form
    {
        public Plot _plot;  // 图表  
        public string[] _timeLabelArray;//x轴描述
        string[] _recipes;// 数据对应的配方名称
        List<double[]> _paramValueArrayList;// 值
        protected List<SignalPlot> _paramSigList; // 折线
        List<int> _seletList;//选中参数的索引
        string _cavityName;    // 用于判断界面是否需要完全重新初始化，比如切换腔体的时候，参数类目、数量可能发生改变，此时tag记录腔体名称
        double _sampleRate = 1;

        public HistoryChartForm(ChartFormParamModel model)
        {
            InitializeComponent();
            _seletList = new(model.ChartDataModels.Count);
            _plot = formsPlot1.Plot;
            _cavityName = model.CavityName;
            _recipes = model.Recipe;
            InitialDataFlowPanel(model.ChartDataModels.AsEnumerable().Select(x => x.Description).ToArray());
            InitialData(model.ChartDataModels, model.Labels);
            InitialCreateAllSig();
            var firstPower = paramList_flPanel.Controls[0] as CheckBox;
            firstPower.Checked = true;
            InitialPlot(_timeLabelArray.Length);
        }
        #region 初始化处理界面中需要的全部数据

        private void InitialData(List<ChartDataModel> model, string[] labels)
        {
            // 1. 时间
            _timeLabelArray = labels;
            // 2. 参数集合初始化
            _paramValueArrayList = new(model.Count);
            _paramValueArrayList.AddRange(model.Select(x => x.Data));
            for (int i = 0; i < model.Count; i++)
            {
                _paramValueArrayList.Add(model[i].Data);
            }
            // 3. 定采样率
            if (_timeLabelArray.Length > 3000)
            {
                _sampleRate = _timeLabelArray.Length;
                toolTipsShow_cbx.Enabled = false;
                toolTipsShow_cbx.Checked = false;
            }
        }
        #endregion

        #region 初始化Plot

        /// <summary>
        /// 初始化图表
        /// </summary>
        public void InitialPlot(int dataLength)
        {
            var positions = GetPositions(dataLength);
            _plot.XTicks(positions, _timeLabelArray);  // X轴刻度添加对应的标签
            _plot.YAxis.Color(Color.Black);  // 设置轴的颜色
            _plot.Title($"历史数据折线图表");
            _plot.XAxis.Ticks(false);   // 不显示横轴标签
        }
        #endregion

        #region 初始化折线
        /// <summary>
        /// 初始化生成所有折线
        /// </summary>
        private void InitialCreateAllSig()
        {
            _paramSigList = new(_paramValueArrayList.Count);
            for (int i = 0; i < _paramValueArrayList.Count; i++)
            {
                _paramSigList.Add(CreateSig(_paramValueArrayList[i], ColorTranslator.FromHtml(DA.Palette.HexColors2[i % Palette.HexColors2.Length]), _plot.YAxis.AxisIndex, null));
            }
        }
        /// <summary>
        /// 创建曲线
        /// </summary>
        /// <param name="dataArray"></param>
        /// <param name="sigColor"></param>
        /// <param name="axisIndex"></param>
        /// <param name="label">图例标签</param>
        /// <returns></returns>
        public SignalPlot CreateSig(double[] dataArray, Color sigColor, int axisIndex, string label)
        {
            var sig = _plot.AddSignal(dataArray, label: label, sampleRate: _sampleRate);
            sig.YAxisIndex = axisIndex;    // 折线图绑定轴
            sig.Color = sigColor; // 折线颜色
            sig.IsVisible = false;//初始化不可见
            return sig;
        }
        #endregion

        #region 初始化全部参数单选框
        /// <summary>
        /// 初始化全部参数单选框
        /// </summary>
        /// <param name="dataNameArray"></param>
        private void InitialDataFlowPanel(string[] dataNameArray)
        {
            for (int i = 0; i < dataNameArray.Length; i++)
            {
                CheckBox checkBox = new()
                {
                    Text = dataNameArray[i],
                    AutoSize = true,
                    Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point),
                    ForeColor = ColorTranslator.FromHtml(DA.Palette.HexColors2[i%Palette.HexColors2.Length]),
                    Tag = i
                };
                checkBox.CheckStateChanged += CheckBox_CheckStateChanged;
                paramList_flPanel.Controls.Add(checkBox);
            }
        }
        #endregion

        #region 参数单选框点击事件
        /// <summary>
        /// 点击选择参数,显示或隐藏热丝曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            RemoveToolTips();
            // 显示和隐藏曲线
            var checkBox = sender as CheckBox;
            if (_paramSigList == null)
            {
                checkBox.Checked = false;
                return;
            }
            int paramIndex = Convert.ToInt32(checkBox.Tag); // 获得当前点击的参数索引
            _paramSigList[paramIndex].IsVisible = checkBox.Checked; // 参数曲线的可见性

            // 记录/移除当前勾选的索引
            if (checkBox.Checked)
            {
                _seletList.Add(paramIndex);
            }
            else
            {
                _seletList.Remove(paramIndex);
            }
            // 刷新图表
            _plot.AxisAuto();
            formsPlot1.Refresh();
        }
        #endregion

        #region 刷新图表中的数据

        public void RefreshDataInPlot(ChartFormParamModel model)
        {
            _plot.Clear();
            if (_cavityName != model.CavityName)   // 切换了腔体，需要重新绘制参数类目，重新选择
            {
                _seletList = new(model.ChartDataModels.Count);
                paramList_flPanel.RemoveAllControls();
                InitialDataFlowPanel(model.ChartDataModels.AsEnumerable().Select(x => x.Description).ToArray());
                allSelect_cbx.Checked = false;
                var firstPower = paramList_flPanel.Controls[0] as CheckBox;
                firstPower.Checked = true;
                _cavityName = model.CavityName;
            }
            _recipes = model.Recipe;
            InitialData(model.ChartDataModels, model.Labels);
            InitialCreateAllSig();
            var positions = GetPositions(_timeLabelArray.Length);
            _plot.XTicks(positions, _timeLabelArray);  // X轴刻度添加对应的标签
            // 保持当前勾选项的状态
            for (int i = 0; i < _seletList.Count; i++)
            {
                _paramSigList[_seletList[i]].IsVisible = true;
            }
            InitialPlot(_timeLabelArray.Length);
            formsPlot1.Refresh();
        }
        #endregion

        #region 全选
        private void AllSelect_cbx_CheckedChanged(object sender, EventArgs e)
        {
            RemoveToolTips();
            foreach (CheckBox checkBox in paramList_flPanel.Controls)
            {
                checkBox.Checked = allSelect_cbx.Checked;   // 所有热丝的选中状态与全选框保持一致
            }
        }
        #endregion

        /// <summary>
        /// 根据元素数量生成位置数组
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double[] GetPositions(int count)
        {
            return Enumerable.Range(0, count).Select(x => (double)x).ToArray();
        }

        #region 显示ToolTips

        protected List<Tooltip> _tipsList = new();
        protected bool _isShowTooltips = true;    // 默认显示
        protected virtual void FormsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_timeLabelArray.Length == 0) return;
            RemoveToolTips();
            (double mouseCoordX, _) = formsPlot1.GetMouseCoordinates();
            StringBuilder sb = new StringBuilder();
            int timeIndex = 0;
            bool haveRecipe = _recipes != null && _recipes.Length > 0;  // 是否数据中包含配方
            for (int i = 0; i < _paramSigList.Count; i++)
            {
                if (!_paramSigList[i].IsVisible) continue;  // 不可见的曲线不显示
                (_, double pointY, int pointIndex) = _paramSigList[i].GetPointNearestX(mouseCoordX);
                if (_isShowTooltips)
                {
                    string recipeTips = haveRecipe ? $"{Environment.NewLine}配方：{_recipes[pointIndex]}" : "";
                    string msg = $"" +
                    $"类型：{paramList_flPanel.Controls[i].Text}{Environment.NewLine}" +
                    $"数据：{pointY}{Environment.NewLine}" +
                    $"时间：{_timeLabelArray[pointIndex]}" + recipeTips;
                    _tipsList.Add(_plot.AddTooltip(msg, x: pointIndex, y: pointY));
                }
                sb.Append($"【{paramList_flPanel.Controls[i].Text}：{pointY}】");
                timeIndex = pointIndex;
            }
            string recipeMsg = haveRecipe ? $"【配方：{_recipes[timeIndex]}】" : "";
            timeTips_lab.Text = $"-->【时间：{_timeLabelArray[timeIndex]}】{recipeMsg}{sb}";
            formsPlot1.Refresh();
        }
        /// <summary>
        /// 移除图标中的tooltips
        /// </summary>
        protected void RemoveToolTips()
        {
            if (_tipsList.Count > 0) _tipsList.ForEach(x => _plot.Remove(x));
        }
        /// <summary>
        /// 切换显示ToolTips，避免遮挡数据点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TooltipsShow_cbx_CheckedChanged(object sender, EventArgs e)
        {
            _isShowTooltips = toolTipsShow_cbx.Checked;
            if (!_isShowTooltips) RemoveToolTips();//如果不显示，则移除现有ToolTips
            formsPlot1.Refresh();
        }
        #endregion
    }
}


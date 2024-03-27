using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DA
{
    /// <summary>
    /// 历史数据转图表
    /// </summary>
    public partial class HistoryChartForm : Form
    {
        public Plot _plot;  // 图表  
        public string[] _timerLabelArray;//时间描述
        List<double[]> _paramValueArrayList;// 值
        List<SignalPlot> _paramSigList; // 折线
        List<int> _seletList;//选中参数的索引
        string _cavityName;
        double _sampleRate = 1;

        public HistoryChartForm(ChartFormParamModel model)
        {
            InitializeComponent();
            _seletList = new(model.ChartDataModels.Count);
            _plot = formsPlot1.Plot;
            _cavityName = model.Tag;
            InitialDataFlowPanel(model.ChartDataModels.AsEnumerable().Select(x => x.Description).ToArray());
            InitialData(model.ChartDataModels, model.Labels);
            InitialCreateAllSig();
            var firstPower = paramList_flPanel.Controls[0] as CheckBox;
            firstPower.Checked = true;
            InitialPlot(_timerLabelArray.Length);
        }
        #region 初始化处理界面中需要的全部数据

        private void InitialData(List<ChartDataModel> model, string[] labels)
        {
            // 1. 时间
            _timerLabelArray = labels;
            // 2. 参数集合初始化
            _paramValueArrayList = new(model.Count);
            for (int i = 0; i < model.Count; i++)
            {
                _paramValueArrayList.Add(model[i].Data);
            }
            // 3. 定采样率
            if (_timerLabelArray.Length > 3000)
            {
                _sampleRate = _timerLabelArray.Length;
                toolTipsShow_cbx.Enabled = false;
                timeTips_lab.Visible = true;
                MessageBox.Show("加载大数据正在进行图标优化");
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
            _plot.XTicks(positions, _timerLabelArray);  // X轴刻度添加对应的标签
            _plot.XAxis.TickLabelStyle(rotation: 20); // 文字逆时针旋转20°
            // _plot.YAxis.Label("");    // Y轴标签
            _plot.YAxis.Color(Color.Black);  // 设置轴的颜色
            // 设置垂直轴最小值为0；适应数据以后设置将被重置
            //_plot.SetAxisLimits(yMin: -2, yMax: 30);   // 默认轴
            //var legend = _plot.Legend();
            //legend.FontSize = 15;
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
                _paramSigList.Add(CreateSig(_paramValueArrayList[i], ColorTranslator.FromHtml(Palette.HexDeepColors[i % Palette.HexDeepColors.Length]), _plot.YAxis.AxisIndex, null));
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
                    ForeColor = ColorTranslator.FromHtml(Palette.HexDeepColors[i % Palette.HexDeepColors.Length]),
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
            if (_cavityName != model.Tag)   // 切换了腔体，需要重新绘制参数类目，重新选择
            {
                _seletList = new(model.ChartDataModels.Count);
                paramList_flPanel.RemoveAllControls();
                InitialDataFlowPanel(model.ChartDataModels.AsEnumerable().Select(x => x.Description).ToArray());
                allSelect_cbx.Checked = false;
                var firstPower = paramList_flPanel.Controls[0] as CheckBox;
                firstPower.Checked = true;
                _cavityName = model.Tag;
            }

            InitialData(model.ChartDataModels, model.Labels);
            InitialCreateAllSig();
            var positions = GetPositions(_timerLabelArray.Length);
            _plot.XTicks(positions, _timerLabelArray);  // X轴刻度添加对应的标签
            // 保持当前勾选项的状态
            for (int i = 0; i < _seletList.Count; i++)
            {
                _paramSigList[_seletList[i]].IsVisible = true;
            }
            InitialPlot(_timerLabelArray.Length);
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
            List<double> tempList = new List<double>();
            for (int i = 0; i < count; i++)
            {
                tempList.Add(i);
            }
            return tempList.ToArray();
        }

        #region 显示ToolTips

        List<Tooltip> _tipsList = new();
        bool _isShowTooltips = true;    // 默认显示
        private void FormsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isShowTooltips) return;
            RemoveToolTips();
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            for (int i = 0; i < _paramSigList.Count; i++)
            {
                if (!_paramSigList[i].IsVisible) continue;
                (double pointX, double pointY, int pointIndex) = _paramSigList[i].GetPointNearestX(mouseCoordX);
                string msg = $"" +
                    $"类型：{paramList_flPanel.Controls[i].Text}{Environment.NewLine}" +
                    $"数据：{pointY}{ Environment.NewLine}" +
                    $"时间：{_timerLabelArray[pointIndex]}";
                _tipsList.Add(_plot.AddTooltip(msg, x: pointIndex, y: pointY));
                timeTips_lab.Text = $"时间：{_timerLabelArray[pointIndex]}";
            }
            formsPlot1.Refresh();
        }
        /// <summary>
        /// 移除图标中的tooltips
        /// </summary>
        private void RemoveToolTips()
        {
            if (_tipsList.Count > 0)
            {
                for (int i = 0; i < _tipsList.Count; i++)
                {
                    _plot.Remove(_tipsList[i]);
                }
            }
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


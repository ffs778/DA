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
        List<Text[]> _paramsTextArrayList;// 标签
        List<double[]> _paramValueArrayList;// 值
        List<SignalPlot> _paramSigList; // 折线
        List<int> _seletList;//选中参数的索引
        string _cavityName;
        VLine _vLine;   // 标记线

        public HistoryChartForm(ChartFormParamModel model)
        {
            InitializeComponent();
            _seletList = new(model.ChartDataModels.Count);
            _plot = formsPlot1.Plot;
            _cavityName = model.Tag;
            InitialDataFlowPanel(model.ChartDataModels.AsEnumerable().Select(x => x.Description).ToArray());
            InitialData(model.ChartDataModels, model.Labels);
            InitialCreateAllSig();
            _vLine = CreateVLine();
            _plot.Add(_vLine);
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
        }

        #endregion

        #region 初始化折线
        /// <summary>
        /// 初始化生成所有折线
        /// </summary>
        private void InitialCreateAllSig()
        {
            _paramSigList = new(_paramValueArrayList.Count);
            _paramsTextArrayList = new(_paramValueArrayList.Count);
            for (int i = 0; i < _paramValueArrayList.Count; i++)
            {
                _paramSigList.Add(CreateSig(_paramValueArrayList[i], ColorTranslator.FromHtml(Palette.HexDeepColors[i % Palette.HexDeepColors.Length]), _plot.YAxis.AxisIndex, null));
                _paramsTextArrayList.Add(CreateSigText(_paramValueArrayList[i], ColorTranslator.FromHtml(Palette.HexDeepColors[i % Palette.HexDeepColors.Length]), _plot.YAxis.AxisIndex));
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
            var sig = _plot.AddSignal(dataArray, label: label);
            sig.YAxisIndex = axisIndex;    // 折线图绑定轴
            sig.Color = sigColor; // 折线颜色
            sig.IsVisible = false;//初始化不可见
            return sig;
        }
        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="dataArray"></param>
        /// <param name="textColor"></param>
        /// <param name="axisIndex"></param>
        /// <returns></returns>
        public Text[] CreateSigText(double[] dataArray, Color textColor, int axisIndex)
        {
            Text[] texts = new Text[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
            {
                var txt = _plot.AddText(dataArray[i].ToString(), i, dataArray[i]);  // 在坐标轴位置放置指定文本
                txt.Alignment = Alignment.LowerCenter;
                txt.YAxisIndex = axisIndex;
                txt.FontSize = 15;
                txt.Color = textColor;   // 数值颜色
                txt.IsVisible = false;  // 初始化数据不可见
                texts[i] = txt;
            }
            return texts;
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
            // 显示和隐藏曲线
            var checkBox = sender as CheckBox;
            if (_paramSigList == null)
            {
                checkBox.Checked = false;
                return;
            }
            int paramIndex = Convert.ToInt32(checkBox.Tag); // 获得当前点击的参数索引
            _paramSigList[paramIndex].IsVisible = checkBox.Checked; // 参数曲线的可见性
            ValueLabelVisible(_paramsTextArrayList[paramIndex], _paramSigList[paramIndex].IsVisible && valueVisible_cbx.Checked);

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

        #region 显示数值
        private void ValueVisible_cbx_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < _seletList.Count; i++)
            {
                ValueLabelVisible(_paramsTextArrayList[_seletList[i]], valueVisible_cbx.Checked);
            }
            formsPlot1.Refresh();
        }
        /// <summary>
        /// 折线标签可见性
        /// </summary>
        /// <param name="lineText"></param>
        /// <param name="isVisible"></param>
        public static void ValueLabelVisible(Text[] lineText, bool isVisible)
        {
            foreach (var item in lineText)
            {
                item.IsVisible = isVisible;
            }
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
            _vLine = CreateVLine();
            _plot.Add(_vLine);
            // 保持当前勾选项的状态
            for (int i = 0; i < _seletList.Count; i++)
            {
                _paramSigList[_seletList[i]].IsVisible = true;
                // 根据线的可见性，处理数据标签的可见性
                ValueLabelVisible(_paramsTextArrayList[_seletList[i]], valueVisible_cbx.Checked);
            }
            InitialPlot(_timerLabelArray.Length);
            formsPlot1.Refresh();
        }
        #endregion

        #region 全选
        private void AllSelect_cbx_CheckedChanged(object sender, EventArgs e)
        {
            AllSelect();
        }
        private void AllSelect()
        {
            foreach (CheckBox checkBox in paramList_flPanel.Controls)
            {
                checkBox.Checked = allSelect_cbx.Checked;   // 所有热丝的选中状态与全选框保持一致
            }
        }
        #endregion
        /// <summary>
        /// 标记线切换显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VLine_cbx_CheckedChanged(object sender, EventArgs e)
        {
            _vLine.IsVisible = VLine_cbx.Checked;
            formsPlot1.Refresh();
        }


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


        #region 添加标记线
        private VLine CreateVLine()
        {
            var vLine = new VLine()
            {
                X = 0,
                Label = "",
                PositionLabelOppositeAxis = true,
                PositionLabelAxis = _plot.XAxis,
                PositionFormatter = GetVLineLabel,
                PositionLabel = true,          // 是否在轴上标记线对应的值
                DragEnabled = true,            // 是否允许拖动
                IsVisible = VLine_cbx.Checked
            };
            return vLine;
        }
        private string GetVLineLabel(double position)
        {
            if (_timerLabelArray.Length == 0) return "";
            var index = Convert.ToInt32(position);
            if (index <= 0)
            {
                return _timerLabelArray[0];
            }
            else if (index > _timerLabelArray.Length - 1)
            {
                return _timerLabelArray[_timerLabelArray.Length - 1];
            }
            return _timerLabelArray[index];
        }
        #endregion
    }
}


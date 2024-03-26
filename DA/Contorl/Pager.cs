using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DA
{
    public partial class Pager : UserControl
    {
        #region 字段
        int _pagerWidth;    // 控件长度，用于自动缩放
        int _currentPageIndex = 1;
        Color _pagerBackColor;
        int _totalCount;
        int _pageSize = 300;
        string _conditionQueryText;
        DataGridView _dataGridView = new();

        #endregion

        #region 属性
        [Description("分页控件绑定的DataGridView对象")]
        public DataGridView PagerDgv
        {
            get => _dataGridView;
            set
            {
                _dataGridView = value;
            }
        }

        [Description("条件查询语句-需拼接分页查询语句")]
        public string ConditionQueryText
        {
            get => _conditionQueryText;
            set { if (value != null) { _conditionQueryText = value; } }
        }


        [Description("分页控件的每页数据量")]
        public int PageSize
        {
            get => _pageSize;
            set { if (value > 0) { _pageSize = value; } }
        }


        [Description("分页控件的背景颜色")]
        public Color PagerBackColor
        {
            get { return _pagerBackColor; }
            set
            {
                _pagerBackColor = value;
                this.flowLayoutPanel1.BackColor = value;
            }
        }
        #endregion

        public Pager()
        {
            InitializeComponent();
            _pagerWidth = this.Width;    // 获取控件默认长度
            pageSize_numUpDown.Value = _pageSize;
        }

        #region 修改每页数据量
        private void Confirm_btn_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        //修改每页大小
        private void PageSize_numUpDown_ValueChanged(object sender, EventArgs e)
        {
            this._pageSize = (int)pageSize_numUpDown.Value;
        }
        #endregion

        #region 下一页
        private void NextPage_btn_Click(object sender, EventArgs e)
        {
            if (_currentPageIndex + 1 <= GetTotalPageNum())
            {
                ++_currentPageIndex;
            }
            RefreshData(false);
        }
        #endregion

        #region 上一页
        private void PrePage_tbn_Click(object sender, EventArgs e)
        {
            if (_currentPageIndex - 1 >= 1)
            {
                --_currentPageIndex;
            }
            RefreshData(false);
        }
        #endregion

        #region 首页
        private void FirstPage_tbn_Click(object sender, EventArgs e)
        {
            _currentPageIndex = 1;
            RefreshData(false);
        }
        #endregion

        #region 尾页
        private void EndPage_tbn_Click(object sender, EventArgs e)
        {
            _currentPageIndex = Convert.ToInt32(GetTotalPageNum());
            RefreshData(false);
        }
        #endregion

        #region 跳转指定页数
        private void GotoPageIndex_tbx_TextChanged(object sender, EventArgs e)
        {
            var bTemp = int.TryParse(gotoPageIndex_tbx.Text, out int result);
            if (bTemp)
            {
                var totoalPageCount = Convert.ToInt32(GetTotalPageNum());
                // 跳转页数大于总页数则为总页数，小于1则为1。
                var gotoPage = result > totoalPageCount ? totoalPageCount : result < 1 ? 1 : result;
                _currentPageIndex = gotoPage;
                gotoPageIndex_tbx.Text = gotoPage.ToString();
            }
            else
            {
                gotoPageIndex_tbx.Text = string.Empty;// 输入非正整数，还原为空。
            }
            RefreshData();
        }
        #endregion

        #region 获得分页后数据
        /// <summary>
        /// 刷新数据
        /// </summary>
        public void RefreshData(bool isGetCount = true)
        {
            if (isGetCount) GetDataCount();
            var currentPageData = GetPagedData();

            totalRow_tbx.Text = _totalCount.ToString();
            currentPageIndex_tbx.Text = $"{_currentPageIndex} / {GetTotalPageNum()}";   // 刷新显示
            _dataGridView.DataSource = currentPageData;
        }
        /// <summary>
        /// 获得数据总量
        /// </summary>
        private void GetDataCount()
        {
            string getCountCommand = _conditionQueryText.Replace("*", "Count(1)");
            _totalCount = Convert.ToInt32(DBHelper.Instance.CheckSQL(getCountCommand).Rows[0][0]);  // 获得数据总量
        }
        /// <summary>
        /// 获得分页后数据
        /// </summary>
        private DataTable GetPagedData()
        {
            CurrectGoTo();
            int offSet = (_currentPageIndex - 1) * PageSize;
            //int fetchRows = this.PageSize;
            string commandText = $"{_conditionQueryText} Limit {_pageSize}  offset {offSet} ;";   // offset：页码 * 页大小；fetchRows: 页大小
            return DBHelper.Instance.CheckSQL(commandText); // 获得分页后数据
        }
        /// <summary>
        /// 纠正跳转数据
        /// </summary>
        private void CurrectGoTo()
        {
            if (_currentPageIndex > GetTotalPageNum())
            {
                _currentPageIndex = Convert.ToInt32(GetTotalPageNum()); // 当前页最大值为总页数
                gotoPageIndex_tbx.Text = _currentPageIndex.ToString();    // 跳转页显示为最大值
            }
        }
        #endregion

        #region 获得总页数
        /// <summary>
        /// 根据每页可显示数量，获得总页数
        /// </summary>
        /// <returns></returns>
        private double GetTotalPageNum()
        {
            double totalPageNum = 1;
            if (_totalCount > 0)
            {
                totalPageNum = Math.Ceiling(_totalCount / Convert.ToDouble(_pageSize));
            }
            return totalPageNum;
        }
        #endregion

        #region 宽度自动调整
        private void PageControl_SizeChanged(object sender, EventArgs e)
        {
            // 自动调整分页区域大小，通过修改中间空白Label的长度来实现。
            // 1.记录控件原本大小。label长度变化与控件长度变化始终一致。控制最小变化值，防止内部控件相互覆盖。
            int pagerChangeValue = this.Width - _pagerWidth;
            if (label8.Width + pagerChangeValue > 0)
            {
                label8.Width += pagerChangeValue;
                _pagerWidth = this.Width;
            }
        }
        #endregion
    }
}

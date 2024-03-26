
namespace DA
{
    partial class Pager
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.confirm_btn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.endPage_tbn = new System.Windows.Forms.Button();
            this.gotoPageIndex_tbx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prePage_tbn = new System.Windows.Forms.Button();
            this.totalRow_tbx = new System.Windows.Forms.TextBox();
            this.nextPage_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.firstPage_btn = new System.Windows.Forms.Button();
            this.currentPageIndex_tbx = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.pageSize_numUpDown = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageSize_numUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // confirm_btn
            // 
            this.confirm_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.confirm_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.confirm_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.confirm_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.confirm_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirm_btn.Location = new System.Drawing.Point(2445, 4);
            this.confirm_btn.Margin = new System.Windows.Forms.Padding(4);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(100, 30);
            this.confirm_btn.TabIndex = 11;
            this.confirm_btn.Text = "确定";
            this.confirm_btn.UseVisualStyleBackColor = false;
            this.confirm_btn.Click += new System.EventHandler(this.Confirm_btn_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(827, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 33);
            this.label7.TabIndex = 16;
            this.label7.Text = "页";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(2234, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "每页数据量：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endPage_tbn
            // 
            this.endPage_tbn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.endPage_tbn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.endPage_tbn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.endPage_tbn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.endPage_tbn.Location = new System.Drawing.Point(324, 4);
            this.endPage_tbn.Margin = new System.Windows.Forms.Padding(4);
            this.endPage_tbn.Name = "endPage_tbn";
            this.endPage_tbn.Size = new System.Drawing.Size(99, 30);
            this.endPage_tbn.TabIndex = 8;
            this.endPage_tbn.Text = "尾页";
            this.endPage_tbn.UseVisualStyleBackColor = false;
            this.endPage_tbn.Click += new System.EventHandler(this.EndPage_tbn_Click);
            // 
            // gotoPageIndex_tbx
            // 
            this.gotoPageIndex_tbx.Location = new System.Drawing.Point(722, 4);
            this.gotoPageIndex_tbx.Margin = new System.Windows.Forms.Padding(4);
            this.gotoPageIndex_tbx.Name = "gotoPageIndex_tbx";
            this.gotoPageIndex_tbx.Size = new System.Drawing.Size(97, 28);
            this.gotoPageIndex_tbx.TabIndex = 5;
            this.gotoPageIndex_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gotoPageIndex_tbx.TextChanged += new System.EventHandler(this.GotoPageIndex_tbx_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(2163, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 33);
            this.label6.TabIndex = 15;
            this.label6.Text = "条数据";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(651, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "跳转到";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prePage_tbn
            // 
            this.prePage_tbn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.prePage_tbn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.prePage_tbn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.prePage_tbn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prePage_tbn.Location = new System.Drawing.Point(115, 4);
            this.prePage_tbn.Margin = new System.Windows.Forms.Padding(4);
            this.prePage_tbn.Name = "prePage_tbn";
            this.prePage_tbn.Size = new System.Drawing.Size(100, 30);
            this.prePage_tbn.TabIndex = 1;
            this.prePage_tbn.Text = "上一页";
            this.prePage_tbn.UseVisualStyleBackColor = false;
            this.prePage_tbn.Click += new System.EventHandler(this.PrePage_tbn_Click);
            // 
            // totalRow_tbx
            // 
            this.totalRow_tbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalRow_tbx.Location = new System.Drawing.Point(2071, 4);
            this.totalRow_tbx.Margin = new System.Windows.Forms.Padding(4);
            this.totalRow_tbx.Name = "totalRow_tbx";
            this.totalRow_tbx.ReadOnly = true;
            this.totalRow_tbx.Size = new System.Drawing.Size(84, 28);
            this.totalRow_tbx.TabIndex = 9;
            // 
            // nextPage_btn
            // 
            this.nextPage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.nextPage_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.nextPage_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.nextPage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextPage_btn.Location = new System.Drawing.Point(223, 4);
            this.nextPage_btn.Margin = new System.Windows.Forms.Padding(4);
            this.nextPage_btn.Name = "nextPage_btn";
            this.nextPage_btn.Size = new System.Drawing.Size(93, 30);
            this.nextPage_btn.TabIndex = 2;
            this.nextPage_btn.Text = "下一页";
            this.nextPage_btn.UseVisualStyleBackColor = false;
            this.nextPage_btn.Click += new System.EventHandler(this.NextPage_btn_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2034, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 33);
            this.label3.TabIndex = 10;
            this.label3.Text = "共";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(614, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 32);
            this.label5.TabIndex = 14;
            this.label5.Text = "页";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(431, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 33);
            this.label4.TabIndex = 12;
            this.label4.Text = "当前";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstPage_btn
            // 
            this.firstPage_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.firstPage_btn.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.firstPage_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.firstPage_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.firstPage_btn.Location = new System.Drawing.Point(4, 4);
            this.firstPage_btn.Margin = new System.Windows.Forms.Padding(4);
            this.firstPage_btn.Name = "firstPage_btn";
            this.firstPage_btn.Size = new System.Drawing.Size(103, 30);
            this.firstPage_btn.TabIndex = 7;
            this.firstPage_btn.Text = "首页";
            this.firstPage_btn.UseVisualStyleBackColor = false;
            this.firstPage_btn.Click += new System.EventHandler(this.FirstPage_tbn_Click);
            // 
            // currentPageIndex_tbx
            // 
            this.currentPageIndex_tbx.Location = new System.Drawing.Point(485, 4);
            this.currentPageIndex_tbx.Margin = new System.Windows.Forms.Padding(4);
            this.currentPageIndex_tbx.Name = "currentPageIndex_tbx";
            this.currentPageIndex_tbx.ReadOnly = true;
            this.currentPageIndex_tbx.Size = new System.Drawing.Size(121, 28);
            this.currentPageIndex_tbx.TabIndex = 13;
            this.currentPageIndex_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.firstPage_btn);
            this.flowLayoutPanel1.Controls.Add(this.prePage_tbn);
            this.flowLayoutPanel1.Controls.Add(this.nextPage_btn);
            this.flowLayoutPanel1.Controls.Add(this.endPage_tbn);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.currentPageIndex_tbx);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.gotoPageIndex_tbx);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.totalRow_tbx);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.pageSize_numUpDown);
            this.flowLayoutPanel1.Controls.Add(this.confirm_btn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(2560, 36);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(864, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(1162, 37);
            this.label8.TabIndex = 17;
            this.label8.Text = "                                                                                 " +
    "                                                 ";
            // 
            // pageSize_numUpDown
            // 
            this.pageSize_numUpDown.Location = new System.Drawing.Point(2355, 3);
            this.pageSize_numUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.pageSize_numUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageSize_numUpDown.Name = "pageSize_numUpDown";
            this.pageSize_numUpDown.Size = new System.Drawing.Size(83, 28);
            this.pageSize_numUpDown.TabIndex = 18;
            this.pageSize_numUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pageSize_numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pageSize_numUpDown.ValueChanged += new System.EventHandler(this.PageSize_numUpDown_ValueChanged);
            // 
            // Pager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pager";
            this.Size = new System.Drawing.Size(2560, 36);
            this.SizeChanged += new System.EventHandler(this.PageControl_SizeChanged);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageSize_numUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button endPage_tbn;
        private System.Windows.Forms.TextBox gotoPageIndex_tbx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button prePage_tbn;
        private System.Windows.Forms.TextBox totalRow_tbx;
        private System.Windows.Forms.Button nextPage_btn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button firstPage_btn;
        private System.Windows.Forms.TextBox currentPageIndex_tbx;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown pageSize_numUpDown;
    }
}

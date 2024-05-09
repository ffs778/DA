
namespace DA
{
    partial class HistoryChartForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            timeTips_lab = new System.Windows.Forms.Label();
            toolTipsShow_cbx = new System.Windows.Forms.CheckBox();
            allSelect_cbx = new System.Windows.Forms.CheckBox();
            paramList_flPanel = new System.Windows.Forms.FlowLayoutPanel();
            formsPlot1 = new ScottPlot.FormsPlot();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // timeTips_lab
            // 
            timeTips_lab.Dock = System.Windows.Forms.DockStyle.Fill;
            timeTips_lab.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            timeTips_lab.Location = new System.Drawing.Point(214, 120);
            timeTips_lab.Name = "timeTips_lab";
            timeTips_lab.Size = new System.Drawing.Size(2327, 120);
            timeTips_lab.TabIndex = 15;
            timeTips_lab.Text = "      ";
            // 
            // toolTipsShow_cbx
            // 
            toolTipsShow_cbx.AutoSize = true;
            toolTipsShow_cbx.Checked = true;
            toolTipsShow_cbx.CheckState = System.Windows.Forms.CheckState.Checked;
            toolTipsShow_cbx.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            toolTipsShow_cbx.Location = new System.Drawing.Point(77, 3);
            toolTipsShow_cbx.Name = "toolTipsShow_cbx";
            toolTipsShow_cbx.Size = new System.Drawing.Size(125, 25);
            toolTipsShow_cbx.TabIndex = 14;
            toolTipsShow_cbx.Text = "显示数据提示";
            toolTipsShow_cbx.UseVisualStyleBackColor = true;
            toolTipsShow_cbx.CheckedChanged += TooltipsShow_cbx_CheckedChanged;
            // 
            // allSelect_cbx
            // 
            allSelect_cbx.AutoSize = true;
            allSelect_cbx.Location = new System.Drawing.Point(141, 3);
            allSelect_cbx.Name = "allSelect_cbx";
            allSelect_cbx.Size = new System.Drawing.Size(61, 25);
            allSelect_cbx.TabIndex = 11;
            allSelect_cbx.Text = "全选";
            allSelect_cbx.UseVisualStyleBackColor = true;
            allSelect_cbx.CheckedChanged += AllSelect_cbx_CheckedChanged;
            // 
            // paramList_flPanel
            // 
            paramList_flPanel.AutoScroll = true;
            paramList_flPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            paramList_flPanel.Location = new System.Drawing.Point(214, 3);
            paramList_flPanel.Name = "paramList_flPanel";
            paramList_flPanel.Size = new System.Drawing.Size(2327, 114);
            paramList_flPanel.TabIndex = 7;
            // 
            // formsPlot1
            // 
            formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            formsPlot1.Location = new System.Drawing.Point(0, 240);
            formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new System.Drawing.Size(2544, 976);
            formsPlot1.TabIndex = 0;
            formsPlot1.MouseMove += FormsPlot1_MouseMove;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.324145F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 91.67586F));
            tableLayoutPanel1.Controls.Add(timeTips_lab, 1, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(paramList_flPanel, 1, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new System.Drawing.Size(2544, 240);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(allSelect_cbx);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(205, 114);
            flowLayoutPanel1.TabIndex = 12;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(toolTipsShow_cbx);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            flowLayoutPanel2.Location = new System.Drawing.Point(3, 123);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(205, 114);
            flowLayoutPanel2.TabIndex = 16;
            // 
            // HistoryChartForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2544, 1216);
            Controls.Add(formsPlot1);
            Controls.Add(tableLayoutPanel1);
            Name = "HistoryChartForm";
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        protected System.Windows.Forms.FlowLayoutPanel paramList_flPanel;
        private System.Windows.Forms.CheckBox allSelect_cbx;
        protected ScottPlot.FormsPlot formsPlot1;
        protected System.Windows.Forms.Label timeTips_lab;
        private System.Windows.Forms.CheckBox toolTipsShow_cbx;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}


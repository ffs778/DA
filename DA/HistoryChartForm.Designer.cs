
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.allSelect_cbx = new System.Windows.Forms.CheckBox();
            this.paramList_flPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.toolTipsShow_cbx = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolTipsShow_cbx);
            this.panel2.Controls.Add(this.allSelect_cbx);
            this.panel2.Controls.Add(this.paramList_flPanel);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1904, 200);
            this.panel2.TabIndex = 4;
            // 
            // allSelect_cbx
            // 
            this.allSelect_cbx.AutoSize = true;
            this.allSelect_cbx.Location = new System.Drawing.Point(127, 17);
            this.allSelect_cbx.Name = "allSelect_cbx";
            this.allSelect_cbx.Size = new System.Drawing.Size(51, 21);
            this.allSelect_cbx.TabIndex = 11;
            this.allSelect_cbx.Text = "全选";
            this.allSelect_cbx.UseVisualStyleBackColor = true;
            this.allSelect_cbx.CheckedChanged += new System.EventHandler(this.AllSelect_cbx_CheckedChanged);
            // 
            // paramList_flPanel
            // 
            this.paramList_flPanel.Location = new System.Drawing.Point(184, 15);
            this.paramList_flPanel.Name = "paramList_flPanel";
            this.paramList_flPanel.Size = new System.Drawing.Size(1696, 179);
            this.paramList_flPanel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "数据项选择：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.formsPlot1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 200);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 760);
            this.panel1.TabIndex = 5;
            // 
            // formsPlot1
            // 
            this.formsPlot1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPlot1.Location = new System.Drawing.Point(0, 0);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1904, 760);
            this.formsPlot1.TabIndex = 0;
            this.formsPlot1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormsPlot1_MouseMove);
            // 
            // toolTipsShow_cbx
            // 
            this.toolTipsShow_cbx.AutoSize = true;
            this.toolTipsShow_cbx.Checked = true;
            this.toolTipsShow_cbx.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolTipsShow_cbx.Location = new System.Drawing.Point(49, 157);
            this.toolTipsShow_cbx.Name = "toolTipsShow_cbx";
            this.toolTipsShow_cbx.Size = new System.Drawing.Size(135, 21);
            this.toolTipsShow_cbx.TabIndex = 12;
            this.toolTipsShow_cbx.Text = "显示图标数据提示框";
            this.toolTipsShow_cbx.UseVisualStyleBackColor = true;
            this.toolTipsShow_cbx.CheckedChanged += new System.EventHandler(this.TooltipsShow_cbx_CheckedChanged);
            // 
            // HistoryChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 960);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "HistoryChartForm";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel paramList_flPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox allSelect_cbx;
        private System.Windows.Forms.Panel panel1;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.CheckBox toolTipsShow_cbx;
    }
}


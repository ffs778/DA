
namespace DA
{
    partial class SingleRecipeAnalysisForm
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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            label1 = new System.Windows.Forms.Label();
            dataTable_cmb = new System.Windows.Forms.ComboBox();
            label2 = new System.Windows.Forms.Label();
            recipe_cmb = new System.Windows.Forms.ComboBox();
            label3 = new System.Windows.Forms.Label();
            group_cmb = new System.Windows.Forms.ComboBox();
            showDatatType_lab = new System.Windows.Forms.Label();
            formData_picb = new System.Windows.Forms.PictureBox();
            chart1Data_picb = new System.Windows.Forms.PictureBox();
            collectData_dgv = new HACDataGridView(components);
            pager1 = new Pager();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)formData_picb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1Data_picb).BeginInit();
            ((System.ComponentModel.ISupportInitialize)collectData_dgv).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(collectData_dgv, 0, 1);
            tableLayoutPanel1.Controls.Add(pager1, 0, 2);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1904, 1041);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(dataTable_cmb);
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(recipe_cmb);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(group_cmb);
            flowLayoutPanel1.Controls.Add(showDatatType_lab);
            flowLayoutPanel1.Controls.Add(formData_picb);
            flowLayoutPanel1.Controls.Add(chart1Data_picb);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(1898, 46);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(88, 25);
            label1.TabIndex = 1;
            label1.Text = "数据源：";
            // 
            // dataTable_cmb
            // 
            dataTable_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dataTable_cmb.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataTable_cmb.FormattingEnabled = true;
            dataTable_cmb.Location = new System.Drawing.Point(97, 3);
            dataTable_cmb.Name = "dataTable_cmb";
            dataTable_cmb.Size = new System.Drawing.Size(452, 33);
            dataTable_cmb.TabIndex = 0;
            dataTable_cmb.SelectedValueChanged += Func_cmb_SelectedValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(555, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(107, 25);
            label2.TabIndex = 3;
            label2.Text = "配方名称：";
            // 
            // recipe_cmb
            // 
            recipe_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            recipe_cmb.Enabled = false;
            recipe_cmb.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            recipe_cmb.FormattingEnabled = true;
            recipe_cmb.Location = new System.Drawing.Point(668, 3);
            recipe_cmb.Name = "recipe_cmb";
            recipe_cmb.Size = new System.Drawing.Size(387, 33);
            recipe_cmb.TabIndex = 2;
            recipe_cmb.SelectedValueChanged += Recipe_cmb_SelectedValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(1061, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(107, 25);
            label3.TabIndex = 4;
            label3.Text = "工艺组别：";
            // 
            // group_cmb
            // 
            group_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            group_cmb.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            group_cmb.FormattingEnabled = true;
            group_cmb.Items.AddRange(new object[] { "全部" });
            group_cmb.Location = new System.Drawing.Point(1174, 3);
            group_cmb.Name = "group_cmb";
            group_cmb.Size = new System.Drawing.Size(108, 33);
            group_cmb.TabIndex = 5;
            group_cmb.SelectedValueChanged += Group_cmb_SelectedValueChanged;
            // 
            // showDatatType_lab
            // 
            showDatatType_lab.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            showDatatType_lab.Location = new System.Drawing.Point(1288, 0);
            showDatatType_lab.Name = "showDatatType_lab";
            showDatatType_lab.Size = new System.Drawing.Size(147, 31);
            showDatatType_lab.TabIndex = 67;
            showDatatType_lab.Text = "数据显示形式：";
            showDatatType_lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // formData_picb
            // 
            formData_picb.Image = Properties.Resources.formSelected;
            formData_picb.Location = new System.Drawing.Point(1441, 3);
            formData_picb.Name = "formData_picb";
            formData_picb.Size = new System.Drawing.Size(43, 31);
            formData_picb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            formData_picb.TabIndex = 69;
            formData_picb.TabStop = false;
            formData_picb.Click += FormData_picb_Click;
            // 
            // chart1Data_picb
            // 
            chart1Data_picb.Image = Properties.Resources.chart2;
            chart1Data_picb.Location = new System.Drawing.Point(1490, 3);
            chart1Data_picb.Name = "chart1Data_picb";
            chart1Data_picb.Size = new System.Drawing.Size(43, 31);
            chart1Data_picb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            chart1Data_picb.TabIndex = 68;
            chart1Data_picb.TabStop = false;
            chart1Data_picb.Click += Graph_Switch_Click;
            // 
            // collectData_dgv
            // 
            collectData_dgv.AllowUserToAddRows = false;
            collectData_dgv.AllowUserToDeleteRows = false;
            collectData_dgv.AllowUserToResizeColumns = false;
            collectData_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan;
            collectData_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            collectData_dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            collectData_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            collectData_dgv.ColumnHeadersHeight = 50;
            collectData_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            collectData_dgv.DefaultCellStyle = dataGridViewCellStyle7;
            collectData_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            collectData_dgv.Location = new System.Drawing.Point(3, 55);
            collectData_dgv.Name = "collectData_dgv";
            collectData_dgv.ReadOnly = true;
            collectData_dgv.RowHeadersVisible = false;
            collectData_dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            collectData_dgv.RowsDefaultCellStyle = dataGridViewCellStyle8;
            collectData_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            collectData_dgv.Size = new System.Drawing.Size(1898, 930);
            collectData_dgv.TabIndex = 1;
            // 
            // pager1
            // 
            pager1.ConditionQueryText = null;
            pager1.Dock = System.Windows.Forms.DockStyle.Fill;
            pager1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            pager1.Location = new System.Drawing.Point(4, 992);
            pager1.Margin = new System.Windows.Forms.Padding(4);
            pager1.Name = "pager1";
            pager1.PagerBackColor = System.Drawing.Color.Empty;
            pager1.PageSize = 300;
            pager1.Size = new System.Drawing.Size(1896, 45);
            pager1.TabIndex = 2;
            // 
            // SingleRecipeAnalysisForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1904, 1041);
            Controls.Add(tableLayoutPanel1);
            Name = "SingleRecipeAnalysisForm";
            ShowIcon = false;
            Text = "数据查询与图标分析工具";
            Shown += SingleRecipeAnalysisForm_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)formData_picb).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1Data_picb).EndInit();
            ((System.ComponentModel.ISupportInitialize)collectData_dgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dataTable_cmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox recipe_cmb;
        private HACDataGridView collectData_dgv;
        private Pager pager1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox group_cmb;
        private System.Windows.Forms.Label showDatatType_lab;
        private System.Windows.Forms.PictureBox formData_picb;
        private System.Windows.Forms.PictureBox chart1Data_picb;
    }
}


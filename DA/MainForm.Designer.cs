
namespace DA
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.func_cmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.recipe_cmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.group_cmb = new System.Windows.Forms.ComboBox();
            this.showDatatType_lab = new System.Windows.Forms.Label();
            this.formData_picb = new System.Windows.Forms.PictureBox();
            this.chart1Data_picb = new System.Windows.Forms.PictureBox();
            this.import_btn = new System.Windows.Forms.Button();
            this.collectData_dgv = new DA.HACDataGridView(this.components);
            this.pager1 = new DA.Pager();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formData_picb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1Data_picb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.collectData_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.collectData_dgv, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pager1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1904, 1041);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.func_cmb);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.recipe_cmb);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.group_cmb);
            this.flowLayoutPanel1.Controls.Add(this.showDatatType_lab);
            this.flowLayoutPanel1.Controls.Add(this.formData_picb);
            this.flowLayoutPanel1.Controls.Add(this.chart1Data_picb);
            this.flowLayoutPanel1.Controls.Add(this.import_btn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1898, 46);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "业务类型：";
            // 
            // func_cmb
            // 
            this.func_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.func_cmb.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.func_cmb.FormattingEnabled = true;
            this.func_cmb.Location = new System.Drawing.Point(116, 3);
            this.func_cmb.Name = "func_cmb";
            this.func_cmb.Size = new System.Drawing.Size(562, 33);
            this.func_cmb.TabIndex = 0;
            this.func_cmb.SelectedValueChanged += new System.EventHandler(this.Func_cmb_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(684, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "配方名称：";
            // 
            // recipe_cmb
            // 
            this.recipe_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recipe_cmb.Enabled = false;
            this.recipe_cmb.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.recipe_cmb.FormattingEnabled = true;
            this.recipe_cmb.Location = new System.Drawing.Point(797, 3);
            this.recipe_cmb.Name = "recipe_cmb";
            this.recipe_cmb.Size = new System.Drawing.Size(473, 33);
            this.recipe_cmb.TabIndex = 2;
            this.recipe_cmb.SelectedValueChanged += new System.EventHandler(this.Recipe_cmb_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(1276, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "工艺组别：";
            // 
            // group_cmb
            // 
            this.group_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.group_cmb.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.group_cmb.FormattingEnabled = true;
            this.group_cmb.Items.AddRange(new object[] {
            "全部"});
            this.group_cmb.Location = new System.Drawing.Point(1389, 3);
            this.group_cmb.Name = "group_cmb";
            this.group_cmb.Size = new System.Drawing.Size(108, 33);
            this.group_cmb.TabIndex = 5;
            this.group_cmb.SelectedValueChanged += new System.EventHandler(this.Group_cmb_SelectedValueChanged);
            // 
            // showDatatType_lab
            // 
            this.showDatatType_lab.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.showDatatType_lab.Location = new System.Drawing.Point(1503, 0);
            this.showDatatType_lab.Name = "showDatatType_lab";
            this.showDatatType_lab.Size = new System.Drawing.Size(147, 31);
            this.showDatatType_lab.TabIndex = 67;
            this.showDatatType_lab.Text = "数据显示形式：";
            this.showDatatType_lab.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // formData_picb
            // 
            this.formData_picb.Image = global::DA.Properties.Resources.formSelected;
            this.formData_picb.Location = new System.Drawing.Point(1656, 3);
            this.formData_picb.Name = "formData_picb";
            this.formData_picb.Size = new System.Drawing.Size(43, 31);
            this.formData_picb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.formData_picb.TabIndex = 69;
            this.formData_picb.TabStop = false;
            this.formData_picb.Click += new System.EventHandler(this.FormData_picb_Click);
            // 
            // chart1Data_picb
            // 
            this.chart1Data_picb.Image = global::DA.Properties.Resources.chart2;
            this.chart1Data_picb.Location = new System.Drawing.Point(1705, 3);
            this.chart1Data_picb.Name = "chart1Data_picb";
            this.chart1Data_picb.Size = new System.Drawing.Size(43, 31);
            this.chart1Data_picb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.chart1Data_picb.TabIndex = 68;
            this.chart1Data_picb.TabStop = false;
            this.chart1Data_picb.Click += new System.EventHandler(this.Graph_Switch_Click);
            // 
            // import_btn
            // 
            this.import_btn.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.import_btn.Location = new System.Drawing.Point(1754, 3);
            this.import_btn.Name = "import_btn";
            this.import_btn.Size = new System.Drawing.Size(135, 33);
            this.import_btn.TabIndex = 70;
            this.import_btn.Text = "数据导入";
            this.import_btn.UseVisualStyleBackColor = true;
            this.import_btn.Click += new System.EventHandler(this.Import_btn_Click);
            // 
            // data_dgv
            // 
            this.collectData_dgv.AllowUserToAddRows = false;
            this.collectData_dgv.AllowUserToDeleteRows = false;
            this.collectData_dgv.AllowUserToResizeColumns = false;
            this.collectData_dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            this.collectData_dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.collectData_dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.collectData_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.collectData_dgv.ColumnHeadersHeight = 50;
            this.collectData_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.collectData_dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.collectData_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collectData_dgv.Location = new System.Drawing.Point(3, 55);
            this.collectData_dgv.Name = "data_dgv";
            this.collectData_dgv.ReadOnly = true;
            this.collectData_dgv.RowHeadersVisible = false;
            this.collectData_dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.collectData_dgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.collectData_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.collectData_dgv.Size = new System.Drawing.Size(1898, 930);
            this.collectData_dgv.TabIndex = 1;
            // 
            // pager1
            // 
            this.pager1.ConditionQueryText = null;
            this.pager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pager1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pager1.Location = new System.Drawing.Point(4, 992);
            this.pager1.Margin = new System.Windows.Forms.Padding(4);
            this.pager1.Name = "pager1";
            this.pager1.PagerBackColor = System.Drawing.Color.Empty;
            this.pager1.PageSize = 300;
            this.pager1.Size = new System.Drawing.Size(1896, 45);
            this.pager1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "数据查询与图标分析工具";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formData_picb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1Data_picb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.collectData_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox func_cmb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox recipe_cmb;
        private HACDataGridView collectData_dgv;
        private Pager pager1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox group_cmb;
        private System.Windows.Forms.Label showDatatType_lab;
        private System.Windows.Forms.PictureBox formData_picb;
        private System.Windows.Forms.PictureBox chart1Data_picb;
        private System.Windows.Forms.Button import_btn;
    }
}


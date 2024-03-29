
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.singleDA_tsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.multiDA_tsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.showForm_panel = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.singleDA_tsmi,
            this.multiDA_tsmi});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1904, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.Yellow;
            this.toolStripMenuItem3.Image = global::DA.Properties.Resources.导入;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(116, 29);
            this.toolStripMenuItem3.Text = "数据导入";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.Import_tsmi_Click);
            // 
            // singleDA_tsmi
            // 
            this.singleDA_tsmi.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.singleDA_tsmi.ForeColor = System.Drawing.Color.White;
            this.singleDA_tsmi.Image = global::DA.Properties.Resources.单次;
            this.singleDA_tsmi.Name = "singleDA_tsmi";
            this.singleDA_tsmi.Size = new System.Drawing.Size(154, 29);
            this.singleDA_tsmi.Text = "单次工艺分析";
            this.singleDA_tsmi.ToolTipText = "观察一组工艺中的数据变化";
            this.singleDA_tsmi.Click += new System.EventHandler(this.SingleDA_tsmi_Click);
            // 
            // multiDA_tsmi
            // 
            this.multiDA_tsmi.ForeColor = System.Drawing.Color.White;
            this.multiDA_tsmi.Image = global::DA.Properties.Resources.多次;
            this.multiDA_tsmi.Name = "multiDA_tsmi";
            this.multiDA_tsmi.Size = new System.Drawing.Size(154, 29);
            this.multiDA_tsmi.Text = "多次工艺对比";
            this.multiDA_tsmi.ToolTipText = "同一工艺在同一时间的变化";
            this.multiDA_tsmi.Click += new System.EventHandler(this.MultiDA_tsmi_Click);
            // 
            // showForm_panel
            // 
            this.showForm_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showForm_panel.Location = new System.Drawing.Point(0, 33);
            this.showForm_panel.Name = "showForm_panel";
            this.showForm_panel.Size = new System.Drawing.Size(1904, 1008);
            this.showForm_panel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.showForm_panel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "数据查询与图标分析工具";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem singleDA_tsmi;
        private System.Windows.Forms.ToolStripMenuItem multiDA_tsmi;
        private System.Windows.Forms.Panel showForm_panel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}


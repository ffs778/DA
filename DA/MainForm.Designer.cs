
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
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            singleDA_tsmi = new System.Windows.Forms.ToolStripMenuItem();
            multiDA_tsmi = new System.Windows.Forms.ToolStripMenuItem();
            showForm_panel = new System.Windows.Forms.Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripMenuItem3, singleDA_tsmi, multiDA_tsmi });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1904, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.BackColor = System.Drawing.SystemColors.MenuHighlight;
            toolStripMenuItem3.ForeColor = System.Drawing.Color.Yellow;
            toolStripMenuItem3.Image = Properties.Resources.导入;
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new System.Drawing.Size(116, 29);
            toolStripMenuItem3.Text = "数据导入";
            toolStripMenuItem3.Click += Import_tsmi_Click;
            // 
            // singleDA_tsmi
            // 
            singleDA_tsmi.BackColor = System.Drawing.SystemColors.MenuHighlight;
            singleDA_tsmi.ForeColor = System.Drawing.Color.White;
            singleDA_tsmi.Image = Properties.Resources.单次;
            singleDA_tsmi.Name = "singleDA_tsmi";
            singleDA_tsmi.Size = new System.Drawing.Size(154, 29);
            singleDA_tsmi.Text = "工艺过程分析";
            singleDA_tsmi.ToolTipText = "观察一组工艺中的数据变化";
            singleDA_tsmi.Click += SingleDA_tsmi_Click;
            // 
            // multiDA_tsmi
            // 
            multiDA_tsmi.ForeColor = System.Drawing.Color.White;
            multiDA_tsmi.Image = Properties.Resources.多次;
            multiDA_tsmi.Name = "multiDA_tsmi";
            multiDA_tsmi.Size = new System.Drawing.Size(154, 29);
            multiDA_tsmi.Text = "工艺时刻对比";
            multiDA_tsmi.ToolTipText = "同一工艺在同一时间的变化";
            multiDA_tsmi.Click += MultiDA_tsmi_Click;
            // 
            // showForm_panel
            // 
            showForm_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            showForm_panel.Location = new System.Drawing.Point(0, 33);
            showForm_panel.Name = "showForm_panel";
            showForm_panel.Size = new System.Drawing.Size(1904, 1008);
            showForm_panel.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1904, 1041);
            Controls.Add(showForm_panel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            ShowIcon = false;
            Text = "数据查询与图标分析工具";
            Shown += MainForm_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem singleDA_tsmi;
        private System.Windows.Forms.ToolStripMenuItem multiDA_tsmi;
        private System.Windows.Forms.Panel showForm_panel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}


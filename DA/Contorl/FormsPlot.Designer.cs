
namespace ScottPlot
{
    partial class FormsPlot
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DefaultRightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.autoAxisMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openInNewWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detachLegendMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotObjectEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据适应刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.DefaultRightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Navy;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(467, 392);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.PictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.PictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // DefaultRightClickMenu
            // 
            this.DefaultRightClickMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DefaultRightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenuItem,
            this.toolStripSeparator1,
            this.saveImageMenuItem,
            this.toolStripSeparator4,
            this.数据适应刷新ToolStripMenuItem});
            this.DefaultRightClickMenu.Name = "contextMenuStrip1";
            this.DefaultRightClickMenu.Size = new System.Drawing.Size(181, 104);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyMenuItem.Text = "复制图片";
            this.copyMenuItem.Click += new System.EventHandler(this.RightClickMenu_Copy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // saveImageMenuItem
            // 
            this.saveImageMenuItem.Name = "saveImageMenuItem";
            this.saveImageMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveImageMenuItem.Text = "图片另存为...";
            this.saveImageMenuItem.Click += new System.EventHandler(this.RightClickMenu_SaveImage_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // autoAxisMenuItem
            // 
            this.autoAxisMenuItem.Name = "autoAxisMenuItem";
            this.autoAxisMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // openInNewWindowMenuItem
            // 
            this.openInNewWindowMenuItem.Name = "openInNewWindowMenuItem";
            this.openInNewWindowMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // detachLegendMenuItem
            // 
            this.detachLegendMenuItem.Name = "detachLegendMenuItem";
            this.detachLegendMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // plotObjectEditorToolStripMenuItem
            // 
            this.plotObjectEditorToolStripMenuItem.Name = "plotObjectEditorToolStripMenuItem";
            this.plotObjectEditorToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // 数据适应刷新ToolStripMenuItem
            // 
            this.数据适应刷新ToolStripMenuItem.Name = "数据适应刷新ToolStripMenuItem";
            this.数据适应刷新ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.数据适应刷新ToolStripMenuItem.Text = "数据适应刷新";
            this.数据适应刷新ToolStripMenuItem.Click += new System.EventHandler(this.RightMenuItemClick_AutoAxis);
            // 
            // FormsPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormsPlot";
            this.Size = new System.Drawing.Size(467, 392);
            this.Load += new System.EventHandler(this.FormsPlot_Load);
            this.SizeChanged += new System.EventHandler(this.OnSizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.DefaultRightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip DefaultRightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem autoAxisMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem openInNewWindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detachLegendMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plotObjectEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 数据适应刷新ToolStripMenuItem;
    }
}

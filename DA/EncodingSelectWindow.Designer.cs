namespace DA
{
    partial class EncodingSelectWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GB2312_radio = new System.Windows.Forms.RadioButton();
            UTF8_radio = new System.Windows.Forms.RadioButton();
            OK_btn = new System.Windows.Forms.Button();
            Cancel_btn = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // GB2312_radio
            // 
            GB2312_radio.AutoSize = true;
            GB2312_radio.Checked = true;
            GB2312_radio.Location = new System.Drawing.Point(72, 22);
            GB2312_radio.Name = "GB2312_radio";
            GB2312_radio.Size = new System.Drawing.Size(109, 21);
            GB2312_radio.TabIndex = 0;
            GB2312_radio.TabStop = true;
            GB2312_radio.Text = "GB2312 (WPS)";
            GB2312_radio.UseVisualStyleBackColor = true;
            // 
            // UTF8_radio
            // 
            UTF8_radio.AutoSize = true;
            UTF8_radio.Location = new System.Drawing.Point(72, 59);
            UTF8_radio.Name = "UTF8_radio";
            UTF8_radio.Size = new System.Drawing.Size(96, 21);
            UTF8_radio.TabIndex = 1;
            UTF8_radio.Text = "UTF8 (Excel)";
            UTF8_radio.UseVisualStyleBackColor = true;
            // 
            // OK_btn
            // 
            OK_btn.Location = new System.Drawing.Point(27, 109);
            OK_btn.Name = "OK_btn";
            OK_btn.Size = new System.Drawing.Size(102, 23);
            OK_btn.TabIndex = 2;
            OK_btn.Text = "确定";
            OK_btn.UseVisualStyleBackColor = true;
            OK_btn.Click += OK_btn_Click;
            // 
            // Cancel_btn
            // 
            Cancel_btn.Location = new System.Drawing.Point(135, 109);
            Cancel_btn.Name = "Cancel_btn";
            Cancel_btn.Size = new System.Drawing.Size(102, 23);
            Cancel_btn.TabIndex = 3;
            Cancel_btn.Text = "取消";
            Cancel_btn.UseVisualStyleBackColor = true;
            Cancel_btn.Click += Cancel_btn_Click;
            // 
            // EncodingSelectWindow
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(249, 157);
            Controls.Add(Cancel_btn);
            Controls.Add(OK_btn);
            Controls.Add(UTF8_radio);
            Controls.Add(GB2312_radio);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "EncodingSelectWindow";
            Text = "EncodingSelectWindow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.RadioButton GB2312_radio;
        private System.Windows.Forms.RadioButton UTF8_radio;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.Button Cancel_btn;
    }
}
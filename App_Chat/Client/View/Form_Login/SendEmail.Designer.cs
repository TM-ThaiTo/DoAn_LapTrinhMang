namespace Client
{
    partial class SendEmail
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_OTP_Nhap = new System.Windows.Forms.TextBox();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.btn_GuiLai = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã OTP";
            // 
            // txt_OTP_Nhap
            // 
            this.txt_OTP_Nhap.Location = new System.Drawing.Point(77, 34);
            this.txt_OTP_Nhap.Name = "txt_OTP_Nhap";
            this.txt_OTP_Nhap.Size = new System.Drawing.Size(172, 20);
            this.txt_OTP_Nhap.TabIndex = 1;
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.Location = new System.Drawing.Point(174, 75);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(75, 23);
            this.btn_XacNhan.TabIndex = 2;
            this.btn_XacNhan.Text = "Xác nhận ";
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            this.btn_XacNhan.Click += new System.EventHandler(this.btn_XacNhan_Click);
            // 
            // btn_GuiLai
            // 
            this.btn_GuiLai.Location = new System.Drawing.Point(66, 84);
            this.btn_GuiLai.Name = "btn_GuiLai";
            this.btn_GuiLai.Size = new System.Drawing.Size(60, 27);
            this.btn_GuiLai.TabIndex = 3;
            this.btn_GuiLai.Text = "Gửi lại";
            this.btn_GuiLai.UseVisualStyleBackColor = true;
            this.btn_GuiLai.Click += new System.EventHandler(this.btn_GuiLai_Click);
            // 
            // SendEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 132);
            this.Controls.Add(this.btn_GuiLai);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.txt_OTP_Nhap);
            this.Controls.Add(this.label1);
            this.Name = "SendEmail";
            this.Text = "SendEmail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_OTP_Nhap;
        private System.Windows.Forms.Button btn_XacNhan;
        private System.Windows.Forms.Button btn_GuiLai;
    }
}
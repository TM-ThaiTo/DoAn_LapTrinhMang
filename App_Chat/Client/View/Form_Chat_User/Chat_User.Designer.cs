namespace Client
{
    partial class Chat_User
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
            this.txt_Mess = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.lsv_Message = new System.Windows.Forms.ListView();
            this.lbl_TenNguoiNhan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_Mess
            // 
            this.txt_Mess.Location = new System.Drawing.Point(12, 384);
            this.txt_Mess.Name = "txt_Mess";
            this.txt_Mess.Size = new System.Drawing.Size(333, 20);
            this.txt_Mess.TabIndex = 1;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(351, 382);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 2;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // lsv_Message
            // 
            this.lsv_Message.HideSelection = false;
            this.lsv_Message.Location = new System.Drawing.Point(11, 22);
            this.lsv_Message.Name = "lsv_Message";
            this.lsv_Message.Size = new System.Drawing.Size(415, 343);
            this.lsv_Message.TabIndex = 3;
            this.lsv_Message.UseCompatibleStateImageBehavior = false;
            this.lsv_Message.View = System.Windows.Forms.View.List;
            // 
            // lbl_TenNguoiNhan
            // 
            this.lbl_TenNguoiNhan.AutoSize = true;
            this.lbl_TenNguoiNhan.Location = new System.Drawing.Point(24, 6);
            this.lbl_TenNguoiNhan.Name = "lbl_TenNguoiNhan";
            this.lbl_TenNguoiNhan.Size = new System.Drawing.Size(82, 13);
            this.lbl_TenNguoiNhan.TabIndex = 4;
            this.lbl_TenNguoiNhan.Text = "Tên người nhận";
            // 
            // Chat_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 418);
            this.Controls.Add(this.lbl_TenNguoiNhan);
            this.Controls.Add(this.lsv_Message);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Mess);
            this.Name = "Chat_User";
            this.Text = "Chat_User";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Chat_User_FormClosing);
            this.Load += new System.EventHandler(this.Chat_User_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_Mess;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.ListView lsv_Message;
        private System.Windows.Forms.Label lbl_TenNguoiNhan;
    }
}
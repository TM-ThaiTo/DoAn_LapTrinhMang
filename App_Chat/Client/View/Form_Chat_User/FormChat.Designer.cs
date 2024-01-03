namespace Client
{
    partial class FormChat
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
            this.lbl_TenNguoiNhan = new System.Windows.Forms.Label();
            this.lsv_Message = new System.Windows.Forms.ListView();
            this.btn_Send = new System.Windows.Forms.Button();
            this.txt_Mess = new System.Windows.Forms.TextBox();
            this.lbl_File = new System.Windows.Forms.Label();
            this.btn_ChonFile = new System.Windows.Forms.Button();
            this.btn_SendFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_TenNguoiNhan
            // 
            this.lbl_TenNguoiNhan.AutoSize = true;
            this.lbl_TenNguoiNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenNguoiNhan.Location = new System.Drawing.Point(25, 7);
            this.lbl_TenNguoiNhan.Name = "lbl_TenNguoiNhan";
            this.lbl_TenNguoiNhan.Size = new System.Drawing.Size(109, 18);
            this.lbl_TenNguoiNhan.TabIndex = 8;
            this.lbl_TenNguoiNhan.Text = "Tên người nhận";
            // 
            // lsv_Message
            // 
            this.lsv_Message.HideSelection = false;
            this.lsv_Message.Location = new System.Drawing.Point(12, 39);
            this.lsv_Message.Name = "lsv_Message";
            this.lsv_Message.Size = new System.Drawing.Size(415, 327);
            this.lsv_Message.TabIndex = 7;
            this.lsv_Message.UseCompatibleStateImageBehavior = false;
            this.lsv_Message.View = System.Windows.Forms.View.List;
            // 
            // btn_Send
            // 
            this.btn_Send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Send.Location = new System.Drawing.Point(352, 372);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 6;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // txt_Mess
            // 
            this.txt_Mess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Mess.Location = new System.Drawing.Point(13, 372);
            this.txt_Mess.Name = "txt_Mess";
            this.txt_Mess.Size = new System.Drawing.Size(333, 22);
            this.txt_Mess.TabIndex = 5;
            // 
            // lbl_File
            // 
            this.lbl_File.AutoSize = true;
            this.lbl_File.Location = new System.Drawing.Point(12, 403);
            this.lbl_File.Name = "lbl_File";
            this.lbl_File.Size = new System.Drawing.Size(16, 13);
            this.lbl_File.TabIndex = 9;
            this.lbl_File.Text = "...";
            // 
            // btn_ChonFile
            // 
            this.btn_ChonFile.Location = new System.Drawing.Point(319, 403);
            this.btn_ChonFile.Name = "btn_ChonFile";
            this.btn_ChonFile.Size = new System.Drawing.Size(27, 23);
            this.btn_ChonFile.TabIndex = 10;
            this.btn_ChonFile.Text = "...";
            this.btn_ChonFile.UseVisualStyleBackColor = true;
            this.btn_ChonFile.Click += new System.EventHandler(this.btn_ChonFile_Click);
            // 
            // btn_SendFile
            // 
            this.btn_SendFile.Location = new System.Drawing.Point(352, 403);
            this.btn_SendFile.Name = "btn_SendFile";
            this.btn_SendFile.Size = new System.Drawing.Size(75, 23);
            this.btn_SendFile.TabIndex = 11;
            this.btn_SendFile.Text = "Send File";
            this.btn_SendFile.UseVisualStyleBackColor = true;
            this.btn_SendFile.Click += new System.EventHandler(this.btn_SendFile_Click);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 432);
            this.Controls.Add(this.btn_SendFile);
            this.Controls.Add(this.btn_ChonFile);
            this.Controls.Add(this.lbl_File);
            this.Controls.Add(this.lbl_TenNguoiNhan);
            this.Controls.Add(this.lsv_Message);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Mess);
            this.Name = "FormChat";
            this.Text = "FormChat";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TenNguoiNhan;
        private System.Windows.Forms.ListView lsv_Message;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox txt_Mess;
        private System.Windows.Forms.Label lbl_File;
        private System.Windows.Forms.Button btn_ChonFile;
        private System.Windows.Forms.Button btn_SendFile;
    }
}
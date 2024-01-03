namespace Client
{
    partial class Form_Chat_Group_Member
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
            this.lbl_TenNhom = new System.Windows.Forms.Label();
            this.lsv_MessGroup = new System.Windows.Forms.ListView();
            this.txt_Mess = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_TenNhom
            // 
            this.lbl_TenNhom.AutoSize = true;
            this.lbl_TenNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenNhom.Location = new System.Drawing.Point(53, 12);
            this.lbl_TenNhom.Name = "lbl_TenNhom";
            this.lbl_TenNhom.Size = new System.Drawing.Size(75, 18);
            this.lbl_TenNhom.TabIndex = 0;
            this.lbl_TenNhom.Text = "Tên nhóm";
            // 
            // lsv_MessGroup
            // 
            this.lsv_MessGroup.HideSelection = false;
            this.lsv_MessGroup.Location = new System.Drawing.Point(12, 46);
            this.lsv_MessGroup.Name = "lsv_MessGroup";
            this.lsv_MessGroup.Size = new System.Drawing.Size(417, 359);
            this.lsv_MessGroup.TabIndex = 1;
            this.lsv_MessGroup.UseCompatibleStateImageBehavior = false;
            this.lsv_MessGroup.View = System.Windows.Forms.View.List;
            // 
            // txt_Mess
            // 
            this.txt_Mess.Location = new System.Drawing.Point(12, 417);
            this.txt_Mess.Name = "txt_Mess";
            this.txt_Mess.Size = new System.Drawing.Size(336, 20);
            this.txt_Mess.TabIndex = 2;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(354, 415);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 3;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // Form_Chat_Group_Member
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 450);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Mess);
            this.Controls.Add(this.lsv_MessGroup);
            this.Controls.Add(this.lbl_TenNhom);
            this.Name = "Form_Chat_Group_Member";
            this.Text = "Form_Chat_Group_Member";
            this.Load += new System.EventHandler(this.Form_Chat_Group_Member_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TenNhom;
        private System.Windows.Forms.ListView lsv_MessGroup;
        private System.Windows.Forms.TextBox txt_Mess;
        private System.Windows.Forms.Button btn_Send;
    }
}
namespace Client
{
    partial class Form_Chat_Group_Main
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
            this.lsv_MessGroup = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_ThanhVien = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TenNhom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.dgv_ID_ThanhVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_NameThanhVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ChinhSua = new System.Windows.Forms.Button();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.btn_GiaiTan = new System.Windows.Forms.Button();
            this.txt_Mess = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThanhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // lsv_MessGroup
            // 
            this.lsv_MessGroup.HideSelection = false;
            this.lsv_MessGroup.Location = new System.Drawing.Point(12, 12);
            this.lsv_MessGroup.Name = "lsv_MessGroup";
            this.lsv_MessGroup.Size = new System.Drawing.Size(467, 511);
            this.lsv_MessGroup.TabIndex = 0;
            this.lsv_MessGroup.UseCompatibleStateImageBehavior = false;
            this.lsv_MessGroup.View = System.Windows.Forms.View.List;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_ThanhVien);
            this.groupBox1.Location = new System.Drawing.Point(485, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 365);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thành viên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_GiaiTan);
            this.groupBox2.Controls.Add(this.btn_ChinhSua);
            this.groupBox2.Controls.Add(this.btn_Luu);
            this.groupBox2.Controls.Add(this.txt_Pass);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_TenNhom);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(491, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 140);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Quản lý nhóm";
            // 
            // dgv_ThanhVien
            // 
            this.dgv_ThanhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ThanhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_ID_ThanhVien,
            this.dgv_NameThanhVien});
            this.dgv_ThanhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ThanhVien.Location = new System.Drawing.Point(3, 16);
            this.dgv_ThanhVien.Name = "dgv_ThanhVien";
            this.dgv_ThanhVien.Size = new System.Drawing.Size(244, 346);
            this.dgv_ThanhVien.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên nhóm";
            // 
            // txt_TenNhom
            // 
            this.txt_TenNhom.Location = new System.Drawing.Point(67, 22);
            this.txt_TenNhom.Name = "txt_TenNhom";
            this.txt_TenNhom.Size = new System.Drawing.Size(164, 20);
            this.txt_TenNhom.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pass";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Location = new System.Drawing.Point(67, 48);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Size = new System.Drawing.Size(164, 20);
            this.txt_Pass.TabIndex = 1;
            // 
            // btn_Luu
            // 
            this.btn_Luu.Location = new System.Drawing.Point(156, 73);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(75, 23);
            this.btn_Luu.TabIndex = 2;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // dgv_ID_ThanhVien
            // 
            this.dgv_ID_ThanhVien.HeaderText = "ID";
            this.dgv_ID_ThanhVien.Name = "dgv_ID_ThanhVien";
            this.dgv_ID_ThanhVien.Width = 30;
            // 
            // dgv_NameThanhVien
            // 
            this.dgv_NameThanhVien.HeaderText = "Tên thành viên";
            this.dgv_NameThanhVien.Name = "dgv_NameThanhVien";
            this.dgv_NameThanhVien.Width = 170;
            // 
            // btn_ChinhSua
            // 
            this.btn_ChinhSua.Location = new System.Drawing.Point(67, 73);
            this.btn_ChinhSua.Name = "btn_ChinhSua";
            this.btn_ChinhSua.Size = new System.Drawing.Size(75, 23);
            this.btn_ChinhSua.TabIndex = 3;
            this.btn_ChinhSua.Text = "Chỉnh sửa";
            this.btn_ChinhSua.UseVisualStyleBackColor = true;
            this.btn_ChinhSua.Click += new System.EventHandler(this.btn_ChinhSua_Click);
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(637, 12);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(93, 23);
            this.btn_LamMoi.TabIndex = 3;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            // 
            // btn_GiaiTan
            // 
            this.btn_GiaiTan.Location = new System.Drawing.Point(122, 111);
            this.btn_GiaiTan.Name = "btn_GiaiTan";
            this.btn_GiaiTan.Size = new System.Drawing.Size(109, 23);
            this.btn_GiaiTan.TabIndex = 4;
            this.btn_GiaiTan.Text = "Giải tán nhóm";
            this.btn_GiaiTan.UseVisualStyleBackColor = true;
            this.btn_GiaiTan.Click += new System.EventHandler(this.btn_GiaiTan_Click);
            // 
            // txt_Mess
            // 
            this.txt_Mess.Location = new System.Drawing.Point(12, 532);
            this.txt_Mess.Name = "txt_Mess";
            this.txt_Mess.Size = new System.Drawing.Size(386, 20);
            this.txt_Mess.TabIndex = 4;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(404, 530);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 5;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // Form_Chat_Group_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 564);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Mess);
            this.Controls.Add(this.btn_LamMoi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsv_MessGroup);
            this.Name = "Form_Chat_Group_Main";
            this.Text = "Form_Chat_Group_Main";
            this.Load += new System.EventHandler(this.Form_Chat_Group_Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThanhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsv_MessGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_ThanhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_ID_ThanhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_NameThanhVien;
        private System.Windows.Forms.Button btn_ChinhSua;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.TextBox txt_Pass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TenNhom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.Button btn_GiaiTan;
        private System.Windows.Forms.TextBox txt_Mess;
        private System.Windows.Forms.Button btn_Send;
    }
}
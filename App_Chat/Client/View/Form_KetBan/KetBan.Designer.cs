namespace Client
{
    partial class KetBan
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
            this.dgv_DanhSachNguoiDung = new System.Windows.Forms.DataGridView();
            this.btn_KetBan = new System.Windows.Forms.Button();
            this.btn_Chan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_TenHienThi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_TenHienThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachNguoiDung)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DanhSachNguoiDung
            // 
            this.dgv_DanhSachNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_ID,
            this.dgv_TenHienThi});
            this.dgv_DanhSachNguoiDung.Location = new System.Drawing.Point(6, 19);
            this.dgv_DanhSachNguoiDung.Name = "dgv_DanhSachNguoiDung";
            this.dgv_DanhSachNguoiDung.Size = new System.Drawing.Size(243, 407);
            this.dgv_DanhSachNguoiDung.TabIndex = 0;
            this.dgv_DanhSachNguoiDung.SelectionChanged += new System.EventHandler(this.dgv_DanhSachNguoiDung_SelectionChanged);
            // 
            // btn_KetBan
            // 
            this.btn_KetBan.Location = new System.Drawing.Point(6, 19);
            this.btn_KetBan.Name = "btn_KetBan";
            this.btn_KetBan.Size = new System.Drawing.Size(150, 40);
            this.btn_KetBan.TabIndex = 1;
            this.btn_KetBan.Text = "Kết bạn";
            this.btn_KetBan.UseVisualStyleBackColor = true;
            this.btn_KetBan.Click += new System.EventHandler(this.btn_KetBan_Click);
            // 
            // btn_Chan
            // 
            this.btn_Chan.Location = new System.Drawing.Point(6, 65);
            this.btn_Chan.Name = "btn_Chan";
            this.btn_Chan.Size = new System.Drawing.Size(150, 40);
            this.btn_Chan.TabIndex = 2;
            this.btn_Chan.Text = "Chặn";
            this.btn_Chan.UseVisualStyleBackColor = true;
            this.btn_Chan.Click += new System.EventHandler(this.btn_Chan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_KetBan);
            this.groupBox1.Controls.Add(this.btn_Chan);
            this.groupBox1.Location = new System.Drawing.Point(266, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 115);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_DanhSachNguoiDung);
            this.groupBox2.Location = new System.Drawing.Point(11, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 426);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách người dùng";
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(272, 205);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(152, 20);
            this.txt_TimKiem.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tìm kiếm";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Client.Properties.Resources.friend;
            this.pictureBox1.Location = new System.Drawing.Point(277, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // txt_TenHienThi
            // 
            this.txt_TenHienThi.Location = new System.Drawing.Point(272, 265);
            this.txt_TenHienThi.Name = "txt_TenHienThi";
            this.txt_TenHienThi.Size = new System.Drawing.Size(152, 20);
            this.txt_TenHienThi.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên hiển thị";
            // 
            // dgv_ID
            // 
            this.dgv_ID.HeaderText = "ID";
            this.dgv_ID.Name = "dgv_ID";
            this.dgv_ID.Visible = false;
            this.dgv_ID.Width = 40;
            // 
            // dgv_TenHienThi
            // 
            this.dgv_TenHienThi.HeaderText = "Tên hiển thị";
            this.dgv_TenHienThi.Name = "dgv_TenHienThi";
            this.dgv_TenHienThi.Width = 200;
            // 
            // KetBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 450);
            this.Controls.Add(this.txt_TenHienThi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "KetBan";
            this.Text = "KetBan";
            this.Load += new System.EventHandler(this.KetBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachNguoiDung)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DanhSachNguoiDung;
        private System.Windows.Forms.Button btn_KetBan;
        private System.Windows.Forms.Button btn_Chan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_TenHienThi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_TenHienThi;
    }
}
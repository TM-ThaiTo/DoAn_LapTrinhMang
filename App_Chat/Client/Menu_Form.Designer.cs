namespace Client
{
    partial class Menu_Form
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_DanhSachDen = new System.Windows.Forms.Button();
            this.btn_Chat = new System.Windows.Forms.Button();
            this.btn_DangXuat = new System.Windows.Forms.Button();
            this.btn_QuanLy = new System.Windows.Forms.Button();
            this.btn_KetBan = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSachBanBe = new System.Windows.Forms.DataGridView();
            this.dgv_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_NguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_HoTen = new System.Windows.Forms.Label();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSachNhom = new System.Windows.Forms.DataGridView();
            this.dgv_IDNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_TenNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_RoiNhom = new System.Windows.Forms.Button();
            this.btn_ThamGiaChat = new System.Windows.Forms.Button();
            this.btn_GiaNhapNhom = new System.Windows.Forms.Button();
            this.btn_Tao = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.txt_TenNhom = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachBanBe)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachNhom)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_DanhSachDen);
            this.groupBox1.Controls.Add(this.btn_Chat);
            this.groupBox1.Controls.Add(this.btn_DangXuat);
            this.groupBox1.Controls.Add(this.btn_QuanLy);
            this.groupBox1.Controls.Add(this.btn_KetBan);
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 437);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btn_DanhSachDen
            // 
            this.btn_DanhSachDen.Location = new System.Drawing.Point(21, 94);
            this.btn_DanhSachDen.Name = "btn_DanhSachDen";
            this.btn_DanhSachDen.Size = new System.Drawing.Size(160, 50);
            this.btn_DanhSachDen.TabIndex = 2;
            this.btn_DanhSachDen.Text = "Danh sách đen";
            this.btn_DanhSachDen.UseVisualStyleBackColor = true;
            this.btn_DanhSachDen.Click += new System.EventHandler(this.btn_DanhSachDen_Click);
            // 
            // btn_Chat
            // 
            this.btn_Chat.Location = new System.Drawing.Point(21, 159);
            this.btn_Chat.Name = "btn_Chat";
            this.btn_Chat.Size = new System.Drawing.Size(160, 50);
            this.btn_Chat.TabIndex = 1;
            this.btn_Chat.Text = "Chat";
            this.btn_Chat.UseVisualStyleBackColor = true;
            this.btn_Chat.Click += new System.EventHandler(this.btn_Chat_Click);
            // 
            // btn_DangXuat
            // 
            this.btn_DangXuat.Location = new System.Drawing.Point(21, 371);
            this.btn_DangXuat.Name = "btn_DangXuat";
            this.btn_DangXuat.Size = new System.Drawing.Size(160, 50);
            this.btn_DangXuat.TabIndex = 0;
            this.btn_DangXuat.Text = "Đăng xuất";
            this.btn_DangXuat.UseVisualStyleBackColor = true;
            this.btn_DangXuat.Click += new System.EventHandler(this.btn_DangXuat_Click);
            // 
            // btn_QuanLy
            // 
            this.btn_QuanLy.Location = new System.Drawing.Point(21, 315);
            this.btn_QuanLy.Name = "btn_QuanLy";
            this.btn_QuanLy.Size = new System.Drawing.Size(160, 50);
            this.btn_QuanLy.TabIndex = 0;
            this.btn_QuanLy.Text = "Quản lý";
            this.btn_QuanLy.UseVisualStyleBackColor = true;
            this.btn_QuanLy.Click += new System.EventHandler(this.btn_QuanLy_Click);
            // 
            // btn_KetBan
            // 
            this.btn_KetBan.Location = new System.Drawing.Point(21, 28);
            this.btn_KetBan.Name = "btn_KetBan";
            this.btn_KetBan.Size = new System.Drawing.Size(160, 50);
            this.btn_KetBan.TabIndex = 0;
            this.btn_KetBan.Text = "Kết bạn";
            this.btn_KetBan.UseVisualStyleBackColor = true;
            this.btn_KetBan.Click += new System.EventHandler(this.btn_KetBan_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_DanhSachBanBe);
            this.groupBox2.Location = new System.Drawing.Point(231, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 434);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách bạn bè";
            // 
            // dgv_DanhSachBanBe
            // 
            this.dgv_DanhSachBanBe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachBanBe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_ID,
            this.dgv_NguoiDung});
            this.dgv_DanhSachBanBe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DanhSachBanBe.Location = new System.Drawing.Point(3, 16);
            this.dgv_DanhSachBanBe.Name = "dgv_DanhSachBanBe";
            this.dgv_DanhSachBanBe.Size = new System.Drawing.Size(273, 415);
            this.dgv_DanhSachBanBe.TabIndex = 0;
            this.dgv_DanhSachBanBe.SelectionChanged += new System.EventHandler(this.dgv_DanhSachBanBe_SelectionChanged);
            // 
            // dgv_ID
            // 
            this.dgv_ID.HeaderText = "ID";
            this.dgv_ID.Name = "dgv_ID";
            this.dgv_ID.Width = 30;
            // 
            // dgv_NguoiDung
            // 
            this.dgv_NguoiDung.HeaderText = "Tên người dùng";
            this.dgv_NguoiDung.Name = "dgv_NguoiDung";
            this.dgv_NguoiDung.Width = 200;
            // 
            // lbl_HoTen
            // 
            this.lbl_HoTen.AutoSize = true;
            this.lbl_HoTen.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HoTen.Location = new System.Drawing.Point(113, 19);
            this.lbl_HoTen.Name = "lbl_HoTen";
            this.lbl_HoTen.Size = new System.Drawing.Size(80, 27);
            this.lbl_HoTen.TabIndex = 2;
            this.lbl_HoTen.Text = "họ tên";
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(849, 35);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(108, 31);
            this.btn_LamMoi.TabIndex = 3;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_DanhSachNhom);
            this.groupBox3.Location = new System.Drawing.Point(709, 72);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 434);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách nhóm";
            // 
            // dgv_DanhSachNhom
            // 
            this.dgv_DanhSachNhom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachNhom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_IDNhom,
            this.dgv_TenNhom,
            this.dgv_pass});
            this.dgv_DanhSachNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DanhSachNhom.Location = new System.Drawing.Point(3, 16);
            this.dgv_DanhSachNhom.Name = "dgv_DanhSachNhom";
            this.dgv_DanhSachNhom.Size = new System.Drawing.Size(264, 415);
            this.dgv_DanhSachNhom.TabIndex = 0;
            this.dgv_DanhSachNhom.SelectionChanged += new System.EventHandler(this.dgv_DanhSachNhom_SelectionChanged);
            // 
            // dgv_IDNhom
            // 
            this.dgv_IDNhom.HeaderText = "ID";
            this.dgv_IDNhom.Name = "dgv_IDNhom";
            this.dgv_IDNhom.Width = 30;
            // 
            // dgv_TenNhom
            // 
            this.dgv_TenNhom.HeaderText = "Tên nhóm";
            this.dgv_TenNhom.Name = "dgv_TenNhom";
            this.dgv_TenNhom.Width = 190;
            // 
            // dgv_pass
            // 
            this.dgv_pass.HeaderText = "Pass";
            this.dgv_pass.Name = "dgv_pass";
            this.dgv_pass.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_RoiNhom);
            this.groupBox4.Controls.Add(this.btn_ThamGiaChat);
            this.groupBox4.Controls.Add(this.btn_GiaNhapNhom);
            this.groupBox4.Controls.Add(this.btn_Tao);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txt_Pass);
            this.groupBox4.Controls.Add(this.txt_TenNhom);
            this.groupBox4.Location = new System.Drawing.Point(513, 121);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(193, 382);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức năng nhóm";
            // 
            // btn_RoiNhom
            // 
            this.btn_RoiNhom.Location = new System.Drawing.Point(18, 319);
            this.btn_RoiNhom.Name = "btn_RoiNhom";
            this.btn_RoiNhom.Size = new System.Drawing.Size(160, 50);
            this.btn_RoiNhom.TabIndex = 4;
            this.btn_RoiNhom.Text = "Rời nhóm";
            this.btn_RoiNhom.UseVisualStyleBackColor = true;
            this.btn_RoiNhom.Click += new System.EventHandler(this.btn_RoiNhom_Click);
            // 
            // btn_ThamGiaChat
            // 
            this.btn_ThamGiaChat.Location = new System.Drawing.Point(18, 220);
            this.btn_ThamGiaChat.Name = "btn_ThamGiaChat";
            this.btn_ThamGiaChat.Size = new System.Drawing.Size(160, 50);
            this.btn_ThamGiaChat.TabIndex = 3;
            this.btn_ThamGiaChat.Text = "Tham gia chat";
            this.btn_ThamGiaChat.UseVisualStyleBackColor = true;
            this.btn_ThamGiaChat.Click += new System.EventHandler(this.btn_ThamGiaChat_Click);
            // 
            // btn_GiaNhapNhom
            // 
            this.btn_GiaNhapNhom.Location = new System.Drawing.Point(18, 164);
            this.btn_GiaNhapNhom.Name = "btn_GiaNhapNhom";
            this.btn_GiaNhapNhom.Size = new System.Drawing.Size(160, 50);
            this.btn_GiaNhapNhom.TabIndex = 2;
            this.btn_GiaNhapNhom.Text = "Gia nhập nhóm";
            this.btn_GiaNhapNhom.UseVisualStyleBackColor = true;
            this.btn_GiaNhapNhom.Click += new System.EventHandler(this.btn_GiaNhapNhom_Click);
            // 
            // btn_Tao
            // 
            this.btn_Tao.Location = new System.Drawing.Point(18, 108);
            this.btn_Tao.Name = "btn_Tao";
            this.btn_Tao.Size = new System.Drawing.Size(160, 50);
            this.btn_Tao.TabIndex = 2;
            this.btn_Tao.Text = "Tạo";
            this.btn_Tao.UseVisualStyleBackColor = true;
            this.btn_Tao.Click += new System.EventHandler(this.btn_Tao_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pass";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên nhóm";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Location = new System.Drawing.Point(60, 59);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.PasswordChar = '*';
            this.txt_Pass.Size = new System.Drawing.Size(127, 20);
            this.txt_Pass.TabIndex = 0;
            // 
            // txt_TenNhom
            // 
            this.txt_TenNhom.Location = new System.Drawing.Point(60, 33);
            this.txt_TenNhom.Name = "txt_TenNhom";
            this.txt_TenNhom.Size = new System.Drawing.Size(127, 20);
            this.txt_TenNhom.TabIndex = 0;
            // 
            // Menu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 512);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_LamMoi);
            this.Controls.Add(this.lbl_HoTen);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Menu_Form";
            this.Text = "Menu_Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_Form_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Form_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachBanBe)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachNhom)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_KetBan;
        private System.Windows.Forms.Button btn_DangXuat;
        private System.Windows.Forms.Button btn_QuanLy;
        private System.Windows.Forms.Label lbl_HoTen;
        private System.Windows.Forms.Button btn_Chat;
        private System.Windows.Forms.DataGridView dgv_DanhSachBanBe;
        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_DanhSachNhom;
        private System.Windows.Forms.Button btn_DanhSachDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_NguoiDung;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_GiaNhapNhom;
        private System.Windows.Forms.Button btn_Tao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Pass;
        private System.Windows.Forms.TextBox txt_TenNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_IDNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_TenNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_pass;
        private System.Windows.Forms.Button btn_ThamGiaChat;
        private System.Windows.Forms.Button btn_RoiNhom;
    }
}
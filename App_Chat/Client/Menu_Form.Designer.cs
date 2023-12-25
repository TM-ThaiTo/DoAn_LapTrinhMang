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
            this.btn_NhanTinNhom = new System.Windows.Forms.Button();
            this.btn_KetBan = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_DanhSachBanBe = new System.Windows.Forms.DataGridView();
            this.dgv_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_NguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_HoTen = new System.Windows.Forms.Label();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachBanBe)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_DanhSachDen);
            this.groupBox1.Controls.Add(this.btn_Chat);
            this.groupBox1.Controls.Add(this.btn_DangXuat);
            this.groupBox1.Controls.Add(this.btn_QuanLy);
            this.groupBox1.Controls.Add(this.btn_NhanTinNhom);
            this.groupBox1.Controls.Add(this.btn_KetBan);
            this.groupBox1.Location = new System.Drawing.Point(12, 144);
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
            // btn_NhanTinNhom
            // 
            this.btn_NhanTinNhom.Location = new System.Drawing.Point(21, 225);
            this.btn_NhanTinNhom.Name = "btn_NhanTinNhom";
            this.btn_NhanTinNhom.Size = new System.Drawing.Size(160, 50);
            this.btn_NhanTinNhom.TabIndex = 0;
            this.btn_NhanTinNhom.Text = "Nhắn tin nhóm";
            this.btn_NhanTinNhom.UseVisualStyleBackColor = true;
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
            this.groupBox2.Location = new System.Drawing.Point(301, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 434);
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
            this.dgv_DanhSachBanBe.Size = new System.Drawing.Size(250, 415);
            this.dgv_DanhSachBanBe.TabIndex = 0;
            this.dgv_DanhSachBanBe.SelectionChanged += new System.EventHandler(this.dgv_DanhSachBanBe_SelectionChanged);
            // 
            // dgv_ID
            // 
            this.dgv_ID.HeaderText = "ID";
            this.dgv_ID.Name = "dgv_ID";
            this.dgv_ID.Visible = false;
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
            this.lbl_HoTen.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_HoTen.Location = new System.Drawing.Point(144, 9);
            this.lbl_HoTen.Name = "lbl_HoTen";
            this.lbl_HoTen.Size = new System.Drawing.Size(68, 24);
            this.lbl_HoTen.TabIndex = 2;
            this.lbl_HoTen.Text = "họ tên";
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Location = new System.Drawing.Point(733, 118);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(75, 23);
            this.btn_LamMoi.TabIndex = 3;
            this.btn_LamMoi.Text = "Làm mới";
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Location = new System.Drawing.Point(560, 147);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 434);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách nhóm";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(245, 415);
            this.dataGridView2.TabIndex = 0;
            // 
            // Menu_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 590);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_KetBan;
        private System.Windows.Forms.Button btn_DangXuat;
        private System.Windows.Forms.Button btn_QuanLy;
        private System.Windows.Forms.Button btn_NhanTinNhom;
        private System.Windows.Forms.Label lbl_HoTen;
        private System.Windows.Forms.Button btn_Chat;
        private System.Windows.Forms.DataGridView dgv_DanhSachBanBe;
        private System.Windows.Forms.Button btn_LamMoi;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_DanhSachDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_NguoiDung;
    }
}
namespace Client
{
    partial class DanhSachDen
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
            this.dgv_DanhSachChan = new System.Windows.Forms.DataGridView();
            this.btn_BoChan = new System.Windows.Forms.Button();
            this.txt_TenHienThi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_BoChanTatCa = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_TenHienThi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachChan)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_DanhSachChan
            // 
            this.dgv_DanhSachChan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachChan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_ID,
            this.dgv_TenHienThi});
            this.dgv_DanhSachChan.Location = new System.Drawing.Point(6, 19);
            this.dgv_DanhSachChan.Name = "dgv_DanhSachChan";
            this.dgv_DanhSachChan.Size = new System.Drawing.Size(243, 407);
            this.dgv_DanhSachChan.TabIndex = 0;
            this.dgv_DanhSachChan.SelectionChanged += new System.EventHandler(this.dgv_DanhSachChan_SelectionChanged);
            // 
            // btn_BoChan
            // 
            this.btn_BoChan.Location = new System.Drawing.Point(6, 19);
            this.btn_BoChan.Name = "btn_BoChan";
            this.btn_BoChan.Size = new System.Drawing.Size(150, 40);
            this.btn_BoChan.TabIndex = 2;
            this.btn_BoChan.Text = "Bỏ chặn";
            this.btn_BoChan.UseVisualStyleBackColor = true;
            this.btn_BoChan.Click += new System.EventHandler(this.btn_BoChan_Click);
            // 
            // txt_TenHienThi
            // 
            this.txt_TenHienThi.Location = new System.Drawing.Point(269, 261);
            this.txt_TenHienThi.Name = "txt_TenHienThi";
            this.txt_TenHienThi.Size = new System.Drawing.Size(152, 20);
            this.txt_TenHienThi.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tên hiển thị";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tìm kiếm";
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(269, 201);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(152, 20);
            this.txt_TimKiem.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_DanhSachChan);
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 426);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách chặn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_BoChanTatCa);
            this.groupBox1.Controls.Add(this.btn_BoChan);
            this.groupBox1.Location = new System.Drawing.Point(263, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 115);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức năng";
            // 
            // btn_BoChanTatCa
            // 
            this.btn_BoChanTatCa.Location = new System.Drawing.Point(8, 69);
            this.btn_BoChanTatCa.Name = "btn_BoChanTatCa";
            this.btn_BoChanTatCa.Size = new System.Drawing.Size(150, 40);
            this.btn_BoChanTatCa.TabIndex = 3;
            this.btn_BoChanTatCa.Text = "Bỏ chặn tất cả";
            this.btn_BoChanTatCa.UseVisualStyleBackColor = true;
            this.btn_BoChanTatCa.Click += new System.EventHandler(this.btn_BoChanTatCa_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Client.Properties.Resources.block_user;
            this.pictureBox1.Location = new System.Drawing.Point(274, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
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
            // DanhSachDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 450);
            this.Controls.Add(this.txt_TenHienThi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DanhSachDen";
            this.Text = "DanhSachDen";
            this.Load += new System.EventHandler(this.DanhSachDen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachChan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_DanhSachChan;
        private System.Windows.Forms.Button btn_BoChan;
        private System.Windows.Forms.TextBox txt_TenHienThi;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_BoChanTatCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_TenHienThi;
    }
}
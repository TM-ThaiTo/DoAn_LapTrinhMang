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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Chat_Group_Main));
            this.lsv_MessGroup = new System.Windows.Forms.ListView();
            this.pic_ChonFile = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pic_VoiceChat = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btn_Send = new Guna.UI2.WinForms.Guna2Button();
            this.txt_Mess = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.dgv_ThanhVien = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgv_ID_ThanhVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_NameThanhVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txt_Pass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_TenNhom = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_ChinhSua = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Luu = new Guna.UI2.WinForms.Guna2Button();
            this.btn_GiaiTan = new Guna.UI2.WinForms.Guna2Button();
            this.chk_AnHienPass_MatKhau = new Guna.UI2.WinForms.Guna2ImageCheckBox();
            this.pic_LamMoi = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Zoom = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Minimize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ChonFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_VoiceChat)).BeginInit();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThanhVien)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_LamMoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lsv_MessGroup
            // 
            this.lsv_MessGroup.HideSelection = false;
            this.lsv_MessGroup.Location = new System.Drawing.Point(12, 64);
            this.lsv_MessGroup.Name = "lsv_MessGroup";
            this.lsv_MessGroup.Size = new System.Drawing.Size(467, 489);
            this.lsv_MessGroup.TabIndex = 0;
            this.lsv_MessGroup.UseCompatibleStateImageBehavior = false;
            this.lsv_MessGroup.View = System.Windows.Forms.View.List;
            // 
            // pic_ChonFile
            // 
            this.pic_ChonFile.Image = global::Client.Properties.Resources.document;
            this.pic_ChonFile.ImageRotate = 0F;
            this.pic_ChonFile.Location = new System.Drawing.Point(378, 568);
            this.pic_ChonFile.Name = "pic_ChonFile";
            this.pic_ChonFile.Size = new System.Drawing.Size(23, 23);
            this.pic_ChonFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ChonFile.TabIndex = 19;
            this.pic_ChonFile.TabStop = false;
            this.pic_ChonFile.Click += new System.EventHandler(this.pic_ChonFile_Click);
            // 
            // pic_VoiceChat
            // 
            this.pic_VoiceChat.Image = global::Client.Properties.Resources.mic;
            this.pic_VoiceChat.ImageRotate = 0F;
            this.pic_VoiceChat.Location = new System.Drawing.Point(347, 568);
            this.pic_VoiceChat.Name = "pic_VoiceChat";
            this.pic_VoiceChat.Size = new System.Drawing.Size(23, 23);
            this.pic_VoiceChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_VoiceChat.TabIndex = 18;
            this.pic_VoiceChat.TabStop = false;
            this.pic_VoiceChat.Click += new System.EventHandler(this.pic_VoiceChat_Click);
            // 
            // btn_Send
            // 
            this.btn_Send.BorderRadius = 15;
            this.btn_Send.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Send.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Send.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Send.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Send.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Send.ForeColor = System.Drawing.Color.White;
            this.btn_Send.Location = new System.Drawing.Point(415, 559);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(64, 32);
            this.btn_Send.TabIndex = 93;
            this.btn_Send.Text = "Send";
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click_1);
            // 
            // txt_Mess
            // 
            this.txt_Mess.Animated = true;
            this.txt_Mess.BackColor = System.Drawing.Color.Transparent;
            this.txt_Mess.BorderRadius = 15;
            this.txt_Mess.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Mess.DefaultText = "";
            this.txt_Mess.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Mess.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Mess.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Mess.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Mess.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Mess.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_Mess.ForeColor = System.Drawing.Color.Black;
            this.txt_Mess.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Mess.Location = new System.Drawing.Point(12, 559);
            this.txt_Mess.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Mess.Name = "txt_Mess";
            this.txt_Mess.PasswordChar = '\0';
            this.txt_Mess.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txt_Mess.PlaceholderText = "Nhập tin nhắn";
            this.txt_Mess.SelectedText = "";
            this.txt_Mess.Size = new System.Drawing.Size(330, 32);
            this.txt_Mess.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txt_Mess.TabIndex = 92;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 20;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Controls.Add(this.dgv_ThanhVien);
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(485, 270);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.Size = new System.Drawing.Size(244, 321);
            this.guna2GroupBox1.TabIndex = 94;
            this.guna2GroupBox1.Text = "Thành viên nhóm";
            // 
            // dgv_ThanhVien
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgv_ThanhVien.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ThanhVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_ThanhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ThanhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_ID_ThanhVien,
            this.dgv_NameThanhVien});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ThanhVien.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_ThanhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ThanhVien.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_ThanhVien.Location = new System.Drawing.Point(0, 40);
            this.dgv_ThanhVien.Name = "dgv_ThanhVien";
            this.dgv_ThanhVien.RowHeadersVisible = false;
            this.dgv_ThanhVien.Size = new System.Drawing.Size(244, 281);
            this.dgv_ThanhVien.TabIndex = 0;
            this.dgv_ThanhVien.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_ThanhVien.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv_ThanhVien.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv_ThanhVien.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_ThanhVien.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv_ThanhVien.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv_ThanhVien.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_ThanhVien.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv_ThanhVien.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_ThanhVien.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv_ThanhVien.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_ThanhVien.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ThanhVien.ThemeStyle.HeaderStyle.Height = 17;
            this.dgv_ThanhVien.ThemeStyle.ReadOnly = false;
            this.dgv_ThanhVien.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv_ThanhVien.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_ThanhVien.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgv_ThanhVien.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.dgv_ThanhVien.ThemeStyle.RowsStyle.Height = 22;
            this.dgv_ThanhVien.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv_ThanhVien.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // dgv_ID_ThanhVien
            // 
            this.dgv_ID_ThanhVien.FillWeight = 30.45685F;
            this.dgv_ID_ThanhVien.HeaderText = "ID";
            this.dgv_ID_ThanhVien.Name = "dgv_ID_ThanhVien";
            // 
            // dgv_NameThanhVien
            // 
            this.dgv_NameThanhVien.FillWeight = 169.5432F;
            this.dgv_NameThanhVien.HeaderText = "Tên thành viên";
            this.dgv_NameThanhVien.Name = "dgv_NameThanhVien";
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.Controls.Add(this.chk_AnHienPass_MatKhau);
            this.guna2GroupBox2.Controls.Add(this.btn_GiaiTan);
            this.guna2GroupBox2.Controls.Add(this.btn_Luu);
            this.guna2GroupBox2.Controls.Add(this.btn_ChinhSua);
            this.guna2GroupBox2.Controls.Add(this.txt_Pass);
            this.guna2GroupBox2.Controls.Add(this.txt_TenNhom);
            this.guna2GroupBox2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GroupBox2.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(485, 86);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.Size = new System.Drawing.Size(244, 178);
            this.guna2GroupBox2.TabIndex = 95;
            this.guna2GroupBox2.Text = "Quán lý nhóm";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(9, 48);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(57, 17);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Tên nhóm";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(9, 71);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(26, 17);
            this.guna2HtmlLabel2.TabIndex = 0;
            this.guna2HtmlLabel2.Text = "Pass";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_Pass.DefaultText = "";
            this.txt_Pass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_Pass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_Pass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Pass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_Pass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Pass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Pass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_Pass.Location = new System.Drawing.Point(82, 67);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.PasswordChar = '●';
            this.txt_Pass.PlaceholderText = "";
            this.txt_Pass.ReadOnly = true;
            this.txt_Pass.SelectedText = "";
            this.txt_Pass.Size = new System.Drawing.Size(115, 21);
            this.txt_Pass.TabIndex = 4;
            // 
            // txt_TenNhom
            // 
            this.txt_TenNhom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_TenNhom.DefaultText = "";
            this.txt_TenNhom.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_TenNhom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_TenNhom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenNhom.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_TenNhom.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenNhom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_TenNhom.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_TenNhom.Location = new System.Drawing.Point(82, 44);
            this.txt_TenNhom.Name = "txt_TenNhom";
            this.txt_TenNhom.PasswordChar = '\0';
            this.txt_TenNhom.PlaceholderText = "";
            this.txt_TenNhom.ReadOnly = true;
            this.txt_TenNhom.SelectedText = "";
            this.txt_TenNhom.Size = new System.Drawing.Size(145, 21);
            this.txt_TenNhom.TabIndex = 5;
            // 
            // btn_ChinhSua
            // 
            this.btn_ChinhSua.BorderRadius = 10;
            this.btn_ChinhSua.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_ChinhSua.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ChinhSua.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_ChinhSua.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_ChinhSua.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_ChinhSua.ForeColor = System.Drawing.Color.White;
            this.btn_ChinhSua.Location = new System.Drawing.Point(27, 108);
            this.btn_ChinhSua.Name = "btn_ChinhSua";
            this.btn_ChinhSua.Size = new System.Drawing.Size(85, 24);
            this.btn_ChinhSua.TabIndex = 6;
            this.btn_ChinhSua.Text = "Chỉnh sửa";
            this.btn_ChinhSua.Click += new System.EventHandler(this.btn_ChinhSua_Click_1);
            // 
            // btn_Luu
            // 
            this.btn_Luu.BorderRadius = 10;
            this.btn_Luu.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Luu.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Luu.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Luu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Luu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Luu.ForeColor = System.Drawing.Color.White;
            this.btn_Luu.Location = new System.Drawing.Point(142, 108);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(85, 24);
            this.btn_Luu.TabIndex = 6;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click_1);
            // 
            // btn_GiaiTan
            // 
            this.btn_GiaiTan.BorderRadius = 10;
            this.btn_GiaiTan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_GiaiTan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_GiaiTan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_GiaiTan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_GiaiTan.FillColor = System.Drawing.Color.Red;
            this.btn_GiaiTan.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_GiaiTan.ForeColor = System.Drawing.Color.White;
            this.btn_GiaiTan.Location = new System.Drawing.Point(112, 151);
            this.btn_GiaiTan.Name = "btn_GiaiTan";
            this.btn_GiaiTan.Size = new System.Drawing.Size(115, 24);
            this.btn_GiaiTan.TabIndex = 6;
            this.btn_GiaiTan.Text = "Giải tán nhóm";
            this.btn_GiaiTan.Click += new System.EventHandler(this.btn_GiaiTan_Click_1);
            // 
            // chk_AnHienPass_MatKhau
            // 
            this.chk_AnHienPass_MatKhau.BackColor = System.Drawing.Color.Transparent;
            this.chk_AnHienPass_MatKhau.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.chk_AnHienPass_MatKhau.CheckedState.ImageSize = new System.Drawing.Size(18, 18);
            this.chk_AnHienPass_MatKhau.Image = ((System.Drawing.Image)(resources.GetObject("chk_AnHienPass_MatKhau.Image")));
            this.chk_AnHienPass_MatKhau.ImageOffset = new System.Drawing.Point(0, 0);
            this.chk_AnHienPass_MatKhau.ImageRotate = 0F;
            this.chk_AnHienPass_MatKhau.ImageSize = new System.Drawing.Size(18, 18);
            this.chk_AnHienPass_MatKhau.Location = new System.Drawing.Point(202, 70);
            this.chk_AnHienPass_MatKhau.Margin = new System.Windows.Forms.Padding(2);
            this.chk_AnHienPass_MatKhau.Name = "chk_AnHienPass_MatKhau";
            this.chk_AnHienPass_MatKhau.Size = new System.Drawing.Size(25, 20);
            this.chk_AnHienPass_MatKhau.TabIndex = 97;
            this.chk_AnHienPass_MatKhau.UseTransparentBackground = true;
            this.chk_AnHienPass_MatKhau.CheckedChanged += new System.EventHandler(this.chk_AnHienPass_MatKhau_CheckedChanged);
            // 
            // pic_LamMoi
            // 
            this.pic_LamMoi.Image = global::Client.Properties.Resources.loading_arrow;
            this.pic_LamMoi.ImageRotate = 0F;
            this.pic_LamMoi.Location = new System.Drawing.Point(696, 50);
            this.pic_LamMoi.Name = "pic_LamMoi";
            this.pic_LamMoi.Size = new System.Drawing.Size(30, 30);
            this.pic_LamMoi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_LamMoi.TabIndex = 96;
            this.pic_LamMoi.TabStop = false;
            this.pic_LamMoi.Click += new System.EventHandler(this.pic_LamMoi_Click);
            // 
            // Zoom
            // 
            this.Zoom.Animated = true;
            this.Zoom.AnimatedGIF = true;
            this.Zoom.BackColor = System.Drawing.Color.Transparent;
            this.Zoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Zoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Zoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Zoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Zoom.FillColor = System.Drawing.Color.Orange;
            this.Zoom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Zoom.ForeColor = System.Drawing.Color.White;
            this.Zoom.Location = new System.Drawing.Point(701, 11);
            this.Zoom.Margin = new System.Windows.Forms.Padding(2);
            this.Zoom.Name = "Zoom";
            this.Zoom.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Zoom.Size = new System.Drawing.Size(11, 12);
            this.Zoom.TabIndex = 120;
            this.Zoom.UseTransparentBackground = true;
            this.Zoom.Click += new System.EventHandler(this.Zoom_Click);
            // 
            // Minimize
            // 
            this.Minimize.Animated = true;
            this.Minimize.AnimatedGIF = true;
            this.Minimize.BackColor = System.Drawing.Color.Transparent;
            this.Minimize.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Minimize.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Minimize.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Minimize.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Minimize.FillColor = System.Drawing.Color.GreenYellow;
            this.Minimize.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Minimize.ForeColor = System.Drawing.Color.White;
            this.Minimize.Location = new System.Drawing.Point(685, 11);
            this.Minimize.Margin = new System.Windows.Forms.Padding(2);
            this.Minimize.Name = "Minimize";
            this.Minimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Minimize.Size = new System.Drawing.Size(11, 12);
            this.Minimize.TabIndex = 119;
            this.Minimize.UseTransparentBackground = true;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.Animated = true;
            this.guna2CircleButton1.AnimatedGIF = true;
            this.guna2CircleButton1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.FillColor = System.Drawing.Color.OrangeRed;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Location = new System.Drawing.Point(716, 11);
            this.guna2CircleButton1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(11, 12);
            this.guna2CircleButton1.TabIndex = 118;
            this.guna2CircleButton1.UseTransparentBackground = true;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::Client.Properties.Resources.chat;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(485, 12);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(50, 50);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 122;
            this.guna2PictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 32);
            this.label1.TabIndex = 121;
            this.label1.Text = "Chat Nhóm Chủ Phòng";
            // 
            // Form_Chat_Group_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 608);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Zoom);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.pic_LamMoi);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Mess);
            this.Controls.Add(this.pic_ChonFile);
            this.Controls.Add(this.pic_VoiceChat);
            this.Controls.Add(this.lsv_MessGroup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Chat_Group_Main";
            this.Text = "Form_Chat_Group_Main";
            this.Load += new System.EventHandler(this.Form_Chat_Group_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_ChonFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_VoiceChat)).EndInit();
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ThanhVien)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_LamMoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsv_MessGroup;
        private Guna.UI2.WinForms.Guna2PictureBox pic_ChonFile;
        private Guna.UI2.WinForms.Guna2PictureBox pic_VoiceChat;
        private Guna.UI2.WinForms.Guna2Button btn_Send;
        private Guna.UI2.WinForms.Guna2TextBox txt_Mess;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView dgv_ThanhVien;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_ID_ThanhVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_NameThanhVien;
        private Guna.UI2.WinForms.Guna2Button btn_GiaiTan;
        private Guna.UI2.WinForms.Guna2Button btn_Luu;
        private Guna.UI2.WinForms.Guna2Button btn_ChinhSua;
        private Guna.UI2.WinForms.Guna2TextBox txt_Pass;
        private Guna.UI2.WinForms.Guna2TextBox txt_TenNhom;
        private Guna.UI2.WinForms.Guna2ImageCheckBox chk_AnHienPass_MatKhau;
        private Guna.UI2.WinForms.Guna2PictureBox pic_LamMoi;
        private Guna.UI2.WinForms.Guna2CircleButton Zoom;
        private Guna.UI2.WinForms.Guna2CircleButton Minimize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label label1;
    }
}
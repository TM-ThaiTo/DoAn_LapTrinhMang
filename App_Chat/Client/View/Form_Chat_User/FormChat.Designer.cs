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
            this.components = new System.ComponentModel.Container();
            this.lbl_TenNguoiNhan = new System.Windows.Forms.Label();
            this.lsv_Message = new System.Windows.Forms.ListView();
            this.pic_ChonFile = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pic_VoiceChat = new Guna.UI2.WinForms.Guna2PictureBox();
            this.txt_Mess = new Guna.UI2.WinForms.Guna2TextBox();
            this.btn_Send = new Guna.UI2.WinForms.Guna2Button();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.Zoom = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Minimize = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ChonFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_VoiceChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TenNguoiNhan
            // 
            this.lbl_TenNguoiNhan.AutoSize = true;
            this.lbl_TenNguoiNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TenNguoiNhan.Location = new System.Drawing.Point(12, 81);
            this.lbl_TenNguoiNhan.Name = "lbl_TenNguoiNhan";
            this.lbl_TenNguoiNhan.Size = new System.Drawing.Size(109, 18);
            this.lbl_TenNguoiNhan.TabIndex = 8;
            this.lbl_TenNguoiNhan.Text = "Tên người nhận";
            // 
            // lsv_Message
            // 
            this.lsv_Message.HideSelection = false;
            this.lsv_Message.Location = new System.Drawing.Point(12, 102);
            this.lsv_Message.Name = "lsv_Message";
            this.lsv_Message.Size = new System.Drawing.Size(415, 327);
            this.lsv_Message.TabIndex = 7;
            this.lsv_Message.UseCompatibleStateImageBehavior = false;
            this.lsv_Message.View = System.Windows.Forms.View.List;
            // 
            // pic_ChonFile
            // 
            this.pic_ChonFile.Image = global::Client.Properties.Resources.document;
            this.pic_ChonFile.ImageRotate = 0F;
            this.pic_ChonFile.Location = new System.Drawing.Point(334, 443);
            this.pic_ChonFile.Name = "pic_ChonFile";
            this.pic_ChonFile.Size = new System.Drawing.Size(23, 23);
            this.pic_ChonFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ChonFile.TabIndex = 15;
            this.pic_ChonFile.TabStop = false;
            this.pic_ChonFile.Click += new System.EventHandler(this.pic_ChonFile_Click);
            // 
            // pic_VoiceChat
            // 
            this.pic_VoiceChat.Image = global::Client.Properties.Resources.mic;
            this.pic_VoiceChat.ImageRotate = 0F;
            this.pic_VoiceChat.Location = new System.Drawing.Point(303, 443);
            this.pic_VoiceChat.Name = "pic_VoiceChat";
            this.pic_VoiceChat.Size = new System.Drawing.Size(23, 23);
            this.pic_VoiceChat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_VoiceChat.TabIndex = 14;
            this.pic_VoiceChat.TabStop = false;
            this.pic_VoiceChat.Click += new System.EventHandler(this.pic_VoiceChat_Click);
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
            this.txt_Mess.Location = new System.Drawing.Point(12, 434);
            this.txt_Mess.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_Mess.Name = "txt_Mess";
            this.txt_Mess.PasswordChar = '\0';
            this.txt_Mess.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txt_Mess.PlaceholderText = "Nhập tin nhắn";
            this.txt_Mess.SelectedText = "";
            this.txt_Mess.Size = new System.Drawing.Size(284, 32);
            this.txt_Mess.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txt_Mess.TabIndex = 88;
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
            this.btn_Send.Location = new System.Drawing.Point(363, 435);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(64, 32);
            this.btn_Send.TabIndex = 89;
            this.btn_Send.Text = "Send";
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click_1);
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
            this.Zoom.Location = new System.Drawing.Point(405, 7);
            this.Zoom.Margin = new System.Windows.Forms.Padding(2);
            this.Zoom.Name = "Zoom";
            this.Zoom.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Zoom.Size = new System.Drawing.Size(11, 12);
            this.Zoom.TabIndex = 114;
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
            this.Minimize.Location = new System.Drawing.Point(389, 7);
            this.Minimize.Margin = new System.Windows.Forms.Padding(2);
            this.Minimize.Name = "Minimize";
            this.Minimize.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Minimize.Size = new System.Drawing.Size(11, 12);
            this.Minimize.TabIndex = 113;
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
            this.guna2CircleButton1.Location = new System.Drawing.Point(420, 7);
            this.guna2CircleButton1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(11, 12);
            this.guna2CircleButton1.TabIndex = 112;
            this.guna2CircleButton1.UseTransparentBackground = true;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Image = global::Client.Properties.Resources.chat;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(267, 10);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(50, 50);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 121;
            this.guna2PictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 32);
            this.label1.TabIndex = 120;
            this.label1.Text = "Chat User";
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(443, 481);
            this.Controls.Add(this.guna2PictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Zoom);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.guna2CircleButton1);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.txt_Mess);
            this.Controls.Add(this.pic_ChonFile);
            this.Controls.Add(this.pic_VoiceChat);
            this.Controls.Add(this.lbl_TenNguoiNhan);
            this.Controls.Add(this.lsv_Message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormChat";
            this.Text = "FormChat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormChat_FormClosing);
            this.Load += new System.EventHandler(this.FormChat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_ChonFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_VoiceChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_TenNguoiNhan;
        private System.Windows.Forms.ListView lsv_Message;
        private Guna.UI2.WinForms.Guna2PictureBox pic_VoiceChat;
        private Guna.UI2.WinForms.Guna2PictureBox pic_ChonFile;
        private Guna.UI2.WinForms.Guna2TextBox txt_Mess;
        private Guna.UI2.WinForms.Guna2Button btn_Send;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2CircleButton Zoom;
        private Guna.UI2.WinForms.Guna2CircleButton Minimize;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label label1;
    }
}
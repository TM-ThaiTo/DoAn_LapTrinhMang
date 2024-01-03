namespace Server
{
    partial class FormMain
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_StopServer = new System.Windows.Forms.Button();
            this.btn_StartServer = new System.Windows.Forms.Button();
            this.btn_Logout = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_DiaChi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TrangThai = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Logout);
            this.groupBox2.Controls.Add(this.btn_StopServer);
            this.groupBox2.Controls.Add(this.btn_StartServer);
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 186);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hệ thống";
            // 
            // btn_StopServer
            // 
            this.btn_StopServer.Location = new System.Drawing.Point(8, 73);
            this.btn_StopServer.Name = "btn_StopServer";
            this.btn_StopServer.Size = new System.Drawing.Size(181, 48);
            this.btn_StopServer.TabIndex = 0;
            this.btn_StopServer.Text = "Stop Server";
            this.btn_StopServer.UseVisualStyleBackColor = true;
            this.btn_StopServer.Click += new System.EventHandler(this.btn_StopServer_Click);
            // 
            // btn_StartServer
            // 
            this.btn_StartServer.Location = new System.Drawing.Point(8, 19);
            this.btn_StartServer.Name = "btn_StartServer";
            this.btn_StartServer.Size = new System.Drawing.Size(181, 48);
            this.btn_StartServer.TabIndex = 0;
            this.btn_StartServer.Text = "Start Server";
            this.btn_StartServer.UseVisualStyleBackColor = true;
            this.btn_StartServer.Click += new System.EventHandler(this.btn_StartServer_Click);
            // 
            // btn_Logout
            // 
            this.btn_Logout.Location = new System.Drawing.Point(8, 127);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(181, 48);
            this.btn_Logout.TabIndex = 0;
            this.btn_Logout.Text = "Logout";
            this.btn_Logout.UseVisualStyleBackColor = true;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_Port);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txt_DiaChi);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txt_TrangThai);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(195, 107);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Trạng thái Server";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(60, 77);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.ReadOnly = true;
            this.txt_Port.Size = new System.Drawing.Size(129, 20);
            this.txt_Port.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cổng";
            // 
            // txt_DiaChi
            // 
            this.txt_DiaChi.Location = new System.Drawing.Point(60, 51);
            this.txt_DiaChi.Name = "txt_DiaChi";
            this.txt_DiaChi.ReadOnly = true;
            this.txt_DiaChi.Size = new System.Drawing.Size(129, 20);
            this.txt_DiaChi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Địa chỉ IP";
            // 
            // txt_TrangThai
            // 
            this.txt_TrangThai.Location = new System.Drawing.Point(60, 25);
            this.txt_TrangThai.Name = "txt_TrangThai";
            this.txt_TrangThai.ReadOnly = true;
            this.txt_TrangThai.Size = new System.Drawing.Size(129, 20);
            this.txt_TrangThai.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trạng thái";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 319);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormMain";
            this.Text = "App_Chat Server ";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_StartServer;
        private System.Windows.Forms.Button btn_StopServer;
        private System.Windows.Forms.Button btn_Logout;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_DiaChi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TrangThai;
    }
}


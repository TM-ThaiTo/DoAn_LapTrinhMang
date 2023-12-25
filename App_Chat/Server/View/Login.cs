using DevExpress.Xpo.Helpers;
using Server.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Login : Form
    {
        Control_Server cs = new Control_Server();
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txt_Username.Text;
            string password = txt_Password.Text;
            string vaitro = "Admin";

            // Gọi phương thức Login_Server
            bool kq = cs.Login_Server(username, password, vaitro);

            if (kq)
            {
                FormMain fm = new FormMain();
                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!!!", "Lỗi", MessageBoxButtons.OK);
            }
        }
    }
}

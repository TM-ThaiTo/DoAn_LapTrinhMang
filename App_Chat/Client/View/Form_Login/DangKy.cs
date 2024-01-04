using Client.App.MaHoa;
using Client.App;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class DangKy : Form
    {
        #region Biến lưu thông tin 
        string usename_newUser;
        string name_newUser;
        string password_newUser;
        string cfpPassword_newUser;
        string soDienThoai_newUser;
        string email_newUser;
        string address_newUser;
        string age_newUser;
        #endregion
        
        #region Hàm xữ lý
        private void dienThongTin()
        {
            usename_newUser = txt_Username.Text;
            name_newUser = txt_Name.Text;
            password_newUser = txt_Password.Text;
            cfpPassword_newUser = txt_ConfimPassword.Text;
            soDienThoai_newUser = txt_SoDienThoai.Text;
            email_newUser = txt_Email.Text;
            address_newUser = txt_Address.Text;

            if (!string.IsNullOrEmpty(address_newUser))
            {
                address_newUser = "NULL";
            }
        }
        private bool kiemTraNhap()
        {
            if (string.IsNullOrEmpty(usename_newUser) ||
                string.IsNullOrEmpty(name_newUser) ||
                string.IsNullOrEmpty(password_newUser) ||
                string.IsNullOrEmpty(cfpPassword_newUser) ||
                string.IsNullOrEmpty(soDienThoai_newUser) ||
                string.IsNullOrEmpty(email_newUser))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!", " Thông báo ", MessageBoxButtons.OK);
                return false;
            }

            if (password_newUser != cfpPassword_newUser)
            {
                MessageBox.Show("Nhập mật khẩu xác nhận sai !!", "Lỗi", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        private void guiYeuCau()
        {
            // cấu trúc [NewUser]$username$password$name$phone$email$address$age
            string yeuCau = $"[NewUser]${usename_newUser.MaHoa()}${cfpPassword_newUser.MaHoa()}${name_newUser.MaHoa()}${soDienThoai_newUser.MaHoa()}${email_newUser.MaHoa()}${address_newUser.MaHoa()}";
            string ketQua = Result.Instance.Request(yeuCau);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Máy chủ không phản hồi", "Lỗi", MessageBoxButtons.OK);
            }
            else if (!ketQua.Equals("[NULL]"))
            {
                MessageBox.Show("Đăng kí thành công!!");
                Login fm = new Login();
                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản bị trùng vui lòng lấy tài khoản khác", "Thông báo", MessageBoxButtons.OK);
            }
        }
        private void dangKi()
        {
            dienThongTin();
            if (kiemTraNhap())
            {
                guiYeuCau();
            }
        }
        #endregion

        #region Form
        public DangKy()
        {
            InitializeComponent();
        }
        private void btn_DangKy_Click(object sender, EventArgs e)
        {
            dangKi();
        }
        private void chk_AnHienPass_MatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AnHienPass_MatKhau.Checked)
            {
                txt_Password.PasswordChar = '\0';
            }
            else
            {
                txt_Password.PasswordChar = '●';
            }
        }
        private void chk_AnHienPass_XacNhanMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AnHienPass_XacNhanMatKhau.Checked)
            {
                txt_ConfimPassword.PasswordChar = '\0';
            }
            else
            {
                txt_ConfimPassword.PasswordChar = '●';
            }
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login fm = new Login();
            this.Close();
            fm.Show();
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Minimize_Click(object sender, EventArgs e)
        {
            Minimize.Click += delegate {
                // Thu nhỏ form.
                this.WindowState = FormWindowState.Minimized;
            };
        }
        private void Zoom_Click(object sender, EventArgs e)
        {
            Zoom.Click += delegate {
                // Kiểm tra trạng thái hiện tại của form.
                if (this.WindowState == FormWindowState.Maximized)
                {
                    // Thu nhỏ form.
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    // Phóng to form.
                    this.WindowState = FormWindowState.Maximized;
                }
            };
        }
        #endregion
    }
}

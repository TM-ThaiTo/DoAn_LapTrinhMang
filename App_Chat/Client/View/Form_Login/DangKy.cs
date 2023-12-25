using Client.App.MaHoa;
using Client.App;
using System;
using System.Windows.Forms;
using DevExpress.XtraEditors.Filtering.Templates;
using Client.App.Class_MaHoa;

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

            if (!string.IsNullOrEmpty(email_newUser))
            {
                address_newUser = "NULL";
            }

            age_newUser = DateTime_String.Date_To_String(dtp_Age.Value);

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

            // Lấy ngày tháng năm hiện tại
            DateTime currentDate = DateTime.Now;
            DateTime ngaySinh = dtp_Age.Value.Date;
            if (ngaySinh > currentDate)
            {
                MessageBox.Show("Vui lòng nhập ngày sinh phải nhỏ hơn ngày hiện tại!!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        private void guiYeuCau()
        {
            // cấu trúc [NewUser]$username$password$name$phone$email$address$age
            string yeuCau = $"[NewUser]${usename_newUser.MaHoa()}${cfpPassword_newUser.MaHoa()}${name_newUser.MaHoa()}${soDienThoai_newUser.MaHoa()}${email_newUser.MaHoa()}${address_newUser.MaHoa()}${age_newUser.MaHoa()}";
            string ketQua = Result.Instance.Request(yeuCau);

            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Máy chủ không phản hồi", "Lỗi", MessageBoxButtons.OK);
            }
            else if (!ketQua.Equals("[NULL]"))
            {
                MessageBox.Show("Đăng kí thành công!!");
                Login fm = new Login();
                fm.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản bị trùng vui lòng lấy tài khoản khác", "Thông báo", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region Form
        public DangKy()
        {
            InitializeComponent();
        }
        private void btn_DangKi_Click(object sender, EventArgs e)
        {
            dienThongTin();
            if (kiemTraNhap())
            {
                guiYeuCau();
            }
        }
        #endregion
    }
}

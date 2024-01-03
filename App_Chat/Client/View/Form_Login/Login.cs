using Client.App;
using Client.App.Class_ThongTinUser;
using Client.App.MaHoa;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Login : Form
    {
        #region Hàm xử lý đăng nhập
        private void guiYeuCau_DangNhap(string username, string password) // gửi yêu cầu và thực hiện yêu cầu
        {
            // Cấu trúc [Login]$UserName$Password;
            string yeuCau = $"[Login]${username.MaHoa()}${password.MaHoa()}";

            string ketQua = Result.Instance.Request(yeuCau);
            XuLyKetQua_Login(ketQua);
        }
        private void XuLyKetQua_Login(string ketQua) // xử lý kết quả trả về từ server
        {
            if (string.IsNullOrEmpty(ketQua))
            {
                //MessageBox.Show("Máy chủ không phản hồi", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            else if (!ketQua.Equals("[NULL]"))
            {
                // Phân tích thông tin từ chuỗi phản hồi và lưu vào UserInfo
                //[OK]$ID$username$password$HoTen$Email$SoDienThoai$serverIP$address$age
                string[] parts = ketQua.Split('$');
                
                string IDuser = parts[1].ToString();
                string username = parts[2].GiaiMa();
                string password = parts[3].GiaiMa();
                string name = parts[4].GiaiMa();
                string email = parts[5].GiaiMa();
                string soDienThoai = parts[6].GiaiMa();
                string serverIP = parts[7].GiaiMa();
                string address = parts.Length > 8 ? parts[8].GiaiMa() : null;
                
                // Lưu thông tin vào UserInfo
                themThongTin_User(IDuser, username, password, name, email, soDienThoai, serverIP, address);

                // Chuyển đến form Menu
                Menu_Form fm = new Menu_Form();
                fm.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }
        private void themThongTin_User(string IDuser, string username, string password, string name, string email, string soDienThoai, string serverIP, string address)
        {
            // Làm mới thông tin người dùng trước khi thêm thông tin mới
            UserInfo.Instance.ResetUserInfo();

            // Đặt giá trị mới
            UserInfo.Instance.Id = IDuser;
            UserInfo.Instance.Username = username;
            UserInfo.Instance.Password = password;
            UserInfo.Instance.Name = name;
            UserInfo.Instance.Email = email;
            UserInfo.Instance.SoDienThoai = soDienThoai;
            UserInfo.Instance.ServerIP = serverIP;
            UserInfo.Instance.Address = address;
        }
        private bool kiemTraNhap(string username, string password) // kiểm tra nhập
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!", "Thông báo");
                return false;
            }

            return true;
        }
        private void login()//Hàm login
        {
            string use_name = txt_Username.Text;
            string password = txt_Password.Text;

            // Kiểm tra xem cả hai trường dữ liệu đã được nhập hay chưa
            if (kiemTraNhap(use_name, password) == false)
            {
                return;
            }
            guiYeuCau_DangNhap(use_name, password);
        }
        private void dangki() // hàm đăng kí
        {
            DangKy fm = new DangKy();
            fm.Show();
            this.Hide();
        }
        #endregion

        #region Form
        public Login()
        {
            InitializeComponent();
        }
        private void btn_Login_Click(object sender, EventArgs e)
        {
            login();
        }
        private void btn_DangKi_Click(object sender, EventArgs e)
        {
           dangki();
        }
        #endregion
    }
}

using Client.App;
using Client.App.Class_MaHoa;
using Client.App.Class_ThongTinUser;
using Client.App.MaHoa;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Client
{
    public partial class QuanLy : Form
    {
        #region Biến lưu trữ toàn form
        string name_form;
        string password_form;
        string soDienThoai_form;
        string email_form;
        string address_form;
        string age_form;

        string duongDanAnh;
        string duongDanBit;

        byte[] pic_User;
        #endregion

        #region Hàm chức năng quản lý thông tin nhập
        private void hienThi_ThongTin() // hàm hiển thị thông tin lên form
        {
            txt_TenHienThi.Text = UserInfo.Instance.Name;
            txt_TaiKhoan.Text = UserInfo.Instance.Username;
            txt_Password.Text = UserInfo.Instance.Password;
            txt_SoDienThoai.Text = UserInfo.Instance.SoDienThoai;
            txt_Email.Text = UserInfo.Instance.Email;

            // Chuỗi ngày tháng năm
            string dateString = UserInfo.Instance.Age;
            dtp_Age.Value = DateTime_String.String_To_Date(dateString);

            string userAddress = UserInfo.Instance.Address;
            txt_Address.Text = userAddress ?? string.Empty;
        }
        private void thongTin_ReadOnly_true() // hàm mở readonly
        {
            txt_TenHienThi.ReadOnly = true;
            txt_TaiKhoan.ReadOnly = true;
            txt_Password.ReadOnly = true;
            txt_SoDienThoai.ReadOnly = true;
            txt_Email.ReadOnly = true;
            txt_Address.ReadOnly = true;

            btn_ChonAnh.Enabled = false;
            btn_LuuThongTin.Enabled = false;
        }
        private void thongTin_ReadOnly_false() // hàm đóng readonly
        {
            txt_TenHienThi.ReadOnly = false;
            txt_SoDienThoai.ReadOnly = false;
            txt_Email.ReadOnly = false;

            btn_ChonAnh.Enabled = true;
        }
        private bool kiemTraEmail(string email)
        {
            // Biểu thức chính quy kiểm tra định dạng email
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Kiểm tra sự khớp định dạng email
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        private bool kiemTraNhap() // hàm kiểm tra nhập
        {
            string name = txt_TenHienThi.Text;
            string username = txt_TaiKhoan.Text;
            string password = txt_Password.Text;
            string soDienThoai = txt_SoDienThoai.Text;
            string email = txt_Email.Text;

            if(string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(soDienThoai) ||
                string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!", "Thông báo", MessageBoxButtons.OK);
                return false;
            }

            if(kiemTraEmail(email) == false)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng email!!", "Thông báo", MessageBoxButtons.OK);
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
        private void dienThongTinForm()
        {
            name_form = txt_TenHienThi.Text;
            password_form = txt_Password.Text;
            soDienThoai_form = txt_SoDienThoai.Text;
            email_form = txt_Email.Text;
            address_form = txt_Address.Text;
            age_form = DateTime_String.Date_To_String(dtp_Age.Value);
        }
        private void AddImage() // hàm chọn ảnh và thêm ảnh
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                duongDanAnh = openFile.FileName;
                //byte[] imageBytes = ConvertImgToByte(openFile.FileName);
                byte[] imageBytes = PicToByte.ConvertImgToByte(duongDanAnh);
                pic_User = imageBytes;
                // Lưu dữ liệu hình ảnh dưới dạng chuỗi Base64
                string base64Image = Convert.ToBase64String(imageBytes);
                duongDanBit = base64Image;

                // Chuyển byte array thành hình ảnh
                //Image originalImage = ByteToImg(imageBytes);
                Image originalImage = PicToByte.ByteToImg(imageBytes);

                // Kích thước cố định cho PictureBox
                int fixedWidth = 150; // Đổi kích thước theo nhu cầu của bạn
                int fixedHeight = 200; // Đổi kích thước theo nhu cầu của bạn

                // Tạo hình ảnh mới với kích thước cố định
                Image resizedImage = new Bitmap(fixedWidth, fixedHeight);
                using (Graphics g = Graphics.FromImage(resizedImage))
                {
                    g.DrawImage(originalImage, 0, 0, fixedWidth, fixedHeight);
                }

                // Hiển thị hình ảnh cố định trên PictureBox
                pic_Avata.Image = resizedImage;
            }
        }
        #endregion

        #region Hàm gửi đến server
        private void guiYeuCau() // gửi yêu cầu và thực hiện yêu cầu
        {
            string id = UserInfo.Instance.Id;
            string username = UserInfo.Instance.Username;
            string password = password_form;
            string name = name_form;
            string soDienThoai = soDienThoai_form;
            string email = email_form;
            string address = address_form;
            string age = age_form;

            MessageBox.Show(age);
            //string anh = (string)(pic_User);
            // [UpdateInfo]$id$username$password$hoten$soDienThoai$email$address$age
            string yeuCau = $"[UpdateInfo]${id.MaHoa()}${username.MaHoa()}${password.MaHoa()}${name.MaHoa()}${soDienThoai.MaHoa()}${email.MaHoa()}${address.MaHoa()}${age.MaHoa()}";

            // Gửi yêu cầu và nhận kết quả từ server
            string ketQua = Result.Instance.Request(yeuCau); // [OK]
            XuLyKetQua_Login(ketQua);
        }
        private void XuLyKetQua_Login(string ketQua) // xử lý kết quả trả về từ server
        {
            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Máy chủ không phản hồi", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            else if (!ketQua.Equals("[NULL]"))
            {
                MessageBox.Show("Đã cập nhập thông tin thành công!!");
                themThongTin_User();
            }
            else
            {
                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }
        private void themThongTin_User()
        {
            // Đặt giá trị mới
            UserInfo.Instance.Password = password_form;
            UserInfo.Instance.Name = name_form;
            UserInfo.Instance.Email = email_form;
            UserInfo.Instance.SoDienThoai = soDienThoai_form;
            UserInfo.Instance.Address = address_form;
            UserInfo.Instance.Age = age_form;
        }
        #endregion

        #region Hàm quản lý form
        private void thongTin()
        {
            hienThi_ThongTin();
            thongTin_ReadOnly_true();
        }
        private void suaThongTin()
        {
            thongTin_ReadOnly_false();
            btn_LuuThongTin.Enabled = true;
        }
        private void luuThongTin()
        {
            if (kiemTraNhap() == false)
            {
                return;
            }
            else
            {
                dienThongTinForm();
                guiYeuCau();
                btn_LuuThongTin.Enabled = false;
            }
        }
        #endregion

        #region Cấu hình Form
        public QuanLy()
        {
            InitializeComponent();
        }
        private void QuanLyThongTin_User_Load(object sender, EventArgs e)
        {
            thongTin();
        }
        private void btn_ChonAnh_Click(object sender, EventArgs e)
        {
            AddImage();
        }
        private void btn_SuaThongTin_Click(object sender, EventArgs e)
        {
            suaThongTin();
        }
        private void btn_LuuThongTin_Click(object sender, EventArgs e)
        {
            luuThongTin();
        }
        #endregion
    }
}

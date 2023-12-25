using Client.App;
using Client.App.Class_ThongTinUser;
using Client.App.MaHoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class SendEmail : Form
    {
        #region Biến lưu trữ
        string email;
        string OTP;
        #endregion

        #region Hàm xử lý chức năng
        private static Random random = new Random();
        public static int RandomOTP()
        {
            int otp = random.Next(100000, 999999);
            return otp;
        }
        private void guiYeuCau()
        {
            email = UserInfo.Instance.Email;
            string OTP = RandomOTP().ToString();
            string yeuCau = $"[SendMail_Login]${email.MaHoa()}${OTP.MaHoa()}";
            string ketQua = Result.Instance.Request(yeuCau);
            xuLyKetQua(ketQua);
        }
        private void xuLyKetQua(string ketQua)
        {
            if (string.IsNullOrEmpty(ketQua))
            {
                MessageBox.Show("Máy chủ không phản hồi", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            else if (!ketQua.Equals("[NULL]"))
            {
                MessageBox.Show("Đã gửi OTP đến Email!!", "Thông báo");
            }
            else
            {
                return;
            }
        }
        private bool kiemTraOTP()
        {
            string OTP_Nhap = txt_OTP_Nhap.Text;
            if(kiemTraNhap() == true)
            {
                if(OTP_Nhap == OTP)
                {
                    return true;
                }
            }
            return false;
        }
        private bool kiemTraNhap()
        {
            string OTP_Nhap = txt_OTP_Nhap.Text;
            if (string.IsNullOrEmpty(OTP_Nhap))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Chức năng của Form
        public SendEmail() // vừa chạy form thì gửi email
        {
            InitializeComponent();
            guiYeuCau();
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            if(kiemTraOTP() == true)
            {
                MessageBox.Show("Đăng nhập thành công!!", "Thông báo");
                Menu_Form fm = new Menu_Form();
                fm.Show();
                this.Hide();
            }
        }
        private void btn_GuiLai_Click(object sender, EventArgs e)
        {
            guiYeuCau();
        }
        #endregion


    }
}

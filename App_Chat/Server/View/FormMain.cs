using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.App;

namespace Server
{
    public partial class FormMain : Form
    {
        #region Biến của form
        Control_Server sv;
        private bool isServerStart = false;
        #endregion

        #region Hàm chức năng
        // Stop Server
        private void stop_sv()
        {
            try
            {
                btn_StartServer.Enabled = true; // bật nút bắt đầu server
                btn_StopServer.Enabled = false; // tắt nút stop server
                txt_TrangThai.Text = "Ngừng hoạt động!!";
                txt_DiaChi.Text = "";
                txt_Port.Text = "";
                sv.Stop();
                isServerStart = false;
            }
            catch
            {
                MessageBox.Show("Lỗi khi dừng server!!", "Lỗi");
            }
        }
        // Logout Server
        private void Logout()
        {
            Login fm = new Login();
            fm.Show();
            this.Hide();
        }
        #endregion

        #region Cấu hình và nút của form
        public FormMain()
        {
            InitializeComponent();
            sv = new Control_Server();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            txt_TrangThai.Text = "Ngừng hoạt động!!";
            btn_StopServer.Enabled = false;
        }
        
        // Star Server
        private async void btn_StartServer_Click(object sender, EventArgs e)
        {
            try
            {
                btn_StartServer.Enabled = false; // Tắt nút bắt server
                btn_StopServer.Enabled = true; // bật nút tắt server
                txt_TrangThai.Text = "Đang hoạt động";
                txt_DiaChi.Text = sv.serverIP.ToString();
                txt_Port.Text = sv.port.ToString();
                await Task.Run(() =>
                {
                    sv.Start(); // Khởi động server
                    isServerStart = true;
                });
            }
            catch
            {
                MessageBox.Show("Lỗi khi khởi động server!!", "Lỗi");
            }
        }
        
        //Nút stop server
        private void btn_StopServer_Click(object sender, EventArgs e)
        {
            stop_sv();
        }
        
        // Nút logout server
        private void btn_Logout_Click(object sender, EventArgs e)
        {
            if (isServerStart == true)
            {
                // Hiển thị hộp thoại xác nhận với người dùng
                DialogResult result = MessageBox.Show("Server đang hoạt động. Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    stop_sv();
                    Logout();
                }
            }
            else
            {
                Logout();
            }
        }
        #endregion
    }
}

using Client.App;
using Client.App.Class_ThongTinUser;
using Client.App.MaHoa;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Menu_Form : Form
    {
        #region Biến
        string id_BanBe;
        string HoTen_BanBe;

        private CancellationTokenSource cancellationTokenSource;

        #endregion

        #region Hàm xữ lý
        private void guiYeuCau(int title)
        {
            if(title == 0) // load list bạn bè
            {
                string yeuCau = $"[Load_Friend]${UserInfo.Instance.Id}";
                string ketQua = Result.Instance.Request(yeuCau);
                XuLyKetQua(ketQua, title);
            }
            else if(title == 1)
            {
                return;
            }
        }
        private void XuLyKetQua(string ketQua, int title) // xử lý kết quả trả về từ server
        {
            if (string.IsNullOrEmpty(ketQua))
            {
                //MessageBox.Show("Máy chủ không phản hồi", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            // titile: 0: load_listFriend --- 1: load_ListGroup
            else if (!ketQua.Equals("[NULL]") && title == 0)
            {
                Fill_ListFriend(ketQua);
                return;
            }
            else if (!ketQua.Equals("[NULL]") && title == 1)
            {
                MessageBox.Show("Đã gửi yêu cầu kết bạn", "Thông báo");
                return;
            }
            else if (!ketQua.Equals("[NULL]") && title == 2)
            {
                MessageBox.Show("Đã chặn người dùng!!", "Thông báo");
                return;
            }
            else
            {
                return;
            }
        }
        private void Fill_ListFriend(string ketQua) // fill kết quả từ server lên datagirdView
        {
            dgv_DanhSachBanBe.Rows.Clear(); // Xóa tất cả các hàng hiện tại
            string[] parts = ketQua.Split('$');
            // Thêm dữ liệu từ các phần tách được vào DataTable
            for (int i = 1; i < parts.Length; i += 2)
            {
                if (parts[i] != UserInfo.Instance.Id && parts[i+1] != UserInfo.Instance.Name)
                {
                    string id = parts[i];
                    string hoTen = parts[i + 1].GiaiMa();

                    dgv_DanhSachBanBe.Rows.Add(id, hoTen);
                }
            }
        }
        private void LamMoi()
        {
            lbl_HoTen.Text = UserInfo.Instance.Name;
            guiYeuCau(0);
            guiYeuCau(1);
        }
        private void dgv_DanhSachBanBe_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (dgv_DanhSachBanBe.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                DataGridViewRow selectedRow = dgv_DanhSachBanBe.SelectedRows[0];

                id_BanBe = selectedRow.Cells[0].Value.ToString();
                HoTen_BanBe = selectedRow.Cells[1].Value.ToString();
            }
            else
            {
                return;
            }
        }
        private void close_Form() 
        {
            cancellationTokenSource?.Cancel(); // Hủy bỏ vòng lặp khi form đóng
        }

        #endregion

        #region Hàm của form
        public Menu_Form()
        {
            InitializeComponent();
        }
        private async void Menu_Form_Load(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();

            await Task.Run(async () =>
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    LamMoi();
                    // Sử dụng Task.Delay thay vì Thread.Sleep để tránh đóng băng luồng
                    await Task.Delay(10000);
                }
            });
        }

        private void btn_QuanLy_Click(object sender, EventArgs e)
        {
            QuanLy fm = new QuanLy();
            fm.Show();
        }

        private void btn_KetBan_Click(object sender, EventArgs e)
        {
            KetBan frm = new KetBan();
            frm.Show();
        }

        private void btn_DanhSachDen_Click(object sender, EventArgs e)
        {
            DanhSachDen frm = new DanhSachDen();
            frm.Show();
        }

        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
        private void btn_Chat_Click(object sender, EventArgs e)
        {
            Chat_User cu = new Chat_User(UserInfo.Instance.Id, UserInfo.Instance.Name, id_BanBe, HoTen_BanBe);
            cu.Show();
        }
        private void btn_DangXuat_Click(object sender, EventArgs e)
        {

        }
        private void Menu_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            close_Form();
        }
        #endregion

    }
}

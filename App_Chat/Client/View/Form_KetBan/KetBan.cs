using Client.App;
using Client.App.Class_ThongTinUser;
using Client.App.MaHoa;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class KetBan : Form
    {
        #region Biến của form
        string id;
        string tenHienThi;
        #endregion

        #region Hàm xữ lý
        private void LocKetQua(string ketQua)
        {
            if (string.IsNullOrEmpty(ketQua))
            {
                return;
            }
            else if (!ketQua.Equals("[NULL]"))
            {
                Fill_User(ketQua);
                return;
            }
            
            else
            {
                return;
            }
        }
        private void Fill_User(string ketQua) // fill kết quả từ server lên datagirdView
        {
            string[] parts = ketQua.Split('$');
            string trangThai = parts[0];
            if(trangThai == "[OK_Load_ListUser]")
            {
                // Thêm dữ liệu từ các phần tách được vào DataTable
                for (int i = 1; i < parts.Length; i += 2)
                {
                    string id = parts[i];
                    string hoTen = parts[i + 1].GiaiMa();

                    dgv_DanhSachNguoiDung.Rows.Add(id, hoTen);
                }
                return;
            }
            if(ketQua == "[Done_Block_User]")
            {
                MessageBox.Show("Đã chặn người dùng");
            }

            if (ketQua == "[Pending]")
            {
                MessageBox.Show("Đã gửi yêu cầu kết bạn!!");
                return;
            }
            if (ketQua == "[Accept]")
            {
                MessageBox.Show("Đã chấp nhận kết bạn!!");
                return;
            }
            if (ketQua == "[Done_Friend]")
            {
                MessageBox.Show("Hai người dùng đã là bạn bè!!");
                return;
            }
            if (ketQua == "[Block_Friend]")
            {
                MessageBox.Show("Bạn đã chặn người dùng hoặc đã bị người dùng chặn không thể kết bạn!!");
                return;
            }
        }
        private void dgv_DanhSachNguoiDung_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (dgv_DanhSachNguoiDung.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                DataGridViewRow selectedRow = dgv_DanhSachNguoiDung.SelectedRows[0];

                 id = selectedRow.Cells[0].Value.ToString();
                 tenHienThi = selectedRow.Cells[1].Value.ToString();

                txt_TenHienThi.Text = tenHienThi;
            }
            else
            {
                // Nếu không có hàng nào được chọn, làm các thao tác phù hợp hoặc để trống
                id = string.Empty;
                tenHienThi = string.Empty;
                txt_TenHienThi.Text = string.Empty;
            }
        }
        private bool kiemTraThongTin() // hàm kiểm tra thông tin trước xữ lý
        {
            if (id == null || tenHienThi == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng!!", "Thông tin");
                return false;
            }
            return true;
        }
        #endregion

        #region Hàm gửi đến server
        private void bketBan()
        {
            if (kiemTraThongTin() == false)
            {
                return;
            }
            string yeuCau = $"[Make_Friend]${UserInfo.Instance.Id}${id}";
            string ketQua = Result.Instance.Request(yeuCau);
            LocKetQua(ketQua);
        }
        private void chan()
        {
            if (kiemTraThongTin() == false)
            {
                return;
            }
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn chặn người dùng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string yeuCau = $"[Block_User]${UserInfo.Instance.Id}${id}";
                string ketQua = Result.Instance.Request(yeuCau);
                LocKetQua(ketQua);
            }
            else
            {
                return;
            }
        }
        private void load_DanhSachUser()
        {
            // [Load_User]$id
            string yeuCau = $"[Load_User]${UserInfo.Instance.Id}";
            string ketQua = Result.Instance.Request(yeuCau);
            LocKetQua(ketQua);
        }
        #endregion

        #region Cấu hình form
        public KetBan()
        {
            InitializeComponent();
        }
        private void btn_KetBan_Click(object sender, EventArgs e)
        {
            bketBan();
        }
        private void btn_Chan_Click(object sender, EventArgs e)
        {
            chan();
        }
        private void KetBan_Load(object sender, EventArgs e)
        {
            load_DanhSachUser();
        }
        #endregion
    }
}

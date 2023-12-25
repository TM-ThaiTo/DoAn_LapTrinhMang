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
                //MessageBox.Show("Máy chủ không phản hồi", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            else if (!ketQua.Equals("[NULL]"))
            {
                Fill_User(ketQua);
                return;
            }
            else if (ketQua == "[Pending]")
            {
                MessageBox.Show("Đã gửi yêu cầu kết bạn!!");
            }
            else if (ketQua == "[Accept]")
            {
                MessageBox.Show("Đã chấp nhận kết bạn!!");
            }
            else if (ketQua == "[Done_Friend]")
            {
                MessageBox.Show("Hai người dùng đã là bạn bè!!");
            }
            else if (ketQua == "[Block_Friend]")
            {
                MessageBox.Show("Bạn đã chặn người dùng hoặc đã bị người dùng chặn không thể kết bạn!!");
            }
            else
            {
                return;
            }
        }
        private void Fill_User(string ketQua) // fill kết quả từ server lên datagirdView
        {
            string[] parts = ketQua.Split('$');
            // Thêm dữ liệu từ các phần tách được vào DataTable
            for (int i = 1; i < parts.Length; i += 2)
            {
                string id = parts[i];
                string hoTen = parts[i + 1].GiaiMa();

                dgv_DanhSachNguoiDung.Rows.Add(id, hoTen);
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

        #region Cấu hình form
        public KetBan()
        {
            InitializeComponent();
        }

        private void btn_KetBan_Click(object sender, EventArgs e)
        {
            if (kiemTraThongTin() == false)
            {
                return;
            }
            string yeuCau = $"[Make_Friend]${UserInfo.Instance.Id}${id}";
            string ketQua = Result.Instance.Request(yeuCau);
            LocKetQua(ketQua);
        }

        private void btn_Chan_Click(object sender, EventArgs e)
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

        private void KetBan_Load(object sender, EventArgs e)
        {
            // [Load_User]$id
            string yeuCau = $"[Load_User]${UserInfo.Instance.Id}";
            string ketQua = Result.Instance.Request(yeuCau);
            LocKetQua(ketQua);
        }
    }
    #endregion

}

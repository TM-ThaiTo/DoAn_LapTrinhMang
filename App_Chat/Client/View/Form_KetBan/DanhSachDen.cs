using Client.App.Class_ThongTinUser;
using Client.App;
using System;
using System.Windows.Forms;
using Client.App.MaHoa;

namespace Client
{
    public partial class DanhSachDen : Form
    {
        #region Biến của form
        string id;
        string TenHienThi;
        #endregion

        #region Hàm xữ lý
        private void XuLyKetQua(string ketQua) // xử lý kết quả trả về từ server
        {
            if (string.IsNullOrEmpty(ketQua))
            {
                //MessageBox.Show("Máy chủ không phản hồi", "Lỗi", MessageBoxButtons.OK);
                return;
            }
            // titile: 0: load danh sách --- 1: bo chan --- 2: bo chan tat ca
            else if (!ketQua.Equals("[NULL]"))
            {
                Fill_KetQua(ketQua);
                return;
            }
            else
            {
                return;
            }
        }
        private void Fill_KetQua(string ketQua) // fill kết quả từ server lên datagirdView
        {
            string[] parts = ketQua.Split('$');
            string trangThai = parts[0];

            if( trangThai == "[OK_LoadListBlock]")
            {
                // Thêm dữ liệu từ các phần tách được vào DataTable
                for (int i = 1; i < parts.Length; i += 2)
                {
                    string id = parts[i];
                    string hoTen = parts[i + 1].GiaiMa();

                    dgv_DanhSachChan.Rows.Add(id, hoTen);
                }
                return;
            }
            if(trangThai == "[Done_Un_BlockUser]")
            {
                MessageBox.Show("Đã bỏ chặn người dùng!");
                return;
            }
            if (trangThai == "[Done_UnBlockAll]")
            {
                MessageBox.Show("Đã bỏ chăn tất cả người dùng!");
                return;
            }
        }
        private void dgv_DanhSachChan_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (dgv_DanhSachChan.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                DataGridViewRow selectedRow = dgv_DanhSachChan.SelectedRows[0];

                id = selectedRow.Cells[0].Value.ToString();
                TenHienThi = selectedRow.Cells[1].Value.ToString();

                txt_TenHienThi.Text = TenHienThi;
                btn_BoChan.Enabled = true;
            }
            else
            {
                // Nếu không có hàng nào được chọn, làm các thao tác phù hợp hoặc để trống
                id = string.Empty;
                TenHienThi = string.Empty;
                txt_TenHienThi.Text = string.Empty;
                btn_BoChan.Enabled = false;
            }
        }
        private bool kiemTraNhap()
        {
            if(id == null || TenHienThi == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng muốn bỏ chặn!!");
                return false;
            }
            return true;
        }
        #endregion

        #region Hàm chức năng của form
        private void Load_danhSachDen()
        {
            // [Load_User]$id
            string yeuCau = $"[Load_Block_User]${UserInfo.Instance.Id}";
            string ketQua = Result.Instance.Request(yeuCau);
            XuLyKetQua(ketQua);
            btn_BoChan.Enabled = false;
        }
        private void un_Block()
        {
            if (kiemTraNhap() == false)
            {
                return;
            }
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn chặn người dùng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // [Un_Block_User]$id1$id2
                string yeuCau = $"[Un_Block_User]${UserInfo.Instance.Id}${id}";
                string ketQua = Result.Instance.Request(yeuCau);
                XuLyKetQua(ketQua);
            }
            else
            {
                return;
            }
        }
        private void un_block_all()
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn bỏ chặn tất người dùng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // [Un_Block_User]$id1
                string yeuCau = $"[Un_Block_All]${UserInfo.Instance.Id}";
                string ketQua = Result.Instance.Request(yeuCau);
                XuLyKetQua(ketQua);
            }
            else
            {
                return;
            }
        }
        #endregion

        #region Hàm của form
        public DanhSachDen()
        {
            InitializeComponent();
        }
        private void DanhSachDen_Load(object sender, EventArgs e)
        {
            Load_danhSachDen();
        }
        private void btn_BoChan_Click(object sender, EventArgs e)
        {
            un_Block();
        }
        private void btn_BoChanTatCa_Click(object sender, EventArgs e)
        {
            un_block_all();
        }
        #endregion
    }
}

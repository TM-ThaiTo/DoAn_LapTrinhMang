using Client.App;
using Client.App.Class_ThongTinUser;
using Client.App.MaHoa;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Menu_Form : Form
    {
        #region Biến
        // biến của Chat
        string id_BanBe;
        string Name_BanBe;

        // biến của group
        string id_Group;
        string name_Group;
        string pass_Group;
        int row_Group;

        private CancellationTokenSource cancellationTokenSource;
        #endregion

        #region Hàm xữ lý
        private bool kiemTraNhap()
        {
            if(string.IsNullOrEmpty(txt_TenNhom.Text) ||
                string.IsNullOrEmpty(txt_Pass.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhóm!!");
                return false;
            }
            return true;
        }
        private bool kiemTraChonGroup()
        {
            if(id_Group == null || name_Group == null)
            {
                MessageBox.Show("Vui lòng chọn thông tin Group!");
                return false;
            }
            return true;
        }
        private void guiYeuCau(int title)
        {
            if (title == 0) // load list bạn bè
            {
                string yeuCau = $"[Load_Friend]${UserInfo.Instance.Id}";
                string ketQua = Result.Instance.Request(yeuCau);
                XuLyKetQua(ketQua, title);
            }
            else if (title == 1)
            {
                string yeuCau = $"[Load_Group]${UserInfo.Instance.Id}";
                string ketQua = Result.Instance.Request(yeuCau);
                XuLyKetQua(ketQua, title);
            } // load list Nhóm
            else if (title == 2) 
            {
                if (kiemTraNhap() == false)
                {
                    return;
                }
                string nameGroup = txt_TenNhom.Text;
                string passgroup = txt_Pass.Text;

                // [New_Group]$id$nameGroup$pass
                string yeuCau = $"[New_Group]${UserInfo.Instance.Id}${nameGroup.MaHoa()}${passgroup.MaHoa()}";
                string ketQua = Result.Instance.Request(yeuCau);

                if (string.IsNullOrEmpty(ketQua))
                {
                    return;
                }
                else if (ketQua == "[OK]")
                {
                    MessageBox.Show("Tạo nhóm thành công!!");
                    LamMoi();
                    return;
                }// OK khi tạo thành công
                else if (ketQua == "[NULL]")
                {
                    MessageBox.Show("Tên phòng bị trùng vui lòng chọn tên khác");
                    return;
                }// NULL khi bị trùng tên
                else
                {
                    return;
                }
            } // tạo nhóm
            else if (title == 3) 
            {
                if (kiemTraNhap() == false)
                {
                    return;
                }
                string nameGroup = txt_TenNhom.Text;
                string passgroup = txt_Pass.Text;

                // [Join_Group]$id$nameGroup$pass
                string yeuCau = $"[Join_Group]${UserInfo.Instance.Id}${nameGroup.MaHoa()}${passgroup.MaHoa()}";
                string ketQua = Result.Instance.Request(yeuCau);
                if (string.IsNullOrEmpty(ketQua))
                {
                    return;
                }
                else if (ketQua == "[OK]")
                {
                    MessageBox.Show("Tham gia nhóm thành công");
                    LamMoi();
                    return;
                }// OK khi tham gia thành công
                else if (ketQua == "[NULL]")
                {
                    MessageBox.Show("Tên phòng không tồn tại hoặc sai mật khẩu");
                    return;
                }// NULL khi không tìm thấy group
                else
                {
                    return;
                }
            } // gia nhập nhóm
            else if (title == 4) 
            {
                if(kiemTraChonGroup() == false)
                {
                    return;
                }
                // [Out_Group]$id_user$id_group$name_Group 
                string yeuCau = $"[Out_Group]${UserInfo.Instance.Id}${id_Group}${name_Group.MaHoa()}";
                string ketQua = Result.Instance.Request(yeuCau);
                if (string.IsNullOrEmpty(ketQua))
                {
                    return;
                }
                else if (ketQua == "[OK]")
                {
                    MessageBox.Show("Bạn rời nhóm thành công!!");
                    dgv_DanhSachNhom.Rows.RemoveAt(row_Group);
                    LamMoi();
                    return;
                }// OK khi rời nhóm thành công
                else if (ketQua == "[NULL]")
                {
                    MessageBox.Show("Bạn hiện là chủ phòng không thể rời nhóm ở đây!!");
                    return;
                }// NULL khi không rời nhóm
                else
                {
                    return;
                }
            } // rời nhóm
            else if (title == 5)
            {
                if(kiemTraChonGroup() == false)
                {
                    return;
                }
                string yeuCau = $"[VaiTro_Group]${UserInfo.Instance.Id}${id_Group}";
                string ketQua = Result.Instance.Request(yeuCau);
                if (string.IsNullOrEmpty(ketQua))
                {
                    return;
                }
                else if (ketQua == "[MAIN]")
                {
                    Form_Chat_Group_Main fm = new Form_Chat_Group_Main(id_Group, name_Group, pass_Group);
                    fm.Show();
                    return;
                }// MAIN khi là chủ phòng
                else if(ketQua == "[MEMBER]")
                {
                    Form_Chat_Group_Member fm = new Form_Chat_Group_Member(id_Group, name_Group);
                    fm.Show();
                    return;
                } // MEMBER khi là thành viên nhóm
                else if (ketQua == "[NULL]")
                {
                    MessageBox.Show("Lỗi tham gia phòng chat!!");
                    return;
                }// NULL khi lỗi tham gia nhóm
                else
                {
                    return;
                }
            } // Tham gia chat Nhom
            else
            {
                return;
            }
        }
        private void XuLyKetQua(string ketQua, int title) // xữ lý load danh sách
        {
            if (string.IsNullOrEmpty(ketQua))
            {
                return;
            }
            // 0: load_listFriend 
            else if (!ketQua.Equals("[NULL]") && title == 0)
            {
                Fill_ListFriend(ketQua);
                return;
            }
            // 1: load_ListGroup
            else if (!ketQua.Equals("[NULL]") && title == 1)
            {
                Fill_ListGroup(ketQua);
                return;
            }
            else
            {
                return;
            }
        }
        private void Fill_ListFriend(string ketQua) // fill kết quả listFriend server lên datagirdView
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
        private void Fill_ListGroup(string ketQua)
        {
            string[] parts = ketQua.Split('$');

            // Check if there is any data to display
            if (parts.Length <= 1)
            {
                dgv_DanhSachNhom.Rows.Clear();
                return;
            }

            dgv_DanhSachNhom.Rows.Clear(); // Xóa tất cả các hàng hiện tại

            // Thêm dữ liệu từ các phần tách được vào DataTable
            for (int i = 1; i < parts.Length; i += 3)
            {
                string id_gr = parts[i];
                string name_gr = parts[i + 1].GiaiMa();
                string pass_gr = parts[i + 2].GiaiMa();
                dgv_DanhSachNhom.Rows.Add(id_gr, name_gr, pass_gr);
            }
        }
        private void LamMoi()
        {
            lbl_HoTen.Text = UserInfo.Instance.Name;
            txt_TenNhom.Text = "";
            txt_Pass.Text = "";

            // Clear rows in dgv_DanhSachBanBe
            dgv_DanhSachBanBe.Rows.Clear();

            // Clear rows in dgv_DanhSachNhom
            dgv_DanhSachNhom.Rows.Clear();

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
                Name_BanBe = selectedRow.Cells[1].Value.ToString();
            }
            else
            {
                return;
            }
        }
        private void dgv_DanhSachNhom_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn hay không
            if (dgv_DanhSachNhom.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                DataGridViewRow selectedRow = dgv_DanhSachNhom.SelectedRows[0];
                id_Group = selectedRow.Cells[0].Value.ToString();
                name_Group = selectedRow.Cells[1].Value.ToString();
                pass_Group = selectedRow.Cells[2].Value.ToString();
                row_Group = dgv_DanhSachNhom.CurrentCell.RowIndex;
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
        private void Menu_Form_Load(object sender, EventArgs e)
        {
            LamMoi();
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
        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận với người dùng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login fm = new Login();
                fm.Show();
            }
            
        }
        private void Menu_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            close_Form();
        }
        // chức năng của chat user
        private void btn_Chat_Click(object sender, EventArgs e)
        {
            /*Chat_User cu = new Chat_User(id_BanBe, HoTen_BanBe);
            cu.Show();*/
            if (id_BanBe != null && Name_BanBe != null)
            {
                FormChat fm = new FormChat(id_BanBe, Name_BanBe);
                fm.Show();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bạn bè để chat!!", "Thông báo", MessageBoxButtons.OK);
            }
        }
        // các chức năng của group chat
        private void btn_Tao_Click(object sender, EventArgs e)
        {
            guiYeuCau(2);
        }
        private void btn_GiaNhapNhom_Click(object sender, EventArgs e)
        {
            guiYeuCau(3);
        }
        private void btn_RoiNhom_Click(object sender, EventArgs e)
        {
            guiYeuCau(4);
        }
        private void btn_ThamGiaChat_Click(object sender, EventArgs e)
        {
            guiYeuCau(5);
        }
        #endregion
    }
}

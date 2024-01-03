using Client.App.Class_ThongTinUser;
using Client.App;
using System;
using System.Windows.Forms;
using Client.App.MaHoa;
using System.Net.Sockets;
using System.Threading;
using Client.App.Class_GuiYeuCau;

namespace Client
{
    public partial class Form_Chat_Group_Main : Form
    {
        #region Biến
        string id_User;
        string id_Group;
        string name_Group;
        string pass_Group;

        // TCP client
        private TcpClient client;
        #endregion

        #region Hàm xữ lý chỉnh sửa thông tin nhóm
        private void LamMoi()
        {
            txt_TenNhom.Text = name_Group;
            txt_Pass.Text = pass_Group;

            txt_TenNhom.ReadOnly = true;
            txt_Pass.ReadOnly = true;
        }
        private void chinhSua()
        {
            txt_Pass.ReadOnly = false;
            txt_TenNhom.ReadOnly = false;
        }
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
        private void luuThongTin()
        {
            if(kiemTraNhap() == false)
            {
                return;
            }
            string new_nameGroup = txt_TenNhom.Text;
            string new_passGroup = txt_Pass.Text;

            //[Update_Group]${idGr}${newName}${newPass}
            string yeuCau = $"[Update_Group]${id_Group}${new_nameGroup.MaHoa()}${new_passGroup.MaHoa()}";
            string ketQua = Result.Instance.Request(yeuCau);
            
            if (string.IsNullOrEmpty(ketQua))
            {
                return;
            }
            else if (ketQua == "[OK]")
            {
                MessageBox.Show("Cập nhật thông tin nhóm thành công!!");
                name_Group = txt_TenNhom.Text;
                pass_Group = txt_Pass.Text;
                LamMoi();
                return;
            }// OK khi cập nhật thông tin thành công
            else if (ketQua == "[NULL]")
            {
                MessageBox.Show("Tên phòng bị trùng vui lòng lấy tên khác");
                return;
            }// NULL khi tên phòng bị trùng
            else
            {
                return;
            }
        }
        private void giaiTanNhom()
        {
            DialogResult result = MessageBox.Show("Bạn chắn chắn muốn xóa hành động này không thể hồi phục nội dung trong nhóm!!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                //[Update_Group]${idGr}${newName}${newPass}
                string yeuCau = $"[Del_Group]${id_Group}";
                string ketQua = Result.Instance.Request(yeuCau);

                if (string.IsNullOrEmpty(ketQua))
                {
                    return;
                }
                else if (ketQua == "[OK]")
                {
                    MessageBox.Show("Đã xóa Group thành công!!");
                    this.Close();
                    return;
                }// OK khi xóa thành công
                else if (ketQua == "[NULL]")
                {
                    MessageBox.Show("Lỗi xóa group vui lòng đợi một thời gian!!");
                    return;
                }// NULL khi lỗi xóa group
                else
                {
                    return;
                }
            } else
            {
                return;
            }
        }
        private void Load_Member()
        {
            // $"[Load_Member]$idGr
            string nd = $"[Load_Member]${id_Group}";
            string ketQua = Result.Instance.Request(nd);
            if(ketQua != "[NULL]")
            {
                Add_Load_Member(ketQua);
            }
            else { return; }
        }
        private void Add_Load_Member(string ketQua)
        {
            dgv_ThanhVien.Rows.Clear(); // Xóa tất cả các hàng hiện tại
            string[] parts = ketQua.Split('$');
            // Thêm dữ liệu từ các phần tách được vào DataTable
            for (int i = 1; i < parts.Length; i += 2)
            {
                if (parts[i] != UserInfo.Instance.Id && parts[i + 1] != UserInfo.Instance.Name)
                {
                    string id = parts[i];
                    string hoTen = parts[i + 1].GiaiMa();
                    dgv_ThanhVien.Rows.Add(id, hoTen);
                }
            }
        }
        #endregion

        #region TCP gửi tin nhắn
        // hàm kết nối
        private void Connect()
        {
            client = new TcpClient();
            try
            {
                string svIP = InfoServer.Instance.ServerIP;
                client.Connect(svIP, InfoServer.Instance.PortTCP_ChatUser);
                Thread receiveThread = new Thread(Receive);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch
            {
                MessageBox.Show("Không thể kết nổi serve!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        // hàm đóng client
        private void CloseClient()
        {
            client.Close();
        }

        // hàm nhận thông tin từ server
        private void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.GetStream().Read(data, 0, data.Length);
                    string message = (string)Result.Instance.Deserialize(data);

                    AddMessage(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                CloseClient();
            }
        }

        // hàm thêm tin vào listView
        private void AddMessage(string message)
        {
            if (lsv_MessGroup.InvokeRequired)
            {
                lsv_MessGroup.Invoke(new MethodInvoker(() => AddMessage(message)));
            }
            else
            {
                // Tách thông tin từ message : [Chat_Group]$id_Gr$id_Gui$HoTenGui$Mess
                string[] parts = message.Split('$');
                string id_Gr = parts[1];
                string id_NgGui = parts[2];
                string name_NgGui = parts[3];
                string mess = parts[4].GiaiMa();

                // Kiểm tra xem có ít nhất một phần tử hay không
                if (parts.Length > 0 && id_Gr == id_Group)
                {
                    // Sử dụng phần tử đầu tiên (parts[0]) làm Text cho ListViewItem
                    string mess_add = name_NgGui + ": " + mess;
                    lsv_MessGroup.Items.Add(new ListViewItem() { Text = mess_add });
                }
                else
                {
                    return;
                }
            }
        }

        // hàm gửi
        private void Send()
        {
            if (txt_Mess.Text != string.Empty)
            {
                // [Chat_Group]$id_Gr$id_Gui$HoTenGui$Mess
                string id_Gui_Gr = UserInfo.Instance.Id;
                string name_Gui = UserInfo.Instance.Name;
                string mess = txt_Mess.Text;

                // gửi đến server => gửi đến các client khác và client này
                string noiDung = $"[Chat_Group]${id_Group}${id_Gui_Gr}${name_Gui}${mess.MaHoa()}";
                string gui = $"{noiDung}";
                byte[] data = Result.Instance.Serialize(gui);
                client.GetStream().Write(data, 0, data.Length);

                // gửi đến server => lưu
                // $"[New_Mess_Group]$idGr$idGui$mess
                string nd = $"[New_Mess_Group]${id_Group}${id_Gui_Gr}${mess.MaHoa()}";
                string ketQua = Result.Instance.Request(nd);
                if (ketQua == "[OK]")
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi lưu tin nhắn!!");
                    return;
                }
            }
        }

        // hàm load tin nhắn cũ
        private void LoadMess()
        {
            // $"[Load_Mess_Group]$idGr
            string nd = $"[Load_Mess_Group]${id_Group}";
            string ketQua = Result.Instance.Request(nd);
            MessageBox.Show(ketQua);
            if (ketQua == "[NULL]")
            {
                return;
            }
            
            if (string.IsNullOrEmpty(ketQua) || ketQua.Equals("[NULL]"))
            {
                return;
            }

            lsv_MessGroup.Items.Clear();
            string[] parts = ketQua.Split('$');

            for (int i = 1; i < parts.Length - 1; i += 2)
            {
                string userName = parts[i].GiaiMa();
                string content = parts[i + 1].GiaiMa();

                string noidungMess = userName + ": " + content;
                lsv_MessGroup.Items.Add(noidungMess);
            }
        }
        #endregion

        #region Form
        public Form_Chat_Group_Main(string idGroup, string nameGroup, string passGroup)
        {
            InitializeComponent();
            id_User = idGroup;
            id_Group = idGroup;
            name_Group = nameGroup;
            pass_Group = passGroup;
            Connect();
        }
        private void Form_Chat_Group_Main_Load(object sender, EventArgs e)
        {
            LamMoi();
            Load_Member();
            LoadMess();
        }
        private void btn_ChinhSua_Click(object sender, EventArgs e)
        {
            chinhSua();
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            luuThongTin();
        }
        private void btn_GiaiTan_Click(object sender, EventArgs e)
        {
            giaiTanNhom();
        }
        private void btn_Send_Click(object sender, EventArgs e)
        {
            Send();
            txt_Mess.Text = "";
        }
        #endregion
    }
}

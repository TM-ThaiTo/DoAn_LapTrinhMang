using Client.App.Class_ThongTinUser;
using Client.App.MaHoa;
using Client.App;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.App.Class_GuiYeuCau;

namespace Client
{
    public partial class Form_Chat_Group_Member : Form
    {
        #region Biến
        string id_User;
        string id_Group;
        string name_Group;

        // TCP client
        private TcpClient client;
        #endregion

        #region Hàm TCP
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
                string id_Gui = UserInfo.Instance.Id;
                string name_Gui = UserInfo.Instance.Name;
                string mess = txt_Mess.Text;

                // gửi đến server => gửi đến các client khác và client này
                string noiDung = $"[Chat_Group]${id_Group}${id_Gui}${name_Gui}${mess.MaHoa()}";
                string gui = $"{noiDung}";
                byte[] data = Result.Instance.Serialize(gui);
                client.GetStream().Write(data, 0, data.Length);


                // gửi đến server => lưu
                // $"[New_Mess_Group]$idGr$idGui$mess
                string nd = $"[New_Mess_Group]${id_Group}${UserInfo.Instance.Id}${mess.MaHoa()}";
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
        public Form_Chat_Group_Member(string idGroup, string nameGroup)
        {
            InitializeComponent();
            id_User = idGroup;
            id_Group = idGroup;
            name_Group = nameGroup; 
            Connect();
        }
        private void btn_Send_Click(object sender, EventArgs e)
        {
            Send();
            txt_Mess.Text = "";
        }
        private void Form_Chat_Group_Member_Load(object sender, EventArgs e)
        {
            lbl_TenNhom.Text = name_Group;
            LoadMess();
        }
        #endregion
    }
}

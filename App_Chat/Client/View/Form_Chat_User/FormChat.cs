using Client.App;
using Client.App.Class_GuiYeuCau;
using Client.App.Class_ThongTinUser;
using Client.App.MaHoa;
using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class FormChat : Form
    {
        #region Biến của form
        string id_Nhan;
        string name_Nhan;
        // TCP client
        private TcpClient client;
        #endregion


        #region Hàm của form
        public FormChat(string id_BanBe, string Name_BanBe)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            // Gán id và Name_BanBe được chọn từ menuForm
            id_Nhan = id_BanBe;
            name_Nhan = Name_BanBe;

            Connect();
        }
        private void FormChat_Load(object sender, EventArgs e)
        {
            string yeuCau = $"[Load_Mess_ChatUser]${UserInfo.Instance.Id}${id_Nhan}";
            string ketQua = Result.Instance.Request(yeuCau);
            XuLyKetQua_LoadMess(ketQua);
        }
        private void btn_Send_Click(object sender, EventArgs e)
        {
            Send();
        }
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseClient();
        }
        #endregion


        #region Hàm xữ lý TCP
        // hàm kết nối
        private void Connect()
        {
            client = new TcpClient();
            try
            {
                string svIP = InfoServer.Instance.ServerIP;
                client.Connect(svIP, 9999);
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

                    string message = (string)Deserialize(data);
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
            if (lsv_Message.InvokeRequired)
            {
                lsv_Message.Invoke(new MethodInvoker(() => AddMessage(message)));
            }
            else
            {
                // Tách thông tin từ message [Chat_User]$id_Nhan$id_Gui$HoTenGui$Mess
                string[] parts = message.Split('$');
                string id_NgNhan = parts[1];
                string id_NgGui = parts[2];
                string name_NgGui = parts[3];
                string mess = parts[4].GiaiMa();

                // Kiểm tra xem có ít nhất một phần tử hay không
                if (parts.Length > 0 && (id_NgNhan == UserInfo.Instance.Id && id_NgGui == id_Nhan) || 
                                        (id_NgNhan == id_Nhan && id_NgGui == UserInfo.Instance.Id))
                {
                    // Sử dụng phần tử đầu tiên (parts[0]) làm Text cho ListViewItem
                    lsv_Message.Items.Add(new ListViewItem() { Text = mess });
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
                // [Chat_User]$id_Nhan$id_Gui$HoTenGui$Mess
                string id_Gui = UserInfo.Instance.Id;
                string name_Gui = UserInfo.Instance.Name;
                string mess = txt_Mess.Text;

                string noiDung = $"[Chat_User]${id_Nhan}${id_Gui}${name_Gui}${mess.MaHoa()}";
                string gui = $"{noiDung}";

                byte[] data = Serialize(gui);
                client.GetStream().Write(data, 0, data.Length);

                // $"[New_Mess_ChatUser]$id1$id2$mess
                string nd = $"[New_Mess_ChatUser]${UserInfo.Instance.Id}${id_Nhan}${mess.MaHoa()}";
                string ketQua = Result.Instance.Request(nd);
                if(ketQua == "[OK]")
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Lỗi lưu tin nhắn!!");
                }
            }
        }

        // hàm chuyển dữ liệu thành bit
        private byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        // hàm chuyển bit thành dữ liệu
        private object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

        // hàm load tin nhắn cũ
        private void XuLyKetQua_LoadMess(string ketQua)
        {
            if (string.IsNullOrEmpty(ketQua) || ketQua.Equals("[NULL]"))
            {
                return;
            }

            lsv_Message.Items.Clear();
            string[] parts = ketQua.Split('$');

            for (int i = 1; i < parts.Length - 1; i += 4)
            {
                string idGui = parts[i];
                string idNhan = parts[i + 1];
                string mess = parts[i + 2].GiaiMa();
                string date = parts[i + 3];

                // Kiểm tra cả hai điều kiện trong cùng một lệnh if
                if (idGui == UserInfo.Instance.Id)
                {
                    lsv_Message.Items.Add($"{UserInfo.Instance.Name}: {mess}");
                }
                else if (idGui == idNhan)
                {
                    lsv_Message.Items.Add($"{name_Nhan}: {mess}");
                }
            }
        }
        #endregion
    }
}

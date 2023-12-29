using Client.App.Class_ThongTinUser;
using Client.App;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using Client.App.MaHoa;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Client.App.Class_GuiYeuCau;

namespace Client
{
    public partial class Chat_User : Form
    {
        private string id_Gui;
        private string hoTen_Gui;
        private string id_Nhan;
        private string name_Nhan;

        private Socket serverSocket;
        private Thread listenThread;
        private bool isServerStart;
        
        private TcpClient client;
        public Chat_User(string id_ngNhan, string name_ngNhan)
        {
            InitializeComponent();
            id_Gui = UserInfo.Instance.Id;
            hoTen_Gui = UserInfo.Instance.Name;
            id_Nhan = id_ngNhan;
            name_Nhan = name_ngNhan;
        }

        private void Chat_User_Load(object sender, EventArgs e)
        {
            lbl_TenNguoiNhan.Text = name_Nhan;
            Connect();
            //Load_Mess();
            //StartListeningForMessages();
        }

        private void Load_Mess()
        {
            string noiDung = $"[Load_Mess_ChatUser]${id_Gui}${id_Nhan}";
            string ketQua = Result.Instance.Request(noiDung);

            if (!string.IsNullOrEmpty(ketQua) && !ketQua.Equals("[NULL]"))
            {
                LoadandAdd_ListMess(ketQua);
            }
        }

        private void LoadandAdd_ListMess(string ketQua)
        {
            lsv_Message.Items.Clear();
            string[] parts = ketQua.Split('$');

            for (int i = 1; i < parts.Length - 1; i += 4)
            {
                string idGui = parts[i];
                string idNhan = parts[i + 1];
                string mess = parts[i + 2].GiaiMa();
                string date = parts[i + 3];

                // Kiểm tra cả hai điều kiện trong cùng một lệnh if
                if (idGui == id_Gui)
                {
                    lsv_Message.Items.Add($"{hoTen_Gui}: {mess}");
                }
                else if (idGui == idNhan)
                {
                    lsv_Message.Items.Add($"{name_Nhan}: {mess}");
                }
            }
        }

        private void Send_Mess()
        {
            string mess = txt_Mess.Text;

            if (string.IsNullOrEmpty(mess))
            {
                return;
            }

            lsv_Message.Items.Add($"{hoTen_Gui}: {mess}");

            string noiDung = $"[New_Mess_ChatUser]${id_Gui}${id_Nhan}${mess.MaHoa()}";
            string ketQua = Result.Instance.Request(noiDung);

            if (ketQua == "[OK]")
            {
                MessageBox.Show("Gửi tin nhắn thành công!!");
            }
        }

        
        private async void StartListeningForMessages()
        {
            try
            {
                isServerStart = true;
                await Task.Run(() =>
                {
                    while (isServerStart)
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead = serverSocket.Receive(buffer);

                        if (bytesRead > 0)
                        {
                            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            ProcessReceivedMessage(receivedMessage);
                            MessageBox.Show(receivedMessage);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error receiving message: {ex.Message}", "Error");
            }
        }

        private void ProcessReceivedMessage(string receivedMessage)
        {
            Invoke(new Action(() =>
            {
                lsv_Message.Items.Add(receivedMessage);
            }));
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            //Send_Mess();
            Send();
        }

        private void Chat_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            isServerStart = false;
        }

        #region 
        private void Connect()
        {
            client = new TcpClient();
            try
            {
                client.Connect(InfoServer.Instance.ServerIP, 9999);
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
                    MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                CloseClient();
            }
        }
        private void Send()
        {
            if (txt_Mess.Text != string.Empty)
            {
                byte[] data = Serialize(txt_Mess.Text);
                client.GetStream().Write(data, 0, data.Length);
            }
        }

        // hàm đóng client
        private void CloseClient()
        {
            client.Close();
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
        #endregion
    }
}

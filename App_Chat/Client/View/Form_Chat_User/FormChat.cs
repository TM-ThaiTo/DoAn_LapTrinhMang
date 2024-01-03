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

        // file
        private string selectedFilePath;
        #endregion

        #region Hàm xữ lý TCP
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

                    if (message.StartsWith("[File_Message]"))
                    {
                        // Xử lý thông điệp file
                        HandleFileMessage(message);
                    }
                    else
                    {
                        // Xử lý thông điệp văn bản
                        AddMessage(message);
                    }
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
                if (parts.Length > 0 && (id_NgNhan == id_Nhan && id_NgGui == UserInfo.Instance.Id)
                                     || (id_NgNhan == UserInfo.Instance.Id && id_NgGui == id_Nhan))
                {
                    // Sử dụng phần tử đầu tiên (parts[0]) làm Text cho ListViewItem
                    string mess_add = name_NgGui + ": " + mess;
                    lsv_Message.Items.Add(new ListViewItem() { Text = mess_add });
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


                // gửi đến server => gửi đến các client khác và client này
                byte[] data = Result.Instance.Serialize(gui);
                client.GetStream().Write(data, 0, data.Length);


                // gửi đến server => lưu
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
                txt_Mess.Text = "";
            }
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
                else if (idGui == id_Nhan)
                {
                    lsv_Message.Items.Add($"{name_Nhan}: {mess}");
                }
            }
        }
        #endregion

        #region Gui file
        // gửi file
        private void SendFile()
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Vui lòng chọn một file để gửi.");
                return;
            }

            try
            {
                // Đọc dữ liệu từ file
                byte[] fileData = File.ReadAllBytes(selectedFilePath);

                // Tạo một thông điệp để gửi thông tin file
                // [File_Message]${id_Nhan}${id_Gui}${ten_File}${kichThuoc}${noiDung}
                string fileName = Path.GetFileName(selectedFilePath);
                string message = $"[File_Message]${id_Nhan}${UserInfo.Instance.Id}${fileName}${fileData.Length}${Convert.ToBase64String(fileData)}";

                // Gửi thông điệp tới server
                byte[] data = Result.Instance.Serialize(message);
                client.GetStream().Write(data, 0, data.Length);

                MessageBox.Show("File đã được gửi thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi gửi file: {ex.Message}");
            }
        }
        private void chonFile()
        {
            // Tạo một đối tượng OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Đặt các thuộc tính cho OpenFileDialog
            openFileDialog.Title = "Chọn file";
            openFileDialog.Filter = "All Files|*.*"; // Bạn có thể thay đổi định dạng file ở đây

            // Hiển thị hộp thoại chọn file và kiểm tra kết quả
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Lấy đường dẫn của file được chọn
                selectedFilePath = openFileDialog.FileName;
                lbl_File.Text = selectedFilePath;
            }
        }
        private void HandleFileMessage(string fileMessage)
        {
            // [File_Message]${id_Nhan}${id_Gui}${ten_File}${kichThuoc}${noiDung}
            string[] parts = fileMessage.Split('$');
            string id_NgNhan = parts[1];
            string id_NgGui = parts[2];
            string fileName = parts[3];
            int fileSize = int.Parse(parts[4]);
            byte[] fileData = Convert.FromBase64String(parts[5]);

            // Kiểm tra xem có phải là file được gửi đến cho client hiện tại không
            if (id_NgNhan == UserInfo.Instance.Id)
            {
                // Hiển thị hộp thoại hỏi người dùng có muốn nhận file không
                DialogResult result = MessageBox.Show($"Bạn vừa nhận một file có tên: {fileName} bạn có nhận không?", "Nhận file", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Lưu file vào máy
                    SaveFile(fileName, fileData);
                }
                else
                {
                    return;
                }
            }
        }
        private void SaveFile(string fileName, byte[] fileData)
        {
            string savePath = Path.Combine(Application.StartupPath, fileName);
            File.WriteAllBytes(savePath, fileData);
            MessageBox.Show("Đã lưu file trong debug", "Thông báo");
        }
        #endregion

        #region Hàm của form
        public FormChat(string id_BanBe, string Name_BanBe)
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            // Gán id và Name_BanBe được chọn từ menuForm
            id_Nhan = id_BanBe;
            name_Nhan = Name_BanBe;
            lbl_TenNguoiNhan.Text = name_Nhan;
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
            txt_Mess.Text = "";
        }
        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseClient();
        }
        private void btn_ChonFile_Click(object sender, EventArgs e)
        {
            chonFile();
        }
        private void btn_SendFile_Click(object sender, EventArgs e)
        {
            SendFile();
            lbl_File.Text = "...";
        }
        #endregion
    }
}

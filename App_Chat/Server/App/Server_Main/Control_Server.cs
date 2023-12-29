using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Server.Models;
using System.Collections.Generic;
using Server.App.MaHoa;
using Server.App.Client;
using System.Threading;
using System;
using Server.App.Email;
using Server.App.Client.Load__User;
using Server.App.Client.Friend_User;
using Server.App.Client.Friend_User.Block;
using Server.App.Client.Chat_User;
using Server.App.Client.TTKetNoi_User;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server.App
{
    public class Control_Server
    {
        #region Thuộc tính server
        private Socket serverSocket;
        public readonly string serverIP = "192.168.1.3";
        public int port = 12003;

        private App_Chat_DB context = new App_Chat_DB();
        public List<Socket> danhSachClientSockets = new List<Socket>();
        public List<string> danhSachClientIPs = new List<string>();
        public bool isServerStart = false;
        public List<ThongTinKetNoi> danhSachThongTinKetNoi;

        private TcpListener server;
        private List<TcpClient> clientList;
        private Queue<string> messageQueue;

        #endregion

        #region Cấu hình server
        public void Start()
        {
            danhSachThongTinKetNoi = new List<ThongTinKetNoi>();
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(serverIP), port);
                serverSocket.Bind(ep);
                serverSocket.Listen(100);
                MessageBox.Show("Đã khởi động server!", "Thông báo", MessageBoxButtons.OK);

                isServerStart = true;

                Thread serverThread = new Thread(ListenLoop);
                serverThread.Start();
                StartServerTCP();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động server: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Stop()
        {
            try
            {
                if (serverSocket != null)
                {
                    isServerStart = false;
                    serverSocket.Close();
                    MessageBox.Show("Server đã ngừng hoạt động!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi dừng server: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListenLoop()
        {
            try
            {
                while (isServerStart)
                {
                    Socket clientSocket = serverSocket.Accept();
                    string clientIP = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();

                    danhSachClientSockets.Add(clientSocket);
                    danhSachClientIPs.Add(clientIP);

                    byte[] duLieu = new byte[102400000];
                    int demNhan = clientSocket.Receive(duLieu);
                    string noiDung = Encoding.UTF8.GetString(duLieu, 0, demNhan);

                    xuLyYeuCau(clientSocket, clientIP, noiDung);
                }
            }
            catch
            {
                //MessageBox.Show($"Lỗi trong quá trình lắng nghe: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Login vào Server
        public bool Login_Server(string username, string password, string vaiTro)
        {
            var taikhoan = context.Users.Any(tk => tk.Username == username && tk.Passwords == password && tk.VaiTro == vaiTro);
            return taikhoan;
        }
        #endregion

        #region TCP
        private void StartServerTCP()
        {
            clientList = new List<TcpClient>();
            messageQueue = new Queue<string>();

            IPAddress svIP = IPAddress.Parse(serverIP);
            server = new TcpListener(svIP, 9999);
            server.Start();

            Thread listenThread = new Thread(ListenForClients);
            listenThread.IsBackground = true;
            listenThread.Start();
        }

        // hàm lấy dữ liệu từ các client
        private void ListenForClients()
        {
            try
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    clientList.Add(client);

                    Thread receiveThread = new Thread(() => Receive(client));
                    receiveThread.IsBackground = true;
                    receiveThread.Start();

                    // New: Start a new thread to handle message broadcasting
                    Thread broadcastThread = new Thread(() => BroadcastMessages());
                    broadcastThread.IsBackground = true;
                    broadcastThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void BroadcastMessages() // New
        {
            while (true)
            {
                lock (messageQueue)
                {
                    if (messageQueue.Count > 0)
                    {
                        string message = messageQueue.Dequeue();
                        BroadcastMessage(message);
                    }
                }

                Thread.Sleep(10); // Adjust the sleep time as needed
            }
        }

        // hàm kết nối đến các client
        private void Receive(TcpClient client)
        {
            try
            {
                while (true)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] data = new byte[1024 * 5000];
                    int bytesRead = stream.Read(data, 0, data.Length);

                    if (bytesRead == 0)
                        break;

                    string message = (string)Deserialize(data);
                    EnqueueMessage(message); // New
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Client disconnected: {ex.Message}");
            }
            finally
            {
                clientList.Remove(client);
                client.Close();
            }
        }

        private void EnqueueMessage(string message) // New
        {
            lock (messageQueue)
            {
                messageQueue.Enqueue(message);
            }
        }

        private void BroadcastMessage(string message) // New
        {
            lock (clientList)
            {
                foreach (TcpClient client in clientList)
                {
                    Send(client, message);
                }
            }
        }

        // hàm đóng server
        private void CloseServer()
        {
            server.Stop();
            foreach (TcpClient client in clientList)
            {
                client.Close();
            }
        }


        // hàm gửi mess
        private void Send(TcpClient client, string message)
        {
            if (!client.Connected) return;

            NetworkStream stream = client.GetStream();
            byte[] data = Serialize(message);
            stream.Write(data, 0, data.Length);
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

        #region Xữ lý yêu cầu
        // hàm xữ lý yêu cầu
        private void xuLyYeuCau(Socket clientSocket, string clientIP, string noiDung)
        {
            // Tách lấy phần yêu cầu từ nội dung
            string[] parts = noiDung.Split('$');
            string yeuCau = parts[0];
            //MessageBox.Show(noiDung); // kiểm tra tí xóa
            switch (yeuCau)
            {
                // ----------------------------------------- Login User ----------------------------
                // Login
                case "[Login]": //[Login]$username$password
                    Login_User lg = new Login_User();
                    string username = parts[1].GiaiMa();
                    string password = parts[2].GiaiMa();
                    lg.Login_Client(context, clientSocket, username, password, serverIP, danhSachThongTinKetNoi);
                    break;

                // ----------------------------------------- Đăng kí User --------------------------
                // Them User
                case "[NewUser]": // [NewUser]$username$password$name$phone$email$address$age
                    MessageBox.Show(noiDung);
                    CreateNew_User crn = new CreateNew_User();
                    string new_username = parts[1].GiaiMa();
                    string new_password = parts[2].GiaiMa();
                    string hoten = parts[3].GiaiMa();
                    string soDienThoai = parts[4].GiaiMa();
                    string email = parts[5].GiaiMa();
                    string address = parts[6].GiaiMa();
                    string age = parts[7].GiaiMa();
                    crn.NewUser_Client(context, clientSocket, new_username, new_password, hoten, soDienThoai, email, address, age);
                    break;

                // ----------------------------------------- Gửi OTP -------------------------------
                // Gửi OTP đến mail
                case "[SendMail_Login]": // [SendMail_Login]$email$OTP
                    SendMail sn = new SendMail();
                    string mail = parts[1].GiaiMa();
                    string code = parts[2].GiaiMa();
                    sn.Send(clientSocket, mail, code);
                    break;

                // ----------------------------------------- Cập nhật thông tin User ---------------
                // UpdateInfo
                case "[UpdateInfo]": // [UpdateInfo]$id$username$password$hoten$soDienThoai$email$address$age
                    UpdateInfor_User upu = new UpdateInfor_User();
                    string id = parts[1].GiaiMa();
                    string username_up = parts[2].GiaiMa();
                    string password_up = parts[3].GiaiMa();
                    string name = parts[4].GiaiMa();
                    string soDienThoai_up = parts[5].GiaiMa();
                    string email_up = parts[6].GiaiMa();
                    string address_up = parts[7].GiaiMa();
                    string age_up = parts[8].GiaiMa();
                    upu.UpdateInfor(context, clientSocket, id, username_up, password_up, name, soDienThoai_up, email_up, address_up, age_up);
                    break;

                // ----------------------------------------- Load User -----------------------------
                // Load User
                case "[Load_User]": // [Load_User]$id
                    int id_user = int.Parse(parts[1]);
                    Load_User lu = new Load_User();
                    lu.LoadUser(context, clientSocket, id_user);
                    break;

                // ------------------------------------------ Block User -----------------------------
                // block user
                case "[Block_User]": //[Block_User]$id$id2
                    int id_user_Block = int.Parse(parts[1]);
                    int id_user_Nhan = int.Parse(parts[2]);
                    BlockUser bf = new BlockUser();
                    bf.block_user(context, clientSocket, id_user_Block, id_user_Nhan);
                    break;

                // Load block user
                case "[Load_Block_User]": //[Load_Block_User]$id
                    int id_user_Load = int.Parse(parts[1]);
                    Load_Block lb = new Load_Block();
                    lb.Load_List_Block(context, clientSocket, id_user_Load);
                    break;

                // Un_Block_User
                case "[Un_Block_User]": // [Un_Block_User]$id$id2
                    int id_User_Block = int.Parse(parts[1]);
                    int id_User_Un = int.Parse(parts[2]);
                    UnBlock ub = new UnBlock();
                    ub.Un_Block_User(context, clientSocket, id_User_Block, id_User_Un);
                    break;

                // Un_Block_All
                case "[Un_Block_All]": // [Un_Block_User]$id1
                    int id_yeu_Cau = int.Parse(parts[1]);
                    UnBlock uba = new UnBlock();
                    uba.Un_Block_All(context, clientSocket, id_yeu_Cau);
                    break;

                // --------------------------------------- Ket ban User ---------------------------
                // make friend
                case "[Make_Friend]": // [Make_Friend]$id1$id2
                    int id_yc_MF = int.Parse(parts[1]);
                    int id_nyc_MF = int.Parse(parts[2]);

                    MakeFriend mf = new MakeFriend();
                    mf.GuiYeuCau_KetBan(context, clientSocket, id_yc_MF, id_nyc_MF);
                    break;

                // Load Friend
                case "[Load_Friend]": // [Load_Friend]$id
                    int id_load_fr = int.Parse(parts[1]);

                    LoadListFriend llf = new LoadListFriend();
                    llf.Load_List_Friend(context, clientSocket, id_load_fr);
                    break;

                // ---------------------- Chat 2 User-------------------------------

                // Load tin nhắn giữa 2 User
                case "[Load_Mess_ChatUser]": // $[Load_Mess_ChatUser]$id1$id2
                    int id_Chu = int.Parse(parts[1]);
                    int id_Ban = int.Parse(parts[2]);

                    Load_Mess lm = new Load_Mess();
                    lm.Load_Mess_User(context, clientSocket, id_Chu, id_Ban);
                    break;

                case "[New_Mess_ChatUser]": // $"[New_Mess_ChatUser]$id1$id2$mess
                    int id_Gui = int.Parse(parts[1]);
                    int id_Nhan = int.Parse(parts[2]);
                    string mess = parts[3].GiaiMa();

                    New_Mess nm = new New_Mess();
                    nm.New_Mess_ChatUser(context, clientSocket, id_Gui, id_Nhan, mess);
                    break;

                case "[Send_Mess_User]": // $[Send_Mess_User]$idGui$idNhan$mess

                    break;
                // --------------------- Chat group ------------------------------

                default:

                    break;
            }
        }
        #endregion
    }
}

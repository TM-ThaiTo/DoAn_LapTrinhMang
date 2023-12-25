using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.App.Class_Chat
{
    public class Server_Chat_User
    {
        private Socket serverSocket;
        // tình trạng server
        public bool isServerStart = false;

        public void Start(string serverIP, int port) // Start Server
        {
            try
            {
                // Khởi tạo socket của server
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(serverIP), port);
                serverSocket.Bind(ep);
                serverSocket.Listen(100);
                MessageBox.Show("Đã khởi động server!", "Thông báo", MessageBoxButtons.OK);

                isServerStart = true;

                // Tạo và khởi động một luồng mới cho server
                Thread serverThread = new Thread(ListenLoop);
                serverThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động server: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Stop() // Stop Server
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
        private void ListenLoop() // Nghe yêu cầu từ Client
        {
            try
            {
                while (isServerStart)
                {
                    // Chấp nhận kết nối từ client và lấy thông tin địa chỉ IP
                    Socket clientSocket = serverSocket.Accept();
                    string clientIP = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();

                    // Nhận dữ liệu từ client
                    byte[] duLieu = new byte[102400000];
                    int demNhan = clientSocket.Receive(duLieu);
                    string noiDung = Encoding.UTF8.GetString(duLieu, 0, demNhan);
                }
            }
            catch
            {
                //MessageBox.Show($"Lỗi trong quá trình lắng nghe: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string Request(string serverIP, int port, string yeuCau)
        {
            using (Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    // Kết nối đến máy chủ
                    sk.Connect(IPAddress.Parse(serverIP), port);

                    // Chuyển yêu cầu sang dạng mảng byte
                    byte[] duLieu = Encoding.UTF8.GetBytes(yeuCau);

                    // Gửi yêu cầu
                    sk.Send(duLieu);

                    // Nhận phản hồi từ server
                    byte[] buffer = new byte[102400000];
                    int bytesRead = sk.Receive(buffer);

                    // Kiểm tra nếu có dữ liệu nhận được
                    if (bytesRead > 0)
                    {
                        // Chuyển mảng byte thành chuỗi
                        string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                        MessageBox.Show("Kết quả trả về từ server: " + response);

                        // Đóng kết nối
                        sk.Close();
                        sk.Dispose();

                        return response;
                    }
                    else
                    {
                        MessageBox.Show("Không nhận được dữ liệu từ server", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                catch (SocketException ex)
                {
                    MessageBox.Show($"Không thể kết nối đến server: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi trong quá trình thực hiện yêu cầu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }
    }
}

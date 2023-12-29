using Client.App.Class_GuiYeuCau;
using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Client.App.Class_Chat
{
    public class Result_Chat_User
    {
        public String serverIP = InfoServer.Instance.ServerIP;
        public int port = InfoServer.Instance.Port;

        private static Result_Chat_User instance;
        public static Result_Chat_User Instance
        {
            get { if (instance == null) instance = new Result_Chat_User(); return instance; }
            private set { instance = value; }
        }
        private Result_Chat_User() { }


        public string Request(string yeuCau)
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

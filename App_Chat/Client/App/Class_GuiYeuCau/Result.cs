using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Client.App.Class_GuiYeuCau;

namespace Client.App
{
    public class Result
    {
        #region Biến
        // địa chỉ
        public String serverIP = InfoServer.Instance.ServerIP;
        public int port = InfoServer.Instance.Port;

        private static Result instance;
        public static Result Instance
        {
            get { if (instance == null) instance = new Result(); return instance; }
            private set { instance = value; }
        }
        private Result() { }
        #endregion

        #region Hàm xữ lý 
        // hàm gửi dữ liệu thường và trả về kết quả được gửi từ server
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

                        //MessageBox.Show("Kết quả trả về từ server: " + response);

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
        public string Request()
        {
            using (Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    // Kết nối đến máy chủ
                    sk.Connect(IPAddress.Parse(serverIP), port);

                    // Nhận phản hồi từ server
                    byte[] buffer = new byte[102400000];
                    int bytesRead = sk.Receive(buffer);
                    
                    // Chuyển mảng byte thành chuỗi
                    string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Kiểm tra nếu có dữ liệu nhận được
                    if (bytesRead > 0)
                    {
                        return response;
                    }
                    else
                    {
                        return response = null;
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

        // hàm gửi dữ liệu và nhận về dữ liệu byte từ server
        public byte[] bRequest(string yeuCau, ref int demNhan)
        {
            using (Socket sk = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    // Ket noi den may chu
                    sk.Connect(IPAddress.Parse(serverIP), port);
                    byte[] duLieu = Encoding.UTF8.GetBytes(yeuCau);
                    // Gui yeu cau
                    int dem = sk.Send(duLieu);

                    // Nhan tra loi va hien thi
                    byte[] ketQua = new byte[102400000];
                    demNhan = sk.Receive(ketQua);
                    var c = ketQua.Length;
                    // Dong ket noi
                    sk.Close();
                    sk.Dispose();

                    return ketQua;
                }
                catch
                {
                    return null;
                }
            }
        }
        #endregion
    }
}

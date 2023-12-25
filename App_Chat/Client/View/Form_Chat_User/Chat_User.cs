using Client.App.Class_ThongTinUser;
using Client.App;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using Client.App.MaHoa;
using Client.App.Class_Chat;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Threading;
using DevExpress.XtraPrinting.Preview;

namespace Client
{
    public partial class Chat_User : Form
    {
        #region Biến
        string id_Chu;
        string hoTen_Chu;
        string id_BanBe;
        string hoTen_BanBe;


        string IP_ChuPhong;
        int port_ChuPhong;


        private CancellationTokenSource cancellationTokenSource;
        #endregion

        #region Hàm xữ lý test
        /*private void hamLayIPvaPort()
        {
            try
            {
                // Lấy địa chỉ IP của máy
                string hostName = Dns.GetHostName();
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);

                // Chọn địa chỉ IPv4 đầu tiên, nếu có
                IPAddress ipAddress = hostEntry.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);

                if (ipAddress == null)
                {
                    MessageBox.Show("Không tìm thấy địa chỉ IPv4.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lấy thông tin cổng đang được sử dụng
                TcpListener tcpListener = new TcpListener(ipAddress, 0); // 0 để chọn một cổng trống tự động
                tcpListener.Start();

                int port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
                
                // Đóng cổng sau khi đã lấy thông tin
                tcpListener.Stop();
                
                // Lưu vào biến
                IP_ChuPhong = ipAddress.ToString();
                port_ChuPhong = port;

                // Hiển thị thông tin hoặc sử dụng ip và port trong ứng dụng của bạn
                MessageBox.Show($"IP Address: {IP_ChuPhong}\nPort: {port}", "Thông tin IP và Port", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guiYeuCau_DenServerChinh(string id)
        {
            hamLayIPvaPort();
            //[Tao_Chat_User]$id1$IP$port$id2
            string yeuCau = $"[Tao_Chat_User]${UserInfo.Instance.Id}${IP_ChuPhong.MaHoa()}${port_ChuPhong.ToString()}${id}";
            string ketQua = Result.Instance.Request(yeuCau);
            XuLyKetQua(ketQua);
        }
        private void XuLyKetQua(string ketQua) // xử lý kết quả trả về từ server
        {
            // Tách lấy phần yêu cầu từ nội dung
            string[] parts = ketQua.Split('$');
            string yeuCau = parts[0];
            if (string.IsNullOrEmpty(ketQua))
            {
                return;
            }
            else if (yeuCau == "[OK]")
            {
                //Start_Sever_Chat();
                //load_Form(hoTen_BanBe);
                return;
            }
            else if(yeuCau != "[OK_1]")
            {
                //string noidung = $"[OK_1]${ip}${port}";
                string ip = parts[1];
                int port = int.Parse(parts[2]);
                //load_Form(hoTen_BanBe);
            }
            else
            {
                return;
            }
        }
        private async void Start_Sever_Chat()
        {
            try
            {
                Server_Chat_User sv = new Server_Chat_User();
                await Task.Run(() =>
                {
                    sv.Start(IP_ChuPhong, port_ChuPhong);
                });
            } catch { }
        }*/
        #endregion

        #region Hàm xữ lý
        private void load_Form(string hoTen)
        {
            lbl_TenNguoiNhan.Text = hoTen;
        }
        
        // xữ lý Send mess
        private void Send_Mess()
        {
            // gửi: [New_Mess_ChatUser]$id1$id2$mess
            // id1 == id_Chu, id2 == id2_BanBe
            // mess == txt_Mess
            string mess = txt_Mess.Text;
            
            if (string.IsNullOrEmpty(mess))
            {
                return;
            }

            // id_Chu là id người gửi id_BanBe id nhận
            // $"[New_Mess_ChatUser]$id1$id2$mess
            string noiDung = $"[New_Mess_ChatUser]${id_Chu}${id_BanBe}${mess.MaHoa()}";

            string ketQua = Result.Instance.Request(noiDung);
            if(ketQua == "[OK]")
            {
                Load_Mess();
            }
            //XuLyKetQua_NewMess(ketQua, mess);
        }

        private void LoadandAdd_ListMess(string ketQua)
        {
            lsv_Message.Items.Clear(); // Xóa tất cả các mục trong ListView

            string[] parts = ketQua.Split('$');
            // Thêm dữ liệu từ các phần tách được vào ListView
            for (int i = 1; i < parts.Length - 1; i += 4) // Bắt đầu từ 1 và tăng 4 để lấy giá trị mess
            {
                string idGui = parts[i];
                string idNhan = parts[i + 1];
                if(idGui == id_Chu)
                {
                    string mess = parts[i + 2].GiaiMa();
                    string date = parts[i + 3];
                    lsv_Message.Items.Add(hoTen_Chu + ":" + mess);
                }
                else if(idGui == id_BanBe)
                {
                    string mess = parts[i + 2].GiaiMa();
                    string date = parts[i + 3];
                    lsv_Message.Items.Add(hoTen_BanBe + ":" + mess);
                }
            }
        }
        // xữ lý load mess
        private void Load_Mess()
        {
            string noiDung = $"[Load_Mess_ChatUser]${id_Chu}${id_BanBe}";
            string ketQua = Result.Instance.Request(noiDung);
            LoadandAdd_ListMess(ketQua);
        }
        #endregion

        #region Hàm của form
        public Chat_User(string id1, string hoTenChu, string id2, string hoTen_Khach)
        {
            InitializeComponent();
            id_Chu = id1;
            hoTen_Chu = hoTenChu;
            id_BanBe = id2;
            hoTen_BanBe = hoTen_Khach;
        }
        private async void Chat_User_Load(object sender, EventArgs e)
        {
            load_Form(hoTen_BanBe);

            string lastMessages = string.Empty;

            cancellationTokenSource = new CancellationTokenSource();

            await Task.Run(async () =>
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    string noiDung = $"[Load_Mess_ChatUser]${id_Chu}${id_BanBe}";
                    string ketQua = Result.Instance.Request(noiDung);

                    if (ketQua != lastMessages) // Kiểm tra xem dữ liệu mới có khác so với dữ liệu hiện tại không
                    {
                        LoadandAdd_ListMess(ketQua);
                        lastMessages = ketQua; // Cập nhật dữ liệu hiện tại
                    }

                    // Sử dụng Task.Delay thay vì Thread.Sleep để tránh đóng băng luồng
                    await Task.Delay(2000);
                }
            });
        }
        private void btn_Send_Click(object sender, EventArgs e)
        {
            Send_Mess();
        }
        private void Chat_User_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource?.Cancel(); // Hủy bỏ vòng lặp khi form đóng
        }
        #endregion


    }
}

using Server.App.Client.TTKetNoi_User;
using Server.App.MaHoa;
using Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.App.Client
{
    public class Login_User
    {
        // hàm login client
        public void Login_Client(App_Chat_DB context,  Socket clientSocket, string username, string password, string serverIP, List<ThongTinKetNoi> danhSachThongTinKetNoi)
        {
            // Kiểm tra tài khoản trong cơ sở dữ liệu
            var taiKhoan = context.Users.SingleOrDefault(tk => tk.Username == username && tk.Passwords == password && tk.VaiTro == "User");

            if (taiKhoan == null)
            {
                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi_null = "[NULL]";
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi_null));
                return;
            }

            var ttTaiKhoan = context.User_Details.SingleOrDefault(tt => tt.UserDetailID == taiKhoan.UserID);

            /*DateTime selectedDateTime = (DateTime)ttTaiKhoan.DateOfBirth;
            string formattedDateTime = selectedDateTime.ToString("dd MM yyyy");
            string age = formattedDateTime;*/

            // Thêm thông tin kết nối vào danh sách
            ThongTinKetNoi thongTinKetNoi = new ThongTinKetNoi
            {
                ID = taiKhoan.UserID,
                ClientSocket = clientSocket,
                IP = ((System.Net.IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString(),
                Port = ((System.Net.IPEndPoint)clientSocket.RemoteEndPoint).Port,
                Username = username
            };
            danhSachThongTinKetNoi.Add(thongTinKetNoi);

            // Kiểm tra xem cả hai người dùng có đang kết nối không
            var nguoiNhan = danhSachThongTinKetNoi.FirstOrDefault(x => x.ID == taiKhoan.UserID);
            string port_Client = nguoiNhan.Port.ToString();
            string IP_Client = nguoiNhan.IP.ToString();
            
            
            // Gửi phản hồi về client cùng với địa chỉ IP
            string noidung = $"[OK]${taiKhoan.UserID}${username.MaHoa()}${password.MaHoa()}${ttTaiKhoan.FullName.MaHoa()}${ttTaiKhoan.Email.MaHoa()}${ttTaiKhoan.PhoneNumber.MaHoa()}${serverIP.MaHoa()}${IP_Client.MaHoa()}${port_Client.MaHoa()}${ttTaiKhoan.Address.MaHoa()}";
            string traloi = $"{noidung}";
            clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
        }
    }
}

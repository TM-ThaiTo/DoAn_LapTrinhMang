using Server.App.MaHoa;
using Server.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server.App.Client
{
    public class Login_User
    {
        // hàm login client
        public void Login_Client(App_Chat_DB context,  Socket clientSocket, string username, string password, string serverIP)
        {
            string noidung = "";

            // Kiểm tra tài khoản trong cơ sở dữ liệu
            var taiKhoan = context.Users.SingleOrDefault(tk => tk.Username == username && tk.Passwords == password && tk.VaiTro == "User");
            
            if(taiKhoan == null)
            {
                noidung = "[NULL]";
                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi_null = $"{noidung}";

                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi_null));
                return;
            }else
            {
                var ttTaiKhoan = context.User_Details.SingleOrDefault(tt => tt.UserDetailID == taiKhoan.UserID);

                DateTime selectedDateTime = (DateTime)ttTaiKhoan.DateOfBirth;
                string formattedDateTime = selectedDateTime.ToString("dd MM yyyy");
                string age = formattedDateTime;
                //[OK]$ID$username$password$HoTen$Email$SoDienThoai$serverIP$address$age
                noidung = $"[OK]${taiKhoan.UserID}${username.MaHoa()}${password.MaHoa()}${ttTaiKhoan.FullName.MaHoa()}${ttTaiKhoan.Email.MaHoa()}${ttTaiKhoan.PhoneNumber.MaHoa()}${serverIP.MaHoa()}${ttTaiKhoan.Address.MaHoa()}${age.MaHoa()}";
                //noidung = "[OK]";
            }

            // Gửi phản hồi về client cùng với địa chỉ IP
            string traloi = $"{noidung}";

            // Sử dụng clientSocket để gửi phản hồi về client
            clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
        }
    }
}

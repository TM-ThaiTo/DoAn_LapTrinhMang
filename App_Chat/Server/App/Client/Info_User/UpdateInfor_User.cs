using Server.App.MaHoa;
using Server.Models;
using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.App.Client
{
    public class UpdateInfor_User
    {
        public void UpdateInfor(App_Chat_DB context, Socket clientSocket, string id, string username, string password, string hoten, string soDienThoai, string email, string address)
        {
            int id_user = int.Parse(id);
            var taikhoan = context.Users.SingleOrDefault(tk => tk.UserID == id_user);

            taikhoan.Passwords = password;

            var ttTaiKhoan = context.User_Details.SingleOrDefault(tt => tt.UserID == taikhoan.UserID);
            ttTaiKhoan.FullName = hoten;
            ttTaiKhoan.PhoneNumber = soDienThoai;
            ttTaiKhoan.Email = email;
            ttTaiKhoan.Address = address;

            // Lưu thay đổi vào cơ sở dữ liệu
            try
            {
                context.SaveChanges();
                string noidung = $"[OK]";
                string traLoi = $"{noidung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi lưu thay đổi vào cơ sở dữ liệu
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }
}

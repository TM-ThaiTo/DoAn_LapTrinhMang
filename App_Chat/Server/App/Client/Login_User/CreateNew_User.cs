using Server.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server.App.Client
{
    public class CreateNew_User
    {
        private bool kiemTraTaiKhoan(App_Chat_DB context, string new_username)
        {
            var kt = context.Users.SingleOrDefault(tk => tk.Username == new_username);
            if (kt != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int LayMaxID(App_Chat_DB context)
        {
            // Sử dụng LINQ để truy vấn cơ sở dữ liệu và lấy ID lớn nhất
            var maxID = context.Users.Max(item => (int?)item.UserID) ?? 0;

            return maxID + 1;  
        }

        // tạo và lưu newUser
        public void NewUser_Client(App_Chat_DB context, Socket clientSocket, string new_username, string new_password, string fullname, string phone, string email, string address)
        {
            if(kiemTraTaiKhoan(context, new_username) == false)
            {
                string noidung = "[NULL]";

                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi = $"{noidung}";
                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
                return;
            }

            int ID = LayMaxID(context);
            User newUser = new User
            {
                UserID = ID,
                Username = new_username,
                Passwords = new_password,
                VaiTro = "User"
            };

            User_Details newThongTin = new User_Details
            {
                UserDetailID = ID,
                UserID = ID,
                FullName = fullname,
                Email = email,
                //DateOfBirth = dateTime,
                PhoneNumber = phone,
                Address = address,
            };

            try
            {
                context.Users.Add(newUser);
                context.SaveChanges();
                context.User_Details.Add(newThongTin);
                context.SaveChanges();
                string noidung = "[OK]";

                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi = $"{noidung}";

                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
            } catch { } 
        }
        private byte[] ConvertImgToByte(string imagePath)
        {
            try
            {
                // Đọc hình ảnh từ đường dẫn và chuyển đổi thành mảng byte
                using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        return memoryStream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chuyển đổi ảnh thành byte: " + ex.Message);
                return null;
            }
        }
    }
}

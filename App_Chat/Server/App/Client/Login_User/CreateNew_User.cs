using Server.App.MaHoa;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Server.App.Client
{
    public class CreateNew_User
    {
        private DateTime dateTime;

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
        public void NewUser_Client(App_Chat_DB context, Socket clientSocket, string new_username, string new_password, string fullname, string phone, string email, string address, string age)
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
            // Chuỗi ngày tháng năm
            string dateString = age;

            // Định dạng chuỗi ngày tháng năm
            string dateFormat = "dd MM yyyy";
            try
            {
                // Chuyển đổi chuỗi sang DateTime
                dateTime = DateTime.ParseExact(dateString, dateFormat, null);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Không thể chuyển đổi chuỗi: {ex.Message}");
            }

            /* // Tên của file ảnh trong thư mục Resources
             string imageName = "user.png";

             // Lấy đường dẫn tương đối đến thư mục Resources
             string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", imageName);
             byte[] byteAnh = ConvertImgToByte(imagePath);*/

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
                DateOfBirth = dateTime,
                PhoneNumber = phone,
                Address = address,
            };

            /*PicUser newPic = new PicUser
            {
                IDanh = ID,
                IDtt = ID,
                Pic = byteAnh,
            };
            try
            {
                context.PicUsers.Add(newPic);
                context.SaveChanges();
            } catch(Exception ex)
            {
                MessageBox.Show("Lỗi lưu ảnh!!");
            }*/
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

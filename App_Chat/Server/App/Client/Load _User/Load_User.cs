using Server.App.MaHoa;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server.App.Client.Load__User
{
    public class Load_User
    {
        public void LoadUser(App_Chat_DB context, Socket clientSocket, int id)
        {
            var allowedUserIDs = context.FriendLists
            .Where(su => (su.Status == "Friend" || su.Status == "Block") && su.Status != "Pending" && (su.UserID1 == id || su.UserID2 == id))
            .Select(su => su.UserID1 == id ? su.UserID2 : su.UserID1)
            .ToList();

            var users = context.Users
                .Where(u => u.UserID != id && u.UserID != 1 && !allowedUserIDs.Contains(u.UserID))
                .Select(u => u.UserID)
                .ToList();

            // Khởi tạo danh sách để chứa thông tin người dùng
            List<string> mangThongTinNguoiDung = new List<string>();

            // Sử dụng LINQ để lấy thông tin người dùng và gộp vào danh sách
            var userInfos = from userID in users
                            let tt_User = context.User_Details.SingleOrDefault(u => u.UserID == userID)
                            where tt_User != null
                            select $"${userID}${tt_User.FullName.MaHoa()}";

            mangThongTinNguoiDung.AddRange(userInfos);

            
            string title = "[OK]";
            string noidung = title + string.Join("", mangThongTinNguoiDung);

            //MessageBox.Show(noidung);
            // Gửi phản hồi về client cùng với địa chỉ IP
            string traloi = $"{noidung}";

            // Sử dụng clientSocket để gửi phản hồi về client
            clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
        }
    }
}

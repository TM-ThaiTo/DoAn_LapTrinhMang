using Server.App.MaHoa;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Server.App.Client.Friend_User.Block
{
    public class Load_Block
    {
        public void Load_List_Block(App_Chat_DB context, Socket clientSocket, int id)
        {
            // Lấy danh sách UserID2 trong bảng chặn
            var blockedUserIDs = context.FriendLists
                .Where(su => su.UserID1 == id && su.Status == "Block")
                .Select(su => su.UserID2)
                .ToList();

            // Lấy thông tin người dùng từ bảng User_Details
            var tt_user = context.User_Details
                .Where(tt => blockedUserIDs.Contains(tt.UserID))
                .ToList();

            // Khởi tạo List<string> để chứa thông tin người dùng
            List<string> mangThongTinNguoiDung = new List<string>();

            // Sử dụng vòng lặp foreach để duyệt qua danh sách người dùng và gộp thông tin vào List
            string title = "[OK]";
            foreach (var nguoiDung in tt_user)
            {
                mangThongTinNguoiDung.Add($"${nguoiDung.UserID}${nguoiDung.FullName.MaHoa()}");
            }

            // Chuyển List<string> thành mảng nếu cần
            string[] mangThongTinNguoiDungArray = mangThongTinNguoiDung.ToArray();

            string noidung = title + string.Join("", mangThongTinNguoiDung);

            // Gửi phản hồi về client cùng với địa chỉ IP
            string traloi = $"{noidung}";

            // Sử dụng clientSocket để gửi phản hồi về client
            clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
        }

    }
}

using Server.App.MaHoa;
using Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.App.Client
{
    public class LoadListFriend
    {
        public void Load_List_Friend(App_Chat_DB context, Socket clientSocket, int id)
        {
            var friendUserIDs = context.FriendLists
            .Where(su => (su.Status == "Friend" && su.Status != "Block" && su.Status != "Pending" && (su.UserID1 == id || su.UserID2 == id)))
            .SelectMany(su => new[] { su.UserID1, su.UserID2 })
            .Distinct()
            .ToList();

            // Kiểm tra xem danh sách bạn bè có rỗng không
            if (friendUserIDs.Count == 0)
            {
                // Danh sách bạn bè rỗng, gửi phản hồi về client
                string traloi_null = "[NULL]";
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi_null));
                return;
            }

            var tt_user = context.User_Details
                .Where(tt => friendUserIDs.Contains(tt.UserID))
            // Lấy thông tin người dùng từ bảng User_Details
                .ToList();

            // Khởi tạo List<string> để chứa thông tin người dùng
            List<string> mangThongTinNguoiDung = new List<string>();

            // Sử dụng vòng lặp foreach để duyệt qua danh sách người dùng và gộp thông tin vào List
            foreach (var nguoiDung in tt_user)
            {
                mangThongTinNguoiDung.Add($"${nguoiDung.UserID}${nguoiDung.FullName.MaHoa()}");
            }

            string title = "[OK]";

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

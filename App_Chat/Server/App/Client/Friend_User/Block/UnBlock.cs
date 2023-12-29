using Server.Models;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.App.Client.Friend_User.Block
{
    public class UnBlock
    {
        public void Un_Block_User(App_Chat_DB context, Socket clientSocket, int id_yeuCau, int id_un)
        {
            var ubu = context.FriendLists.SingleOrDefault(un => (un.UserID1 == id_yeuCau && un.UserID2 == id_un) 
                                                             &&  un.Status == "Block");

            if (ubu != null)
            {
                // Xóa dòng khỏi bảng FriendLists
                context.FriendLists.Remove(ubu);

                try
                {
                    context.SaveChanges();

                    string noiDung = "[Done_Un_BlockUser]";
                    // Gửi phản hồi về client cùng với địa chỉ IP
                    string traloi = $"{noiDung}";
                    // Sử dụng clientSocket để gửi phản hồi về client
                    clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
                }
                catch
                {
                    return;
                }
            }
        }
            
        public void Un_Block_All(App_Chat_DB context, Socket clientSocket, int id_yeuCau)
        {
            // Lấy tất cả các dòng có UserID1 là id_yeuCau
            var blockedEntries = context.FriendLists.Where(un => un.UserID1 == id_yeuCau
                                                              || un.UserID2 == id_yeuCau).ToList();

            if(blockedEntries != null)
            {
                // Xóa tất cả các dòng từ danh sách blockedEntries
                context.FriendLists.RemoveRange(blockedEntries);
                try
                {
                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    string noiDung = "[Done_UnBlockAll]";

                    // Gửi phản hồi về client cùng với địa chỉ IP
                    string traloi = $"{noiDung}";

                    // Sử dụng clientSocket để gửi phản hồi về client
                    clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
                }
                catch
                {
                    return;
                }
            }
            
            
        }
    
    }
}

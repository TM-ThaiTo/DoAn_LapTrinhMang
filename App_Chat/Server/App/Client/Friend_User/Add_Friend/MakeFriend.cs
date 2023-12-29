using Server.Models;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.App.Client.Friend_User
{
    public class MakeFriend
    {
        // hàm gửi lời mời kết bạn
        private int LayMaxID(App_Chat_DB context)
        {
            // Sử dụng LINQ để truy vấn cơ sở dữ liệu và lấy ID lớn nhất
            var maxID = context.FriendLists.Max(item => (int?)item.FriendshipID) ?? 1;

            return maxID + 1;
        }
        public void Gui_Friend(App_Chat_DB context, Socket clientSocket, int id1, int id2)
        {
            FriendList Make_Friend = new FriendList()
            {
                FriendshipID = LayMaxID(context),
                UserID1 = id1,
                UserID2 = id2,
                Status = "Pending",
            };
            try
            {
                context.FriendLists.Add(Make_Friend);
                context.SaveChanges();

                string noidung = "[Pending]";
                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi = $"{noidung}";
                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
            }
            catch
            {
                return;
            }
        }

        // hàm accept kết bạn
        public void Accept_Friend(App_Chat_DB context, Socket clientSocket, int frID)
        {
            var existingRequest = context.FriendLists.FirstOrDefault(f => f.FriendshipID == frID);
            existingRequest.Status = "Friend";
            try
            {
                context.SaveChanges();
                string noidung = "[Accept]";

                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi = $"{noidung}";
                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
            }
            catch
            {
                return;
            }
        }
        
        public void Done_Friend (Socket clientSocket)
        {
            string noidung = "[Done_Friend]";

            // Gửi phản hồi về client cùng với địa chỉ IP
            string traloi = $"{noidung}";

            // Sử dụng clientSocket để gửi phản hồi về client
            clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
        }
        
        public void Block_Friend(Socket clientSocket)
        {
            string noidung = "[Block_Friend]";

            // Gửi phản hồi về client cùng với địa chỉ IP
            string traloi = $"{noidung}";

            // Sử dụng clientSocket để gửi phản hồi về client
            clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
        }
        
        public void GuiYeuCau_KetBan(App_Chat_DB context, Socket clientSocket, int id1, int id2)
        {
            var existingRequest = context.FriendLists
                .FirstOrDefault(f => (f.UserID1 == id1 && f.UserID2 == id2) || (f.UserID1 == id2 && f.UserID2 == id1));

            if(existingRequest == null)
            {
                Gui_Friend(context, clientSocket, id1, id2);
                return;
            }

            if(existingRequest != null && existingRequest.Status == "Pending") 
            {
                Accept_Friend(context, clientSocket, existingRequest.FriendshipID);
                return;
            }
            if (existingRequest != null && existingRequest.Status == "Friend")
            {
                Done_Friend(clientSocket);
                return;
            }
            
            if(existingRequest != null && existingRequest.Status == "Block")
            {
                Block_Friend(clientSocket   );
                return;
            }
        }
    }
}

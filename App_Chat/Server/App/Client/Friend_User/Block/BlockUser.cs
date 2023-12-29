using Server.Models;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.App.Client.Friend_User
{
    public class BlockUser
    {
        private int LayMaxID(App_Chat_DB context)
        {
            // Sử dụng LINQ để truy vấn cơ sở dữ liệu và lấy ID lớn nhất
            var maxID = context.FriendLists.Max(item => (int?)item.FriendshipID) ?? 0;

            return maxID + 1;
        }

        public void block_user(App_Chat_DB context, Socket clientSocket, int id_user_Block, int id_user_Nhan)
        {
            FriendList fr = new FriendList()
            {
                FriendshipID = LayMaxID(context),
                UserID1 = id_user_Block,
                UserID2 = id_user_Nhan,
                Status = "Block"
            };

            try
            {
                context.FriendLists.Add(fr);
                context.SaveChanges();

                string noidung = "[Done_Block_User]";
                
                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi = $"{noidung}";

                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
            }
            catch
            {

            }
        }
    }
}

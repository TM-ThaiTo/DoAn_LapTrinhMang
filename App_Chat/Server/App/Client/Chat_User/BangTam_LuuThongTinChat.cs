using Server.App.MaHoa;
using Server.Models;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server.App.Client.Chat_User
{
    public class BangTam_LuuThongTinChat
    {
        private int capID(App_Chat_DB context)
        {
            // Sử dụng LINQ để truy vấn cơ sở dữ liệu và lấy ID lớn nhất
            var maxID = context.Chat_Infor.Max(item => (int?)item.ID) ?? 0;
            return maxID + 1;
        }
        private void Luu_ThongTin_Moi(App_Chat_DB context, Socket clientSocket, int id1, string ip, int port, int id2)
        {
            Chat_Infor ci = new Chat_Infor()
            {
                ID = capID(context),
                UserID1 = id1,
                UserID2 = id2,
                IP = ip,
                Port = port,
            };

            try
            {
                context.Chat_Infor.Add(ci);
                context.SaveChanges();

                string noidung = "[OK]";

                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi = $"{noidung}";

                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
            }
            catch
            {

            }
        }
        private void Luu_ThongTin_Them(App_Chat_DB context, Socket clientSocket, int id1, string ip, int port, int id2)
        {
            var ttUser1 = context.Chat_Infor.SingleOrDefault(tt => tt.UserID1 == id2 && tt.UserID2 == id1);
            Chat_Infor ci = new Chat_Infor()
            {
                ID = capID(context),
                UserID1 = id1,
                UserID2 = id2,
                IP = ip,
                Port = port,
            };

            try
            {
                context.Chat_Infor.Add(ci);
                context.SaveChanges();

                string ip_User1 = ttUser1.IP;
                string port_User1 = ttUser1.Port.ToString();
                
                //string noidung = $"[OK_1]${ip}${port}";
                string noidung = $"[OK_1]${ip_User1}${port_User1}";

                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi = $"{noidung}";

                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
            }
            catch
            {

            }
        }
        public void Luu_User(App_Chat_DB context, Socket clientSocket, int id1, string ip, int port, int id2)
        {
            var c_u = context.Chat_Infor.SingleOrDefault(tt =>
                    (tt.UserID1 == id1 && tt.UserID2 == id2) || (tt.UserID1 == id2 && tt.UserID2 == id1));

            if (c_u == null) // nếu chưa có 
            {
                Luu_ThongTin_Moi(context, clientSocket, id1, ip, port, id2);
                return;
            }
            else if(c_u != null)
            {
                Luu_ThongTin_Them(context, clientSocket, id1, ip, port, id2);
                return;
            }
        }

        public void XoaBangTam(App_Chat_DB context, Socket clientSocket, int id1, int id2)
        {
            // Tìm dòng cần xóa dựa trên 2 id
            var rowToDelete = context.Chat_Infor.SingleOrDefault(row => row.UserID1 == id1 && row.UserID2 == id2);

            if (rowToDelete != null)
            {
                // Xóa dòng khỏi bảng
                context.Chat_Infor.Remove(rowToDelete);

                try
                {
                    // Lưu thay đổi vào cơ sở dữ liệu
                    context.SaveChanges();

                    string noidung = $"[OK]";

                    // Gửi phản hồi về client cùng với địa chỉ IP
                    string traloi = $"{noidung}";

                    // Sử dụng clientSocket để gửi phản hồi về client
                    clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
                }
                catch
                {
                    string noidung = $"[NULL]";

                    // Gửi phản hồi về client cùng với địa chỉ IP
                    string traloi = $"{noidung}";

                    // Sử dụng clientSocket để gửi phản hồi về client
                    clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
                }
                
            }
        }
    }
}

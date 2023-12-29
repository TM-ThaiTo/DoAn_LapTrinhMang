using Server.App.MaHoa;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Server.App.Client.Chat_User
{
    public class Load_Mess
    {
        public string Date_To_String(DateTime? timestamp)
        {
            if (timestamp.HasValue)
            {
                DateTime selectedDateTime = timestamp.Value;
                string formattedDateTime = selectedDateTime.ToString("dd MM yyyy HH:mm:ss");
                return formattedDateTime;
            }
            else
            {
                // Handle the case when timestamp is null (e.g., return an empty string or another default value)
                return "[NULL TIMESTAMP]";
            }
        }
        public void Load_Mess_User(App_Chat_DB context, Socket clientSocket, int id1, int id2)
        {
            var messages = context.Messages
                .Where(m => m.SenderID == id1 && m.ReceiverID == id2 || m.SenderID == id2 && m.ReceiverID == id1)
                .OrderBy(m => m.Timestamp)  // Sắp xếp theo thời gian tăng dần (từ cũ đến mới)
                .ToList();

            // Khởi tạo danh sách để chứa thông tin người dùng
            List<string> mangMess_vaDateTime = new List<string>();

            // Thêm thông tin từ các tin nhắn vào danh sách
            foreach (var message in messages)
            {
                // ket qua $idGui$idNhan$mess$date
                string messInfo = $"${message.SenderID}${message.ReceiverID}${message.Content.MaHoa()}${Date_To_String(message.Timestamp)}";
                mangMess_vaDateTime.Add(messInfo);
            }

            // Kiểm tra xem có tin nhắn hay không
            if (mangMess_vaDateTime.Count == 0)
            {
                string tl = $"[NULL]";

                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(tl));
                return;
            }

            string title = "[OK]";
            string noidung = title + string.Join("", mangMess_vaDateTime);

            // Gửi phản hồi về client cùng với địa chỉ IP
            string traloi = $"{noidung}";

            // Sử dụng clientSocket để gửi phản hồi về client
            clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
        }
    }
}

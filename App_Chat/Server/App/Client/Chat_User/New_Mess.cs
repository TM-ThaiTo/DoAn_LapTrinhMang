﻿using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Server.App.Client.Chat_User
{
    public class New_Mess
    {
        private int MessID(App_Chat_DB context)
        {
            // Sử dụng LINQ để truy vấn cơ sở dữ liệu và lấy ID lớn nhất
            var maxID = context.Messages.Max(item => (int?)item.MessageID) ?? 0;

            return maxID + 1;
        }
        public void New_Mess_ChatUser(App_Chat_DB context, Socket clientSocket, int id1, int id2, string mess)
        {
            Message mess1 = new Message()
            {
                MessageID = MessID(context),
                SenderID = id1,
                ReceiverID = id2,
                Content = mess,
                Timestamp = DateTime.Now,
            };

            try
            {
                context.Messages.Add(mess1);
                context.SaveChanges();

                string noiDung = "[OK]";
                
                // Gửi phản hồi về client cùng với địa chỉ IP
                string traloi = $"{noiDung}";

                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
            }
            catch
            {

            }
        }
    }
}

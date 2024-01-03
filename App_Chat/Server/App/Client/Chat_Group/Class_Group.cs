using Server.App.MaHoa;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Server.App.Client.Chat_Group
{
    public class Class_Group
    {
        #region Biến
        App_Chat_DB context = new App_Chat_DB();

        private static Class_Group instance;
        public static Class_Group Instance
        {
            get { if (instance == null) instance = new Class_Group(); return instance; }
            private set { instance = value; }
        }
        private Class_Group() { }
        #endregion

        #region Hàm tạo nhóm chat mới
        private bool kiemTra_TenGroup(string nameGroup)
        {
            var ng = context.GroupChats.SingleOrDefault(group => group.GroupName == nameGroup);
            if (ng != null)
            {
                return false;
            }
            return true;
        }
        private int capID_newGroup()
        {
            // Sử dụng LINQ để truy vấn cơ sở dữ liệu và lấy ID lớn nhất
            var maxID = context.GroupChats.Max(item => (int?)item.GroupID) ?? 0;

            return maxID + 1;
        }
        private int capID_memberGroup()
        {
            // Sử dụng LINQ để truy vấn cơ sở dữ liệu và lấy ID lớn nhất
            var maxID = context.GroupMembers.Max(item => (int?)item.GroupMemberID) ?? 0;

            return maxID + 1;
        }
        public void New_Group(Socket clientSocket, int id_ChuGruop, string nameGroup, string passGroup)
        {
            if (kiemTra_TenGroup(nameGroup) == false)
            {
                string noiDung = "[NULL]";
                string traLoi = $"{noiDung}";

                // Sử dụng clientSocket để gửi phản hồi về client
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                return;
            }

            try
            {
                int grID = capID_newGroup();

                // Create a new GroupChat object
                GroupChat newGroup = new GroupChat
                {
                    GroupID = grID,
                    GroupName = nameGroup,
                    GroupPassword = passGroup,
                    OwnerID = id_ChuGruop
                };

                context.GroupChats.Add(newGroup);
                context.SaveChanges();

                // Create a new GroupMember object
                GroupMember memberGroup = new GroupMember
                {
                    GroupMemberID = capID_memberGroup(),
                    GroupID = grID,
                    UserID = id_ChuGruop,
                };

                context.GroupMembers.Add(memberGroup);
                context.SaveChanges();

                string noiDung = "[OK]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
            }
            catch
            {
                string noiDung = "[NULL]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
            }
        }
        #endregion

        #region Hàm Load listNhom
        public void Load_Group(Socket clientSocket, int id)
        {
            var id_User_Group = context.GroupMembers.Where(idg => idg.UserID == id).ToList();

            if (id_User_Group == null || id_User_Group.Count == 0)
            {
                string noiDung = "[NULL]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                return;
            }

            // Khởi tạo List<string> để chứa thông tin nhóm
            List<string> mangThongTinGroup = new List<string>();

            // Sử dụng vòng lặp foreach để duyệt qua danh sách nhóm và gộp thông tin vào List
            foreach (var groupMember in id_User_Group)
            {
                int groupId = groupMember.GroupID;

                // Retrieve the GroupChat based on the GroupID
                var group = context.GroupChats.FirstOrDefault(g => g.GroupID == groupId);

                if (group != null)
                {
                    string tt_gr = $"${group.GroupID}${group.GroupName.MaHoa()}${group.GroupPassword.MaHoa()}";
                    mangThongTinGroup.Add(tt_gr);
                }
            }

            string title = "[OK]";
            // Chuyển List<string> thành mảng nếu cần
            string[] mangThongTinNhomArray = mangThongTinGroup.ToArray();

            string noidung = title + string.Join("", mangThongTinGroup);
            string traloi = $"{noidung}";
            clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
        }
        #endregion

        #region Hàm Join group
        public void Join_Group(Socket clientSocket, int id_Join, string name_GroupJoin, string pass_GroupJoin)
        {
            var joinGr = context.GroupChats.SingleOrDefault(jg => jg.GroupName == name_GroupJoin);
            if (joinGr != null)
            {
                if (!string.Equals(pass_GroupJoin, joinGr.GroupPassword, StringComparison.OrdinalIgnoreCase))
                {
                    string noiDung = "[NULL]";
                    string traLoi = $"{noiDung}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                    return;
                }

                // Kiểm tra xem thành viên đã tồn tại trong nhóm chưa
                var existingMember = context.GroupMembers
                    .FirstOrDefault(m => m.GroupID == joinGr.GroupID && m.UserID == id_Join);

                if (existingMember != null)
                {
                    string noiDung = "[NULL]";
                    string traLoi = $"{noiDung}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                    return;
                }

                try
                {
                    GroupMember newMember = new GroupMember()
                    {
                        GroupMemberID = capID_memberGroup(),
                        GroupID = joinGr.GroupID,
                        UserID = id_Join
                    };

                    context.GroupMembers.Add(newMember);
                    context.SaveChanges();

                    string noiDung = "[OK]";
                    string traLoi = $"{noiDung}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                } 
                catch
                {
                    /*string noiDung = "[NULL]";
                    string traLoi = $"{noiDung}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));*/
                    MessageBox.Show("2");
                    return;
                }
            }
            else
            {
                /*string noiDung = "[NULL]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));*/
                MessageBox.Show("1");
                return;
            }
        }
        #endregion

        #region Out group
        public void Out_Group(Socket clientSocket, int id_User_Out, int id_Group_Out, string name_Group_Out)
        {
            var kt_MainGroup = context.GroupChats.SingleOrDefault(mg => mg.GroupID == id_Group_Out && mg.OwnerID == id_User_Out);
            if(kt_MainGroup != null)
            {
                string noiDung = "[NULL]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                return;
            }

            var member_Group = context.GroupMembers.SingleOrDefault(mg => mg.GroupID == id_Group_Out && mg.UserID ==  id_User_Out);
            if(member_Group != null)
            {
                try
                {
                    context.GroupMembers.Remove(member_Group);
                    context.SaveChanges();

                    string noiDung = "[OK]";
                    string traLoi = $"{noiDung}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                }
                catch
                {
                    return;
                }
            }
        }
        #endregion

        #region Giải tán Group
        public void Del_Group(Socket clientSocket, int id_Group)
        {
            try
            {
                var ttGR = context.GroupChats.SingleOrDefault(tt => tt.GroupID == id_Group);

                if (ttGR != null)
                {
                    // xóa mess
                    var messGR = context.GroupMessages.Where(mess => mess.GroupID == id_Group).ToList();
                    context.GroupMessages.RemoveRange(messGR);

                    // xóa mem
                    var memGR = context.GroupMembers.Where(mem => mem.GroupID == id_Group).ToList();
                    context.GroupMembers.RemoveRange(memGR);

                    // xóa group
                    context.GroupChats.Remove(ttGR);

                    // lưu
                    context.SaveChanges();

                    string noiDung = "[OK]";
                    string traLoi = $"{noiDung}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                }
                else
                {
                    string noiDung = "[NULL]";
                    string traLoi = $"{noiDung}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions that may occur during the deletion process
                // Log or display an error message based on your application's requirements

                // Inform the client about the error
                string noiDung = "[ERROR]";
                string traLoi = $"{noiDung} {ex.Message}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
            }
        }

        #endregion

        #region Vai trò nhóm
        public void VaiTro_Group(Socket clientSocket, int id, int id_group)
        {
            var vaitro = context.GroupChats.SingleOrDefault(vt => vt.GroupID == id_group && vt.OwnerID == id);
            if(vaitro!= null)
            {
                string noiDung = "[MAIN]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                return;
            } 
            else
            {
                string noiDung = "[MEMBER]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                return;
            }
        }
        #endregion

        #region Update thông tin nhóm
        public void Update_Group(Socket clientSocket, int id_Group, string name_new, string pass_new)
        {
            var gr = context.GroupChats.SingleOrDefault(tt => tt.GroupID == id_Group);
            if(gr != null)
            {
                if(kiemTra_TenGroup(name_new) == false)
                {
                    string noiDung = "[NULL]";
                    string traLoi = $"{noiDung}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                    return;
                }

                try
                {
                    gr.GroupName = name_new;
                    gr.GroupPassword = pass_new;
                    context.SaveChanges();

                    string noiDung = "[OK]";
                    string traLoi = $"{noiDung}";
                    clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                    return;
                }
                catch
                {
                    return;
                }
            }
        }
        #endregion

        #region New mess Group
        private int capID_MessGroup()
        {
            // Sử dụng LINQ để truy vấn cơ sở dữ liệu và lấy ID lớn nhất
            var maxID = context.GroupMessages.Max(item => (int?)item.GroupMessageID) ?? 0;
            return maxID + 1;
        }
        public void New_Mess(Socket clientSocket, int idGr, int idUser, string mess)
        {
            GroupMessage newMess = new GroupMessage()
            {
                GroupMessageID = capID_MessGroup(),
                GroupID = idGr,
                UserID = idUser,
                Content = mess,
                Timestamp = DateTime.Now,
            };

            try
            {
                context.GroupMessages.Add(newMess);
                context.SaveChanges();
                string noiDung = "[OK]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
            }
            catch
            {
                string noiDung = "[NULL]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
                return;
            }
        }
        #endregion

        #region Load mess Group
        public void Load_Mess_Group(Socket clientSocket, int idGr)
        {
            // Lấy tin nhắn từ bảng GroupMessages và gắn tên người gửi dựa trên bảng User
            var messages = context.GroupMessages
                .Where(m => m.GroupID == idGr)
                .OrderBy(m => m.Timestamp)
                .ToList();

            // Khởi tạo danh sách để chứa thông tin tin nhắn
            List<string> messGr = new List<string>();

            // Thêm thông tin tin nhắn vào danh sách
            foreach (var message in messages)
            {
                var nameUser = context.User_Details.FirstOrDefault(n => n.UserID == message.UserID);

                string formattedMessage = $"${nameUser.FullName.MaHoa()}${message.Content.MaHoa()}";
                messGr.Add(formattedMessage);
            }

            // Nếu có tin nhắn, gửi về clientSocket
            if (messGr.Any())
            {
                string noiDung = "[Load_Mess]";
                string traLoi = noiDung + string.Join("", messGr);
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
            }
            else
            {
                // Không có tin nhắn, thông báo về clientSocket
                string noiDung = "[NULL]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
            } 
        }
        #endregion

        #region Load Member
        // Class để chứa thông tin về thành viên
        public class MemberInfo
        {
            public int UserId { get; set; }
            public string FullName { get; set; }
        }
        public List<MemberInfo> LoadMembers(int groupId)
        {
            // Sử dụng class MemberInfo để chứa thông tin về thành viên
            List<MemberInfo> members = context.GroupMembers
                .Where(m => m.GroupID == groupId)
                .Select(m => new MemberInfo
                {
                    UserId = m.UserID,
                    FullName = context.User_Details
                        .Where(u => u.UserID == m.UserID)
                        .Select(u => u.FullName)
                        .FirstOrDefault()
                })
                .ToList();

            return members;
        }
        public void Load_Member(Socket clientSocket, int idGr)
        {
            var members = LoadMembers(idGr);

            if (members != null && members.Any())
            {
                // Sử dụng StringBuilder để nối chuỗi hiệu quả hơn
                StringBuilder memberString = new StringBuilder("[MemberList]");

                foreach (var member in members)
                {
                    memberString.Append($"${member.UserId}${member.FullName.MaHoa()}");
                }
                // Chuyển đổi StringBuilder thành string và gửi đến client
                clientSocket.Send(Encoding.UTF8.GetBytes(memberString.ToString()));
            }
            else
            {
                // Gửi thông báo nếu không có thành viên
                string noiDung = "[NULL]";
                string traLoi = $"{noiDung}";
                clientSocket.Send(Encoding.UTF8.GetBytes(traLoi));
            }
        }
        #endregion
    }
}

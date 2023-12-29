using System.Net.Sockets;

namespace Server.App.Client.TTKetNoi_User
{
    public class ThongTinKetNoi
    {
        public int ID { get; set; }
        public Socket ClientSocket { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
    }
}

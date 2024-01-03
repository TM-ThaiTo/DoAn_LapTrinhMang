using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.App.Server_Main
{
    public class InfoServer
    {
        private static InfoServer instance;
        private InfoServer() { }
        public static InfoServer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InfoServer();
                }
                return instance;
            }
        }

        private string IPserver_Main = "192.168.1.3";
        private int port_Main = 12003;
        private int port_ChatUser = 12004;
        private int port_ChatGroup = 12005;
        private string matkhau_MD5 = "1h87h8712j";

        public string IPserver_Main1 { get => IPserver_Main; set => IPserver_Main = value; }
        public int Port_Main { get => port_Main; set => port_Main = value; }
        public int Port_ChatUser { get => port_ChatUser; set => port_ChatUser = value; }
        public int Port_ChatGroup { get => port_ChatGroup; set => port_ChatGroup = value; }
        public string Matkhau_MD5 { get => matkhau_MD5; set => matkhau_MD5 = value; }
    }
}

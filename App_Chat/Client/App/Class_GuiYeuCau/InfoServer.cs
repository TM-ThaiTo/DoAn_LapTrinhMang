﻿namespace Client.App.Class_GuiYeuCau
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

        // biến lưu trữ thông tin server
        private string serverIP = "192.168.1.3";
        private int port = 12003;
        private string matKhau_MD5 = "1h87h8712j";
        
        private int portTCP_ChatUser = 12004;
        private int portTCP_ChatGroup = 12005;


        public string ServerIP { get => serverIP; set => serverIP = value; }
        public int Port { get => port; set => port = value; }
        public string MatKhau_MD5 { get => matKhau_MD5; set => matKhau_MD5 = value; }
        public int PortTCP_ChatUser { get => portTCP_ChatUser; set => portTCP_ChatUser = value; }
        public int PortTCP_ChatGroup { get => portTCP_ChatGroup; set => portTCP_ChatGroup = value; }
    }
}

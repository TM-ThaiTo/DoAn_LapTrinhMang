namespace Client.App.Class_ThongTinUser
{
    public class UserInfo
    {
        // Đối tượng duy nhất của lớp UserInfo
        private static UserInfo instance;
        private UserInfo() { }
        public static UserInfo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInfo();
                }
                return instance;
            }
        }

        // Phương thức làm mới (reset) thông tin người dùng
        public void ResetUserInfo()
        {
            Id = string.Empty;
            Name = string.Empty;
            Email = string.Empty;
            SoDienThoai = string.Empty;
        }

        // Các thuộc tính thông tin người dùng
        private string id;
        private string username;
        private string password;
        private string name;
        private string email;
        private string soDienThoai;
        private string serverIP;
        private string address;
        private byte[] pic;



        public string Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Email { get => email; set => email = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string ServerIP { get => serverIP; set => serverIP = value; }
        public byte[] Pic { get => pic; set => pic = value; }
        public string Address { get => address; set => address = value; }
    }
}

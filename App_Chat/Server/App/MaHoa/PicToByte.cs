using System.Drawing;
using System.IO;


namespace Server.App.MaHoa
{
    static class PicToByte
    {
        public static byte[] ConvertImgToByte(this string filePath) // hàm chuyển ảnh thành mảng byte
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] picbyte = new byte[fs.Length];
                fs.Read(picbyte, 0, picbyte.Length);
                return picbyte;
            }
        }
        public static Image ByteToImg(byte[] byteArray) // Hàm chuyển đổi mảng byte thành hình ảnh
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
    }
}

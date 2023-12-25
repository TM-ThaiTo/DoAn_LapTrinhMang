using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.App.Class_MaHoa
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

        // Hàm chuyển đổi từ Base64 string sang đối tượng Image
        private static Image Base64ToImage(string base64ImageString)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(base64ImageString);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    return image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuyển đổi ảnh từ Base64: " + ex.Message, "Lỗi", MessageBoxButtons.OK);
                return null;
            }
        }
    }
}

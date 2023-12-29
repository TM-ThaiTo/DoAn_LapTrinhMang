using System;
using System.Globalization;
using System.Windows.Forms;

namespace Server.App.MaHoa
{
    public class DateTime_To_String
    {
        public static DateTime String_To_Date(string str)
        {
            // Định dạng chuỗi ngày tháng năm
            string dateFormat = "dd MM yyyy";

            System.DateTime dateTime;

            // Thử chuyển đổi chuỗi sang DateTime
            if (System.DateTime.TryParseExact(str, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return dateTime;
            }
            else
            {
                // Nếu không thành công, có thể xử lý theo cách phù hợp với ứng dụng của bạn
                MessageBox.Show("Ngày tháng năm không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DateTime.MinValue;
            }
        }

        /*public static string Date_To_String(DateTime? timestamp)
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
        }*/

    }
}

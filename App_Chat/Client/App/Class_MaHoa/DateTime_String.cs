using System;
using System.Globalization;
using System.Windows.Forms;

namespace Client.App.Class_MaHoa
{
    public class DateTime_String
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

        public static string Date_To_String(DateTime dateTime)
        {
            DateTime selectedDateTime = dateTime;
            string formattedDateTime = selectedDateTime.ToString("dd MM yyyy");
            return formattedDateTime;
        }

    }
}

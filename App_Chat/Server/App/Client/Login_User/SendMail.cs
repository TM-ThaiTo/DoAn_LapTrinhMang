using DevExpress.XtraEditors.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Server.App.Email
{
    public class SendMail
    {
        private string subject;
        public void Send(Socket clientSocket, string email, string otp)
        {
            try
            {
                var fromAddress = new MailAddress("trinhto061003@gmail.com");
                var toAddress = new MailAddress(email);
                const string frompass = "gtbi nbao xaaq zmxt"; // xac thuc 2 buoc de nhan ma
                string body = otp.ToString();

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, frompass),
                    Timeout = 200000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                })
                {
                    smtp.Send(message);
                }
                //MessageBox.Show("OTP đã được gửi qua Email.");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Gửi phản hồi về client cùng với địa chỉ IP
            string traloi = $"[OK]";

            // Sử dụng clientSocket để gửi phản hồi về client
            clientSocket.Send(Encoding.UTF8.GetBytes(traloi));
        }
    }
}

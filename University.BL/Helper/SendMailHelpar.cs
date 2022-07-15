using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Helper
{
    public static class SendMailHelpar
    {
        public static string SendMial(MailVM model)
        {
            try
            {
                MailMessage mailMessage = new MailMessage("mme61627@gmail.com" , model.Customer);
                mailMessage.Subject = model.Title;
                mailMessage.Body = model.Message;

                string FileName = Path.GetFileName(model.Attach.FileName);
                mailMessage.Attachments.Add(new Attachment(model.Attach.OpenReadStream() ,FileName));

                SmtpClient smtp = new SmtpClient("smtp.gmail.com" ,587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("mme61627@gmail.com", "yhydybuutjvefklv");
                smtp.Send("mme61627@gmail.com", model.Customer, model.Title, model.Message);

                smtp.Send(mailMessage);

                var result = "Mail Send Successfully";
                return result;
            }
            catch (Exception)
            {

                var result = "Mail Faild";
                return result;
            }
        }

     

    }
}

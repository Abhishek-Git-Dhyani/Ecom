using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace Ecom.Controllers
{
    public class CommunicationController : Controller
    {
        [HttpPost] //Sending Mail through SMTP protocol
        public ActionResult SendMail(string email)
        {
            try
            {
                using(SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    //client.Port = 587;
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("01.abhishek.dhyani@gmail.com", "bdqswfghqkbztfdj");

                    using(MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("01.abhishek.dhyani@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Test";
                        mail.Body = "https://localhost:44379/Account/Signup";

                        
                        client.Send(mail);
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult GetMail(string email)
        {
            try
            {
                string subject = "This is a mailing test";
                string body = "Hi ther abhishek";

                using (var message = new MailMessage())
                {
                    message.To.Add(email);
                    message.Subject = subject;
                    message.Body = body;
                    message.IsBodyHtml = true;

                    using (var client = new SmtpClient())
                    {
                        try
                        {
                            client.Send(message);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
                TempData["mailSent"] = "Mail sent successfully";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
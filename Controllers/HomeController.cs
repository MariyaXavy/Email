using Microsoft.AspNetCore.Mvc;
using MimeKit.Text;
using MailKit.Security;
using MimeKit;
using MailKit.Net.Smtp;


namespace studentform.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mariyaxavy2000@gmail.com"));
            email.To.Add(MailboxAddress.Parse("mariyaxavy@gmail.com"));
            email.Subject = "hi";

            email.Body = new TextPart(TextFormat.Html) { Text = "<h1> This is a test Mail <h1>" };
            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("mariyaxavy2000@gmail.com", "zgjl uiod xdht kekc");
            smtp.Send(email);
            smtp.Disconnect(true);
            ViewBag.Message = "a mail has been snd successully";
            return View();
        }

    }
}
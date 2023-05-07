using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    [Area("Admin")]
    public class SentMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest request)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "deneme123@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", request.ReceiverMail);
            mimeMessage.From.Add(mailboxAddressTo);

            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = request.Body;
            mimeMessage.Body = bodybuilder.ToMessageBody();

            mimeMessage.Subject = request.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("deneme123@gmail.com", "123456789@");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}

using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Threading.Tasks;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
	[AllowAnonymous]
	public class PasswordChangeController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public PasswordChangeController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult ForgetPassword()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
		{
			var user = _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
			string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(await user);
			var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
			{
				userId = user.Id,
				token = passwordResetToken
			}, HttpContext.Request.Scheme);


			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "deneme123@gmail.com");
			mimeMessage.From.Add(mailboxAddressFrom);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
			mimeMessage.From.Add(mailboxAddressTo);

			var bodybuilder = new BodyBuilder();
			bodybuilder.TextBody = passwordResetTokenLink;
			mimeMessage.Body = bodybuilder.ToMessageBody();

			mimeMessage.Subject = "Şifre Değişiklik Talebi";
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587, false);
			client.Authenticate("deneme123@gmail.com", "123456789@");
			client.Send(mimeMessage);
			client.Disconnect(true);
			return View();
		}

		[HttpGet]
		public IActionResult ResetPassword(string userid,string token)
		{
			TempData["userid"] = userid;
			TempData["token"] = token;
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
			var userid = TempData["userid"];
			var token = TempData["token"];
			var user = await _userManager.FindByNameAsync(userid.ToString());
			if (resetPasswordViewModel.Password==resetPasswordViewModel.ConfirmPassword) 
			{
				var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
			return View();
        }
    }
}

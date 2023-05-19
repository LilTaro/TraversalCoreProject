using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using TraversalCoreProject.Areas.Member.Models;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            userEditViewModel model = new userEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PhoneNumber = values.PhoneNumber;
            model.Mail = values.Email;
            model.Gender = values.Gender;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(userEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Image.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userImages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await model.Image.CopyToAsync(stream);
                user.ImageUrl = "/userImages/" + imagename;
            }
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Mail;
            user.Gender = model.Gender;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}

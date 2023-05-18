using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutNavbar:ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;

        public _MemberLayoutNavbar(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.image = values.ImageUrl;
            ViewBag.username = values.Name + " " + values.Surname;
            return View();
        }
	}
}

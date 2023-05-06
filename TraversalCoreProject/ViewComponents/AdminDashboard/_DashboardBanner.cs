using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _DashboardBanner:ViewComponent
    {
        Context C = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.count = C.Users.Count();
            return View();
        }
    }
}

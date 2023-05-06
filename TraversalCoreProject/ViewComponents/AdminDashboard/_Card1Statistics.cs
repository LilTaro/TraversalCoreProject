using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _Card1Statistics:ViewComponent
    {
        Context C = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = C.Destinations.Count();
            ViewBag.v2 = C.Reservations.Count();
            return View();
        }
    }
}

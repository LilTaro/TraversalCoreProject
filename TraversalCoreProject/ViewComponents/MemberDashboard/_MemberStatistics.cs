using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.MemberDashboard
{
    public class _MemberStatistics:ViewComponent
    {
        Context C = new Context();
		public IViewComponentResult Invoke()
        {
            ViewBag.reservation = C.Reservations.Count();
            ViewBag.comment = C.Comments.Count();
            ViewBag.guide = C.Guides.Count();
            ViewBag.route = C.Destinations.Count();
            ViewBag.announcement = C.Announcements.Count();
            ViewBag.users = C.Users.Count();
            ViewBag.score = "8.6";
            return View();
        }
    }
}

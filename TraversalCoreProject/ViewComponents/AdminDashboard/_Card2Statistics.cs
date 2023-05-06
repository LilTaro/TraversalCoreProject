using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.AdminDashboard
{
    public class _Card2Statistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = "$5,368";
            ViewBag.v2 = "$14,857";
            ViewBag.v3 = "$55,124k";
            return View();
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class DestinationController : Controller
    {
        DestinationManager destination = new DestinationManager(new EFDestinationDal());
        public IActionResult Index()
        {
            var values = destination.GetList();
            return View(values);
        }
    }
}

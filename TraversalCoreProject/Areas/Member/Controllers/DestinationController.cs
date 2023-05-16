using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
	[Area("Member")]
    public class DestinationController : Controller
    {
        private readonly IDestinationDal _destinationDal;

        public DestinationController(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public IActionResult Index()
        {
            var values = _destinationDal.GetList();
            return View(values);
        }
    }
}

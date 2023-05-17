using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.Areas.Member.Controllers
{
	[Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class DestinationController : Controller
    {
        private readonly IDestinationDal _destinationDal;

        public DestinationController(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public IActionResult Index(string searchString)
        {
			ViewData["CurrentFilter"] = searchString;
			var values = from X in _destinationDal.GetList() select X;
			if (!string.IsNullOrEmpty(searchString))
			{
				values = values.Where(Y => Y.DestinationCity.Contains(searchString));
			}
			return View(values.ToList());
		}
    }
}

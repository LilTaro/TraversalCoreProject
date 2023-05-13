using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationDal _destinationDal;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationDal destinationDal, UserManager<AppUser> userManager)
        {
            _destinationDal = destinationDal;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _destinationDal.GetList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> DestinationDetails(int id) 
        {
            ViewBag.Id = id;
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userid = value.Id;
            var values = _destinationDal.GetDestinationWithGuide(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        { 
            return View();
        }
    }
}

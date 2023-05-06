using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
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
        [HttpGet]
        public IActionResult DestinationDetails(int id) 
        {
            ViewBag.Id = id;
            var values = _destinationDal.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetails(Destination destination)
        { 
            return View();
        }
    }
}

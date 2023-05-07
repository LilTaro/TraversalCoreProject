using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Destination")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _destinationService.GetList();
            return View(values);
        }
        [Route("AddDestination")]
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [Route("AddDestination")]
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.Add(destination);
            return RedirectToAction("Index");
        }
        [Route("DeleteDestination/{id}")]
        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.GetByID(id);
            _destinationService.Delete(values);
            return RedirectToAction("Index");
        }
        [Route("UpdateDestination/{id}")]
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = _destinationService.GetByID(id);
            return View(values);
        }
        [Route("UpdateDestination/{id}")]
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.Update(destination);
            return RedirectToAction("Index");
        }
    }
}

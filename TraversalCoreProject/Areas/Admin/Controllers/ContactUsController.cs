using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ContactUs")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }
		[Route("Index")]
		public IActionResult Index()
        {
            var values = _contactUsService.GetListContactUsByTrue();
            return View(values);
        }
		[Route("Details/{id}")]
		[HttpGet]
        public IActionResult Details(int id) 
        {
            var values = _contactUsService.GetByID(id);
            return View(values);
        }
		[Route("DeleteMessage/{id}")]
		public IActionResult DeleteMessage(int id) 
        {
            var values = _contactUsService.GetByID(id);
            _contactUsService.Delete(values);
            return RedirectToAction("Index");
        }
    }
}

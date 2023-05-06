using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideDal _guideDal;

        public GuideController(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public IActionResult Index()
        {
            var values = _guideDal.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            _guideDal.Insert(guide);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var values = _guideDal.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateGuide(Guide guide)
        {
            _guideDal.Update(guide);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToTrue(int id)
        {
            return RedirectToAction("Index");
        }
        public IActionResult ChangeToFalse(int id)
        {
            return RedirectToAction("Index");
        }
    }
}

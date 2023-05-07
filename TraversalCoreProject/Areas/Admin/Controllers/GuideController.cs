using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideDal _guideDal;

        public GuideController(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideDal.GetList();
            return View(values);
        }
        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide(int id)
        {
            var values = _guideDal.GetByID(id);
            return View(values);
        }
        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult validationResult = validationRules.Validate(guide);
            if (validationResult.IsValid)
            {
                _guideDal.Insert(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Route("UpdateGuide/{id}")]
        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var values = _guideDal.GetByID(id);
            return View(values);
        }
        [Route("UpdateGuide/{id}")]
        [HttpPost]
        public IActionResult UpdateGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult validationResult = validationRules.Validate(guide);
            if (validationResult.IsValid)
            {
                _guideDal.Update(guide);
                return RedirectToAction("Index", "Guide", new { area = "Admin" });
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Route("DeleteGuide/{id}")]
        public IActionResult DeleteGuide(int id) 
        { 
            var values=_guideDal.GetByID(id);
            _guideDal.Delete(values);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _guideDal.ChangeToTrueByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _guideDal.ChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}

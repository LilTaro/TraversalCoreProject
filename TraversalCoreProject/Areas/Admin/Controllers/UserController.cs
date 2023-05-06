using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _userService;
        private readonly IReservationService _reservationService;

        public UserController(IAppUserService userService, IReservationService reservationService)
        {
            _userService = userService;
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var values = _userService.GetList();
            return View(values);
        }
        public IActionResult DeleteUser(int id)
        {
            var values = _userService.GetByID(id);
            _userService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var values = _userService.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateUser(AppUser user)
        {
            _userService.Update(user);
            return RedirectToAction("Index");
        }
        public IActionResult CommentUser()
        {
            _userService.GetList();
            return RedirectToAction("Index");
        }
        public IActionResult ReservationUser(int id)
        {
            var values = _reservationService.GetListWithReservationByApproved(id);
            return View(values);
        }
    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal());
        ReservationManager reservationManager = new ReservationManager(new EFReservationDal());

        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult MyCurrentReservation()
        {
            return View();
        }

        public IActionResult MyOldReservation()
        {
            return View();
        }

        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListApprovalReservation(values.Id);
            return View(valuesList);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from X in destinationManager.GetList()
                                           select new SelectListItem
                                           {
                                               Text = X.DestinationCity,
                                               Value = X.DestinationID.ToString(),
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            reservation.AppUserID = 1;
            reservation.Status = "Onay Bekliyor";
            reservationManager.Add(reservation);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}

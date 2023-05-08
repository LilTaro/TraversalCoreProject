using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Announcement")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.GetList());
            return View(values);
        }
        [HttpGet]
        [Route("AddAnnouncement")]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [Route("AddAnnouncement")]
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO announcementAdd)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Add(new Announcement()
                {
                    AnnouncementTitle = announcementAdd.AnnouncementTitle,
                    AnnouncementContent = announcementAdd.AnnouncementContent,
                    AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(announcementAdd);
        }
        [Route("DeleteAnnouncement/{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.GetByID(id);
            _announcementService.Delete(values);
            return RedirectToAction("Index");
        }
        [Route("UpdateAnnouncement/{id}")]
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.GetByID(id));
            return View(values);
        }
        [Route("UpdateAnnouncement/{id}")]
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO announcementUpdate)
        {
            if (ModelState.IsValid)
            {
                _announcementService.Update(new Announcement()
                {
                    AnnouncementID = announcementUpdate.AnnouncementID,
                    AnnouncementTitle = announcementUpdate.AnnouncementTitle,
                    AnnouncementContent = announcementUpdate.AnnouncementContent,
                    AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(announcementUpdate);
        }
    }
}

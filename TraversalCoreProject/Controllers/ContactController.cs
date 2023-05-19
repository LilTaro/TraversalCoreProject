using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDTO sendMessage)
        {
            if (ModelState.IsValid)
            {
                _contactUsService.Add(new ContactUs()
                {
                    MessageBody = sendMessage.MessageBody,
                    Mail = sendMessage.Mail,
                    Subject = sendMessage.Subject,
                    Name = sendMessage.Name,
                    Status = true,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Default");
            }
            return View(sendMessage);
        }
    }
}

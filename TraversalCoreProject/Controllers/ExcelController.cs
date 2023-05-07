using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<destinationModel> DestinationList()
        {
            List<destinationModel> model = new List<destinationModel>();
            using (var C = new Context())
            {
                model = C.Destinations.Select(X => new destinationModel
                {
                    City = X.DestinationCity,
                    DayNight = X.DestinationTime,
                    Price = X.DestinationPrice,
                    Capacity = X.Capacity
                }).ToList();
            }
            return model;
        }

        public IActionResult DestinationExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya1.xlsx");
        }
    }
}

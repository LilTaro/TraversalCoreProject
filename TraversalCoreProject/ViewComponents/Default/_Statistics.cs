﻿using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents
{
    
    public class _Statistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var C = new Context();
            ViewBag.v1 = C.Destinations.Count();
            ViewBag.v2 = C.Guides.Count();
            ViewBag.v3 = 350;
            return View();
        }
    }
}
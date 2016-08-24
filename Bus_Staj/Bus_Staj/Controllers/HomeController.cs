using Bus_Staj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bus_Staj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";      

            return View();
        }

        public ActionResult Homi()
        {
            ViewBag.Title = "Hommi page";

            return View();
        }


        
    }
}

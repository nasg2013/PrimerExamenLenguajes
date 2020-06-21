using Lab1MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1MVC.Controllers
{
    public class NationalityController : Controller
    {
        NationalityData nationalityData = new NationalityData();
        // GET: Nationality
        public ActionResult ListNationalities()
        {
            return Json(nationalityData.ListAll(), JsonRequestBehavior.AllowGet);
        }

    }
}
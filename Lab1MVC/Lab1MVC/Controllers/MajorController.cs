using Lab1MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1MVC.Controllers
{
    public class MajorController : Controller
    {
        MajorData majorData = new MajorData();
        // GET: Major
        public ActionResult ListMajors()
        {
            return Json(majorData.ListAll(), JsonRequestBehavior.AllowGet);
        }
    }
}
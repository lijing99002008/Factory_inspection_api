using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Factory_inspection_api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult erification()
        {
            ViewBag.Title = "erification";
            ViewBag.Message = "返回是否可以登陆";
            
            return View();
        }
    }
}

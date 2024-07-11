using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadAndDisplayImageInMvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ControlPanel()
        {
            return View();
        }
        public ActionResult game()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
    }
}
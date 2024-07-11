using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadAndDisplayImageInMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string Name,string Password)
        {
            if (Name.Trim().ToLower() == "1" && Password.Trim().ToLower() == "1")
            {
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage("20:Ali", false);
                return RedirectToAction("ControlPanel", "Home");
            }
            return View();
        }
    }
}
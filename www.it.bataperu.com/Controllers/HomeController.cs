using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using www.it.bataperu.com.Domain;

namespace www.it.bataperu.com.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session[Constantes.NameSessionUser] == null)
                return RedirectToAction("Login", "Account");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
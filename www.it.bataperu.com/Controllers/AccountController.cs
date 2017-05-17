using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using www.it.bataperu.com.Domain;
using www.it.bataperu.com.Models;

namespace www.it.bataperu.com.Controllers
{
    public class AccountController : Controller
    {
        IAuthenticationManager Authentication
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        // GET: Account
        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var data = new Data();
            var users = data.users();

            if (users.Any(p => p.user == model.Usuario && p.password == model.Password))
            {
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Usuario), }, DefaultAuthenticationTypes.ApplicationCookie);

                Authentication.SignIn(new AuthenticationProperties
                {
                    IsPersistent = model.RememberMe
                }, identity);
                Session[Constantes.NameSessionUser] = "ok";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Intento de acceso no valido.");
                return View(model);
            }
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Authentication.SignOut();
            Session[Constantes.NameSessionUser] = null;
            return RedirectToAction("Login", "Account");
        }
    }
}
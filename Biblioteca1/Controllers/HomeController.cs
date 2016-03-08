using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Biblioteca1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(Usuario usuario)
        {
           
            if (usuario.IsValid(usuario.email, usuario.senha))
            {
                FormsAuthentication.SetAuthCookie(usuario.email, false);
                return RedirectToAction("Index", "Emprestimos");
            }
            else
            {
                ModelState.AddModelError("", "");
            }
            
            return View(usuario);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Home");
        }

        public ActionResult Registrar()
        {
            return RedirectToAction("Create", "Usuarios");
        }



    }
}
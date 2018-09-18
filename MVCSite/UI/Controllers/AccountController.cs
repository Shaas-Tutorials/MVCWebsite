using BAL;
using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        protected IUnitOfWork uow;
        public AccountController(IUnitOfWork _uow)
        {
            uow = _uow;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = uow.AuthenticateRepo.ValidateUser(model.Username, model.Password);
                if (user != null)
                {
                    string data = JsonConvert.SerializeObject(user);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.Username, DateTime.Now, DateTime.Now.AddMinutes(20), false, data);
                    string encTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(authCookie);

                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "User" });
                    }
                }
            }
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
    }
}
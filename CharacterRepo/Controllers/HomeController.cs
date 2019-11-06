using CharacterRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace CharacterRepo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "An Example of a Personalized NPC Character Stub";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Login

        [HttpGet]
        public ActionResult Login()
        {
            // displays empty login screen with predefined returnURL
            LoginModel m = new LoginModel();
            m.Message = TempData["Message"]?.ToString() ?? "";
            m.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
            m.Username = "";
            m.Password = "";
            return View(m);
        }

        [HttpPost]
        public ActionResult Login(LoginModel info)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UserBO user = ctx.GetUserByUsername(info.Username);
                if (user == null)
                {
                    info.Message = $"The Username '{info.Username}' does not exist in the database";              
                    return View(info);
                }
                string pass = info.Password;
                RoleBO role = ctx.GetRoleByID(user.RoleID_FK);
                if (pass == user.Password)
                {
                    Session["AUTHUsername"] = info.Username;
                    Session["AuthRoles"] = role.Role;
                    return Redirect(info.ReturnURL);

                }
                info.Message = "The password was incorrect";                
                return View(info);
            }                
        }

        #endregion

        public ActionResult Signout()
        {
            Session.Remove("AUTHUserName");
            Session.Remove("AUTHRoles");
            return Redirect(@"~/Home");
        }

        public ActionResult Errortest()
        {
            Exception ex = new Exception("This is my test exception");
            return View("Error", ex);
        }
    }
}
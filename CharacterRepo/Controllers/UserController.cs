using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using CharacterRepo.Filters;
using CharacterRepo.Models;

namespace CharacterRepo.Controllers
{
    [MustBeLoggedIn]
    [MustBeInRole(Roles ="Administrator,Moderator")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<UserBO> items = ctx.GetAllUsers();
                return View(items);
            }
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UserBO user = ctx.GetUserByID(id);
                return View(user);
            }
        }

        #region Create/Register a new User

        // GET: User/Create
        [OverrideAuthorization]
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [OverrideAuthorization]
        public ActionResult Create(UserBO user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BLLContext ctx = new BLLContext())
                    {
                        if (ctx.GetUserByUsername(user.UserName) == null)
                        {
                            ctx.NewUser(user.FirstName, user.LastName, user.UserName, user.Password, user.EmailAddress, user.RoleID_FK);
                            return RedirectToAction("Index", "Home");
                        }

                        ViewBag.message = "Username already exists.";
                        return View(user);
                    } 
                }
                ViewBag.message = "The Form was filled out incorrectly.";
                return View(user);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Edit a user

        // GET: User/Edit/5
        [OverrideAuthorization]
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<RoleBO> items = ctx.GetAllRoles();
                List<SelectListItem> myRoles = new List<SelectListItem>();
                foreach (RoleBO item in items)
                {
                    SelectListItem itm = new SelectListItem();
                    itm.Value = item.RoleID.ToString();
                    itm.Text = item.Role;
                    myRoles.Add(itm);
                }
                ViewBag.MyRoles = myRoles;

                UserBO user = ctx.GetUserByID(id);

                if (user != null)
                {
                    if ((user.UserName == User.Identity.Name) || User.IsInRole("Moderator") || User.IsInRole("Administrator"))
                    {
                        return View(user);
                    }
                    // need to finish logic to send message that user isn't this user
                    TempData["message"] = "This ain't your stuff.";
                    return RedirectToAction("Login", "Home");
                }
                // need to finish logic to send message that user isn't in database
                TempData["message"] = "The URL entered is invalid. Please log in and follow the links";
                return RedirectToAction("Login", "Home");
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        [OverrideAuthorization]
        public ActionResult Edit(int id, UserBO user)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    using (BLLContext ctx = new BLLContext())
                    {
                        ctx.UpdateUser(user);
                        return RedirectToAction("Index");
                    } 
                }
                ViewBag.message = "The Form was filled out incorrectly.";
                return View(user);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Delete a user

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UserBO user = ctx.GetUserByID(id);
                return View(user);
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserBO user)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeleteUser(id);
                    return RedirectToAction("Index");                   
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View(ex);
            }
        }

        #endregion

    }
}

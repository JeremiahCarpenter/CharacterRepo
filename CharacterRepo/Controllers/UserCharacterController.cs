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
    public class UserCharacterController : Controller
    {
        // GET: UserCharacter List
        [MustBeInRole(Roles = "Administrator,Moderator")]
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<UserCharacterBO> items = ctx.GetAllUserCharacters();
                return View(items);
            }
        }

        // GET: UserCharacters List by User
        public ActionResult Personal()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<UserCharacterBO> items = ctx.GetAllUserCharactersByUserName(User.Identity.Name);
                return View(items);

                //UserBO user = ctx.GetUserByUsername(User.Identity.Name);
                //List<UserCharacterBO> items = ctx.GetAllUserCharactersByUserName(User.Identity.Name);
                //if ((user.UserName == User.Identity.Name) || User.IsInRole("Moderator") || User.IsInRole("Administrator"))
                //{
                //    return View(items); 
                //}
                //TempData["message"] = "This ain't your list of personalized characters.";
                //return RedirectToAction("Login", "Home");

            }
        }

        // GET: UserCharacter/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UserCharacterBO character = ctx.GetUserCharacter(id);
                UserBO user = ctx.GetUserByID(character.UserID_FK);

                if ((user.UserName == User.Identity.Name) || User.IsInRole("Moderator") || User.IsInRole("Administrator"))
                {
                    return View(character);
                }
                // need to finish logic to send message that user isn't this user
                TempData["message"] = "This ain't your personalized character.";
                return RedirectToAction("Login", "Home");

            }
        }

        #region Create a Usercharacter (not needed?)

        // GET: UserCharacter/Create
        public ActionResult Create()
        {
            // redirect to character copy
            return RedirectToAction("Index", "Character");
        }

        // POST: UserCharacter/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Edit a UserCharacter

        // GET: UserCharacter/Edit/5
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                UserCharacterBO character = ctx.GetUserCharacter(id);
                UserBO user = ctx.GetUserByID(character.UserID_FK);

                if ((user.UserName == User.Identity.Name) || User.IsInRole("Moderator") || User.IsInRole("Administrator"))
                {
                    return View(character);
                }

                TempData["message"] = "This ain't your personalized character.";
                return RedirectToAction("Login", "Home");
            }
        }

        // POST: UserCharacter/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserCharacterBO character)
        {
            try
            {
                // TODO: Add update logic here

                using (BLLContext ctx = new BLLContext())
                {
                    ctx.UpdateUserCharacter(character);
                    return RedirectToAction("Personal"); 
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Delete a UserCharacter

        // GET: UserCharacter/Delete/5
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                //UserCharacterBO uChar = ctx.GetUserCharacter(id);
                //return View(uChar);                
                UserCharacterBO character = ctx.GetUserCharacter(id);
                if (character != null)
                {                    
                    UserBO user = ctx.GetUserByID(character.UserID_FK);
                    if ((user.UserName == User.Identity.Name) || User.IsInRole("Moderator") || User.IsInRole("Administrator"))
                    {
                        return View(character);
                    }
                    // need to finish logic to send message that user isn't this user
                    TempData.Remove("Message");
                    TempData["Message"] = "This ain't your personalized character.";
                    return RedirectToAction("Login", "Home"); 
                }
                return View("Error");
            }
            
        }

        // POST: UserCharacter/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserCharacterBO uChar)
        {
            try
            {
                // TODO: Add delete logic here

                using (BLLContext ctx = new BLLContext())
                {

                    ctx.DeleteUserCharacter(id);
                    return RedirectToAction("Personal"); 
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

    }
}

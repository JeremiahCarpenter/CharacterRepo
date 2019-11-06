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
    public class CharacterController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<CharacterBO> items = ctx.GetAllCharacters();
                return View(items);
            }
        }

        // GET: Character/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                CharacterBO character = ctx.GetCharacter(id);
                return View(character);
            }
        }

        #region Create Character

        // GET: Character/Create
        [MustBeInRole(Roles="Administrator,Moderator")]
        public ActionResult Create()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<ClassBO> items = ctx.GetAllClasses();
                List<SelectListItem> myClasses = new List<SelectListItem>();
                foreach(ClassBO item in items )
                {
                    SelectListItem itm = new SelectListItem();
                    itm.Value = item.ClassName;
                    itm.Text = item.ClassName;
                    myClasses.Add(itm);
                }
                ViewBag.MyClasses = myClasses;

                List<SeriesBO> series = ctx.GetAllSeries();
                List<SelectListItem> mySeries = new List<SelectListItem>();
                foreach(SeriesBO cBO in series)
                {
                    SelectListItem itm = new SelectListItem();
                    itm.Value = cBO.SeriesID.ToString();
                    itm.Text = cBO.SeriesTitle;
                    mySeries.Add(itm);
                }
                ViewBag.MySeries = mySeries;

            return View();
            }
        }

        // POST: Character/Create
        [MustBeInRole(Roles = "Administrator,Moderator")]
        [HttpPost]
        public ActionResult Create(CharacterBO character)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.NewCharacter(character.Name, character.Class, character.AC, character.Strength, character.Dexterity, character.Constitution, character.Intelligence, character.Wisdom, character.Charisma, character.Description, character.SeriesID_FK);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Edit Character

        // GET: Character/Edit/5
        [MustBeInRole(Roles = "Administrator,Moderator")]
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<ClassBO> items = ctx.GetAllClasses();
                List<SelectListItem> myClasses = new List<SelectListItem>();
                foreach (ClassBO item in items)
                {
                    SelectListItem itm = new SelectListItem();
                    itm.Value = item.ClassName;
                    itm.Text = item.ClassName;
                    myClasses.Add(itm);
                }
                ViewBag.MyClasses = myClasses;
                CharacterBO character = ctx.GetCharacter(id);
                return View(character);
            }
        }

        // POST: Character/Edit/5
        [HttpPost]
        [MustBeInRole(Roles = "Administrator,Moderator")]
        public ActionResult Edit(int id, CharacterBO character)
        {
            try
            {
                // TODO: Add update logic here

                using (BLLContext ctx = new BLLContext())
                {
                    // character.CharacterID = id;
                    ctx.UpdateCharacter(character);

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Delete Character

        // GET: Character/Delete/5
        [MustBeInRole(Roles = "Administrator,Moderator")]
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                CharacterBO character = ctx.GetCharacter(id);
                return View(character); 
            }
        }

        // POST: Character/Delete/5
        [HttpPost]
        [MustBeInRole(Roles = "Administrator,Moderator")]
        public ActionResult Delete(int id, CharacterBO _character)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeleteCharacter(id);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error");
            }
        }

        #endregion

        #region Create a UserCharacter from template

        // GET: A Character template with user input to create a personal character
        public ActionResult Copy(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                CharacterBO character = ctx.GetCharacter(id);
                CharacterTransition ctran = new CharacterTransition(character);
                return View(ctran);
            }
        }

        [HttpPost]
        public ActionResult Copy(CharacterTransition character)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    var _user = ctx.GetUserByUsername(User.Identity.Name);
                    int rv = ctx.NewUserCharacter(character, _user.UserID);

                    return RedirectToAction("Details", "UserCharacter", new { id = rv });
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

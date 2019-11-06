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
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<AuthorBO> items = ctx.GetAllAuthors();
                return View(items); 
            }
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                AuthorBO author = ctx.GetAuthor(id);
                return View(author); 
            }
        }

        #region Create Author

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(AuthorBO author)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (BLLContext ctx = new BLLContext())
                    {
                        ctx.NewAuthor(author.Name);
                        return RedirectToAction("Index");
                    } 
                }
                return View(author);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Edit Author

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                AuthorBO author = ctx.GetAuthor(id);
                return View(author);
            }
        }

        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AuthorBO author)
        {
            try
            {
                // TODO: Add update logic here

                using (BLLContext ctx = new BLLContext())
                {
                    ctx.UpdateAuthor(author);
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

        #region Delete Author

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                AuthorBO author = ctx.GetAuthor(id);
                return View(author);
            }
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction("Index");
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

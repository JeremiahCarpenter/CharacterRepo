using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CharacterRepo.Filters;
using CharacterRepo.Models;

namespace CharacterRepo.Controllers
{
    [MustBeLoggedIn]
    [MustBeInRole(Roles = "Administrator,Moderator")]
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View("Construction");
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View("Construction");
        }

        #region Create Book

        // GET: Book/Create
        public ActionResult Create()
        {
            return View("Construction");
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return View("Construction");
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Edit Book

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Construction");
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return View("Construction");
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Delete Book

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Construction");
        }

        // POST: Book/Delete/5
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

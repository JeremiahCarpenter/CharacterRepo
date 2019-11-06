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
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View("Construction");
        }

        // GET: Class/Details/5
        public ActionResult Details(int id)
        {
            return View("Construction");
        }

        #region Create a Class

        // GET: Class/Create
        public ActionResult Create()
        {
            return View("Construction");
        }

        // POST: Class/Create
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

        #region Edit a Class

        // GET: Class/Edit/5
        public ActionResult Edit(int id)
        {
            return View("Construction");
        }

        // POST: Class/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Delete a Class

        // GET: Class/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Construction");
        }

        // POST: Class/Delete/5
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

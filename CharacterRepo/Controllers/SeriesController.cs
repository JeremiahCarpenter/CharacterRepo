using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using CharacterRepo.Models;
using CharacterRepo.Filters;

namespace CharacterRepo.Controllers
{
    [MustBeLoggedIn]
    [MustBeInRole(Roles = "Administrator,Moderator")]
    public class SeriesController : Controller
    {
        // GET: Series
        public ActionResult Index()
        {
            using (BLLContext ctx = new BLLContext())
            {
                List<SeriesBO> items = ctx.GetAllSeries();
                return View(items);
            }
        }

        // GET: Series/Details/5
        public ActionResult Details(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {               
                SeriesBO series = ctx.GetSeries(id);
                AuthorBO author = ctx.GetAuthor(series.AuthorID_FK);
                SeriesAuthor m = new SeriesAuthor();
                m.SeriesID = series.SeriesID;
                m.SeriesTitle = series.SeriesTitle;
                m.AuthorName = author.Name;

                return View(m);
            }
        }

        #region Create a Series

        // GET: Series/Create
        public ActionResult Create()
        {
            using (BLLContext ctx = new BLLContext())
            {
                NewSeriesAndAuthor m = new NewSeriesAndAuthor();
                var authors = ctx.GetAllAuthors();
                m.SetAuthorList(authors);
                return View(m); 
            }
        }

        // POST: Series/Create
        [HttpPost]
        public ActionResult Create(NewSeriesAndAuthor seriesAndAuthor)
        {
            try
            {
                using (BLLContext ctx = new BLLContext())
                {
                    if ((seriesAndAuthor.NewSeriesName != null) && ((seriesAndAuthor.SelectAuthorID != 0) || (seriesAndAuthor.NewAuthorName != null)))
                    {
                        if (string.IsNullOrWhiteSpace(seriesAndAuthor.NewAuthorName))
                        {
                            ctx.NewSeries(seriesAndAuthor.NewSeriesName, seriesAndAuthor.SelectAuthorID);
                        }
                        else
                        {
                            var id = ctx.NewAuthor(seriesAndAuthor.NewAuthorName);
                            ctx.NewSeries(seriesAndAuthor.NewSeriesName, id.AuthorID);
                        }
                        return RedirectToAction("Index"); 
                    }
                    TempData["message"] = "The Form must be filled out correctly.";
                    return RedirectToAction("Create");
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return View("Error", ex);
            }
        }

        #endregion

        #region Edit a Series

        // GET: Series/Edit/5
        public ActionResult Edit(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                SeriesBO series = ctx.GetSeries(id);
                return View(series);
            }
        }

        // POST: Series/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SeriesBO series)
        {
            try
            {

                using (BLLContext ctx = new BLLContext())
                {
                    ctx.UpdateSeries(series);
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

        #region Delete a Series

        // GET: Series/Delete/5
        public ActionResult Delete(int id)
        {
            using (BLLContext ctx = new BLLContext())
            {
                SeriesBO series = ctx.GetSeries(id);
                return View(series);
            }
        }

        // POST: Series/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SeriesBO series)
        {
            try
            {
                // TODO: Add delete logic here
                // add delete for Characters and UserCharacters

                using (BLLContext ctx = new BLLContext())
                {
                    ctx.DeleteSeries(id);
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
    }
}

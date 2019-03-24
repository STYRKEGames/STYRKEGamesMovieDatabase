using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using STYRKEGamesMovieDatabase.Models;

namespace STYRKEGamesMovieDatabase.Controllers
{
    //[Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private MovieDatabaseEntities db = new MovieDatabaseEntities();

        #region ActionResults 
        // GET: /StoreManager/
        public ActionResult Index()
        {
            var movies = db.Movies.Include(a => a.Genre).Include(a => a.Director).Include(a => a.Cast).Include(a => a.Writer)
                .OrderBy(a => a.Price);

            return View(movies.ToList());
        }

        // GET: /StoreManager/Details/5
        public ActionResult Details(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: /StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name");
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "Name");
            ViewBag.CastId = new SelectList(db.Casts, "CastId", "Name");
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "Name");
            return View();
        }

        // POST: /StoreManager/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", movie.GenreId);
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "Name", movie.DirectorId);
            ViewBag.CastId = new SelectList(db.Casts, "CastId", "Name", movie.CastId);
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "Name", movie.WriterId);
            return View(movie);
        }

        // GET: /StoreManager/Edit/5
        public ActionResult Edit(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", movie.GenreId);
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "Name", movie.DirectorId);
            ViewBag.CastId = new SelectList(db.Casts, "CastId", "Name", movie.CastId);
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "Name", movie.WriterId);
            return View(movie);
        }

        // POST: /StoreManager/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Name", movie.GenreId);
            ViewBag.DirectorId = new SelectList(db.Directors, "DirectorId", "Name", movie.DirectorId);
            ViewBag.CastId = new SelectList(db.Casts, "CastId", "Name", movie.CastId);
            ViewBag.WriterId = new SelectList(db.Writers, "WriterId", "Name", movie.WriterId);
            return View(movie);
        }

        // GET: /StoreManager/Delete/5
        public ActionResult Delete(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /StoreManager/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
#endregion
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
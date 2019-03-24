using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STYRKEGamesMovieDatabase.Models;

namespace STYRKEGamesMovieDatabase.Controllers
{
    public class StoreController : Controller
    {
        MovieDatabaseEntities storeDB = new MovieDatabaseEntities();
      
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();

            return View(genres);
        }

        // GET: /Store/Browse?genre=GENRENAME
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre genre and its Associated associated Movies movies from database
            var genreModel = storeDB.Genres.Include("Movies")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            var movie = storeDB.Movies.Find(id);

            return View(movie);
        }

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres
                .OrderByDescending(
                    g => g.Movies.Sum(
                        a => a.OrderDetails.Sum(
                            od => od.Quantity)))
                .Take(9)
                .ToList();

            return PartialView(genres);
        }
    }
}
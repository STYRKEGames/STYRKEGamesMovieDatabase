using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STYRKEGamesMovieDatabase.Models;

namespace STYRKEGamesMovieDatabase.Controllers
{
    public class HomeController : Controller
    {
        private MovieDatabaseEntities storeDB = new MovieDatabaseEntities();
     
        // GET: /Home/
        public ActionResult Index()
        {
            // Get most popular movies
            var movies = GetTopSellingMovies(6);

            return View(movies);
        }

        private List<Movie> GetTopSellingMovies(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            return storeDB.Movies
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        #region ActionResults For Searches
        // Add actionresults to search for specific thing


        public ActionResult MovieSearch(string q)
        {
            var movies = GetMovies(q);

            return PartialView("_MovieSearch", movies);
        }

        public ActionResult DirectorSearch(string q)
        {
            var directors = GetDirectors(q);

            return PartialView("_DirectorSearch", directors);
        }

        public ActionResult CastSearch(string q)
        {
            var artists = GetCasts(q);

            return PartialView("_CastSearch", artists);
        }

        public ActionResult WriterSearch(string q)
        {
            var artists = GetWriters(q);

            return PartialView("_WriterSearch", artists);
        }

        //looks for and list the users search results

        private List<Movie> GetMovies(string searchString)
        {
            return storeDB.Movies
                .Where(a => a.Title.Contains(searchString))
                .ToList();
        }

        private List<Director> GetDirectors(string searchString)
        {
            return storeDB.Directors
                .Where(a => a.Name.Contains(searchString))
                .ToList();
        }

        private List<Cast> GetCasts(string searchString)
        {
            return storeDB.Casts
                .Where(a => a.Name.Contains(searchString))
                .ToList();
        }

        private List<Writer> GetWriters(string searchString)
        {
            return storeDB.Writers
                .Where(a => a.Name.Contains(searchString))
                .ToList();
        }

        public ActionResult DailyDeal()
        {
            var movie = GetDailyDeal();

            return PartialView("_DailyDeal", movie);
        }

        // Select an movie and discount it by 50%
        private Movie GetDailyDeal()
        {
            var movie = storeDB.Movies
                .OrderBy(a => System.Guid.NewGuid())
                .First();

            movie.Price *= 0.5m;
            return movie;
        }
        #endregion
    }
}


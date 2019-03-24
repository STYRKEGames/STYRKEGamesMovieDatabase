using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace STYRKEGamesMovieDatabase.Models
{
    public class DBinitializer : DropCreateDatabaseIfModelChanges<MovieDatabaseEntities>
    {
        protected override void Seed(MovieDatabaseEntities context)
        {
            const string imgUrl = "~/Images/placeholder.png";

            var genres = AddGenres(context);
            var directors = AddDirectors(context);
            var casts = AddCasts(context);
            var writers = AddWriters(context);


            AddMovies(context, imgUrl, genres, directors, casts, writers);

            context.SaveChanges();
        }

        #region Add Movies Method

        private static void AddMovies(MovieDatabaseEntities context, string imgUrl, List<Genre> genres, List<Director> directors, List<Cast> casts, List<Writer> writers)
        {
            context.Movies.Add(new Movie
            {
                Title = "Frozen",
                Genre = genres.SingleOrDefault(g => g.Name == "Animation"),
                Price = 9.99M,
                Director = directors.SingleOrDefault(a => a.Name == "Chris Buck"),
                Cast = casts.SingleOrDefault(a => a.Name == "Kristen Bell"),
                Writer = writers.SingleOrDefault(a => a.Name == "Jennifer Lee"),
                MovieArtUrl = imgUrl
            });

            //context.Movies.Add(new Movie
            //{
            //    Title = "The Godfather",
            //    Genre = genres.Single(g => g.Name == "Crime"),
            //    Price = 9.99M,
            //    Director = directors.Single(a => a.Name == "Director Name To Be Added For Godfather"),
            //    Cast = casts.Single(a => a.Name == "Cast Name To Be Added For Godfather"),
            //    Writer = writers.Single(a => a.Name == "Writer Name To Be Added For Godfather"),
            //    MovieArtUrl = imgUrl
            //});

        }
        #endregion

        #region Methods to Add Stuff


        private static List<Director> AddDirectors(MovieDatabaseEntities context)
        {
            var directors = new List<Director>
            {
                new Director { Name = "Chris Buck" },
                new Director { Name = "Martin Scorsese" },

            };
            directors.ForEach(s => context.Directors.Add(s));
            context.SaveChanges();
            return directors;
        }


        private static List<Cast> AddCasts(MovieDatabaseEntities context)
        {
            var casts = new List<Cast>
            {
                new Cast { Name = "Kristen Bell" },
                new Cast { Name = "Idina Menzel" },

            };
            casts.ForEach(s => context.Casts.Add(s));
            context.SaveChanges();
            return casts;
        }

        private static List<Writer> AddWriters(MovieDatabaseEntities context)
        {
            var writers = new List<Writer>
            {
                new Writer { Name = "Jennifer Lee" },
                new Writer { Name = "Hans Christian Andersen" },

            };
            writers.ForEach(s => context.Writers.Add(s));
            context.SaveChanges();
            return writers;
        }

        private static List<Genre> AddGenres(MovieDatabaseEntities context)
        {
            var genres = new List<Genre>
            {
                new Genre { Name = "Comedy" },
                new Genre { Name = "Sci-FI" },
                new Genre { Name = "Horror" },
                new Genre { Name = "Romance" },
                new Genre { Name = "Action" },
                new Genre { Name = "Thriller" },
                new Genre { Name = "Drama" },
                new Genre { Name = "Mystery" },
                new Genre { Name = "Crime" },
                new Genre { Name = "Animation" },
                new Genre { Name = "Adventure" },
                new Genre { Name = "Fantasy" },
                new Genre { Name = "Comedy-Romance" },
                new Genre { Name = "Action-Comedy" },
                new Genre { Name = "SuperHero" },

            };

            genres.ForEach(s => context.Genres.Add(s));
            context.SaveChanges();
            return genres;
        }

        #endregion
    }
}
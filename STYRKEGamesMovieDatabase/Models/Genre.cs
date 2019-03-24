using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace STYRKEGamesMovieDatabase.Models
{
    public  class Genre
    {
        public int      GenreId     { get; set; }
        public string   Name        { get; set; }
        public string   Description { get; set; }
        public List<Movie> Movies   { get; set; }
    }
}

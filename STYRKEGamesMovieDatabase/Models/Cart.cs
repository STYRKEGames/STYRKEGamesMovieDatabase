using System;
using System.ComponentModel.DataAnnotations;

namespace STYRKEGamesMovieDatabase.Models
{
    public class Cart
    {
        [Key]
        public int RecordId  { get; set; }
        public string CartId { get; set; }
        public int MovieId   { get; set; }
        public int Count     { get; set; }

        public System.DateTime DateCreated { get; set; }

        public virtual Movie Movie  { get; set; }
    }
}
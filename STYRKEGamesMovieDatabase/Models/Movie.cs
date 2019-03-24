using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace STYRKEGamesMovieDatabase.Models
{
    public class Movie {
        [ScaffoldColumn(false)]

        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public int CastId { get; set; }
        public int WriterId { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 2)]
        public string Title { get; set; }



        [Required]
        [Range(0.01, 100.00)]

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Movie Art URL")]
        [StringLength(1024)]
        public string MovieArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Director Director { get; set; }
        public virtual Cast Cast { get; set; }
        public virtual Writer Writer { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
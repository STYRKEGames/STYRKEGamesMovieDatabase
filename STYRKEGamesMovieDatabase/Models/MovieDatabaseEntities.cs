using System.Data.Entity;
using STYRKEGamesMovieDatabase.Models;

namespace STYRKEGamesMovieDatabase.Models
{
    public class MovieDatabaseEntities : DbContext
    {
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
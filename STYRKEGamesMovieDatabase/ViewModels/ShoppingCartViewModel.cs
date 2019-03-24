using System.Collections.Generic;
using STYRKEGamesMovieDatabase.Models;

namespace STYRKEGamesMovieDatabase.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}
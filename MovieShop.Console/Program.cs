using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Data;
using MovieShop.Services;

namespace MovieShop.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MovieShopDbContext())
            {
                //var data = db.Genres.ToList();
                //var movie = db.Movies.ToList().Where(a => a.Title.StartsWith("A")).ToList();
                //MovieService movieService = new MovieService();
                //var movie = movieService.GetMovieDetails(1);
                
            }
        }
    }
}

using MovieShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext context) : base(context)
        {
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _context.Genres.Where(g => g.Id == genreId).SelectMany(m => m.Movies).ToList();
        }

        public IEnumerable<Movie> GetTopGrossingMovies()
        {
            var movie = _context.Movies.OrderByDescending(m => m.Revenue).Take(20).ToList();
            return movie;
        }

        public override Movie GetById(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            return movie;
        }
    }

    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetTopGrossingMovies();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);

    }
}

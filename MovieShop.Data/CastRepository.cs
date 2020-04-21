using MovieShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MovieShop.Data
{
    public class CastRepository : Repository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext context) : base(context)
        {
        }

        public Cast GetCastWithMovies(int castId)
        {
            var cast = _context.Casts.Where(x => x.Id == castId).Include(x => x.MovieCasts.Select(m => m.Movie)).FirstOrDefault();
            return cast;                            
        }

        public override void Add(Cast cast)
        {
            base.Add(cast);
            //_context.Casts.Add(cast);
            _context.SaveChanges();
        }
    }

    public interface ICastRepository : IRepository<Cast>
    {
        Cast GetCastWithMovies(int castId);
    }
}

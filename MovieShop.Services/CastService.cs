using MovieShop.Data;
using MovieShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Services
{
   public class CastService:ICastService
    {
        ICastRepository _CastRepository;
        public CastService()
        {
            _CastRepository = new CastRepository(new MovieShopDbContext());
        }

        public void AddCast(Cast cast)
        {
            _CastRepository.Add(cast);
        }

        public Cast GetCastWithMovie(int id)
        {
            var cast = _CastRepository.GetCastWithMovies(id);
            return cast;
        }


    }

    public interface ICastService
    {
         Cast GetCastWithMovie(int id);
        void AddCast(Cast cast);
    }
}

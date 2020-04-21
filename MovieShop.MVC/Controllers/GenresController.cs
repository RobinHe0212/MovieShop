using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Services;

namespace MovieShop.MVC.Controllers
{
    public class GenresController : Controller
    {
        IGenreService _genreService;
        public GenresController()
        {
            _genreService = new GenreService();
        }
        // GET: Genres
        public PartialViewResult Index()
        {
            return PartialView("GenresView", _genreService.GetAllGenres().OrderBy(g => g.Name).ToList());
        }
    }
}
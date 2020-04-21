using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Services;

namespace MovieShop.MVC.Controllers
{
    [RoutePrefix("Movies")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [Route("genre/{genreId}")]
        public ActionResult Genre(int genreId)
        {
            var movie = _movieService.GetMoviesByGenre(genreId).OrderBy(g=>g.Title).ToList();
            return View("MoviesByGenre", movie);
        }
        [Route("details/{id}")]
        public ActionResult Details(int id) {
            var movie = _movieService.GetMovieDetails(id);
            return View(movie);
        }

        // GET: Movies
        [HttpGet]
        public ActionResult Index()
        {
            //call Service layer to get top 20 revenue
            var movie = _movieService.GetTopGrossingMovies();
            return View(movie);
        }
    }
}
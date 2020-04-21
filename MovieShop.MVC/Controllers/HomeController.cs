using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Services;
using MovieShop.MVC.Filter;
using NLog.Web;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;

namespace MovieShop.MVC.Controllers
{
    [MovieShopExceptionFilter]
    public class HomeController : Controller
    {

       private readonly IMovieService _movieService;
        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult IndexText()
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            
            var num = 5;
            var op = num / 0;
            return View(op);
        }

        public ActionResult Index()
        {
            // get top revenue movies and show them in home page,
            // use same Movie Card as you did for genres movies
            var movies = _movieService.GetTopGrossingMovies();
            return View(movies);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
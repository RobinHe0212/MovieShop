using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShop.Entity;
using MovieShop.Services;

namespace MovieShop.MVC.Controllers
{
    public class CastsController : Controller
    {
        ICastService _castService;
        public CastsController()
        {
            _castService = new CastService();
        }
        // GET: Casts
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create() {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Cast cast)
        {
            _castService.AddCast(cast);
            return View();
        }
    }
}
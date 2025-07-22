using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthWebApp_Authenticated.Models;
using System.Linq;


namespace HealthWebApp_Authenticated.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var latestArticles = db.Articles
                           .OrderByDescending(a => a.PublishedDate)
                           .Take(3)
                           .ToList();
            return View(latestArticles);
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
using IoCDemoWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoCDemoWebApplication.Controllers
{
    public class HomeController : Controller
    {
        IProductsRepo repo = null;// new RealProductsRepo();

        //public HomeController()
        //{
        //    repo = new RealProductsRepo();
        //}
        public HomeController(IProductsRepo repo)
        {
            this.repo = repo;
        }
        
        public ActionResult Index()
        {
            return View(repo.GetProducts());
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
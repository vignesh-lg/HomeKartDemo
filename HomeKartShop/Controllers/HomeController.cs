using AutoMapper;
using HomeKartShop.BL;
using HomeKartShop.Entity;
using HomeKartShop.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace HomeKartShop.Controllers
{
    public class HomeController : Controller
    {
        UserBusinessLogic userManager;
        public HomeController()
        {
            userManager = new UserBusinessLogic();
        }
        public ActionResult Index()
        {
            return View(userManager.GetCarouselSliders());
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

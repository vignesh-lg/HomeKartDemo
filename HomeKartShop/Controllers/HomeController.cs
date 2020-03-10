using AutoMapper;
using HomeKartShop.BL;
using HomeKartShop.Entity;
using HomeKartShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            return View();
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
        [HttpGet]
        public ActionResult SliderImage()
        {
            return View(userManager.GetCarouselSliders());
        }
        [HttpPost]
        public ActionResult SliderImage(HttpPostedFileBase fileupload)
        {
            if (fileupload != null)
            {
                CarouselSliderModel carouselSliderModel = new CarouselSliderModel();
                carouselSliderModel.FileName = Path.GetFileName(fileupload.FileName);
                carouselSliderModel.FileSize = (fileupload.ContentLength) / 1000;
                fileupload.SaveAs(Server.MapPath("~/Images/" + carouselSliderModel.FileName));
                carouselSliderModel.FilePath = "~/Images/" + carouselSliderModel.FileName;
                CarouselSlider slider = Mapper.Map<CarouselSliderModel, CarouselSlider>(carouselSliderModel);
                if (userManager.ToAdd(slider) == true)
                {
                    return RedirectToAction("SliderImage", "Home");
                }
            }
            return View();
        }
    }
}
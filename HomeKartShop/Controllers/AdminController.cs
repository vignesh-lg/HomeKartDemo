using AutoMapper;
using HomeKartShop.BL;
using HomeKartShop.DAL;
using HomeKartShop.Entity;
using HomeKartShop.Models;
using System.Web.Mvc;

using System;
using System.Web;
using System.IO;

namespace HomeKartShop.Controllers
{
    public class AdminController : Controller
    {
        UserBusinessLogic userManager;
        public AdminController()
        {
           // ViewBag.State = new SelectList(userManager.StateView(), "StateId", "StateName");
            userManager = new UserBusinessLogic();
        }
        // GET: Admin
        [OutputCache(Duration = 30)]
        public ActionResult AdminHome(UserLoginData userLoginData)
        {
            return View(userLoginData);
        }
        [HttpGet]

        public ActionResult CustomerData()
        {
            return View(userManager.CustomerView());
        }

        [HttpGet]
        [ActionName("Admin_Registration")]
        public ActionResult Registration_Get()
        {

            ViewBag.State = new SelectList(userManager.StateView(), "StateName", "StateName");
            ViewBag.City = new SelectList(userManager.CityView(), "CityName", "CityName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Admin_Registration")]
        public ActionResult Registration_Post(UserRegisterData userdata)
        {
            ViewBag.State = new SelectList(userManager.StateView(), "StateName", "StateName");
            ViewBag.City = new SelectList(userManager.CityView(), "CityName", "CityName");
            if (ModelState.IsValid)
            {
                User registration = Mapper.Map<UserRegisterData, User>(userdata);
                registration.UserName = "HK_" + registration.CellNumber;
                registration.RegistrationNumber= "HKrt" + registration.CellNumber;
                registration.Password = "HKrt" + registration.CellNumber;
                if (userManager.ToRegister(registration) == true)
                    TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("CustomerData", "Admin");
            }
            TempData["Message"] = "Try Again";
            return View();
        }

        public ActionResult Details(int id)
        {

            return View(userManager.ToDisplay(id));
        }
        [HttpGet]
        [ActionName("Update")]
        public ActionResult Update_Get(int id)
        {
            ViewBag.State = new SelectList(userManager.StateView(), "StateName", "StateName");
            ViewBag.City = new SelectList(userManager.CityView(), "CityName", "CityName");
            return View(userManager.ToDisplay(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public ActionResult Update_Post( int id, User_Update userdata)
        {
            ViewBag.State = new SelectList(userManager.StateView(), "StateName", "StateName");
            ViewBag.City = new SelectList(userManager.CityView(), "CityName", "CityName");
            if (ModelState.IsValid)
            {
                User registration = Mapper.Map<User_Update, User>(userdata);
                registration.UpdatedDate = DateTime.Now;
                if (userManager.ToUpdate(registration) == true)
                    return RedirectToAction("CustomerData");
            }
            return View();

        }
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(int id)
        {
            return View(userManager.ToDisplay(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete_Post(int id, User  userdata)
        {

            if (userManager.ToDelete(id, userdata) == true)
                return RedirectToAction("CustomerData");
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
                    return RedirectToAction("SliderImage", "Admin");
                }
            }
            return View();
        }
        public ActionResult CarousalDetails(int id)
        {

            return View(userManager.ToDisplayCarousel(id));
        }
        [HttpGet]
        [ActionName("CarouselUpdate")]
        public ActionResult Get_Corousel(int id)
        {
            return View(userManager.ToDisplayCarousel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CarouselUpdate")]
        public ActionResult Update_Carousel(int id, CarouselSliderModel carouselSliderModel)
        {
            ViewBag.State = new SelectList(userManager.StateView(), "StateName", "StateName");
            ViewBag.City = new SelectList(userManager.CityView(), "CityName", "CityName");
            if (ModelState.IsValid)
            {
                CarouselSlider registration = Mapper.Map<CarouselSliderModel, CarouselSlider>(carouselSliderModel);
               
                if (userManager.ToUpdateCarousel(registration) == true)
                    return RedirectToAction("SliderImage");
            }
            return View();

        }
        [HttpGet]
        [ActionName("CarouselDelete")]
        public ActionResult Get_Carousel(int id)
        {
            return View(userManager.ToDisplayCarousel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("CarouselDelete")]
        public ActionResult Delete_Carousel(int id, CarouselSlider carouselSlider)
        {
            if (userManager.ToDeleteCarousel(id, carouselSlider) == true)
                return RedirectToAction("SliderImage");
            return View();
        }
    }
}
using AutoMapper;
using HomeKartShop.BL;
using HomeKartShop.DAL;
using HomeKartShop.Entity;
using HomeKartShop.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

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

            ViewBag.State = new SelectList(UserBusinessLogic.GetStateDetails());
            ViewBag.City = new SelectList(UserBusinessLogic.GetBangloreDetails());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Admin_Registration")]
        public ActionResult Registration_Post(UserRegisterData userdata)
        {
            ViewBag.State = new SelectList(UserBusinessLogic.GetStateDetails());
            ViewBag.City = new SelectList(UserBusinessLogic.GetBangloreDetails());
            if (ModelState.IsValid)
            {
                User registration = Mapper.Map<UserRegisterData, User>(userdata);
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
            ViewBag.State = new SelectList(UserBusinessLogic.GetStateDetails());
            ViewBag.City = new SelectList(UserBusinessLogic.GetBangloreDetails());
            return View(userManager.ToDisplay(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public ActionResult Update_Post(int id, UserRegisterData userdata)
        {
            ViewBag.State = new SelectList(UserBusinessLogic.GetStateDetails());
            ViewBag.City = new SelectList(UserBusinessLogic.GetBangloreDetails());
            if (ModelState.IsValid)
            {
                User registration = Mapper.Map<UserRegisterData, User>(userdata);
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
    }
}
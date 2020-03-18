using AutoMapper;
using HomeKartShop.BL;
using HomeKartShop.DAL;
using HomeKartShop.Entity;
using HomeKartShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeKartShop.Controllers
{
    public class UserAccountController : Controller
    {
        UserBusinessLogic userManager;
        public UserAccountController()
        {
            userManager = new UserBusinessLogic();
        }
        [HttpGet]
        [ActionName("Registration")]
        public ActionResult Registration_Get()
        {

            ViewBag.State = new SelectList(userManager.StateView(), "StateName","StateName");
            ViewBag.City = new SelectList(userManager.CityView(), "CityName", "CityName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Registration")]
        public ActionResult Registration_Post(UserRegisterData userdata)
        {


            ViewBag.State = new SelectList(userManager.StateView(), "StateName", "StateName");
            ViewBag.City = new SelectList(userManager.CityView(), "CityName", "CityName");
            if (ModelState.IsValid)
            {
                User registration = Mapper.Map<UserRegisterData, User>(userdata);
                registration.UserName = "HK_" + registration.CellNumber;
                registration.RegistrationNumber = "HKrt" + registration.CellNumber;
                if (userManager.ToRegister(registration)==true)
                TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("Secured", "UserAccount");
            }
            TempData["Message"] = "Try Again";
            return View();
        }
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserRegisterData userLoginData)
        {
            if (userManager.CheckLogin(userLoginData.UserName, userLoginData.Password) == "admin")
            {
                FormsAuthentication.SetAuthCookie(userLoginData.UserName, false);
                Session["UserName"] = userLoginData.UserName;
                Session["UserId"] = userLoginData.UserId;
                TempData["Message"] = userLoginData.UserName;
                return RedirectToAction("UserDashBoard");
            }
            else if (userManager.CheckLogin(userLoginData.UserName, userLoginData.Password) != null)
            {
                FormsAuthentication.SetAuthCookie(userLoginData.UserName, false);
                Session["UserName"] = userLoginData.UserName;
                TempData["Message"] = userLoginData.UserName;
                Session["UserId"] = userLoginData.UserId;
                return RedirectToAction("UserDashBoard");
            }
            TempData["Message"] = "Incorrect UserName or Password";
            return View();
        }
        [Authorize]
        public ActionResult Secured()
        {
            return View();
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserName"] != null)
            {
                if (Session["UserName"].ToString() == "admin")
                {
                    return RedirectToAction("AdminHome", "Admin");
                }
                else if (Session["UserName"].ToString() != null)
                {
                    
                    return RedirectToAction("CustomerHome", "Customer");
                }
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccount");
            }
        }
        public ActionResult LogOut()
        {
            Session.Remove("UserName");
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
using HomeKartShop.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeKartShop.Controllers
{
    public class CustomerController : Controller
    { 
        UserBusinessLogic userManager;
        public CustomerController()
        {
            // ViewBag.State = new SelectList(userManager.StateView(), "StateId", "StateName");
            userManager = new UserBusinessLogic();
        }
        // GET: Customer
        public ActionResult CustomerHome(Models.UserRegisterData userLoginData)
        {
            return View(userLoginData);
        }
       
    }
}
using AutoMapper;
using HomeKartShop.BL;
using HomeKartShop.Entity;
using HomeKartShop.Models;
using System;
using System.Web.Mvc;

namespace HomeKartShop.Controllers
{
    public class InventoryController : Controller
    {
        InventoryBusinessLogic userManager = new InventoryBusinessLogic();
        // GET: Inventory
        public ActionResult ProductData()
        {
            return View(userManager.ViewProduct());
        }

        [HttpGet]
        [ActionName("Product_Registration")]
        public ActionResult Registration_Get()
        {
            ViewBag.Category = new SelectList(userManager.ViewProductCategory(), "CategoryName", "CategoryName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Product_Registration")]
        public ActionResult Registration_Post(InventoryModel inventoryModel)
        {
            ViewBag.Category = new SelectList(userManager.ViewProductCategory(), "CategoryName", "CategoryName");
            if (ModelState.IsValid)
            {
                var registration = Mapper.Map<InventoryModel, Inventory>(inventoryModel);
              
                if (userManager.ToRegisterProduct(registration) == true)
                    TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("ProductData", "Inventory");
            }
            return View();
        }

        public ActionResult ProductDetails(int id)
        {

            return View(userManager.ToDisplayProduct(id));
        }
        [HttpGet]
        [ActionName("ProductUpdate")]
        public ActionResult Update_Get(int id)
        {
            ViewBag.Category = new SelectList(userManager.ViewProductCategory(), "CategoryName", "CategoryName");
            return View(userManager.ToDisplayProduct(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ProductUpdate")]
        public ActionResult Update_Post(int id, InventoryModel inventoryModel)
        {
            ViewBag.Category = new SelectList(userManager.ViewProductCategory(), "CategoryName", "CategoryName");
            if (ModelState.IsValid)
            {
                var registration = Mapper.Map<InventoryModel, Inventory>(inventoryModel);
                if (userManager.ToUpdateProduct(registration) == true)
                    return RedirectToAction("ProductData");
            }
            return View();

        }
        [HttpGet]
        [ActionName("ProductDelete")]
        public ActionResult Delete_Get(int id)
        {
            return View(userManager.ToDisplayProduct(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ProductDelete")]
        public ActionResult Delete_Post(int id, Inventory inventory)
        {

            if (userManager.ToDeleteProduct(id, inventory) == true)
                return RedirectToAction("ProductData");
            return View();
        }









        public ActionResult ProductCategoryData()
        {
            return View(userManager.ViewProductCategory());
        }

        [HttpGet]
        [ActionName("ProductCategoryRegistration")]
        public ActionResult Registration_GetCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ProductCategoryRegistration")]
        public ActionResult Registration_PostCategory(ProductCategoryModel inventoryModel)
        {
            if (ModelState.IsValid)
            {
                var registration = Mapper.Map<ProductCategoryModel, ProductCategory >(inventoryModel);

                if (userManager.ToRegisterProductCategory(registration) == true)
                    TempData["Message"] = "Registered Sucessfully";
                return RedirectToAction("ProductCategoryData", "Inventory");
            }
            return View();
        }

        public ActionResult ProductCategoryDetails(int id)
        {

            return View(userManager.ToDisplayProductCategory(id));
        }
        [HttpGet]
        [ActionName("ProductCategoryUpdate")]
        public ActionResult Update_GetCategory(int id)
        {
            return View(userManager.ToDisplayProductCategory(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ProductCategoryUpdate")]
        public ActionResult Update_PostCategory(int id, ProductCategoryModel inventoryModel)
        {
            if (ModelState.IsValid)
            {
                var registration = Mapper.Map<ProductCategoryModel, ProductCategory>(inventoryModel);
                if (userManager.ToUpdateProductCategory(registration) == true)
                    return RedirectToAction("ProductCategoryData");
            }
            return View();

        }
        [HttpGet]
        [ActionName("ProductCategoryDelete")]
        public ActionResult Delete_GetCategory(int id)
        {
            return View(userManager.ToDisplayProductCategory(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ProductCategoryDelete")]
        public ActionResult Delete_PostCategory(int id, ProductCategory inventory)
        {

            if (userManager.ToDeleteProductCategory(id, inventory) == true)
                return RedirectToAction("ProductCategoryData");
            return View();
        }
    }
}
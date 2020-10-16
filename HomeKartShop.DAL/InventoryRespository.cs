using HomeKartShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartShop.DAL
{
    public class InventoryRepository
    {
        public bool ToRegisterProduct(Inventory inventory)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.inventory.Add(inventory);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public Inventory ToDisplayProduct(int ProductId)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.inventory.Where(model => model.ProductId == ProductId).FirstOrDefault();

            }

        }

        public bool ToUpdateProduct(Inventory inventory)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.Entry(inventory).State = EntityState.Modified;
                userDataBase.SaveChanges();
                return true;
            }

        }
        public bool ToDeleteProduct(int ProductId, Inventory inventory)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                inventory = userDataBase.inventory.Where(model => model.ProductId == ProductId).FirstOrDefault();
                userDataBase.inventory.Remove(inventory);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public List<Inventory> ViewProduct()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.inventory.ToList();
            }
        }
        public bool ToRegisterProductCategory(ProductCategory inventory)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.productCategory.Add(inventory);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public object ToDisplayProductCategory(int CategoryId)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.productCategory.Where(model => model.CategoryId == CategoryId).FirstOrDefault();

            }

        }

        public bool ToUpdateProductCategory(ProductCategory inventory)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.Entry(inventory).State = EntityState.Modified;
                userDataBase.SaveChanges();
                return true;
            }
        }
        public bool ToDeleteProductCategory(int CategoryId, ProductCategory inventory)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                inventory = userDataBase.productCategory.Where(model => model.CategoryId == CategoryId).FirstOrDefault();
                userDataBase.productCategory.Remove(inventory);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public List<ProductCategory> ViewProductCategory()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.productCategory.ToList();
            }
        }
    }
}

using HomeKartShop.DAL;
using HomeKartShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartShop.BL
{
    public class InventoryBusinessLogic
    {
        InventoryRepository inventoryRepository = new InventoryRepository();
        public bool ToRegisterProduct(Inventory inventory)
        {
            return inventoryRepository.ToRegisterProduct(inventory);

        }
        public List<Inventory> ViewProduct()
        {
            return inventoryRepository.ViewProduct();
        }
        public object ToDisplayProduct(int ProductId)
        {
            return inventoryRepository.ToDisplayProduct(ProductId);
        }
        public bool ToUpdateProduct(Inventory inventory)
        {
            return inventoryRepository.ToUpdateProduct(inventory);
        }
        public bool ToDeleteProduct(int ProductId, Inventory inventory)
        {
            return inventoryRepository.ToDeleteProduct(ProductId, inventory);
        }
        public bool ToRegisterProductCategory(ProductCategory inventory)
        {
            return inventoryRepository.ToRegisterProductCategory(inventory);

        }
        public List<ProductCategory> ViewProductCategory()
        {
            return inventoryRepository.ViewProductCategory();
        }
        public object ToDisplayProductCategory(int CategoryID)
        {
            return inventoryRepository.ToDisplayProductCategory(CategoryID);
        }
        public bool ToUpdateProductCategory(ProductCategory inventory)
        {
            return inventoryRepository.ToUpdateProductCategory(inventory);
        }
        public bool ToDeleteProductCategory(int CategoryId, ProductCategory inventory)
        {
            return inventoryRepository.ToDeleteProductCategory(CategoryId, inventory);
        }
    }
}

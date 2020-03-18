using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeKartShop.Models
{
    public class InventoryModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Quantity { get; set; }
        public string Category { get; set; }
        public int TotalStock { get; set; }
        public int TotalSold { get; set; }
        public int Remaining { get; set; }
    }
}
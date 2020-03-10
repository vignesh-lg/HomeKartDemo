using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeKartShop.Models
{
    public class CarouselSliderModel
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public Nullable<int> FileSize { get; set; }
        public string FilePath { get; set; }
    }
}
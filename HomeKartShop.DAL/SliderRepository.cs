using HomeKartShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartShop.DAL
{
    public class SliderRepository
    {
        UserDataBase userDataBase = new UserDataBase();
        public List<CarouselSlider>GetCarouselSliders()
        {
            return userDataBase.carouselSliders.ToList();
        }
        public bool ToAdd(CarouselSlider carouselSlider)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.carouselSliders.Add(carouselSlider);
                userDataBase.SaveChanges();
                return true;
            }
        }
    }
}

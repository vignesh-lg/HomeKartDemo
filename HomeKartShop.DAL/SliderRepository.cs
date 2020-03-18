using HomeKartShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
                SqlParameter filename = new SqlParameter("@FileName", carouselSlider.FileName);
                SqlParameter filesize = new SqlParameter("@FileSize", carouselSlider.FileSize);
                SqlParameter filepath = new SqlParameter("@FilePath", carouselSlider.FilePath);
                var data = userDataBase.Database.ExecuteSqlCommand(" CarouselSlider_Insert @FileName,@FileSize,@FilePath", filename, filesize, filepath);
                //userDataBase.carouselSliders.Add(carouselSlider);
                //userDataBase.SaveChanges();
                return true;
            }
        }
        public object ToDisplayCarousel(int UserId)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.carouselSliders.Where(model => model.ID == UserId).FirstOrDefault();

            }

        }

        public bool ToUpdateCarousel(CarouselSlider carouselSlider)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.Entry(carouselSlider).State = EntityState.Modified;
                userDataBase.SaveChanges();
                return true;
            }
        }
        public bool ToDeleteCarousel(int UserId, CarouselSlider carouselSlider)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                SqlParameter id = new SqlParameter("@ID", UserId);
                var data = userDataBase.Database.ExecuteSqlCommand("CarouselSlider_Delete @ID",id);
                //carouselSlider = userDataBase.carouselSliders.Where(model => model.ID == UserId).FirstOrDefault();
                //userDataBase.carouselSliders.Remove(carouselSlider);
                //userDataBase.SaveChanges();
                return true;
            }
        }
    }
}

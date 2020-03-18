using HomeKartShop.DAL;
using HomeKartShop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartShop.BL
{
    public class UserBusinessLogic
    {
        UserRepository userRepository = new UserRepository();
        SliderRepository sliderRepository = new SliderRepository();
        public string CheckLogin(string username, string password)
        {
            return userRepository.CheckLogin(username, password);
        }
        public bool ToRegister(User user)
        {
            return userRepository.ToRegister(user);

        }
        public List<User> CustomerView()
        {
            return userRepository.CustomerView();
        }
        public object ToDisplay(int UserId)
        {
            return userRepository.ToDisplay(UserId);
        }
        public bool ToUpdate(User user)
        {
            return userRepository.ToUpdate(user);
        }
        public bool ToDelete(int UserId, User user)
        {
            return userRepository.ToDelete(UserId, user);
        }
        public List<State> StateView()
        {
            StateView stateView = new UserRepository();
            return stateView.StateList();
        }
        public List<City> CityView()
        {
            CityView cityView = new UserRepository();
            return cityView.CityList();
        }
        public object ToDisplayCustomer(string UserId)
        {
            return userRepository.ToDisplayCustomer(UserId);
        }
        public List<CarouselSlider> GetCarouselSliders()
        {
            return sliderRepository.GetCarouselSliders();
        }
        public bool ToAdd(CarouselSlider carouselSlider)
        {
            return sliderRepository.ToAdd(carouselSlider);
        }
        public object ToDisplayCarousel(int UserId)
        {
            return sliderRepository.ToDisplayCarousel(UserId);
        }
        public bool ToUpdateCarousel(CarouselSlider carouselSlider)
        {
            return sliderRepository.ToUpdateCarousel(carouselSlider);
        }
        public bool ToDeleteCarousel(int UserId, CarouselSlider carouselSlider)
        {
            return sliderRepository.ToDeleteCarousel(UserId, carouselSlider);
        }
    }
}

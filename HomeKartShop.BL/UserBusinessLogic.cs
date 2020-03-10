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
        public static IEnumerable<String> GetStateDetails()
        {
            return UserRepository.GetDetails();
        }
        public static IEnumerable<String> GetTamilNaduDetails()
        {
            return UserRepository.GetTamilNaduDetails();
        }
        public static IEnumerable<String> GetAndhraDetails()
        {
            return UserRepository.GetAndhraDetails(); ;
        }
        public static IEnumerable<String> GetBangloreDetails()
        {
            return UserRepository.GetBangloreDetails();
        }
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
            return userRepository.StateView();
        }
        public List<City> CityView()
        {
            return userRepository.CityView();
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
    }
}

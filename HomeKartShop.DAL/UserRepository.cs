using AutoMapper;
using HomeKartShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeKartShop.DAL
{
    public class UserRepository
    {
        public static List<String> stateList = new List<String>();
        public static List<String> tamilnaducityList = new List<String>();
        public static List<String> andhracityList = new List<String>();
        public static List<String> banglorecityList = new List<String>();

        static UserRepository()
        {
            stateList.Add("Tamil Nadu");
            stateList.Add("Andhra Pradesh");
            stateList.Add("Bangalore");
            tamilnaducityList.Add("Salem");
            tamilnaducityList.Add("Chennai");
            tamilnaducityList.Add("Coimbatore");
            andhracityList.Add("Tirupathi");
            andhracityList.Add("Hydreabad");
            banglorecityList.Add("Mysore");
            banglorecityList.Add("Manglore");
        }
        public static IEnumerable<String> GetDetails()
        {
            return stateList;
        }
        public static IEnumerable<String> GetTamilNaduDetails()
        {
            return tamilnaducityList;
        }
        public static IEnumerable<String> GetAndhraDetails()
        {
            return andhracityList;
        }
        public static IEnumerable<String> GetBangloreDetails()
        {
            return banglorecityList;
        }
        public string CheckLogin(string username, string password)
        {

            //foreach (var data in userContext.user)
            //{
            //    if (data.UserName == username)
            //    {
            //        if (data.Password == password)
            //            return data.UserName;
            //        else
            //            return null;
            //    }
            //}

            using (UserDataBase userContext = new UserDataBase())
            {
                var obj = userContext.user.Where(a => a.UserName.Equals(username) && a.Password.Equals(password)).FirstOrDefault();
                if (obj != null)
                {
                    return obj.UserName;
                }
                else
                    return null;
            }
        }

        public bool ToRegister(User user)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.user.Add(user);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public List<User> CustomerView()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.user.ToList();
            }

        }
        public object ToDisplay(int UserId)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.user.Where(model => model.UserId == UserId).FirstOrDefault();

            }

        }

        public bool ToUpdate(User user)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                userDataBase.Entry(user).State = EntityState.Modified;
                userDataBase.SaveChanges();
                return true;
            }

        }
        public bool ToDelete(int UserId, User user)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                user = userDataBase.user.Where(model => model.UserId == UserId).FirstOrDefault();
                userDataBase.user.Remove(user);
                userDataBase.SaveChanges();
                return true;
            }
        }
        public List<State> StateView()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.state.ToList();
            }
        }
        public List<City> CityView()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.city.ToList();
            }
        }
        public object ToDisplayCustomer(string UserId)
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.user.Where(model => model.UserName == UserId).FirstOrDefault();

            }

        }
    }
}

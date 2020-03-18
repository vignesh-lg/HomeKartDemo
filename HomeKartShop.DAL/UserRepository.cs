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
    public interface StateView
    {
        List<State> StateList();
    }
    public interface CityView
    {
        List<City> CityList();
    }
    public class UserRepository : StateView,CityView
    {
        public string CheckLogin(string username, string password)
        {
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
        public List<State> StateList()
        {
            using (UserDataBase userDataBase = new UserDataBase())
            {
                return userDataBase.state.ToList();
            }
        }
        public List<City> CityList()
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

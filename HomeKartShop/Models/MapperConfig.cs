using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeKartShop.Entity;

namespace HomeKartShop.Models
{
    public static class MapperConfig
    {
       public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<UserRegisterData, User>();
                config.CreateMap<CarouselSliderModel, CarouselSlider>();
            });
           
        }
    }
}
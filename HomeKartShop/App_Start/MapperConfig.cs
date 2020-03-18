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
                config.CreateMap<UserRegisterData, User>()
                 .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now)); 
                config.CreateMap<CarouselSliderModel, CarouselSlider>();
                config.CreateMap<User_Update, User>();
                config.CreateMap<InventoryModel, Inventory>();
                config.CreateMap<ProductCategoryModel, ProductCategory>();
            });
        }
    }
}
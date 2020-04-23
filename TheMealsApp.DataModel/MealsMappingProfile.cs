using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheMealsApp.Classes;
using TheMealsApp.Classes.Models;

namespace TheMealsApp.DataModel
{
    public class MealsMappingProfile : Profile
    {
        public MealsMappingProfile()
        {
            CreateMap<Menu, MenuModel>();
        }
    }
}

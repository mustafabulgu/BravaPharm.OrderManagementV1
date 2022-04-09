using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BravaPharm.OrderManagement.App.Services;
using BravaPharm.OrderManagement.App.ViewModels;

namespace BravaPharm.OrderManagement.App.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDetailViewModel, CategoryDetailVm>().ReverseMap();
            CreateMap<CategoryProductViewModel, CategoryProductVm>().ReverseMap();
            CreateMap<CategorySimpleViewModel, CategorySimpleVm>().ReverseMap();
            CreateMap<CategorySimpleViewModel, CreateCategoryCommand>();
            CreateMap<CategorySimpleViewModel, UpdateCategoryCommand>();

        }
    }
}

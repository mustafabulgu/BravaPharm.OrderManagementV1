using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BravaPharm.OrderManagement.Application.Features.Categories.Commands.CreateCategory;
using BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryDetail;
using BravaPharm.OrderManagement.Application.Features.Categories.Queries.GetCategoryList;
using BravaPharm.OrderManagement.Application.Features.Products.Commands.CreateProduct;
using BravaPharm.OrderManagement.Application.Features.Products.Commands.UpdateProduct;
using BravaPharm.OrderManagement.Application.Features.Products.Queries.GetProductDetail;
using BravaPharm.OrderManagement.Application.Features.Products.Queries.GetProductList;
using BravaPharm.OrderManagement.Domain.Entities;

namespace BravaPharm.OrderManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //GetProductDetail, GetProductList
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductSimpleVm>().ReverseMap();
            CreateMap<Product, ProductDetailVm>().ReverseMap();

            //GetCategoryList
            CreateMap<Category, CategorySimpleVm>().ReverseMap();

            //GetCategoryDetail
            CreateMap<Category, CategoryDetailVm>().ReverseMap();
            CreateMap<Product, CategoryProductVm>().ReverseMap();


            //Create Product
            CreateMap<CreateProductCommand, Product>();

            //update Product
            CreateMap<UpdateProductCommand, Product>();

            //create category
            CreateMap<CreateCategoryCommand, Category>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using shop.Models;
using shop.Dtos;


namespace shop.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto,Category>();
            Mapper.CreateMap<Order, OrderDto>();
            Mapper.CreateMap<OrderDto, Order>();
        }
    }
}
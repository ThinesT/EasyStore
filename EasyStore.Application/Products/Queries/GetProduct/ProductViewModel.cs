﻿using AutoMapper;
using EasyStore.Application.Interfaces.Mapping;
using EasyStore.Domain.Entities;

namespace EasyStore.Application.Products.Queries.GetProduct
{
    public class ProductViewModel : ICustomMapping
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>()
                .ForMember(pDTO => pDTO.ProductId, opt => opt.MapFrom(p => p.ProductId))
                .ForMember(pDTO => pDTO.ProductName, opt => opt.MapFrom(p => p.ProductName))
                .ForMember(pDTO => pDTO.ProductDescription, opt => opt.MapFrom(p => p.ProductDescription))
                .ForMember(pDTO => pDTO.Price, opt => opt.MapFrom(p => p.Price.Value));
        }
    }
}
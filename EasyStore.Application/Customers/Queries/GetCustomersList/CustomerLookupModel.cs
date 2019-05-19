using System;
using AutoMapper;
using EasyStore.Application.Interfaces.Mapping;
using EasyStore.Domain.Entities;

namespace EasyStore.Application.Customers.Queries.GetCustomersList
{
    public class CustomerLookupModel : ICustomMapping
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public void CreateMappings(Profile configuration)
        {
            configuration.CreateMap<Customer, CustomerLookupModel>()
                .ForMember(cDTO => cDTO.CustomerId, opt => opt.MapFrom(c => c.CustomerId))
                .ForMember(cDTO => cDTO.FirstName, opt => opt.MapFrom(c => c.FirstName))
                .ForMember(cDTO => cDTO.LastName, opt => opt.MapFrom(c => c.LastName))
                .ForMember(cDTO => cDTO.Phone, opt => opt.MapFrom(c => c.Phone));
        }
    }
}

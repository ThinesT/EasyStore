using System;
using EasyStore.Domain.ValueObjects;
using MediatR;

namespace EasyStore.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address_1 { get; set; }
        public string Address_2 { get; set; }
        public string City { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}

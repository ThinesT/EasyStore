using System;
using MediatR;

namespace EasyStore.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }

    }
}

using MediatR;

namespace EasyStore.Application.Customers.Commands.CreateCustomer
{
    public class CustomerCreated : INotification
    {
        public int CustomerId { get; set; }

    }
}
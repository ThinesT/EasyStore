using System;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Application.Interfaces;
using EasyStore.Application.Notifications.Models;
using MediatR;

namespace EasyStore.Application.Customers.Commands.CreateCustomer
{
    public class CustomerCreatedHandler : INotificationHandler<CustomerCreated>
    {

        private readonly INotificationService _notification;

        public CustomerCreatedHandler(INotificationService notification)
        {
            _notification = notification;
        }

        public async Task Handle(CustomerCreated notification, CancellationToken cancellationToken)
        {
            await _notification.SendAsync(new Message());
        }

    }
}

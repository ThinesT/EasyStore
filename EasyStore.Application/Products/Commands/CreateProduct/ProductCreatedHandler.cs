using System;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Application.Interfaces;
using EasyStore.Application.Notifications.Models;
using MediatR;

namespace EasyStore.Application.Products.Commands.CreateProduct
{
    public class ProductCreatedHandler : INotificationHandler<ProductCreated> 
    {
        private readonly INotificationService _notificationService;

        public ProductCreatedHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            await _notificationService.SendAsync(new Message());
        }
    }
}

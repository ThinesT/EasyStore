using MediatR;

namespace EasyStore.Application.Products.Commands.CreateProduct
{
    public class ProductCreated : INotification
    {
        public int ProductId { get; set; }
    }
}
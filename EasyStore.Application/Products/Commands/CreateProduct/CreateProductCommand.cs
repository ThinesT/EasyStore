using System;
using MediatR;

namespace EasyStore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
    }
}

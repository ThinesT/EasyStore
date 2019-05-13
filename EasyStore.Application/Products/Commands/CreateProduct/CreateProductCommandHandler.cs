using System;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Application.Interfaces;
using EasyStore.Domain.Entities;
using EasyStore.Domain.ValueObjects;
using MediatR;

namespace EasyStore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IEasyStoreDbContext _context;
        private readonly IMediator _mediator;

        public CreateProductCommandHandler(IEasyStoreDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = request.ProductName,
                Price = new Money(request.Price),
                ProductDescription = request.ProductDescription,
            };

            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new ProductCreated { ProductId = product.ProductId }, cancellationToken);

            return Unit.Value;

            
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Application.Exceptions;
using EasyStore.Application.Interfaces;
using EasyStore.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IEasyStoreDbContext _context;

        public UpdateProductCommandHandler(IEasyStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.ProductId);

            if(product == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            product.Price = new Domain.ValueObjects.Money(request.Price);
            product.ProductDescription = request.ProductDescription;
            product.ProductName = request.ProductName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

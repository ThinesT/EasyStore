using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Application.Exceptions;
using EasyStore.Application.Interfaces;
using EasyStore.Domain.Entities;
using MediatR;

namespace EasyStore.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IEasyStoreDbContext _context;

        public DeleteProductCommandHandler(IEasyStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);

            if(product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            var hasOrders = _context.OrderedItems.Any(o => o.ProductId == request.Id);

            if (hasOrders)
            {
                throw new DeleteFailureException(nameof(Product), request.Id, "Existing orders are associated with this product");
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}

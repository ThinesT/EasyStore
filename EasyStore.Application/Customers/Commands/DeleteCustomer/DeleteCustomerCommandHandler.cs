using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Application.Exceptions;
using EasyStore.Application.Interfaces;
using EasyStore.Domain.Entities;
using MediatR;

namespace EasyStore.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IEasyStoreDbContext _context;

        public DeleteCustomerCommandHandler(IEasyStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.CustomerId);

            if(customer == null)
            {
                throw new NotFoundException(nameof(Customer), request.CustomerId);
            }

            var customerHasOrders = _context.Orders.Any(o => o.CustomerId == request.CustomerId);

            if (customerHasOrders)
            {
                throw new DeleteFailureException(nameof(Customer), request.CustomerId, "There are existing orders associated with this customer");
            }

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

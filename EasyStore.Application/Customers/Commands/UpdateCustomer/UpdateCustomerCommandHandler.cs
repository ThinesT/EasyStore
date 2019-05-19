using System;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Application.Exceptions;
using EasyStore.Application.Interfaces;
using EasyStore.Domain.Entities;
using EasyStore.Domain.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IEasyStoreDbContext _context;

        public UpdateCustomerCommandHandler(IEasyStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId == request.CustomerId);

            if(customer == null)
            {
                throw new NotFoundException(nameof(Customer), request.CustomerId);
            }

            customer.Address = new Address(request.Address_1, 
                                           request.Address_2,
                                           request.City,
                                           request.EmailAddress, 
                                           request.Country,
                                           request.ZipCode);

            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;
            customer.Phone = request.Phone;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}

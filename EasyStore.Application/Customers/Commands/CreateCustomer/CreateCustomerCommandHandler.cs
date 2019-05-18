using System;
using System.Threading;
using System.Threading.Tasks;
using EasyStore.Application.Interfaces;
using EasyStore.Domain.Entities;
using EasyStore.Domain.ValueObjects;
using MediatR;

namespace EasyStore.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
    {
        private readonly IEasyStoreDbContext _context;
        private readonly IMediator _mediator;

        public CreateCustomerCommandHandler(IEasyStoreDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone,
                Address = new Address(request.Address_1, request.Address_2, request.City, request.EmailAddress, request.Country, request.ZipCode),
            };

            await _context.Customers.AddAsync(customer);

            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new CustomerCreated { CustomerId = customer.CustomerId }, cancellationToken);

            return Unit.Value;
        }
    }
}

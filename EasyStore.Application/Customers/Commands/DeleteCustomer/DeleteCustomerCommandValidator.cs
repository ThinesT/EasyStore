using System;
using FluentValidation;

namespace EasyStore.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("CustomerId should not be empty!");
        }
    }
}

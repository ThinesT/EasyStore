using System;
using FluentValidation;

namespace EasyStore.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty().WithMessage("CustomerId is required to update the customer");
        }
    }
}

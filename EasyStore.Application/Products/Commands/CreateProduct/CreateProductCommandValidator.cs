using System;
using FluentValidation;

namespace EasyStore.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            // applied fluent validations
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Product name required!");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Product price must have a value!");
        }
    }
}

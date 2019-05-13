using System;
using FluentValidation;

namespace EasyStore.Application.Products.Queries.GetProduct
{
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(p => p.Id).NotEmpty().WithMessage("Product Id is required to retrieve a product!");
        }
    }
}

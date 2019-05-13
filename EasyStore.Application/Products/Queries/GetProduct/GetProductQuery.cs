using System;
using MediatR;

namespace EasyStore.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }

    }
}

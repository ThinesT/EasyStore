using System;
using MediatR;

namespace EasyStore.Application.Products.Queries
{
    public class GetProductsListQuery : IRequest<ProductListViewModel>
    {

    }
}

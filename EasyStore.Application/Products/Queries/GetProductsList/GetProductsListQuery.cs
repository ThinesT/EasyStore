using System;
using MediatR;

namespace EasyStore.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<ProductListViewModel>
    {

    }
}

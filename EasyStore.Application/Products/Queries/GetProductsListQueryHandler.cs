using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Application.Products.Queries
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductListViewModel>
    {
        private readonly IEasyStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IEasyStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductListViewModel> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.ProjectTo<ProductLookupModel>(_mapper.ConfigurationProvider).ToListAsync();

            return new ProductListViewModel
            {
                Products = products
            };
        }
    }
}

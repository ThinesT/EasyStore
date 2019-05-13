using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Application.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, ProductListViewModel>
    {
        private readonly IEasyStoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetProductsListQueryHandler> _logger;

        public GetProductsListQueryHandler(IEasyStoreDbContext context, IMapper mapper, IAppLogger<GetProductsListQueryHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<ProductListViewModel> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting products list from database, Products:{request}", request);
            var products = await _context.Products.ProjectTo<ProductLookupModel>(_mapper.ConfigurationProvider).ToListAsync();

            return new ProductListViewModel
            {
                Products = products
            };
        }
    }
}

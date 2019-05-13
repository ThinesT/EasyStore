using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using EasyStore.Application.Exceptions;
using EasyStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly IEasyStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IEasyStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductViewModel>(await _context.Products
                                 .Where(p => p.ProductId == request.Id)
                                 .SingleOrDefaultAsync(cancellationToken));

            if(product == null)
            {
                throw new NotFoundException(nameof(product),request.Id);
            }

            return product;
        }
    }
}

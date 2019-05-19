using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EasyStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EasyStore.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListViewModel>
    {
        private readonly IEasyStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(IEasyStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomersListViewModel> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            return new CustomersListViewModel
            {
                Customers = await _context.Customers.ProjectTo<CustomerLookupModel>(_mapper.ConfigurationProvider)
                                                    .ToListAsync(cancellationToken)
            };
        }
    }
}

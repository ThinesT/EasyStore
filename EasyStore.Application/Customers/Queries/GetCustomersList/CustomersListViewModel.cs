using System.Collections.Generic;
using EasyStore.Domain.Entities;

namespace EasyStore.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListViewModel
    {
        public IList<CustomerLookupModel> Customers { get; set; }
    }
}
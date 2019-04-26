using System;
using System.Collections.Generic;
using EasyStore.Domain.ValueObjects;

namespace EasyStore.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderedItems = new HashSet<OrderedItem>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Address Billings { get; set; }
        public Address Shippings { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderedItem> OrderedItems { get; private set; }


    }
}

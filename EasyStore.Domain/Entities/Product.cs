using EasyStore.Domain.ValueObjects;

namespace EasyStore.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public Money Price { get; set; }

    }
}

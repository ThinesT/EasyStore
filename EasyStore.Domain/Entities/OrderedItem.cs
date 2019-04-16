namespace EasyStore.Domain.Entities
{
    public class OrderedItem
    {
        public int OrderedItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
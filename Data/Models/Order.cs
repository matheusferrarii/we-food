namespace we_food.Data.Model
{
    public class Order
    {
        public Guid Id { get; set; }

        public string CustomerName { get; set; }

        public decimal TotalAmount { get;  set; }

        public List<OrderItem> Items { get; set; } = new();

        public string Status { get;  set; }

        public DateTime CreatedAt { get;  set; }
    }
}

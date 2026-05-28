using we_food.contexts.order.ValueObjects;

namespace we_food.Data.Model
{
    public class OrderItem
    {
        public Guid MenuItemId { get;  set; }

        public int Quantity { get;  set; }

        public decimal UnitPrice { get;  set; }

        public decimal Subtotal { get;  set; }


    }
}

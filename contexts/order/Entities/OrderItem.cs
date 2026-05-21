using we_food.contexts.order.ValueObjects;

namespace we_food.contexts.order.Entities
{
    public class OrderItem
    {
        public Guid MenuItemId { get; private set; }

        public Quantity Quantity { get; private set; }

        public Money UnitPrice { get; private set; }

        public Money Subtotal => new Money(Quantity.Value * UnitPrice.Value);

        public OrderItem(Guid menuItemId, Quantity quantity, Money unitPrice)
        {
            MenuItemId = menuItemId;

            Quantity = quantity;

            UnitPrice = unitPrice;
        }
    }
}

using we_food.contexts.order.Entities;

namespace we_food.contexts.order.DTOS
{
    public class OrderItemResponseDTO
    {
        public Guid Id { get; set; }
        public Guid MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }

        public static OrderItemResponseDTO From(OrderItem i) => new()
        {
            Id = i.Id,
            MenuItemId = i.MenuItemId,
            Quantity = i.Quantity.Value,
            UnitPrice = i.UnitPrice.Value,
            Subtotal = i.Subtotal.Value
        };
    }
}

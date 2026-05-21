namespace we_food.contexts.order.DTOS
{
    public class CreateOrderItemDTO
    {
        public Guid MenuItemId { get; set; }

        public int Quantity { get; set; }

    }
}

namespace we_food.contexts.order.DTOS
{
    public class CreateOrderDTO
    {
        public string CustomerName { get; set; }

        public List<CreateOrderItemDTO> Items { get; set; }
    }
}

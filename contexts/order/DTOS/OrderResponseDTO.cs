using we_food.contexts.order.Entities;

namespace we_food.contexts.order.DTOS
{
    public class OrderResponseDTO
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItemResponseDTO> Items { get; set; }

        public static OrderResponseDTO From(Order o) => new()
        {
            Id = o.Id,
            CustomerName = o.CustomerName.Value,
            TotalAmount = o.TotalAmount.Value,
            Status = o.Status.ToString(),
            CreatedAt = o.CreatedAt,
            Items = o.Items.Select(OrderItemResponseDTO.From).ToList()
        };
    }
}

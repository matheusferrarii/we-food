using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.DTOS
{
    public class MenuItemResponseDTO
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public static MenuItemResponseDTO From(MenuItem m) => new()
        {
            Id = m.Id,
            RestaurantId = m.RestaurantId,
            Name = m.Name.Value,
            Description = m.Description.Value,
            Price = m.Price.Value,
            CreatedAt = m.CreatedAt
        };
    }
}

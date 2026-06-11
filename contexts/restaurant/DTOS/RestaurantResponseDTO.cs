using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.DTOS
{
    public class RestaurantResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsOpen { get; set; }
        public DateTime CreatedAt { get; set; }

        public static RestaurantResponseDTO From(Restaurant r) => new()
        {
            Id = r.Id,
            Name = r.Name.Value,
            Description = r.Description.Value,
            Phone = r.Phone.Value,
            Address = r.Address.Value,
            IsOpen = r.IsOpen,
            CreatedAt = r.CreatedAt
        };
    }
}

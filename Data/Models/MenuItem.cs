using we_food.contexts.restaurant.ValueObjects;

namespace we_food.Data.Model
{
    public class MenuItem
    {
        public Guid Id { get;  set; }

        public Guid RestaurantId { get;  set; }

        public string Name { get;  set; }

        public string Description { get;  set; }

        public decimal Price { get;  set; }

        public DateTime CreatedAt { get;  set; }
    }
}

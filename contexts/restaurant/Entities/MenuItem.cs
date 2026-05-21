
using we_food.contexts.restaurant.ValueObjects;

namespace we_food.contexts.restaurant.Entities
{
    public class MenuItem
    {
        public Guid Id { get; private set; }

        public Guid RestaurantId { get; private set; }

        public Name Name { get; private set; }

        public Description Description { get; private set; }

        public Money Price { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public MenuItem(Guid restaurantId, Name name, Description description, Money price)
            {
                Id = Guid.NewGuid();
    
                RestaurantId = restaurantId;
    
                Name = name;
    
                Description = description;
    
                Price = price;
    
                CreatedAt = DateTime.UtcNow;
        }

    }
}

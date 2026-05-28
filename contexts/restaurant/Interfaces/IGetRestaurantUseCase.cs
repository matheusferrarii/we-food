using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface IGetRestaurantUseCase
    {
        Task<IEnumerable<Restaurant>> Run();
    }
}

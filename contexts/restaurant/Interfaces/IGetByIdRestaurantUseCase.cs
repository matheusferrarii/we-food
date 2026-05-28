using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface IGetByIdRestaurantUseCase
    {
        Task<Restaurant> Run(Guid id);
    }
}

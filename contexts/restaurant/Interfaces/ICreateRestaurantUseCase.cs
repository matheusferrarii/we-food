using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface ICreateRestaurantUseCase
    {
        Task<Restaurant> Run(RestaurantCreateDTO dto);
    }
}

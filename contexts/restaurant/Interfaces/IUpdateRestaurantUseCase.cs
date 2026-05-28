using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface IUpdateRestaurantUseCase
    {
        Task<Restaurant> Run(Guid id, RestaurantUpdateDTO dto);
    }
}

using we_food.contexts.restaurant.DTOS;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface ICreateRestaurantUseCase
    {
        Task Run(RestaurantCreateDTO dto);
    }
}

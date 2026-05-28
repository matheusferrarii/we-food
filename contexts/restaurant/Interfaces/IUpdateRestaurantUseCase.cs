using we_food.contexts.restaurant.DTOS;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface IUpdateRestaurantUseCase
    {
        Task Run(Guid id, RestaurantUpdateDTO dto);
    }
}

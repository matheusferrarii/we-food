using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface IGetByIdRestaurantMenuUseCase
    {
        Task<List<MenuItem>> Run(Guid id);
    }
}

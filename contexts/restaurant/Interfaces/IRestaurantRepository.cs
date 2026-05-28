using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface IRestaurantRepository
    {
        Task Save(Restaurant restaurant);
        Task Update(Restaurant restaurant);
        Task<Restaurant?> FindById(Guid id);
        Task<List<Restaurant>> FindAll();
    }
}

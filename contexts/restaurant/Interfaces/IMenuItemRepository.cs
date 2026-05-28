using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface IMenuItemRepository
    {
        Task Save(MenuItem menuItem);
        Task Update(MenuItem menuItem);
        Task<MenuItem?> FindById(Guid id);
        Task<List<MenuItem>> FindAll();
        Task<List<MenuItem>> FindByRestaurantId(Guid restaurantId);
    }
}

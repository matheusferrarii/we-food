using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface IGetByIdMenuItemUseCase
    {
        Task<MenuItem> Run(Guid id);
    }
}

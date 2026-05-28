using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Entities;

namespace we_food.contexts.restaurant.Interfaces
{
    public interface ICreateMenuItemUseCase
    {
        Task<MenuItem> Run(MenuItemCreateDTO dto);
    }
}

using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;
using we_food.contexts.restaurant.ValueObjects;

namespace we_food.contexts.restaurant.UseCases
{
    public class CreateMenuItemUseCase : ICreateMenuItemUseCase
    {
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateMenuItemUseCase(IMenuItemRepository menuItemRepository, IRestaurantRepository restaurantRepository)
        {
            _menuItemRepository = menuItemRepository;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<MenuItem> Run(MenuItemCreateDTO dto)
        {
            var restaurant = await _restaurantRepository.FindById(dto.RestaurantId);

            if (restaurant == null)
                throw new Exception("Restaurante não encontrado");

            var menuItem = new MenuItem(
                dto.RestaurantId,
                new Name(dto.Name),
                new Description(dto.Description),
                new Money(dto.Price)
            );

            await _menuItemRepository.Save(menuItem);

            return menuItem;
        }
    }
}

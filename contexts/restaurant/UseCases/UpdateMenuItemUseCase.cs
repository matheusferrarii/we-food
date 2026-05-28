using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;
using we_food.contexts.restaurant.ValueObjects;

namespace we_food.contexts.restaurant.UseCases
{
    public class UpdateMenuItemUseCase : IUpdateMenuItemUseCase
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public UpdateMenuItemUseCase(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<MenuItem> Run(Guid id, MenuItemUpdateDTO dto)
        {
            var menuItem = await _menuItemRepository.FindById(id);

            if (menuItem == null)
                throw new Exception("Item do cardápio não encontrado");

            menuItem.Update(
                new Name(dto.Name),
                new Description(dto.Description),
                new Money(dto.Price)
            );

            await _menuItemRepository.Update(menuItem);

            return menuItem;
        }
    }
}

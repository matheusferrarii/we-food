using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;

namespace we_food.contexts.restaurant.UseCases
{
    public class GetByIdMenuItemUseCase : IGetByIdMenuItemUseCase
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public GetByIdMenuItemUseCase(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<MenuItem> Run(Guid id)
        {
            var menuItem = await _menuItemRepository.FindById(id);

            if (menuItem == null)
                throw new Exception("Item do cardápio não encontrado");

            return menuItem;
        }
    }
}

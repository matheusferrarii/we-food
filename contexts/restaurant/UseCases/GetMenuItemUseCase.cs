using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;

namespace we_food.contexts.restaurant.UseCases
{
    public class GetMenuItemUseCase : IGetMenuItemUseCase
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public GetMenuItemUseCase(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public async Task<List<MenuItem>> Run()
        {
            return await _menuItemRepository.FindAll();
        }
    }
}

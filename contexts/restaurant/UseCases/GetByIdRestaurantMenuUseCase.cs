using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;

namespace we_food.contexts.restaurant.UseCases
{
    public class GetByIdRestaurantMenuUseCase : IGetByIdRestaurantMenuUseCase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public GetByIdRestaurantMenuUseCase(IRestaurantRepository restaurantRepository, IMenuItemRepository menuItemRepository)
        {
            _restaurantRepository = restaurantRepository;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<List<MenuItem>> Run(Guid id)
        {
            var restaurant = await _restaurantRepository.FindById(id);

            if (restaurant == null)
                throw new Exception("Restaurante não encontrado");

            return await _menuItemRepository.FindByRestaurantId(id);
        }
    }
}

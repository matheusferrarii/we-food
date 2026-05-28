using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;

namespace we_food.contexts.restaurant.UseCases
{
    public class GetRestaurantUseCase : IGetRestaurantUseCase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public GetRestaurantUseCase(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<IEnumerable<Restaurant>> Run()
        {
            return await _restaurantRepository.FindAll();
        }
    }
}

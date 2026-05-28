using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;

namespace we_food.contexts.restaurant.UseCases
{
    public class GetByIdRestaurantUseCase : IGetByIdRestaurantUseCase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public GetByIdRestaurantUseCase(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Restaurant> Run(Guid id)
        {
            var restaurant = await _restaurantRepository.FindById(id);

            if (restaurant == null)
                throw new Exception("Restaurante não encontrado");

            return restaurant;
        }
    }
}

using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;

namespace we_food.contexts.restaurant.UseCases
{
    public class UpdateRestaurantStatusUseCase : IUpdateRestaurantStatusUseCase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public UpdateRestaurantStatusUseCase(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Restaurant> Run(Guid id, RestaurantUpdateStatusDTO dto)
        {
            var restaurant = await _restaurantRepository.FindById(id);

            if (restaurant == null)
                throw new Exception("Restaurante não encontrado");

            restaurant.SetStatus(dto.IsOpen);

            await _restaurantRepository.Update(restaurant);

            return restaurant;
        }
    }
}

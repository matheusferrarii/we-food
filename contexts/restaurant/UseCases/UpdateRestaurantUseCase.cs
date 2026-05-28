using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;
using we_food.contexts.restaurant.ValueObjects;

namespace we_food.contexts.restaurant.UseCases
{
    public class UpdateRestaurantUseCase : IUpdateRestaurantUseCase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public UpdateRestaurantUseCase(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Restaurant> Run(Guid id, RestaurantUpdateDTO dto)
        {
            var restaurant = await _restaurantRepository.FindById(id);

            if (restaurant == null)
                throw new Exception("Restaurante não encontrado");

            restaurant.Update(
                new Name(dto.Name),
                new Description(dto.Description),
                new Phone(dto.Phone)
            );

            await _restaurantRepository.Update(restaurant);

            return restaurant;
        }
    }
}

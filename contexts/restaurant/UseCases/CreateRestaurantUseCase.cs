using we_food.contexts.restaurant.DTOS;
using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;
using we_food.contexts.restaurant.ValueObjects;

namespace we_food.contexts.restaurant.UseCases
{
    public class CreateRestaurantUseCase : ICreateRestaurantUseCase
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public CreateRestaurantUseCase(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<Restaurant> Run(RestaurantCreateDTO dto)
        {
            var restaurant = new Restaurant(
                new Name(dto.Name),
                new Description(dto.Description),
                new Phone(dto.Phone),
                new Address(dto.Address)
            );

            await _restaurantRepository.Save(restaurant);

            return restaurant;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;
using we_food.contexts.restaurant.ValueObjects;
using we_food.Data;

namespace we_food.contexts.restaurant.Repository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly Context _context;

        public RestaurantRepository(Context context)
        {
            _context = context;
        }

        public async Task Save(Restaurant restaurant)
        {
            var model = new Data.Model.Restaurant
            {
                Id = restaurant.Id,
                Name = restaurant.Name.Value,
                Description = restaurant.Description.Value,
                Phone = restaurant.Phone.Value,
                Adress = restaurant.Address.Value,
                IsOpen = restaurant.IsOpen,
                CreatedAt = restaurant.CreatedAt
            };

            await _context.Restaurants.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Restaurant restaurant)
        {
            var model = await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == restaurant.Id);

            if (model == null)
                throw new Exception("Restaurante não encontrado");

            model.Name = restaurant.Name.Value;
            model.Description = restaurant.Description.Value;
            model.Phone = restaurant.Phone.Value;
            model.Adress = restaurant.Address.Value;
            model.IsOpen = restaurant.IsOpen;

            await _context.SaveChangesAsync();
        }

        public async Task<Restaurant?> FindById(Guid id)
        {
            var model = await _context.Restaurants.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
                return null;

            return Map(model);
        }

        public async Task<List<Restaurant>> FindAll()
        {
            var models = await _context.Restaurants.AsNoTracking().ToListAsync();
            return models.Select(Map).ToList();
        }

        private static Restaurant Map(Data.Model.Restaurant model)
        {
            return new Restaurant(
                model.Id,
                new Name(model.Name),
                new Description(model.Description),
                new Phone(model.Phone),
                new Address(model.Adress),
                model.IsOpen,
                model.CreatedAt
            );
        }
    }
}

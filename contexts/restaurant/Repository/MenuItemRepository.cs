using Microsoft.EntityFrameworkCore;
using we_food.contexts.restaurant.Entities;
using we_food.contexts.restaurant.Interfaces;
using we_food.contexts.restaurant.ValueObjects;
using we_food.Data;

namespace we_food.contexts.restaurant.Repository
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly Context _context;

        public MenuItemRepository(Context context)
        {
            _context = context;
        }

        public async Task Save(MenuItem menuItem)
        {
            var model = new Data.Model.MenuItem
            {
                Id = menuItem.Id,
                RestaurantId = menuItem.RestaurantId,
                Name = menuItem.Name.Value,
                Description = menuItem.Description.Value,
                Price = menuItem.Price.Value,
                CreatedAt = menuItem.CreatedAt
            };

            await _context.MenuItems.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task Update(MenuItem menuItem)
        {
            var model = await _context.MenuItems.FirstOrDefaultAsync(x => x.Id == menuItem.Id);

            if (model == null)
                throw new Exception("Item do cardápio não encontrado");

            model.Name = menuItem.Name.Value;
            model.Description = menuItem.Description.Value;
            model.Price = menuItem.Price.Value;

            await _context.SaveChangesAsync();
        }

        public async Task<MenuItem?> FindById(Guid id)
        {
            var model = await _context.MenuItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return model == null ? null : Map(model);
        }

        public async Task<List<MenuItem>> FindAll()
        {
            var models = await _context.MenuItems.AsNoTracking().ToListAsync();
            return models.Select(Map).ToList();
        }

        public async Task<List<MenuItem>> FindByRestaurantId(Guid restaurantId)
        {
            var models = await _context.MenuItems
                .AsNoTracking()
                .Where(x => x.RestaurantId == restaurantId)
                .ToListAsync();

            return models.Select(Map).ToList();
        }

        private static MenuItem Map(Data.Model.MenuItem model)
        {
            return new MenuItem(
                model.Id,
                model.RestaurantId,
                new Name(model.Name),
                new Description(model.Description),
                new Money(model.Price),
                model.CreatedAt
            );
        }
    }
}

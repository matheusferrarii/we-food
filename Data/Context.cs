using Microsoft.EntityFrameworkCore;
using we_food.Data.Model;



namespace we_food.Data
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasKey(restaurant => restaurant.Id);

            modelBuilder.Entity<MenuItem>()
                .HasKey(menuItem => menuItem.Id);

            modelBuilder.Entity<Order>()
                .HasKey(order => order.Id);

            modelBuilder.Entity<OrderItem>()
                .HasKey(orderItem => orderItem.MenuItemId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

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
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(120);
                entity.Property(r => r.Adress).HasMaxLength(255);
                entity.Property(r => r.Description).HasMaxLength(500);
                entity.Property(r => r.Phone).HasMaxLength(20);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Name).IsRequired().HasMaxLength(120);
                entity.Property(m => m.Description).HasMaxLength(500);
                entity.Property(m => m.Price).HasColumnType("decimal(18,2)");
                entity.HasIndex(m => m.RestaurantId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.CustomerName).IsRequired().HasMaxLength(120);
                entity.Property(o => o.Status).IsRequired().HasMaxLength(30);
                entity.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");

                entity.HasMany(o => o.Items)
                    .WithOne()
                    .HasForeignKey(i => i.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(i => i.Subtotal).HasColumnType("decimal(18,2)");
                entity.HasIndex(i => i.OrderId);
                entity.HasIndex(i => i.MenuItemId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

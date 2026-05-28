using Microsoft.EntityFrameworkCore;
using we_food.contexts.order.Interfaces;
using we_food.contexts.order.Repository;
using we_food.contexts.order.UseCases;
using we_food.contexts.restaurant.Interfaces;
using we_food.contexts.restaurant.Repository;
using we_food.contexts.restaurant.UseCases;
using we_food.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<Context>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Repositories
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Restaurant use cases
builder.Services.AddScoped<ICreateRestaurantUseCase, CreateRestaurantUseCase>();
builder.Services.AddScoped<IGetRestaurantUseCase, GetRestaurantUseCase>();
builder.Services.AddScoped<IGetByIdRestaurantUseCase, GetByIdRestaurantUseCase>();
builder.Services.AddScoped<IUpdateRestaurantUseCase, UpdateRestaurantUseCase>();
builder.Services.AddScoped<IUpdateRestaurantStatusUseCase, UpdateRestaurantStatusUseCase>();
builder.Services.AddScoped<IGetByIdRestaurantMenuUseCase, GetByIdRestaurantMenuUseCase>();

// MenuItem use cases
builder.Services.AddScoped<ICreateMenuItemUseCase, CreateMenuItemUseCase>();
builder.Services.AddScoped<IGetMenuItemUseCase, GetMenuItemUseCase>();
builder.Services.AddScoped<IGetByIdMenuItemUseCase, GetByIdMenuItemUseCase>();
builder.Services.AddScoped<IUpdateMenuItemUseCase, UpdateMenuItemUseCase>();

// Order use cases
builder.Services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
builder.Services.AddScoped<IGetOrderUseCase, GetOrderUseCase>();
builder.Services.AddScoped<IGetByIdOrderUseCase, GetByIdOrderUseCase>();
builder.Services.AddScoped<IUpdateOrderStatusUseCase, UpdateOrderStatusUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

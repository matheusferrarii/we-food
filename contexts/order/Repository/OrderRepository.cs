using Microsoft.EntityFrameworkCore;
using we_food.contexts.order.Entities;
using we_food.contexts.order.Enums;
using we_food.contexts.order.Interfaces;
using we_food.contexts.order.ValueObjects;
using we_food.Data;

namespace we_food.contexts.order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;

        public OrderRepository(Context context)
        {
            _context = context;
        }

        public async Task Save(Order order)
        {
            var orderModel = new Data.Model.Order
            {
                Id = order.Id,

                CustomerName = order.CustomerName.Value,

                TotalAmount = order.TotalAmount.Value,

                Status = order.Status.ToString(),

                CreatedAt = order.CreatedAt,

                Items = order.Items.Select(item => new Data.Model.OrderItem
                {

                    MenuItemId = item.MenuItemId,

                    Quantity = item.Quantity.Value,

                    UnitPrice = item.UnitPrice.Value,

                    Subtotal = item.Subtotal.Value

                }).ToList()
            };

            await _context.Orders.AddAsync(orderModel);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Order order)
        {
            var orderModel = await _context.Orders
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == order.Id);

            if (orderModel == null)
                throw new Exception("Pedido não encontrado");

            orderModel.CustomerName = order.CustomerName.Value;

            orderModel.TotalAmount = order.TotalAmount.Value;

            orderModel.Status = order.Status.ToString();

            await _context.SaveChangesAsync();
        }

        public async Task<Order?> FindById(Guid id)
        {
            var orderModel = await _context.Orders
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (orderModel == null)
                return null;

            var items = orderModel.Items.Select(item =>
                new OrderItem(
                    item.MenuItemId,
                    new Quantity(item.Quantity),
                    new Money(item.UnitPrice)
                )
            ).ToList();

            var order = new Order(
                new CustomerName(orderModel.CustomerName),
                items
            );

            return order;
        }

        public async Task<List<Order>> FindAll()
        {
            var ordersModel = await _context.Orders
                .Include(x => x.Items)
                .ToListAsync();

            var orders = ordersModel.Select(orderModel =>
            {
                var items = orderModel.Items.Select(item =>
                    new OrderItem(
                        item.MenuItemId,
                        new Quantity(item.Quantity),
                        new Money(item.UnitPrice)
                    )
                ).ToList();

                return new Order(
                    new CustomerName(orderModel.CustomerName),
                    items
                );
            }).ToList();

            return orders;
        }
    }
}
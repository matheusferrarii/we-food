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
                    Id = item.Id,
                    OrderId = order.Id,
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
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefaultAsync(x => x.Id == id);

            return orderModel == null ? null : Map(orderModel);
        }

        public async Task<List<Order>> FindAll()
        {
            var ordersModel = await _context.Orders
                .AsNoTracking()
                .Include(x => x.Items)
                .ToListAsync();

            return ordersModel.Select(Map).ToList();
        }

        private static Order Map(Data.Model.Order model)
        {
            var items = model.Items.Select(item =>
                new OrderItem(
                    item.Id,
                    item.MenuItemId,
                    new Quantity(item.Quantity),
                    new Money(item.UnitPrice)
                )
            ).ToList();

            var status = Enum.TryParse<OrderStatus>(model.Status, out var parsed)
                ? parsed
                : OrderStatus.Pending;

            return new Order(
                model.Id,
                new CustomerName(model.CustomerName),
                items,
                status,
                model.CreatedAt
            );
        }
    }
}

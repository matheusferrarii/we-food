using we_food.contexts.order.DTOS;
using we_food.contexts.order.Entities;
using we_food.contexts.order.Interfaces;
using we_food.contexts.order.ValueObjects;
using we_food.contexts.restaurant.Interfaces;

namespace we_food.contexts.order.UseCases
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMenuItemRepository _menuItemRepository;

        public CreateOrderUseCase(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository)
        {
            _orderRepository = orderRepository;
            _menuItemRepository = menuItemRepository;
        }

        public async Task<Order> Run(CreateOrderDTO dto)
        {
            if (dto.Items == null || dto.Items.Count == 0)
                throw new Exception("Pedido precisa conter ao menos um item");

            var items = new List<OrderItem>();

            foreach (var itemDto in dto.Items)
            {
                var menuItem = await _menuItemRepository.FindById(itemDto.MenuItemId);

                if (menuItem == null)
                    throw new Exception($"Item do cardápio {itemDto.MenuItemId} não encontrado");

                items.Add(new OrderItem(
                    menuItem.Id,
                    new Quantity(itemDto.Quantity),
                    new Money(menuItem.Price.Value)
                ));
            }

            var order = new Order(new CustomerName(dto.CustomerName), items);

            await _orderRepository.Save(order);

            return order;
        }
    }
}

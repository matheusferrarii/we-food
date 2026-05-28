using we_food.contexts.order.DTOS;
using we_food.contexts.order.Entities;
using we_food.contexts.order.Enums;
using we_food.contexts.order.Interfaces;

namespace we_food.contexts.order.UseCases
{
    public class UpdateOrderStatusUseCase : IUpdateOrderStatusUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderStatusUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Run(Guid id, UpdateOrderStatusDTO dto)
        {
            var order = await _orderRepository.FindById(id);

            if (order == null)
                throw new Exception("Pedido não encontrado");

            if (!Enum.IsDefined(typeof(OrderStatus), dto.Status))
                throw new Exception("Status inválido");

            order.ChangeStatus((OrderStatus)dto.Status);

            await _orderRepository.Update(order);

            return order;
        }
    }
}

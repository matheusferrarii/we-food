using we_food.contexts.order.Entities;
using we_food.contexts.order.Interfaces;

namespace we_food.contexts.order.UseCases
{
    public class GetByIdOrderUseCase : IGetByIdOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetByIdOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Run(Guid id)
        {
            var order = await _orderRepository.FindById(id);

            if (order == null)
                throw new Exception("Pedido não encontrado");

            return order;
        }
    }
}

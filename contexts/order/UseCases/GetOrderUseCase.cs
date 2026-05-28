using we_food.contexts.order.Entities;
using we_food.contexts.order.Interfaces;

namespace we_food.contexts.order.UseCases
{
    public class GetOrderUseCase : IGetOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> Run()
        {
            return await _orderRepository.FindAll();
        }
    }
}

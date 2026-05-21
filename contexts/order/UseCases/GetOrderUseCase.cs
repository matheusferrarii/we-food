using we_food.contexts.order.Interfaces;

namespace we_food.contexts.order.UseCases
{
    public class GetOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<string> Run()
        {
        }
    }
}

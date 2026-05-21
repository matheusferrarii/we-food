using we_food.contexts.order.Interfaces;

namespace we_food.contexts.order.UseCases
{
    public class GetByIdOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;

        public GetByIdOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<string> Run(Guid id)
        {

        }
    }
}

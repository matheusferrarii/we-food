using we_food.contexts.order.Interfaces;

namespace we_food.contexts.order.UseCases
{
    public class UpdateOrderStatusUseCase
    {
        private readonly IOrderRepository _orderRepository;
    
        public UpdateOrderStatusUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<string> Run(Guid id, string status)
        {
        }
    }
}

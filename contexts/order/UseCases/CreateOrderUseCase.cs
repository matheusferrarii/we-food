using we_food.contexts.order.Interfaces;

namespace we_food.contexts.order.UseCases
{
    public class CreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        public CreateOrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<string> Run(DTOS.CreateOrderDTO dto)
        {

        }

    }
}

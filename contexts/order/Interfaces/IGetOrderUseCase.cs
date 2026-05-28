using we_food.contexts.order.Entities;

namespace we_food.contexts.order.Interfaces
{
    public interface IGetOrderUseCase
    {
        Task<IEnumerable<Order>> Run();
    }
}

using we_food.Data.Model;

namespace we_food.contexts.order.Interfaces
{
    public interface IGetOrderUseCase
    {
        Task<IEnumerable<Order>> Run();
    }
}

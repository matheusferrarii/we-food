using we_food.contexts.order.Entities;

namespace we_food.contexts.order.Interfaces
{
    public interface IOrderRepository
    {
        Task Save(Order order);

        Task Update(Order order);

        Task<Order?> FindById(Guid id);

        Task<List<Order>> FindAll();
    }
}

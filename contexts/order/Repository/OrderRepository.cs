using we_food.contexts.order.Entities;
using we_food.contexts.order.Interfaces;

namespace we_food.contexts.order.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public Task Save(Order order)
        {
            throw new NotImplementedException();
        }

        public Task Update(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<Order?> FindById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> FindAll()
        {
            throw new NotImplementedException();
        }
    }
}

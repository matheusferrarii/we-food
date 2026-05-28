using we_food.contexts.order.Entities;

namespace we_food.contexts.order.Interfaces
{
    public interface IGetByIdOrderUseCase
    {
        Task<Order> Run(Guid id);
    }
}

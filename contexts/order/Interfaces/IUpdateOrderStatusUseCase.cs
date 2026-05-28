using we_food.contexts.order.DTOS;
using we_food.contexts.order.Entities;

namespace we_food.contexts.order.Interfaces
{
    public interface IUpdateOrderStatusUseCase
    {
        Task<Order> Run(Guid id, UpdateOrderStatusDTO dto);
    }
}

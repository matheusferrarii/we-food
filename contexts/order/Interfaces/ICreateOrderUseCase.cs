using we_food.contexts.order.DTOS;
using we_food.contexts.order.Entities;

namespace we_food.contexts.order.Interfaces
{
    public interface ICreateOrderUseCase
    {
        Task<Order> Run(CreateOrderDTO dto);
    }
}

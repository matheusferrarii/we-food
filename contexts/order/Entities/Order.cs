using we_food.contexts.order.Enums;
using we_food.contexts.order.ValueObjects;

namespace we_food.contexts.order.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }

        public CustomerName CustomerName { get; private set; }

        public Money TotalAmount { get; private set; }

        public List<OrderItem> Items { get; private set; }

        public OrderStatus Status { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Order(CustomerName customerName, List<OrderItem> items)
        {
            if (items == null || items.Count == 0)
                throw new Exception("Pedido não pode ser vazio");

            Id = Guid.NewGuid();

            CustomerName = customerName;

            Items = items;

            Status = OrderStatus.Pending;

            CreatedAt = DateTime.UtcNow;

            CalculateTotal();
        }

        private void CalculateTotal()
        {
            var total = Items.Sum(x => x.Subtotal.Value);

            TotalAmount = new Money(total);
        }

        public void Cancel()
        {
            if (Status != OrderStatus.Pending)
                throw new Exception("Apenas pedidos pendentes podem ser cancelados");
            Status = OrderStatus.Canceled;
        }

        public void Prepare()
        {
            if (Status != OrderStatus.Pending)
                throw new Exception("Pedido precisa estar pendente");

            Status = OrderStatus.Preparing;
        }

        public void Dispatch()
        {
            if (Status != OrderStatus.Preparing)
                throw new Exception("Pedido precisa estar em preparo");

            Status = OrderStatus.OutForDelivery;
        }

        public void Deliver()
        {
            if (Status != OrderStatus.OutForDelivery)
                throw new Exception("Pedido não saiu para entrega");

            Status = OrderStatus.Delivered;
        }
    }
}

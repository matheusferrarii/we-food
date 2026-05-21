namespace we_food.contexts.order.ValueObjects
{
    public class Quantity
    {
        public int Value { get; }

        public Quantity(int value)
        {
            if (value <= 0)
                throw new Exception("Quantidade deve ser maior que zero");

            if (value > 100)
                throw new Exception("Quantidade máxima permitida é 100");

            this.Value = value;
        }

    }
}

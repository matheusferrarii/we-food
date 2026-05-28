namespace we_food.contexts.restaurant.ValueObjects
{
    public class Money
    {
        public decimal Value { get; }

        public Money(decimal value)
        {
            if (value < 0)
                throw new Exception("Valor inválido");

            this.Value = value;
        }
    }
}

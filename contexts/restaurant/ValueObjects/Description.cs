namespace we_food.contexts.restaurant.ValueObjects
{
    public class Description
    {
        public string Value { get; }
        public Description(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Descrição inválida");
            if (value.Length < 5)
                throw new Exception("Descrição deve conter no mínimo 5 caracteres");
            this.Value = value;
        }
    }
}

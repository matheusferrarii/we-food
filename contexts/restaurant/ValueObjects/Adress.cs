namespace we_food.contexts.restaurant.ValueObjects
{
    public class Address
    {
        public string Value { get; }

        public Address(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Endereço inválido");
            if (value.Length < 5)
                throw new Exception("Endereço deve conter pelo menos 5 caracteres");
            this.Value = value.Trim();
        }
    }
}

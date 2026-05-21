namespace we_food.contexts.restaurant.ValueObjects
{
    public class Name
    {
        public string Value { get; }
        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Nome inválido");
            if (value.Length < 3)
                throw new Exception("Nome deve conter pelo menos 3 caracteres");
            this.Value = value;
        }
    }
}

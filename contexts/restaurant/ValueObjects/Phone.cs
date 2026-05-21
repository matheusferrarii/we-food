namespace we_food.contexts.restaurant.ValueObjects
{
    public class Phone
    {
        public string Value { get; }

        public Phone(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Telefone inválido");

            if (value.Length < 8 || value.Length > 15)
                throw new Exception("Telefone deve conter entre 8 e 15 caracteres");

            this.Value = value.Trim();
        }
    }
}

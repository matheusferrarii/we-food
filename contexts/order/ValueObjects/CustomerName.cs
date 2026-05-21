namespace we_food.contexts.order.ValueObjects
{
    public class CustomerName
    {
        public string Value { get; }

        public CustomerName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Exception("Nome do cliente é obrigatório");

            if (value.Length < 3)
                throw new Exception("Nome do cliente inválido");

            this.Value = value.Trim();
        }
    }
}

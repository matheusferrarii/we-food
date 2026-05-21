using System.Numerics;
using we_food.contexts.restaurant.ValueObjects;

namespace we_food.contexts.restaurant.Entities
{
    public class Restaurant
    {
        public Guid Id { get; private set; }

        public Name Name { get; private set; }

        public Description Description { get; private set; }

        public Phone Phone { get; private set; }

        public bool IsOpen { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Restaurant(Name name, Description description, Phone phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Phone = phone;
            IsOpen = false;
            CreatedAt = DateTime.UtcNow;
        }

        public void Open()
        {
            if (IsOpen)
                throw new Exception("Restaurante já está aberto");
            IsOpen = true;
        }

        public void Close()
        {
            if (!IsOpen)
                throw new Exception("Restaurante já está fechado");
            IsOpen = false;
        }


    }
}

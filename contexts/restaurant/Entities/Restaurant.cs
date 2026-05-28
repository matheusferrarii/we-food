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

        public Restaurant(Guid id, Name name, Description description, Phone phone, bool isOpen, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Description = description;
            Phone = phone;
            IsOpen = isOpen;
            CreatedAt = createdAt;
        }

        public void Update(Name name, Description description, Phone phone)
        {
            Name = name;
            Description = description;
            Phone = phone;
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

        public void SetStatus(bool isOpen)
        {
            if (isOpen) Open(); else Close();
        }
    }
}

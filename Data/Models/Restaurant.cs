namespace we_food.Data.Model
{
    public class Restaurant
    {
        public Guid Id { get;  set; }

        public string Name { get;  set; }
        public string Adress { get;  set; }

        public string Description { get;  set; }

        public string Phone { get;  set; }

        public bool IsOpen { get;  set; }

        public DateTime CreatedAt { get;  set; }
    }
}

namespace we_food.contexts.restaurant.DTOS
{
    public class MenuItemCreateDTO
    {
        public Guid RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}

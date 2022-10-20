namespace Free_API.Models.DAO
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public List<Allergen> allergens { get; set; } = new List<Allergen>();
    }
}

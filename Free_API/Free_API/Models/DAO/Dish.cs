using System.ComponentModel.DataAnnotations.Schema;

namespace Free_API.Models.DAO
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public double price { get; set; }
        public string description { get; set; } = String.Empty;
        public List<Allergen> allergens { get; set; } = new List<Allergen>();
        public Category category { get; set; }
    }
}

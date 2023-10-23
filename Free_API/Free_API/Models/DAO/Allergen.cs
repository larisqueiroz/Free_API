using System.ComponentModel.DataAnnotations.Schema;

namespace Free_API.Models.DAO
{
    public class Allergen
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public List<Dish> dishes { get; set; } = new List<Dish>();
    }
}

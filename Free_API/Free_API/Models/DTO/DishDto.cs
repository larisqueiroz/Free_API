using System.Text.Json.Serialization;

namespace Free_API.Models.DTO
{
    public class DishDto
    {
        public string Name { get; set; } = String.Empty;
        public double price { get; set; }
        public string description { get; set; } = String.Empty;
        public List<AllergenDto>? allergens { get; set; } = new List<AllergenDto>();
        public CategoryDto category { get; set; }
    }
}

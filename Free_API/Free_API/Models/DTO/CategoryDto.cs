namespace Free_API.Models.DTO
{
    public class CategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public List<DishDto> dishes { get; set; } = new List<DishDto>();
    }
}

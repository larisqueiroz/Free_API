using Free_API.Models.DTO;

namespace Free_API.Models.DTO
{
    public class MenuDto
    {
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public List<CategoryDto> categories { get; set; } = new List<CategoryDto>();
    }
}

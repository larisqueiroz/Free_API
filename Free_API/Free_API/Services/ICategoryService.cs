using Free_API.Models.DAO;
using Free_API.Models.DTO;

namespace Free_API.Services;

public interface ICategoryService
{
    public List<CategoryDto> getAllCategories();
    public CategoryDto getCategoryById(int id);
    public CategoryDto SaveCategory(CategoryDto menu);
    public CategoryDto UpdateCategory(CategoryDto menu, int id);
    public CategoryDto DeleteCategory(int id);
}
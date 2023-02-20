using Free_API.Models.DAO;
using Free_API.Models.DTO;

namespace Free_API.Services;

public interface IMenuService
{
    public List<MenuDto> getAllMenus();
    public MenuDto getMenuById(int id);
    
}
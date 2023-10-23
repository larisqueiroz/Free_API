using Free_API.Models.DTO;

namespace Free_API.Services;

public interface IDishService
{
    public List<DishDto> getAllDishes();
    public DishDto getDishById(int id);
    public DishDto SaveDish(DishDto menu);
    public DishDto UpdateDish(DishDto menu, int id);
    public DishDto DeleteDish(int id);
}
namespace Free_API.Models.DAO;

public class AllergenDish
{
    public int AllergenId { get; set; }
    public Allergen Allergen { get; set; }
    public int DishId { get; set; }
    public Dish Dish { get; set; }

    public AllergenDish(int allergenId, int dishId)
    {
        AllergenId = allergenId;
        DishId = dishId;
    }
}
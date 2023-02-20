using Free_API.Models.DAO;

namespace Free_API.Repositories;

public interface IDishRepository
{
    public List<Dish> GetAll();
    public Dish GetById(int id);
    public Dish Save(Dish menu);
    public Dish Update(Dish menu);
    public Dish Delete(Dish menu);
}
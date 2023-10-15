using Free_API.Models.DAO;

namespace Free_API.Repositories;

public interface ICategoryRepository
{
    public List<Category> GetAll();
    public Category GetById(int id);
    public Category Save(Category category);
    public Category Update(Category category);
    public Category Delete(Category category);
    public Category GetByName(string name);
}
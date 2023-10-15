using Free_API.Models.DAO;

namespace Free_API.Repositories;

public interface IAllergenRepository
{
    public List<Allergen> GetAll();
    public Allergen GetById(int id);
    public Allergen Save(Allergen category);
    public Allergen Update(Allergen category);
    public Allergen Delete(Allergen category);
    public Allergen GetByName(string name);
}
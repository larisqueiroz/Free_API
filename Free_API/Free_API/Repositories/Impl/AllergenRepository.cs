using Free_API;
using Free_API.Data;
using Free_API.Models.DAO;
using Free_API.Models.DTO;

namespace Free_API.Repositories;

public class AllergenRepository : IAllergenRepository
{
    public readonly FreeAPIContext _allergenRepository;
    
    public AllergenRepository(FreeAPIContext allergenRepository)
    {
        _allergenRepository = allergenRepository;
    }
    
    public List<Allergen> GetAll()
    {
        return _allergenRepository.Allergens.ToList();
    }

    public Allergen GetById(int id)
    {
        return _allergenRepository.Allergens.Where(a => a.Id == id).FirstOrDefault();
    }

    public Allergen Save(Allergen allergen)
    {
        _allergenRepository.Allergens.Add(allergen);
        _allergenRepository.SaveChanges();
        return allergen;
    }
    
    public Allergen Update(Allergen allergen)
    {
        _allergenRepository.Allergens.Update(allergen);
        _allergenRepository.SaveChanges();
        return allergen;
    }
    
    public Allergen Delete(Allergen allergen)
    {
        _allergenRepository.Allergens.Remove(allergen);
        _allergenRepository.SaveChanges();
        return allergen;
    }
}
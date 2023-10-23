using Free_API.Models.DTO;

namespace Free_API.Services;

public interface IAllergenService
{
    public List<AllergenDto> getAllAllergens();
    public AllergenDto getAllergenById(int id);
    public AllergenDto SaveAllergen(AllergenDto menu);
    public AllergenDto UpdateAllergen(AllergenDto menu, int id);
    public AllergenDto DeleteAllergen(int id);
    public AllergenDto getAllergenByName(string name);
}
using Free_API.Repositories;
using Free_API.Models.DAO;
using AutoMapper;
using Free_API.Models.DTO;

namespace Free_API.Services.Impl;

public class AllergenService : IAllergenService
{
    public readonly IAllergenRepository _allergenRepository;
    public readonly IMapper _mapper;
    
    public AllergenService(IAllergenRepository allergenRepository, IMapper mapper)
    {
        _allergenRepository = allergenRepository;
        _mapper = mapper;
    }
    
    public List<AllergenDto> getAllAllergens()
    {
        var categories = _allergenRepository.GetAll();
        return _mapper.Map<List<Allergen>, List<AllergenDto>>(categories);
    }
    
    public AllergenDto getAllergenById(int id)
    {
        var allergen = _allergenRepository.GetById(id);
        return _mapper.Map<Allergen, AllergenDto>(allergen);
    }
    
    public AllergenDto getAllergenByName(string name)
    {
        var allergen = _allergenRepository.GetByName(name);
        return _mapper.Map<Allergen, AllergenDto>(allergen);
    }

    public AllergenDto SaveAllergen(AllergenDto allergen)
    {
        var allergenDao = _mapper.Map<Allergen>(allergen);
        return _mapper.Map<AllergenDto>(_allergenRepository.Save(allergenDao));
    }

    public AllergenDto UpdateAllergen(AllergenDto allergen, int id)
    {
        var allergenData = _mapper.Map<Allergen>(allergen);
        var allergenSaved = _allergenRepository.GetById(id);
        if (allergenSaved == null)
        {
            throw new BadHttpRequestException("Alergenico não encontrada");
        }

        allergenSaved.dishes = allergenData.dishes;
        allergenSaved.Name = allergenData.Name;

        var allergenUpdated = _allergenRepository.Update(allergenSaved);

        return _mapper.Map<AllergenDto>(allergenUpdated);
    }
    
    public AllergenDto DeleteAllergen(int id)
    {
        var allergenSaved = _allergenRepository.GetById(id);
        if (allergenSaved == null)
        {
            throw new BadHttpRequestException("Alergenico não encontrado");
        }
        return _mapper.Map<AllergenDto>(_allergenRepository.Delete(allergenSaved));
    }
}
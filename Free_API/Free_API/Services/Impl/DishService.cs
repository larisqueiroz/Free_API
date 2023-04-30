using AutoMapper;
using Free_API.Repositories;
using Free_API.Models.DAO;
using Free_API.Models.DTO;
using BadHttpRequestException = Microsoft.AspNetCore.Http.BadHttpRequestException;

namespace Free_API.Services.Impl;

public class DishService : IDishService
{
    public readonly IDishRepository _dishRepository;
    public readonly IMapper _mapper;
    
    public DishService(IDishRepository dishRepository, IMapper mapper)
    {
        _dishRepository = dishRepository;
        _mapper = mapper;
    }
    
    public List<DishDto> getAllDishes()
    {
        var dishes = _dishRepository.GetAll();
        return _mapper.Map<List<Dish>, List<DishDto>>(dishes);
    }
    
    public DishDto getDishById(int id)
    {
        var dish = _dishRepository.GetById(id);
        return _mapper.Map<Dish, DishDto>(dish);
    }

    public DishDto SaveDish(DishDto dish)
    {
        var dishDao = _mapper.Map<Dish>(dish);
        return _mapper.Map<DishDto>(_dishRepository.Save(dishDao));
    }

    public DishDto UpdateDish(DishDto dish, int id)
    {
        var dishData = _mapper.Map<Dish>(dish);
        var dishSaved = _dishRepository.GetById(id);
        if (dishSaved == null)
        {
            throw new BadHttpRequestException("Prato não encontrado");
        }

        dishSaved.price = dishData.price;
        dishSaved.Name = dishData.Name;
        dishSaved.allergens = dishData.allergens;
        dishSaved.description = dishData.description;
        
        var dishUpdated = _dishRepository.Update(dishSaved);

        return _mapper.Map<DishDto>(dishUpdated);
    }
    
    public DishDto DeleteDish(int id)
    {
        var dishSaved = _dishRepository.GetById(id);
        if (dishSaved == null)
        {
            throw new BadHttpRequestException("Prato não encontrado");
        }
        return _mapper.Map<DishDto>(_dishRepository.Delete(dishSaved));
    }
}
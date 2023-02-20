﻿using Free_API.Models.DAO;
using Free_API.Models.DTO;
using AutoMapper;
using Free_API.Data;

namespace Free_API.Repositories;

public class DishRepository : IDishRepository
{
    public readonly FreeAPIContext _dishRepository;
    
    public DishRepository(FreeAPIContext dishRepository)
    {
        _dishRepository = dishRepository;
    }
    
    public List<Dish> GetAll()
    {
        return _dishRepository.Dishes.ToList();
    }

    public Dish GetById(int id)
    {
        return _dishRepository.Dishes.Where(m => m.Id == id).FirstOrDefault();
    }

    public Dish Save(Dish dish)
    {
        _dishRepository.Dishes.Add(dish);
        _dishRepository.SaveChanges();
        return dish;
    }
    
    public Dish Update(Dish dish)
    {
        _dishRepository.Dishes.Update(dish);
        _dishRepository.SaveChanges();
        return dish;
    }
    
    public Dish Delete(Dish dish)
    {
        _dishRepository.Dishes.Remove(dish);
        _dishRepository.SaveChanges();
        return dish;
    }
}
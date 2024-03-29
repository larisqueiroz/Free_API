﻿using AutoMapper;
using Free_API.Models.DAO;
using Free_API.Models.DTO;

namespace Free_API.Utils;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Allergen, AllergenDto>();
        CreateMap<AllergenDto, Allergen>();
        
        CreateMap<Dish, DishDto>();
        CreateMap<DishDto, Dish>();
        
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
    }
}
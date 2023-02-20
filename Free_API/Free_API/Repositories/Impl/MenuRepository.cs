using AutoMapper;
using Free_API.Data;
using Free_API.Models.DAO;
using Free_API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel;

namespace Free_API.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly FreeAPIContext _menuRepository;

    public MenuRepository(FreeAPIContext menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public List<Menu> GetAll()
    {
        return _menuRepository.Menus.ToList();
    }

    public Menu GetById(int id)
    {
        return _menuRepository.Menus.Where(m => m.Id == id).FirstOrDefault();
    }

    public Menu Save(Menu menu)
    {
        _menuRepository.Menus.Add(menu);
        _menuRepository.SaveChanges();
        return menu;
    }
    
    public Menu Update(Menu menu)
    {
        _menuRepository.Menus.Update(menu);
        _menuRepository.SaveChanges();
        return menu;
    }
    
    public Menu Delete(int id)
    {
        var savedMenu = _menuRepository.Menus.Where(m => m.Id == id).FirstOrDefault();
        if (savedMenu == null)
        {
            throw new Exception("Menu não encontrado");
        }

        _menuRepository.Menus.Remove(savedMenu);
        _menuRepository.SaveChanges();
        return savedMenu;
    }
}
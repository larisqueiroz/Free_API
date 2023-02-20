using Free_API.Models.DAO;
using Free_API.Models.DTO;
using Free_API.Repositories;
using AutoMapper;

namespace Free_API.Services.Impl;

public class MenuService : IMenuService
{
    public readonly IMapper _mapper;
    public readonly IMenuRepository _menuRepository;
    
    public MenuService(IMapper mapper, IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
        _mapper = mapper;
    }

    public List<MenuDto> getAllMenus()
    {
        var menus = _menuRepository.GetAll();
        return _mapper.Map<List<Menu>, List<MenuDto>>(menus);
    }
    
    public MenuDto getMenuById(int id)
    {
        var menu = _menuRepository.GetById(id);
        return _mapper.Map<Menu, MenuDto>(menu);
    }

    public MenuDto SaveMenu(MenuDto menu)
    {
        var menuDao = _mapper.Map<Menu>(menu);
        return _mapper.Map<MenuDto>(_menuRepository.Save(menuDao));
    }

    public MenuDto UpdateMenu(MenuDto menu, int id)
    {
        var menuData = _mapper.Map<Menu>(menu);
        var menuSaved = _menuRepository.GetById(id);
        if (menuSaved == null)
        {
            throw new Exception("Menu não encontrado");
        }

        menuSaved.categories = menuData.categories;
        menuSaved.Description = menuData.Description;
        menuSaved.Name = menuData.Name;
        
        var menuUpdated = _menuRepository.Update(menuSaved);

        return _mapper.Map<MenuDto>(menuUpdated);
    }
    
    public MenuDto DeleteMenu(int id)
    {
        var menuSaved = _menuRepository.GetById(id);
        if (menuSaved == null)
        {
            throw new Exception("Menu não encontrado");
        }
        return _mapper.Map<MenuDto>(_menuRepository.Delete(menuSaved));
    }
}
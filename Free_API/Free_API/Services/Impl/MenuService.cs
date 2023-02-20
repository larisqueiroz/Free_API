using Free_API.Models.DAO;
using Free_API.Models.DTO;
using Free_API.Repositories;
using AutoMapper;

namespace Free_API.Services.Impl;

public class MenuService : IMenuService
{
    public readonly IMenuService _menuService;
    public readonly IMapper _mapper;
    public readonly IMenuRepository _menuRepository;
    
    public MenuService(IMenuService menuService, IMapper mapper, IMenuRepository menuRepository)
    {
        _menuService = menuService;
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
}
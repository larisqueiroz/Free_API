using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Free_API.Services;
using Free_API.Models.DAO;
using Free_API.Models.DTO;

namespace Free_API.Controllers
{
    [ApiController]
    [Route("menus")]
    public class MenuController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMenuService _menuService;

        public MenuController(IMapper mapper, IMenuService menuService)
        {
            _mapper = mapper;
            _menuService = menuService;
        }
        
        /*private List<Category> categories = new List<Category>()
        {
           new Category()
           {
               Id = 1,
               Name = "Salads",
               dishes = new List<Dish>()
               {
                   new Dish()
                   {
                       Id = 1,
                       price = 35,
                       Name = "Caesar Salad",
                       description = "A salad prepared with romaine lettuce, cheese, Caesar sauce and croutons.",
                       allergens = new List<Allergen>()
                       {
                           new Allergen()
                           {
                               Id = 1,
                               Name = "Gluten"
                           }
                       }
                   }
               }
           },

           new Category()
           {
               Id = 2,
               Name = "Starters",
               dishes = new List<Dish>()
               {
                   new Dish()
                   {
                       Id = 1,
                       price = 25,
                       Name = "French Fries with bacon and cheddar cheese",
                       description = "Delicious wavy french fries.",
                       allergens = { }
                   }
               }
           },
        };*/
        [HttpGet]
        public ActionResult<List<Menu>> GetAll()
        {
            return Ok(_menuService.getAllMenus());
        }

        [HttpGet("by_id")]
        public ActionResult<Menu> GetbyId(int id)
        {
            var menu = _menuService.getMenuById(id);
            if (menu == null)
            {
                return BadRequest("Menu not found.");

            }
            return Ok(menu);
        }

        [HttpPost]
        public ActionResult<Menu> Post([FromBody] MenuDto menu)
        {
            var savedMenu = _menuService.SaveMenu(menu);
            return Ok(savedMenu);
        }

        [HttpPut]
        public ActionResult<Menu> Put(MenuDto menu, [FromQuery] int id)
        {
            return Ok(_menuService.UpdateMenu(menu, id));
        }

        [HttpDelete]
        public ActionResult<Menu> Delete(int id)
        {
            var deleted = _menuService.DeleteMenu(id);

            return Ok(deleted);
        }
    }
}

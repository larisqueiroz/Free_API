using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Free_API.Models.DAO;
using Free_API.Models.DTO;
using Free_API.Models.DTO.Pagination;
using Free_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Free_API.Controllers;

[ApiController]
[Route("dishes")]
public class DishController: ControllerBase
{
    public readonly IMapper _mapper;
    public readonly IDishService _dishService;

    public DishController(IMapper mapper, IDishService dishService)
    {
        _mapper = mapper;
        _dishService = dishService;
    }
    
    [HttpGet]
    public ActionResult<List<DishDto>> GetAll([FromQuery] int page, bool order, string? keyword)
    {
        var paged = new PagedResult<DishDto>();
        paged.PagedSearch(page, _dishService.getAllDishes(), keyword,2f, order);
        return Ok(paged);
    }

    [HttpGet("{id}")]
    public ActionResult<DishDto> GetbyId([FromRoute] int id)
    {
        var dish = _dishService.getDishById(id);
        if (dish == null)
        {
            return BadRequest("Dish not found.");

        }
        return Ok(dish);
    }

    [Authorize(Policy = "Operators")]
    [HttpPost]
    public ActionResult<DishDto> Post([FromBody] DishDto dish)
    {
        var savedDish = _dishService.SaveDish(dish);
        return Ok(savedDish);
    }

    [Authorize(Policy = "Operators")]
    [HttpPut]
    public ActionResult<DishDto> Put(DishDto dish, [FromQuery] int id)
    {
        return Ok(_dishService.UpdateDish(dish, id));
    }

    [Authorize(Policy = "Operators")]
    [HttpDelete("{id}")]
    public ActionResult<DishDto> Delete([FromRoute] int id)
    {
        var deleted = _dishService.DeleteDish(id);

        return Ok(deleted);
    }
}
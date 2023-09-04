using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Free_API.Models.DAO;
using Free_API.Models.DTO;
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
    public ActionResult<List<Dish>> GetAll()
    {
        return Ok(_dishService.getAllDishes());
    }

    [HttpGet("{id}")]
    public ActionResult<Dish> GetbyId([FromRoute] int id)
    {
        var dish = _dishService.getDishById(id);
        if (dish == null)
        {
            return BadRequest("Dish not found.");

        }
        return Ok(dish);
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Dish> Post([FromBody] DishDto dish)
    {
        var savedDish = _dishService.SaveDish(dish);
        return Ok(savedDish);
    }

    [Authorize]
    [HttpPut]
    public ActionResult<Dish> Put(DishDto dish, [FromQuery] int id)
    {
        return Ok(_dishService.UpdateDish(dish, id));
    }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<Dish> Delete([FromRoute] int id)
    {
        var deleted = _dishService.DeleteDish(id);

        return Ok(deleted);
    }
}
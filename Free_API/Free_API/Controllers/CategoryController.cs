using Microsoft.AspNetCore.Mvc;
using Free_API.Models.DAO;
using Free_API.Models.DTO;
using AutoMapper;
using Free_API.Models.DTO.Pagination;
using Free_API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Free_API.Controllers;

[ApiController]
[Route("categories")]
public class CategoryController: ControllerBase
{
    public readonly IMapper _mapper;
    public readonly ICategoryService _categoryService;

    public CategoryController(IMapper mapper, ICategoryService categoryService)
    {
        _mapper = mapper;
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public ActionResult<PagedResult<CategoryDto>> GetAll([FromQuery] int page, bool order, string? keyword)
    {
        var paged = new PagedResult<CategoryDto>();
        paged.PagedSearch(page, _categoryService.getAllCategories(), keyword,2f, order);
        return Ok(paged);
    }

    [HttpGet("{id}")]
    public ActionResult<CategoryDto> GetbyId([FromRoute] int id)
    {
        var category = _categoryService.getCategoryById(id);
        if (category == null)
        {
            return BadRequest("Category not found.");

        }
        return Ok(category);
    }

    [Authorize(Policy = "Operators")]
    [HttpPost]
    public ActionResult<Category> Post([FromBody] CategoryDto category)
    {
        var savedCategory = _categoryService.SaveCategory(category);
        return Ok(savedCategory);
    }

    [Authorize(Policy = "Operators")]
    [HttpPut]
    public ActionResult<Category> Put(CategoryDto category, [FromQuery] int id)
    {
        return Ok(_categoryService.UpdateCategory(category, id));
    }

    [Authorize(Policy = "Operators")]
    [HttpDelete("{id}")]
    public ActionResult<CategoryDto> Delete([FromRoute] int id)
    {
        var deleted = _categoryService.DeleteCategory(id);

        return Ok(deleted);
    }
}
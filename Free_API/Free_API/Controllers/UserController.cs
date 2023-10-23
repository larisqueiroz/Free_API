using AutoMapper;
using Free_API.Models.DTO;
using Free_API.Models.DAO;
using Free_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Free_API.Enums;
using Free_API.Models.DTO.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Extensions;

namespace Free_API.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    public readonly IMapper _mapper;
    public readonly IUserService _userService;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Save(UserDto user)
    {
        var saved = _userService.SaveUser(user);

        return saved;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(UserDto request)
    {
        return _userService.Login(request);
    }
    
    [Authorize(Policy = "Administrator")]
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll([FromQuery] int page, bool order, string? keyword)
    {
        var paged = new PagedResult<UserDto>();
        paged.PagedSearch(page, _userService.getAllUsers(), keyword,4f, order);
        return Ok(paged);
    }
    
    [Authorize(Policy = "Administrator")]
    [HttpPut]
    public ActionResult<UserDto> Put(UserDto user, [FromQuery] string email)
    {
        return Ok(_userService.UpdateUser(user, email));
    }

    [Authorize(Policy = "Administrator")]
    [HttpDelete("{id}")]
    public ActionResult<UserDto> Delete([FromRoute] string email)
    {
        var deleted = _userService.DeleteUser(email);

        return Ok(deleted);
    }
}
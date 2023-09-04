using AutoMapper;
using Free_API.Models.DTO;
using Free_API.Models.DAO;
using Free_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Free_API.Enums;
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
    
    [Authorize(Roles = "3")]
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        return _userService.getAllUsers();
    }
}
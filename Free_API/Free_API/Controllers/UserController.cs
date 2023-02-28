using AutoMapper;
using Free_API.Models.DTO;
using Free_API.Models.DAO;
using Free_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

    /*[HttpPost("login")]
    public async Task<ActionResult<User>> Login(UserDto user)
    {
        
    }*/
}
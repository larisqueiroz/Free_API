using AutoMapper;
using Free_API.Repositories;
using Free_API.Models.DAO;
using Free_API.Models.DTO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Free_API.Services.Impl;

public class UserService : IUserService
{
    public readonly IUserRepository _userRepository;
    public readonly IMapper _mapper;
    
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
    
    public List<UserDto> getAllUsers()
    {
        var users = _userRepository.GetAll();
        return _mapper.Map<List<User>, List<UserDto>>(users);
    }
    
    public UserDto getUserByEmail(string email)
    {
        var user = _userRepository.GetByEmail(email);
        return _mapper.Map<User, UserDto>(user);
    }

    public UserDto SaveUser(UserDto user)
    {
        var userDao = _mapper.Map<User>(user);

        var userExists = _userRepository.GetByEmail(user.Email);
        if (userExists != null)
        {
            throw new BadHttpRequestException("Email already exists.");
        }
        
        CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

        userDao.Email = user.Email;
        userDao.Hash = passwordHash;
        userDao.Salt = passwordSalt;
        return _mapper.Map<UserDto>(_userRepository.Save(userDao));
    }

    /*public async Task<ActionResult<string>> Login(User user)
    {
        
    }*/

    public UserDto UpdateUser(UserDto user, string email)
    {
        var userData = _mapper.Map<User>(user);
        var userSaved = _userRepository.GetByEmail(email);
        if (userSaved == null)
        {
            throw new Exception("Usuario não encontrado");
        }

        userSaved.Email = userData.Email;
        userSaved.Name = userData.Name;

        var userUpdated = _userRepository.Update(userSaved);

        return _mapper.Map<UserDto>(userUpdated);
    }
    
    public UserDto DeleteUser(string email)
    {
        var userSaved = _userRepository.GetByEmail(email);
        if (userSaved == null)
        {
            throw new Exception("Usuario não encontrado");
        }
        return _mapper.Map<UserDto>(_userRepository.Delete(userSaved));
    }
}
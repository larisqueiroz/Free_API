using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Free_API.Repositories;
using Free_API.Models.DAO;
using Free_API.Models.DTO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using BadHttpRequestException = Microsoft.AspNetCore.Http.BadHttpRequestException;

namespace Free_API.Services.Impl;

public class UserService : IUserService
{
    public readonly IUserRepository _userRepository;
    public readonly IMapper _mapper;
    public readonly IConfiguration _Configuration;
    
    public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration Configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _Configuration = Configuration;
    }
    
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
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

    public UserDto Login(UserDto user)
    {
        var savedUser = _userRepository.GetByEmail(user.Email);

        if (savedUser == null)
        {
            throw new BadHttpRequestException("Usuario nao encontrado");
        }

        var login = VerifyPasswordHash(user.Password, savedUser.Hash, savedUser.Salt);
        if (!login)
            throw new BadHttpRequestException("Senha incorreta");

        string token = CreateToken(_mapper.Map<UserDto>(savedUser));
        var dto = _mapper.Map<UserDto>(savedUser);
        dto.Token = token;

        return dto;
    }

    private string CreateToken(UserDto user)
    {
        List<Claim> claims = new List<Claim>();
        claims.Add(new Claim(ClaimTypes.Name, user.Name));

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_Configuration.GetSection("AppSettings:Token").Value));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    public UserDto UpdateUser(UserDto user, string email)
    {
        var userData = _mapper.Map<User>(user);
        var userSaved = _userRepository.GetByEmail(email);
        if (userSaved == null)
        {
            throw new BadHttpRequestException("Usuario não encontrado");
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
            throw new BadHttpRequestException("Usuario não encontrado");
        }
        return _mapper.Map<UserDto>(_userRepository.Delete(userSaved));
    }
}
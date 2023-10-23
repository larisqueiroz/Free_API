using Free_API;
using Free_API.Data;
using Free_API.Models.DAO;
using Free_API.Models.DTO;

namespace Free_API.Repositories;

public class UserRepository : IUserRepository
{
    public readonly FreeAPIContext _userRepository;
    
    public UserRepository(FreeAPIContext userRepository)
    {
        _userRepository = userRepository;
    }
    
    public List<User> GetAll()
    {
        return _userRepository.Users.ToList();
    }

    public User GetByEmail(string email)
    {
        return _userRepository.Users.Where(u => u.Email == email.ToLower()).FirstOrDefault();
    }

    public User Save(User user)
    {
        _userRepository.Users.Add(user);
        _userRepository.SaveChanges();
        return user;
    }
    
    public User Update(User user)
    {
        _userRepository.Users.Update(user);
        _userRepository.SaveChanges();
        return user;
    }
    
    public User Delete(User user)
    {
        _userRepository.Users.Remove(user);
        _userRepository.SaveChanges();
        return user;
    }
}

using Free_API.Models.DTO;
using Free_API.Models.DAO;

namespace Free_API.Services;

public interface IUserService
{
    public List<UserDto> getAllUsers();
    public UserDto getUserByEmail(string email);
    public UserDto SaveUser(UserDto user);
    public UserDto UpdateUser(UserDto user, string email);
    public UserDto DeleteUser(string email);
}
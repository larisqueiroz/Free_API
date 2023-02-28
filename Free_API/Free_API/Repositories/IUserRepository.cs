using Free_API;
using Free_API.Data;
using Free_API.Models.DAO;
using Free_API.Models.DTO;

namespace Free_API.Repositories;

public interface IUserRepository
{
    public List<User> GetAll();
    public User GetByEmail(string email);
    public User Save(User user);
    public User Update(User user);
    public User Delete(User user);
}
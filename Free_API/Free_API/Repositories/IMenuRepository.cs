using AutoMapper;
using Free_API.Data;
using Free_API.Models.DAO;
using Free_API.Repositories;

namespace Free_API.Repositories;

public interface IMenuRepository
{
    public List<Menu> GetAll();
    public Menu GetById(int id);
    public Menu Save(Menu menu);
    public Menu Update(Menu menu);
    public Menu Delete(int id);
}
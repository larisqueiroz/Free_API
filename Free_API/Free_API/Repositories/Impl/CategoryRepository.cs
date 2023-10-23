using Free_API.Data;
using Free_API.Models.DAO;
using Microsoft.EntityFrameworkCore;

namespace Free_API.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public readonly FreeAPIContext _categoryRepository;
    
    public CategoryRepository(FreeAPIContext categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public List<Category> GetAll()
    {
        return _categoryRepository.Categories.Include(c => c.dishes).ThenInclude(c => c.allergens).ToList();
    }

    public Category GetById(int id)
    {
        return _categoryRepository.Categories.Where(c => c.Id == id).Include(c => c.dishes).ThenInclude(c => c.allergens).FirstOrDefault();
    }
    
    public Category GetByName(string name)
    {
        return _categoryRepository.Categories.Where(a => a.Name == name | a.Name.ToLower().Contains(name)).FirstOrDefault();
    }

    public Category Save(Category category)
    {
        _categoryRepository.Categories.Add(category);
        _categoryRepository.SaveChanges();
        return category;
    }
    
    public Category Update(Category category)
    {
        _categoryRepository.Categories.Update(category);
        _categoryRepository.SaveChanges();
        return category;
    }
    
    public Category Delete(Category category)
    {
        _categoryRepository.Categories.Remove(category);
        _categoryRepository.SaveChanges();
        return category;
    }
    
}
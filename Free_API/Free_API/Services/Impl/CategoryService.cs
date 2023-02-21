using Free_API.Repositories;
using Free_API.Models.DAO;
using AutoMapper;
using Free_API.Models.DTO;

namespace Free_API.Services;

public class CategoryService : ICategoryService
{
    public readonly ICategoryRepository _categoryRepository;
    public readonly IMapper _mapper;
    
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public List<CategoryDto> getAllCategories()
    {
        var categories = _categoryRepository.GetAll();
        return _mapper.Map<List<Category>, List<CategoryDto>>(categories);
    }
    
    public CategoryDto getCategoryById(int id)
    {
        var category = _categoryRepository.GetById(id);
        return _mapper.Map<Category, CategoryDto>(category);
    }

    public CategoryDto SaveCategory(CategoryDto category)
    {
        var categoryDao = _mapper.Map<Category>(category);
        return _mapper.Map<CategoryDto>(_categoryRepository.Save(categoryDao));
    }

    public CategoryDto UpdateCategory(CategoryDto category, int id)
    {
        var categoryData = _mapper.Map<Category>(category);
        var categorySaved = _categoryRepository.GetById(id);
        if (categorySaved == null)
        {
            throw new Exception("Categoria não encontrada");
        }

        categorySaved.dishes = categoryData.dishes;
        categorySaved.Name = categoryData.Name;

        var categoryUpdated = _categoryRepository.Update(categorySaved);

        return _mapper.Map<CategoryDto>(categoryUpdated);
    }
    
    public CategoryDto DeleteCategory(int id)
    {
        var categorySaved = _categoryRepository.GetById(id);
        if (categorySaved == null)
        {
            throw new Exception("Categoria não encontrada");
        }
        return _mapper.Map<CategoryDto>(_categoryRepository.Delete(categorySaved));
    }
}
using EvoteDomain.Interfaces;
using EvoteDomain.Models;

namespace EvoteDomain.Services;

public class TupleCategoryService : ITupleCategoryService
{
    private readonly ICategorieRepository _repository;

    public TupleCategoryService(ICategorieRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<(int Id, string CategoryName, string CategoryDesc)>> GetCategoriesTupleAsync()
    {
        var categorys = await _repository.GetCategoriesAsync();
        List<(int Id, string CategoryName, string CategoryDesc)> listecategories = categorys.Select(c => (c.Id, c.CategoryName, c.CategoryDesc)).ToList();
        return listecategories;
    }
    public async Task<(int Id, string CategoryName, string CategoryDesc)> GetCategoriesByIdAsync(int id)
    {
        var categorys = await _repository.GetCategoriesByIdAsync(id);
        
        if (categorys != null)
        {
            (int Id, string CategoryName, string CategoryDesc) categorie = (categorys.Id, categorys.CategoryName, categorys.CategoryDesc);
            return categorie;
        }
        else
        {
            (int Id, string CategoryName, string CategoryDesc) notFound = (0,string.Empty,string.Empty);
            return notFound;
        }
    }

    public async Task<(int Id, string CategoryName, string CategoryDesc)> AddCategoriesAsync((int Id, string CategoryName, string CategoryDesc) categories)
    {
        Categories categories1 = new Categories();
        
        categories1.Id = categories.Id;
        categories1.CategoryName = categories.CategoryName;
        categories1.CategoryDesc = categories.CategoryDesc;
        
        var category  = await _repository.AddCategoriesAsync(categories1);
        (int Id, string CategoryName, string CategoryDesc) categorie = (category.Id, category.CategoryName, category.CategoryDesc);
        return categorie;   
    }

    public async Task<(int Id, string CategoryName, string CategoryDesc)> UpdateCategoriesAsync(int id, (int Id, string CategoryName, string CategoryDesc) categories)
    {
        Categories categories1 = new Categories();

        categories1.Id = categories.Id;
        categories1.CategoryName = categories.CategoryName;
        categories1.CategoryDesc = categories.CategoryDesc;

        var category = await _repository.UpdateCategoriesAsync(id,categories1);
        (int Id, string CategoryName, string CategoryDesc) categorie = (category.Id, category.CategoryName, category.CategoryDesc);
        return categorie;
    }

    public async Task<(int Id, string CategoryName, string CategoryDesc)> DeleteCategoriesAsync(int id)
    {
        var category =  await _repository.DeleteCategoriesAsync(id);
        (int Id, string CategoryName, string CategoryDesc) categorie = (category.Id, category.CategoryName, category.CategoryDesc);
        return categorie;
    }
}

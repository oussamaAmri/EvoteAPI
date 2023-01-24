using EvoteDomain.Interfaces;
using EvoteDomain.Models;

namespace EvoteDomain.Services;

public class CategoriesService : ICategorieService
{
    private readonly ICategorieRepository _repository;

    public CategoriesService(ICategorieRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Categories>> GetCategoriesAsync()
    {
        return await _repository.GetCategoriesAsync();
    }

    public async Task<Categories> AddCategoriesAsync(Categories categories)
    {
        return await _repository.AddCategoriesAsync(categories);
    }

    public async Task<Categories> UpdateCategoriesAsync(int id, Categories categories)
    {
        return await _repository.UpdateCategoriesAsync(id, categories);
    }

    public async Task<Categories> DeleteCategoriesAsync(int id)
    {
        return await _repository.DeleteCategoriesAsync(id);
    }

    public async Task<Categories> GetCategoriesByIdAsync(int id)
    {
        return await _repository.GetCategoriesByIdAsync(id);
    }
}

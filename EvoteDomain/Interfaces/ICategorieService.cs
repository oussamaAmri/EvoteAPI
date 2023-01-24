using EvoteDomain.Models;

namespace EvoteDomain.Interfaces;

public interface ICategorieService
{
    Task<IEnumerable<Categories>> GetCategoriesAsync();
    Task<Categories> GetCategoriesByIdAsync(int id);
    Task<Categories> AddCategoriesAsync(Categories categories);
    Task<Categories> UpdateCategoriesAsync(int id, Categories categories);
    Task<Categories> DeleteCategoriesAsync(int id);
}

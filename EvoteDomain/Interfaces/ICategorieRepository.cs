using EvoteDomain.Models;

namespace EvoteDomain.Interfaces;

public interface ICategorieRepository
{
    Task<IEnumerable<Categories>> GetCategoriesAsync();
//    Task<Categories> AddCategoriesAsync(Categories categories);
//    Task<Categories> UpdateCategoriesAsync(int id, Categories categories);
//    Task<Categories> DeleteCategoriesAsync(int id);
}

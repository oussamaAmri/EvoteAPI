using EvoteDomain.Models;

namespace EvoteDomain.Interfaces;

public interface ITupleCategoryService
{
    Task<IEnumerable<(int Id, string CategoryName, string CategoryDesc)>> GetCategoriesTupleAsync();
    Task<(int Id,string CategoryName, string CategoryDesc)> AddCategoriesAsync((int Id,string CategoryName, string CategoryDesc) categories);
    Task<(int Id, string CategoryName, string CategoryDesc)> GetCategoriesByIdAsync(int id);
    Task<(int Id, string CategoryName, string CategoryDesc)> UpdateCategoriesAsync(int id, (int Id, string CategoryName, string CategoryDesc) categories);
    Task<(int Id, string CategoryName, string CategoryDesc)> DeleteCategoriesAsync(int id);
}

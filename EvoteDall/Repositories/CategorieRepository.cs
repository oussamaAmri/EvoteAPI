using EvoteDall.Entities;
using EvoteDomain.Interfaces;
using EvoteDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EvoteDall.Repositories;

public class CategorieRepository : ICategorieRepository
{
    private readonly EvoteDbContext _dbContext;

    public CategorieRepository(EvoteDbContext _dbContext)
    {
        this._dbContext = _dbContext;
    }
    public async Task<IEnumerable<Categories>> GetCategoriesAsync()
    {
        return await _dbContext.Categories.Select(c => new Categories
        {
            Id = c.Idc,
            CategoryName = c.NomC,
            CategoryDesc = c.DescC
        }).ToListAsync();
    }

/*    public async Task<Categories> AddCategoriesAsync(Categories categories)
    {
        var categorie = new CategoriesEntities { Id = categories.Id, CategoryName = categories.CategoryName,CategoryDesc=categories.CategoryDesc};
        _categories.Add(categorie);
        var a = await Task.FromResult(categorie);
        return new Categories { Id = categorie.Id, CategoryName = categorie.CategoryName, CategoryDesc = categorie.CategoryDesc};
    }
    public async Task<Categories> UpdateCategoriesAsync(int id, Categories categories)
    {
        var categorieToUpdate = new CategoriesEntities { CategoryName = categories.CategoryName, CategoryDesc = categories.CategoryDesc };
        foreach (var c in _categories)
        {
            if (c.Id == id)
            {
                c.CategoryName = categorieToUpdate.CategoryName;
                c.CategoryDesc = categorieToUpdate.CategoryDesc;
            }
            else
            {
                return null;
            }
        }
        var a = await Task.FromResult(categorieToUpdate);
        return new Categories { Id = categorieToUpdate.Id, CategoryName = categorieToUpdate.CategoryName, CategoryDesc = categorieToUpdate.CategoryDesc };
    }
    public async Task<Categories> DeleteCategoriesAsync(int id)
    {
        var categorieToDelete = _categories.SingleOrDefault(c => c.Id == id);
        if (categorieToDelete != null)
        {
            _categories.Remove(categorieToDelete);
        }
        else
        {
            return null;
        }

        var a = await Task.FromResult(categorieToDelete);
        return new Categories { Id = categorieToDelete.Id, CategoryName = categorieToDelete.CategoryName, CategoryDesc = categorieToDelete.CategoryDesc };
    }*/
}

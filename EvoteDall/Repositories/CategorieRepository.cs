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

    public async Task<Categories> GetCategoriesByIdAsync(int id)
    {
        var categorie = await _dbContext.Categories.SingleOrDefaultAsync(c => c.Idc == id);
        if (categorie == null)
        {
            return null;
        }
        return new Categories { Id = categorie.Idc, CategoryName = categorie.NomC, CategoryDesc = categorie.DescC };
    }

    public async Task<Categories> AddCategoriesAsync(Categories categories)
    {
        var categorie = new CategoryEntities {NomC = categories.CategoryName,DescC=categories.CategoryDesc};
        var db = _dbContext.Categories.Add(categorie);
        await _dbContext.SaveChangesAsync();
        return new Categories { Id = categorie.Idc, CategoryName = categorie.NomC, CategoryDesc = categorie.DescC};
    }
    public async Task<Categories> UpdateCategoriesAsync(int id, Categories categories)
    {
        var categorie = await _dbContext.Categories.FindAsync(id);
        var categorieToUpdate = new CategoryEntities { NomC = categories.CategoryName,DescC=categories.CategoryDesc};
        if (categorie == null)
        {
            return null;
        }
        categorie.NomC = categorieToUpdate.NomC;
        categorie.DescC = categorieToUpdate.DescC;
        await _dbContext.SaveChangesAsync();
        return new Categories { Id = categorie.Idc, CategoryName = categorie.NomC,CategoryDesc=categorie.DescC};
    }
    public async Task<Categories> DeleteCategoriesAsync(int id)
    {
        var categorie = await _dbContext.Categories.FindAsync(id);
        if (categorie == null)
        {
            return null;
        }
        _dbContext.Categories.Remove(categorie);
        await _dbContext.SaveChangesAsync();
        return new Categories { Id = categorie.Idc,CategoryName=categorie.NomC,CategoryDesc=categorie.DescC};
    }
}

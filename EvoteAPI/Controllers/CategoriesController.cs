using EvoteAPI.ViewModels.Requests;
using EvoteAPI.ViewModels.Responses;
using EvoteDall.Entities;
using EvoteDomain.Interfaces;
using EvoteDomain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.Design;

namespace EvoteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategorieService _categorieService;
        public CategoriesController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            IEnumerable<Categories> categoriesE = await _categorieService.GetCategoriesAsync();
            return Ok(new CategoriesResponses
            {
                categories = categoriesE.Select(c => new Categories
                {
                    Id = c.Id,
                    CategoryName = c.CategoryName,
                    CategoryDesc = c.CategoryDesc 
                })
            });
        }
/*
        [HttpPost("Categories")]
        public async Task<IActionResult> AddCategoriesAsync([FromBody] CreateCategoriesRequest createCategoriesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//error 400 
            }
            var categorie = new Categories {Id = createCategoriesRequest.CategoryId, CategoryName = createCategoriesRequest.CategoryName, CategoryDesc = createCategoriesRequest.CategoryDesc};
            var addcategorie = await _categorieService.AddCategoriesAsync(categorie);
            return Ok(addcategorie);
        }

        [HttpPut("Categories/{id}")]
        public async Task<IActionResult> UpdateCategoriesAsync([FromRoute] int id, [FromBody] UpdateCategoriesRequest updateCategoriesRequest)
        {
            var categorie = new Categories { CategoryName = updateCategoriesRequest.CategoryName,CategoryDesc = updateCategoriesRequest.CategoryDesc};
            var updateCategorie = await _categorieService.UpdateCategoriesAsync(id, categorie);
            if (updateCategorie == null)
            {
                return NotFound();
            }
            else
            {
                return this.Ok(updateCategorie);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriesAsync([FromRoute] int id)
        {
            var DeleteCategorie = await _categorieService.DeleteCategoriesAsync(id);
            if (DeleteCategorie == null)
            {
                return NotFound();
            }

            return this.Ok(DeleteCategorie);
        }*/
    }
}

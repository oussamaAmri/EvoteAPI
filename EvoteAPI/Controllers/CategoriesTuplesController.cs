using EvoteAPI.ViewModels.Requests;
using EvoteAPI.ViewModels.Responses;
using EvoteDomain.Interfaces;
using EvoteDomain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EvoteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesTuplesController : Controller
    {
        private readonly ITupleCategoryService _categorieService;
        public CategoriesTuplesController(ITupleCategoryService categorieService)
        {
            _categorieService = categorieService;
        }

        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategoriesTupleAsync()
        {
            IEnumerable<(int Id, string CategoryName, string CategoryDesc)> categoriesE = await _categorieService.GetCategoriesTupleAsync();
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


        [HttpGet("Categories/{id}")]
        public async Task<IActionResult> GetCategoriesByIdAsync(int id)
        {
            (int Id, string CategoryName, string CategoryDesc) categoriesE = await _categorieService.GetCategoriesByIdAsync(id);
            if (categoriesE.Id == 0)
            {
                return NotFound();
            }
            return Ok(new CategorieResponse
            {
                categories = new Categories { Id = categoriesE.Id, CategoryName = categoriesE.CategoryName, CategoryDesc = categoriesE.CategoryDesc }
            });
        }

        [HttpPost("Categories")]
        public async Task<IActionResult> AddCategoriesAsync([FromBody]CreateCategoriesRequest createCategoriesRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//error 400 
            }
/* equivalen au tuple*/
//            var categorie = new Categories { Id = createCategoriesRequestTuple.CategoryId, CategoryName = createCategoriesRequestTuple.CategoryName, CategoryDesc = createCategoriesRequestTuple.CategoryDesc }; (int a,int b) ffff = (a,b)
            (int Id, string CategoryName, string CategoryDesc) addcategorie = await _categorieService.AddCategoriesAsync((createCategoriesRequest.CategoryId,createCategoriesRequest.CategoryName,createCategoriesRequest.CategoryDesc));
            return Ok(addcategorie);
        }
        [HttpPut("Categories/{id}")]
        public async Task<IActionResult> UpdateCategoriesAsync([FromRoute] int id, [FromBody] UpdateCategoriesTupleRequeste updateCategoriesTupleRequeste)
        {
            var categorie = new Categories {Id = updateCategoriesTupleRequeste.Id, CategoryName = updateCategoriesTupleRequeste.CategoryName, CategoryDesc = updateCategoriesTupleRequeste.CategoryDesc };
            (int Id, string CategoryName, string CategoryDesc) updateCategorie = await _categorieService.UpdateCategoriesAsync(id,(updateCategoriesTupleRequeste.Id ,updateCategoriesTupleRequeste.CategoryName, updateCategoriesTupleRequeste.CategoryDesc));

            if (updateCategorie.Id == 0)
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
            if (DeleteCategorie.Id == 0)
            {
                return NotFound();
            }

            return this.Ok(DeleteCategorie);
        }
    }
}

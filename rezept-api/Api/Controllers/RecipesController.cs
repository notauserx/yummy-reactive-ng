using Microsoft.AspNetCore.Mvc;
using Rezept.Api.Contracts;
using Rezept.Api.Services;

namespace Api.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    public RecipesController() { }


    [HttpGet]
    [HttpHead] 
    public IEnumerable<RecipeListItem> GetRecipes(
        [FromServices] IRecipeListService service,
        string? searchTerm)
    {
        return service.GetRecipeListItems(searchTerm);
    }

    [HttpGet]
    [HttpHead]
    [Route("categories")]
    public IEnumerable<RecipeCategoryItem> GetRecipeCategories(
        [FromServices] IRecipeCategoryService service)
    {
        return service.GetRecipeCategories();
    }

    [HttpOptions]
    public IActionResult GetRecipesOptions()
    {
        Response.Headers.Add("Allow", "GET, HEAD, OPTIONS");
        return Ok();
    }
}

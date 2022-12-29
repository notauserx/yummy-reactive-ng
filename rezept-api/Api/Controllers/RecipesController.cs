using Microsoft.AspNetCore.Mvc;
using Rezept.Api.Contracts;
using Rezept.Api.Services;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeListService recipeListService;

    public RecipesController(IRecipeListService recipeListService)
    {
        this.recipeListService = recipeListService;
    }


    [HttpGet]
    [HttpHead] 
    public IEnumerable<RecipeListItem> Get()
    {
        return recipeListService.GetRecipeListItems();
    }
}

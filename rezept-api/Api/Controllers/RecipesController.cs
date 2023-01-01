using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rezept.Api.Contracts;
using Rezept.Api.Services;
using System.Text.Json;

namespace Api.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    private readonly IMapper _mapper;
    public RecipesController(IMapper mapper)
    {
        _mapper = mapper;
    }


    [HttpGet]
    [HttpHead] 
    public IEnumerable<RecipeListItem> GetRecipes(
        [FromServices]  IRecipeListService service,
        [FromQuery]     RecipeListRequestParams requestParams)
    {
        var recipes = service.GetRecipeListItems(requestParams);

        var paginationMetadata = new
        {
            recipes.TotalCount,
            recipes.TotalPages,
            recipes.CurrentPage,
            recipes.PageSize,
        };

        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return _mapper.Map<IEnumerable<RecipeListItem>>(recipes);
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

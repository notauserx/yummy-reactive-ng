using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Rezept.Api.Contracts;
using Rezept.Api.Services;

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
    public ActionResult GetRecipes(
        [FromServices]  IRecipeListService service,
        [FromQuery]     RecipeListRequestParams requestParams)
    {
        var recipes = service.GetRecipeListItems(requestParams);

        return Ok(new RecipeListResponse
        (
            recipes.TotalCount,
            recipes.TotalPages,
            recipes.CurrentPage,
            recipes.PageSize,
            _mapper.Map<IEnumerable<RecipeListItem>>(recipes)
        ));
    }

    [HttpGet("{id}")]
    [HttpHead("{id}")]
    public async Task<ActionResult<RecipeDetailResponse>> GetRecipe(
        [FromServices]  IRecipeDetailService service,
        [FromRoute] Guid id)
    {
        var recipe = await service.GetRecipeDetailAsync(id);

        return Ok(recipe);
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

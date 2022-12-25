using Microsoft.AspNetCore.Mvc;

using Rezept.Data.Contexts;
using Rezept.Data.Entities;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RezeptController : ControllerBase
    {
        private readonly RezeptDbContext _context;

        public RezeptController(RezeptDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            var recipies = _context.Recipes.Take(5).ToList();

            return recipies;
        }
    }
}

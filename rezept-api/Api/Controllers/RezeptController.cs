using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var recipies = _context.Recipes
                .Include(r => r.Author)
                .Include(r => r.Category)
                .Include(r => r.Keywords)
                .Include(r => r.NutritionInfo)
                .Where(r => r.ImageUrl != null)
                .Take(25)
                .ToList();

            return recipies;
        }
    }
}

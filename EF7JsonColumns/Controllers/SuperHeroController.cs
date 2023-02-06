using EF7JsonColumns.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF7JsonColumns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext context;

        public SuperHeroController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHeroes(List<SuperHero> heroes)
        {
            context.Heroes.AddRange(heroes);
            await context.SaveChangesAsync();
            return Ok(await context.Heroes.ToListAsync());
        }

        [HttpGet("{city}")]
        public async Task<ActionResult<List<SuperHero>>> GetHeroes(string city)
        {
            var heroes = await context.Heroes.Include(h=>h.Details).Where(h => h.Details.City.Contains(city)).ToListAsync();
            return Ok(heroes);
        }
    }
}

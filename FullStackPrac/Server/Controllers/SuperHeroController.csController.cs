using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FullStackPrac.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FullStackPrac.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> Comics = new List<Comic>()
        {
            new Comic { Id = 1, Name = "Marvel" },
            new Comic { Id = 2, Name = "DC" }
        };

        public static List<SuperHero> Heroes = new List<SuperHero>
        {
            new SuperHero
                { Id = 1, FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", comic = Comics[0] },
            new SuperHero
                { Id = 2, FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", comic = Comics[1] },
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            return Ok(Heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHero(int id)
        {
            var hero = Heroes.FirstOrDefault(hero => hero.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, no hero found with id: " + id);
            }
            return Ok(hero);
        }
    };
}
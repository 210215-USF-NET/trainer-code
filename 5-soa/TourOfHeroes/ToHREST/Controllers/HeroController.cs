using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToHBL;
using ToHModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToHREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroBL _heroBL;
        public HeroController(IHeroBL heroBL)
        {
            _heroBL = heroBL;
        }
        // GET: api/<HeroController>
        [HttpGet]
        public async Task<IActionResult> GetHeroesAsync()
        {
            return Ok(await _heroBL.GetHeroesAsync());
        }

        // GET api/<HeroController>/Spiderman
        [HttpGet("{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetHeroByNameAsync(string name)
        {
            var hero = await _heroBL.GetHeroByNameAsync(name);
            if (hero == null) return NotFound();
            return Ok(hero);
        }

        // POST api/<HeroController>
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> AddAHeroAsync([FromBody] Hero hero)
        {
            try
            {
                await _heroBL.AddHeroAsync(hero);
                return CreatedAtAction("AddAHero", hero);
            } catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHeroAsync(int id, [FromBody] Hero hero)
        {
            try
            {
                await _heroBL.UpdateHeroAsync(hero);
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<HeroController>/Thanos
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteAsync(string name)
        {
            try
            {
                await _heroBL.DeleteHeroAsync(await _heroBL.GetHeroByNameAsync(name));
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

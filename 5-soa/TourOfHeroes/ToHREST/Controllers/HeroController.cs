using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToHBL;

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
        public IActionResult GetHeroes()
        {
            return Ok(_heroBL.GetHeroes());
        }

        // GET api/<HeroController>/Spiderman
        [HttpGet("{name}")]
        public IActionResult GetHeroById(string name)
        {
            return Ok(_heroBL.GetHeroByName(name));
        }

        // POST api/<HeroController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HeroController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HeroController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

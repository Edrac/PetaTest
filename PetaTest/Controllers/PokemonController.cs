using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetaTest.Db;
using PetaTest.Models;

namespace PetaTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonContext _context;

        public PokemonController(PokemonContext context)
        {
            _context = context;
            SeedData.Initialize(_context);
        }

        // GET: api/Pokemon
        // GET: api/Pokemon?pageSize=40&page=2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemonList([FromQuery] int pageSize = 20, [FromQuery] int page = 0)
        {
            return await _context.PokemonList.Skip(page * pageSize).Take(pageSize).ToListAsync();
        }

        // GET: api/Pokemon/Bulbasaur
        [HttpGet("{name}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(string name)
        {
            var pokemon = await _context.PokemonList.FindAsync(name);

            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }

        // PUT: api/Pokemon/Bulbasaur
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{name}")]
        public async Task<IActionResult> PutPokemon(string name, Pokemon pokemon)
        {
            if (name != pokemon.Name)
            {
                return BadRequest();
            }

            _context.Entry(pokemon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonExists(name))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pokemon
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pokemon>> PostPokemon(Pokemon pokemon)
        {
            _context.PokemonList.Add(pokemon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPokemon", new { name = pokemon.Name }, pokemon);
        }

        // DELETE: api/Pokemon/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pokemon>> DeletePokemon(int id)
        {
            var pokemon = await _context.PokemonList.FindAsync(id);
            if (pokemon == null)
            {
                return NotFound();
            }

            _context.PokemonList.Remove(pokemon);
            await _context.SaveChangesAsync();

            return pokemon;
        }

        private bool PokemonExists(string name)
        {
            return _context.PokemonList.Any(e => e.Name == name);
        }
    }
}
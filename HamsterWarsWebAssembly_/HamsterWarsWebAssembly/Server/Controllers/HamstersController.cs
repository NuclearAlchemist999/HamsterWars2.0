using DataAccess.Data;
using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamstersController : ControllerBase
    {
        private readonly DataContext _context;

        public HamstersController(DataContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Hamster>>> GetHamsters()
        {
            var hamsters = await _context.Hamsters.ToListAsync();
            return Ok(hamsters);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Hamster>> GetHamster(int id)
        {
            var hamster = await _context.Hamsters.FirstOrDefaultAsync(h => h.Id == id);
            if (hamster == null)
                return NotFound("No hamster here.");

            return Ok(hamster);
        }

        [HttpPost]
        public async Task<ActionResult<Hamster>> AddHamster(Hamster hamster)
        {
            _context.Hamsters.Add(hamster);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHamsters());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Hamster>>> UpdateHamster(Hamster hamster, int id)
        {
            var dbHamster = await _context.Hamsters.FirstOrDefaultAsync(h => h.Id == id);

            if (dbHamster == null)
                return NotFound("No hamster here.");

            dbHamster.Name = hamster.Name;
            dbHamster.Age = hamster.Age;
            dbHamster.FavFood = hamster.FavFood;
            dbHamster.FavThing = hamster.FavThing;

            await _context.SaveChangesAsync();

            return Ok(await GetDbHamsters());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hamster>>> DeleteHamster(int id)
        {
            var dbHamster = await _context.Hamsters.FirstOrDefaultAsync(h => h.Id == id);

            if (dbHamster == null)
                return NotFound("No hamster here.");

           _context.Hamsters.Remove(dbHamster); 

            await _context.SaveChangesAsync();

            return Ok(await GetDbHamsters());
        }

        private async Task<List<Hamster>> GetDbHamsters()
        {
            return await _context.Hamsters.ToListAsync();
        }

    }
}

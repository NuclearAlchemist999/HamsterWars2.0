using DataAccess.Data;
using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.HamsterRepository
{
    public class HamsterRepository : IHamsterRepository
    {
        private readonly DataContext _context;
        public HamsterRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Hamster>> GetHamsters()
        {
            var hamsters = await _context.Hamsters.ToListAsync();
            return hamsters;
        }

        public async Task<Hamster> GetHamster(int id)
        {
            var hamster = await SearchHamster(id);
            return hamster;
        }

        private async Task<Hamster> SearchHamster(int id)
        {
            return await _context.Hamsters.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task AddHamster(Hamster hamster)
        {
            _context.Hamsters.Add(hamster);
            await _context.SaveChangesAsync();   
        }

        public async Task<Hamster> UpdateHamster(Hamster hamster, int id)
        {
            var dbHamster = await SearchHamster(id);

            if (dbHamster != null)
            {
                dbHamster.Name = hamster.Name;
                dbHamster.Age = hamster.Age;
                dbHamster.FavFood = hamster.FavFood;
                dbHamster.FavThing = hamster.FavThing;

                await _context.SaveChangesAsync();

            }

            return dbHamster;
            
        }

        public async Task<Hamster> DeleteHamster(int id)
        {
            var dbHamster = await SearchHamster(id);

            if (dbHamster != null)
            {
                _context.Hamsters.Remove(dbHamster);

                await _context.SaveChangesAsync();
            }
            return dbHamster;
        }

        public async Task<List<Hamster>> GetTwoRandomHamsters()
        {
            var hamsters = await _context.Hamsters.OrderBy(h => Guid.NewGuid()).Take(2).ToListAsync();
            return hamsters;
        }
    }
}

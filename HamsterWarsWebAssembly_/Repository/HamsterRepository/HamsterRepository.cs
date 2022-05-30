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
            var hamster = await _context.Hamsters.FirstOrDefaultAsync(h => h.Id == id);
            return hamster;
        }

        public async Task AddHamster(Hamster hamster)
        {
            _context.Hamsters.Add(hamster);
            await _context.SaveChangesAsync();   
        }

        public async Task<Hamster> UpdateHamster(HamsterGame request, int id)
        {
            var dbHamster = await GetHamster(id);

            if (request.WinStatus == "Winner")
            {
                dbHamster.Wins++;
            }
            else
            {
                dbHamster.Losses++;
            }
            dbHamster.Games++;
            
            await _context.SaveChangesAsync();

            return dbHamster;
            
        }
        public async Task<Hamster> DeleteHamster(int id)
        {
            var dbHamster = await GetHamster(id);

            if (dbHamster != null)
            {
                string dbPath = dbHamster.ImgName;
                string path = $"wwwroot{dbPath}";
                
                _context.Hamsters.Remove(dbHamster);
                
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

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

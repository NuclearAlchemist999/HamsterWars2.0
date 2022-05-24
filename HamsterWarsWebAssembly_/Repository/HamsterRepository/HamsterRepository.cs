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

        public async Task UpdateHamster(UpdateHamsterRequest request)
        {
            string winStat = "";
            int gameId = await AddGame();
            var loser = await _context.Hamsters.FirstOrDefaultAsync(h => h.Id == request.LoserId);

            if (loser != null)
            {
                winStat = "Loser";
                loser.Losses++;
                loser.Games++;
                await AddFighter(loser.Id, gameId, winStat);
            }
            var winner = await _context.Hamsters.FirstOrDefaultAsync(h => h.Id == request.WinnerId);
            winner.Wins++;
            winner.Games++;
            
            winStat = "Winner";
            
            await AddFighter(winner.Id, gameId, winStat);
            
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

        public async Task<int> AddGame()
        {
            var game = new Game
            {
                TimeStamp = DateTime.Now
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game.Id;

        }

        public async Task AddFighter(int hamsterId, int gameId, string winStat)
        {
            var fighter = new HamsterGame
            {
                HamsterId = hamsterId,
                GameId = gameId,
                WinStatus = winStat
            };

            _context.Hamsters_Games.Add(fighter);
            await _context.SaveChangesAsync();
        }
    }
}

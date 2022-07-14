﻿using HamsterWarsWebAssembly.Shared.Data;
using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace HamsterWarsWebAssembly.Server.Repositories.BattleRepository
{
    public class BattleRepository : IBattleRepository
    {
        private readonly DataContext _context;

        public BattleRepository(DataContext context)
        {
            _context = context;
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

        public async Task<HamsterGame> AddFighterAndGame(HamsterGame request)
        {
            var fighterAndGame = new HamsterGame
            {
                HamsterId = request.HamsterId,
                GameId = request.GameId,
                WinStatus = request.WinStatus
            };

            _context.Hamsters_Games.Add(fighterAndGame);
            await _context.SaveChangesAsync();

            return fighterAndGame;
        }




        public async Task<List<JoinModel>> GetFighters(int id)
        {
            var fighters = await (from h in _context.Hamsters
                                  join hg in _context.Hamsters_Games on h.Id equals hg.HamsterId
                                  join g in _context.Games on hg.GameId equals g.Id
                                  where g.Id == id
                                  select new JoinModel
                                  {
                                      GameId = g.Id,
                                      HamsterName = h.Name,
                                      Wins = h.Wins,
                                      Losses = h.Losses,
                                      Games = h.Games,
                                      HamsterId = h.Id,
                                      ImgName = h.ImgName,
                                      WinStatus = hg.WinStatus,
                                      TimeStamp = g.TimeStamp

                                  }).ToListAsync();


            return fighters;

        }
        // Get the games and hamsters that a hamster with a requested id has defeated.
        public async Task<List<JoinModel>> BattleWinner(int id)
        {

            var games = (from hh in _context.Hamsters
                         join hgg in _context.Hamsters_Games on hh.Id equals hgg.HamsterId
                         join gg in _context.Games on hgg.GameId equals gg.Id
                         where hgg.HamsterId == id && hgg.WinStatus == "Winner"
                         select gg.Id);

            var hamsters = await (from g in _context.Games
                                  join hg in _context.Hamsters_Games on g.Id equals hg.GameId
                                  join h in _context.Hamsters on hg.HamsterId equals h.Id

                                  where games.Contains(g.Id) && hg.WinStatus == "Loser"
                                  select new JoinModel
                                  {
                                      GameId = g.Id,
                                      HamsterName = h.Name,
                                      Wins = h.Wins,
                                      Losses = h.Losses,
                                      Games = h.Games,
                                      HamsterId = h.Id,
                                      ImgName = h.ImgName,
                                      WinStatus = hg.WinStatus,
                                      TimeStamp = g.TimeStamp


                                  }).OrderByDescending(g => g.GameId).ToListAsync();

            return hamsters;

        }

        public async Task<List<JoinModel>> BattleHistory()
        {

            var games = await (from h in _context.Hamsters

                               join hg in _context.Hamsters_Games on h.Id equals hg.HamsterId
                               join g in _context.Games on hg.GameId equals g.Id

                               select new JoinModel
                               {
                                   GameId = g.Id,
                                   HamsterName = h.Name,
                                   Wins = h.Wins,
                                   Losses = h.Losses,
                                   Games = h.Games,
                                   HamsterId = h.Id,
                                   ImgName = h.ImgName,
                                   WinStatus = hg.WinStatus,
                                   TimeStamp = g.TimeStamp


                               }).OrderByDescending(g => g.GameId).ToListAsync();

            return games;

        }

        public async Task<Game> DeleteGame(int id)
        {
            var dbGame = await _context.Games.FindAsync(id);

            if (dbGame != null)
            {
                _context.Games.Remove(dbGame);
                await _context.SaveChangesAsync();
            }

            return dbGame;

        }

        public async Task<List<PercentModel>> LoadTopFive()
        {

            var hamsters = await (from h in _context.Hamsters
                                .Where(w => w.Wins >= 3)
                                .OrderByDescending(h => ((double)h.Wins / (double)h.Games))
                                .ThenByDescending(h => h.Wins)
                                  select new PercentModel
                                  {
                                      WinPercentRate = Math.Round(((double)h.Wins / (double)h.Games) * 100, 2),
                                      LossPercentRate = Math.Round(((double)h.Losses / (double)h.Games) * 100, 2),
                                      Name = h.Name,
                                      ImgName = h.ImgName,
                                      Wins = h.Wins,
                                      Losses = h.Losses,
                                      Games = h.Games,


                                  }).Take(5).ToListAsync();

            return hamsters;

        }

        public async Task<List<PercentModel>> LoadBottomFive()
        {

            var hamsters = await (from h in _context.Hamsters
                                    .Where(l => l.Losses >= 3)
                                    .OrderByDescending(h => ((double)h.Losses / (double)h.Games))
                                    .ThenByDescending(h => h.Losses)
                                  select new PercentModel
                                  {
                                      WinPercentRate = Math.Round(((double)h.Wins / (double)h.Games) * 100, 2),
                                      LossPercentRate = Math.Round(((double)h.Losses / (double)h.Games) * 100, 2),
                                      Name = h.Name,
                                      ImgName = h.ImgName,
                                      Wins = h.Wins,
                                      Losses = h.Losses,
                                      Games = h.Games

                                  }).Take(5).ToListAsync();

            return hamsters;

        }

    }
}
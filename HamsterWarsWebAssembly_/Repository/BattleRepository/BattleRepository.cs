﻿using DataAccess.Data;
using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.BattleRepository
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

        public async Task<List<JoinModel>> GetFighters(int id)
        {
            var join = await (from h in _context.Hamsters
                              join hg in _context.Hamsters_Games on h.Id equals hg.HamsterId
                              join g in _context.Games on hg.GameId equals g.Id
                              where g.Id == id
                              select new JoinModel
                              {
                                  HamsterName = h.Name,
                                  Wins = h.Wins,
                                  Losses = h.Losses,
                                  Games = h.Games,
                                  HamsterId = h.Id,
                                  ImgName = h.ImgName,
                                  WinStatus = hg.WinStatus

                              }).ToListAsync();
            return join;

        }


    }
}

using DataAccess.Data;
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
        
    }
}

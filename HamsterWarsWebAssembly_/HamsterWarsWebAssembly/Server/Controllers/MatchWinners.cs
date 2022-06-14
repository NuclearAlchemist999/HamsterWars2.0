using Microsoft.AspNetCore.Mvc;
using Repository.BattleRepository;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchWinners : ControllerBase
    {
        private readonly IBattleRepository _battleRepo;
        public MatchWinners(IBattleRepository battleRepo)
        {
            _battleRepo = battleRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BattleWinner(int id)
        {
            var losers = await _battleRepo.BattleWinner(id);
            if (losers.Count == 0)
                return NotFound("No wins yet or battle history has been deleted.");
            
            return Ok(losers);
        }
    }
}

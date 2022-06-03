using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.BattleRepository;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinnersController : ControllerBase
    {
        private readonly IBattleRepository _battleRepo;
        public WinnersController(IBattleRepository battleRepo)
        {
            _battleRepo = battleRepo;
        }

        [HttpGet]
        public async Task<IActionResult> TopFive()
        {
            var hamsters = await _battleRepo.LoadTopFive();
            return Ok(hamsters);
        }
    }
}

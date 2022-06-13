using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.BattleRepository;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LosersController : ControllerBase
    {
        private readonly IBattleRepository _battleRepo;
        public LosersController(IBattleRepository battleRepo)
        {
            _battleRepo = battleRepo; 
        }

        [HttpGet]
        public async Task<IActionResult> BottomFive()
        {
            var hamsters = await _battleRepo.LoadBottomFive();
            return Ok(hamsters);
        }
    }
}

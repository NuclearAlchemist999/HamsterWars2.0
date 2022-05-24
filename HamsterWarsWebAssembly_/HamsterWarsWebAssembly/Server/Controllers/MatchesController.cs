using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.BattleRepository;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IBattleRepository _battleRepo;
        public MatchesController(IBattleRepository battleRepo)
        {
            _battleRepo = battleRepo;
        }

       
    }
}

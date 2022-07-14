using HamsterWarsWebAssembly.Server.Repositories.AuthRepository;
using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await _authRepo.Register(request);

            bool checkUsername = _authRepo.CheckUsername(user.Username);

            if (!checkUsername)
            {
                return BadRequest("Username already exists.");
            }

            bool validatePassword = _authRepo.PasswordValditaion(request.Password);

            if (!validatePassword)
            {
                return BadRequest("At least 10 to 20 characters, including at least one number and one capital letter.");
            }

            await _authRepo.AddUser(user);

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            var user = await _authRepo.Login(request);

            if (user == null)
            {
                return BadRequest("Invalid credentials.");
            }

            bool verifyPasswordHash = _authRepo.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

            if (!verifyPasswordHash)
            {
                return BadRequest("Invalid credentials.");
            }

            string token = _authRepo.CreateToken(user);

            return Ok(token);
        }
    }
}

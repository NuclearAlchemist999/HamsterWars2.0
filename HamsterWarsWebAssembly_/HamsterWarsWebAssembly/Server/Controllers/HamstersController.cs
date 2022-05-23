using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamstersController : ControllerBase
    {
        public static List<Hamster> hamsters = new List<Hamster>
        {
            new Hamster {
                Id = 1,
                Name = "Gregory",
                Age = 2,
                FavFood = "Peanuts",
                FavThing = "Wheel",
                ImgName = "/Content/images/savedImages/hamster-1.jpg",
                Wins = 0,
                Losses = 0,
                Games = 0

            },
            new Hamster {
                Id = 2,
                Name = "Mr Smith",
                Age = 2,
                FavFood = "Seeds",
                FavThing = "Water bottle",
                ImgName = "/Content/images/savedImages/hamster-2.jpg",
                Wins = 0,
                Losses = 0,
                Games = 0

            },
            new Hamster {
                Id = 3,
                Name = "Valeria",
                Age = 1,
                FavFood = "Bacon",
                FavThing = "Corner",
                ImgName = "/Content/images/savedImages/hamster-3.jpg",
                Wins = 0,
                Losses = 0,
                Games = 0

            },
            new Hamster {
                Id = 4,
                Name = "Schrödinger",
                Age = 2,
                FavFood = "Salad",
                FavThing = "Sleeping",
                ImgName = "/Content/images/savedImages/hamster-4.jpg",
                Wins = 0,
                Losses = 0,
                Games = 0

            },
            new Hamster {
                Id = 5,
                Name = "Menlo",
                Age = 1,
                FavFood = "Carrot",
                FavThing = "Walking",
                ImgName = "/Content/images/savedImages/hamster-5.jpg",
                Wins = 0,
                Losses = 0,
                Games = 0

            }
        };
        [HttpGet]
        public async Task<ActionResult<List<Hamster>>> GetHamsters()
        {
            return Ok(hamsters);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Hamster>> GetHamster(int id)
        {
            var hamster = hamsters.FirstOrDefault(h => h.Id == id);
            if (hamster == null)
                return NotFound("No hamster here.");

            return Ok(hamster);
        }
    }
}

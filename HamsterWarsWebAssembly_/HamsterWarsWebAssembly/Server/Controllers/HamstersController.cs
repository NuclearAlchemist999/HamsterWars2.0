using DataAccess.Data;
using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.HamsterRepository;
using System.Text.Json;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamstersController : ControllerBase
    {
        private readonly IHamsterRepository _hamsterRepo;

        public HamstersController(IHamsterRepository hamsterRepo)
        {
            _hamsterRepo = hamsterRepo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllHamsters()
        {
            var hamsters = await _hamsterRepo.GetHamsters();
            return Ok(hamsters);
       
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneHamster(int id)
        {
            var hamster = await _hamsterRepo.GetHamster(id);
            if (hamster == null)
                return NotFound("No hamster here.");

            return Ok(hamster);
        }

        [HttpPost]
        public async Task<IActionResult> AddHamster(Hamster hamster)
        {
            var hamstero =  await _hamsterRepo.AddHamster(hamster);
            return Ok(hamstero);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHamster(HamsterGame request, int id)
        {
            var hamster = await _hamsterRepo.UpdateHamster(request, id);
            if (hamster == null)
                return NotFound("No hamster here.");
            return Ok(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHamster(int id)
        {
            var dbHamster = await _hamsterRepo.DeleteHamster(id);

            if (dbHamster == null)
                return NotFound("No hamster here.");

            return Ok(dbHamster);
        }
        [HttpGet("random")]
        public async Task<IActionResult> RandomHamsters()
        {
            var hamsters = await _hamsterRepo.GetTwoRandomHamsters();
            return Ok(hamsters);
        }

    }
}

﻿using DataAccess.Data;
using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.HamsterRepository;

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
            await _hamsterRepo.AddHamster(hamster);

            return Ok(await _hamsterRepo.GetHamsters());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHamster(Hamster hamster, int id)
        {
            var dbHamster =await _hamsterRepo.UpdateHamster(hamster, id);

            if (dbHamster == null)
                return NotFound("No hamster here.");

             return Ok(await _hamsterRepo.GetHamsters());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHamster(int id)
        {
            var dbHamster = await _hamsterRepo.DeleteHamster(id);

            if (dbHamster == null)
                return NotFound("No hamster here.");

            return Ok(await _hamsterRepo.GetHamsters());
        }

    }
}

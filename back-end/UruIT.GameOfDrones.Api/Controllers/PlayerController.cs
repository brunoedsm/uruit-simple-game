using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UruIT.GameOfDrones.Domain.Entities;
using UruIT.GameOfDrones.Business.Services;
using UruIT.GameOfDrones.Domain.Contracts.Services;

namespace UruIT.GameOfDrones.Api.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;

        public PlayerController(IPlayerService serviceDI)
        {
            _service = serviceDI;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        // GET: api/Player/id
        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _service.Get(id));
        }

        // POST: api/Player
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Player player)
        {
            return Ok(await _service.Add(player));
        }

        // PUT: api/Player/5
        [HttpPut]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Player player)
        {
            Player entryToUpdate = (Player)_service.Get(id).Result.Data;

            return Ok(await _service.Update(entryToUpdate, player));
        }

        // DELETE: api/Player/5
        [HttpDelete]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Player player = (Player)_service.Get(id).Result.Data;

            return Ok(await _service.Delete(player));
        }
    }

}
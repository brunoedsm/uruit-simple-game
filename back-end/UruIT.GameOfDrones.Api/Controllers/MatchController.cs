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
    [Route("api/match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _service;

        public MatchController(IMatchService serviceDI)
        {
            _service = serviceDI;
        }

        // GET: api/Match
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        // GET: api/Match/id
        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _service.Get(id));
        }

        // POST: api/Match
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Match match)
        {
            return Ok(await _service.Add(match));
        }

        // PUT: api/Match/5
        [HttpPut]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Match match)
        {
            Match entryToUpdate = (Match)_service.Get(id).Result.Data;

            return Ok(await _service.Update(entryToUpdate, match));
        }

        // DELETE: api/Match/5
        [HttpDelete]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Match match = (Match)_service.Get(id).Result.Data;

            return Ok(await _service.Delete(match));
        }
    }

}
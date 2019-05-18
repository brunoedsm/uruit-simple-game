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
    [Route("api/round")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly IRoundService _service;

        public RoundController(IRoundService serviceDI)
        {
            _service = serviceDI;
        }

        // GET: api/Round
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        // GET: api/Round/id
        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _service.Get(id));
        }

        // POST: api/Round
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Round round)
        {
            return Ok(await _service.Add(round));
        }

        // PUT: api/Round/5
        [HttpPut]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Round round)
        {
            Round entryToUpdate = (Round)_service.Get(id).Result.Data;
           
            return Ok(await _service.Update(entryToUpdate, round));
        }

        // DELETE: api/Round/5
        [HttpDelete]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
           Round round  = (Round)_service.Get(id).Result.Data;

          return Ok(await _service.Delete(round));
        }
    }

}
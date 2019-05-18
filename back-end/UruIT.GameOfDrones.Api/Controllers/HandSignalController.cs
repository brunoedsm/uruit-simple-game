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
    [Route("api/handsignal")]
    [ApiController]
    public class HandSignalController : ControllerBase
    {
        private readonly IHandSignalService _service;

        public HandSignalController(IHandSignalService serviceDI)
        {
            _service = serviceDI;
        }

        // GET: api/HandSignal
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        // GET: api/HandSignal/id
        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _service.Get(id));
        }

        // POST: api/HandSignal
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HandSignal handSignal)
        {
            return Ok(await _service.Add(handSignal));
        }

        // PUT: api/HandSignal/5
        [HttpPut]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] HandSignal handSignal)
        {
            HandSignal entryToUpdate = (HandSignal)_service.Get(id).Result.Data;

            return Ok(await _service.Update(entryToUpdate, handSignal));
        }

        // DELETE: api/HandSignal/5
        [HttpDelete]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            HandSignal handSignal = (HandSignal)_service.Get(id).Result.Data;

            return Ok(await _service.Delete(handSignal));
        }
    }

}
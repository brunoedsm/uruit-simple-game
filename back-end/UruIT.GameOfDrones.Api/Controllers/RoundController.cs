using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UruIT.GameOfDrones.Domain.Entities;
using UruIT.GameOfDrones.Business.Services;
using UruIT.GameOfDrones.Domain.Contracts.Services;
using UruIT.GameOfDrones.Domain.Common;
using Microsoft.Extensions.Logging;

namespace UruIT.GameOfDrones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundController : ControllerBase
    {
        private readonly IRoundService _service;
        private readonly ILogger<RoundController> _log;
        public RoundController(IRoundService serviceDI, ILogger<RoundController> log)
        {
            _service = serviceDI;
            _log = log;
        }

        // GET: api/Round
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Prepare(await _service.GetAll());
        }

        // GET: api/Round/id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Prepare(await _service.Get(id));
        }

        // POST: api/Round
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Round round)
        {
            return Prepare(await _service.Add(round));
        }

        // POST: api/Round/filter
        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> Filter([FromBody] Round round)
        {
            return Prepare(await _service.Filter(round));
        }
        
        // PUT: api/Round/5
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Round round)
        {
            Round entryToUpdate = (Round)_service.Get(id).Result.Data;

            return Prepare(await _service.Update(entryToUpdate, round));
        }

        // DELETE: api/Round/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Round round = (Round)_service.Get(id).Result.Data;

            return Prepare(await _service.Delete(round));
        }

        private IActionResult Prepare(RequestResult result)
        {
            if (result.Status == StatusResult.Success)
                return Ok(result);
            else
            {
                var resource = string.Format("{0}/{1}", this.ControllerContext.RouteData.Values["controller"].ToString(),
                                             this.ControllerContext.RouteData.Values["action"].ToString());
                var messages = string.Empty;
                foreach (var m in result.Messages)
                {
                    messages += m.Text + "\n";
                }
                _log.LogError(string.Format("Accessing: {0}, Status: {1}, Errors:{2}", resource, result.Status.ToString(), messages));
                return new BadRequestObjectResult(result);
            }
        }
    }
}
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
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _service;
        private readonly ILogger<PlayerController> _log;
        public PlayerController(IPlayerService serviceDI, ILogger<PlayerController> log)
        {
            _service = serviceDI;
            _log = log;
        }

        // GET: api/Player
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Prepare(await _service.GetAll());
        }

        // GET: api/Player/id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Prepare(await _service.Get(id));
        }

        // POST: api/Player
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Player player)
        {
            return Prepare(await _service.Add(player));
        }

        // POST: api/Player/filter
        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> Filter([FromBody] Player player)
        {
            return Prepare(await _service.Filter(player));
        }

        // PUT: api/Player/5
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Player player)
        {
            Player entryToUpdate = (Player)_service.Get(id).Result.Data;

            return Prepare(await _service.Update(entryToUpdate, player));
        }

        // DELETE: api/Player/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            Player player = (Player)_service.Get(id).Result.Data;

            return Prepare(await _service.Delete(player));
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

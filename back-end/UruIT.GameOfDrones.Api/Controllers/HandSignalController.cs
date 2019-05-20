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
    public class HandSignalController : ControllerBase
    {
        private readonly IHandSignalService _service;
        private readonly ILogger<HandSignalController> _log;
        public HandSignalController(IHandSignalService serviceDI, ILogger<HandSignalController> log)
        {
            _service = serviceDI;
            _log = log;
        }

        // GET: api/HandSignal
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Prepare(await _service.GetAll());
        }

        // GET: api/HandSignal/id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Prepare(await _service.Get(id));
        }

        // POST: api/HandSignal
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HandSignal handSignal)
        {
            return Prepare(await _service.Add(handSignal));
        }

         // POST: api/HandSignal/filter
        [HttpPost]
        [Route("filter")]
        public async Task<IActionResult> Filter([FromBody] HandSignal handSignal)
        {
            return Prepare(await _service.Filter(handSignal));
        }

        // PUT: api/HandSignal/5
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] HandSignal handSignal)
        {
            HandSignal entryToUpdate = (HandSignal)_service.Get(id).Result.Data;

            return Prepare(await _service.Update(entryToUpdate, handSignal));
        }

        // DELETE: api/HandSignal/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            HandSignal handSignal = (HandSignal)_service.Get(id).Result.Data;

            return Prepare(await _service.Delete(handSignal));
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

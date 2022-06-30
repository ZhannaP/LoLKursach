using LOL.Domain.Contracts.Services;
using LOL.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LOL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChempionsController : ControllerBase
    {
        private readonly IChempionService chempionService;

        public ChempionsController(IChempionService chempionService)
        {
            this.chempionService = chempionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChempionModel>>> GetAll()
        {
            return Ok(await chempionService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChempionModel>> GetById(int id)
        {
            return Ok(await chempionService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<ChempionModel>> Create([FromBody]ChempionModel model)
        {
            return Ok(await chempionService.CreateAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]ChempionModel model)
        {
            await chempionService.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await chempionService.DeleteAsync(id);
            return Ok();
        }
    }
}

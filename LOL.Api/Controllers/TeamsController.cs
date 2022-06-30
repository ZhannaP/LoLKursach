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
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService teamService;

        public TeamsController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TeamModel>>> GetAll()
        {
            return Ok(await teamService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamModel>> GetById(int id)
        {
            return Ok(await teamService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<TeamModel>> Create([FromBody] TeamModel model)
        {
            return Ok(await teamService.CreateAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] TeamModel model)
        {
            await teamService.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await teamService.DeleteAsync(id);
            return Ok();
        }
    }
}

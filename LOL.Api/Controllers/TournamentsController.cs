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
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentService tournamentService;

        public TournamentsController(ITournamentService tournamentService)
        {
            this.tournamentService = tournamentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TournamentModel>>> GetAll()
        {
            return Ok(await tournamentService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TournamentModel>> GetById(int id)
        {
            return Ok(await tournamentService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<TournamentModel>> Create([FromBody] TournamentModel model)
        {
            return Ok(await tournamentService.CreateAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] TournamentModel model)
        {
            await tournamentService.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await tournamentService.DeleteAsync(id);
            return Ok();
        }
    }
}

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
    public class DictionariesController : ControllerBase
    {
        private readonly IDictionariesService dictionariesService;

        public DictionariesController(IDictionariesService dictionariesService)
        {
            this.dictionariesService = dictionariesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoleModel>>> GetAll()
        {
            return Ok(await dictionariesService.GetAllRoles());
        }
    }
}

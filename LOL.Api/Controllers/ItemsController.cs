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
    public class ItemsController : ControllerBase
    {
        private readonly IItemService itemService;

        public ItemsController(IItemService itemService)
        {
            this.itemService = itemService;
        }


        [HttpGet]
        public async Task<ActionResult<List<ItemsModel>>> GetAll()
        {
            return Ok(await itemService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemsModel>> GetById(int id)
        {
            return Ok(await itemService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<ItemsModel>> Create([FromBody] ItemsModel model)
        {
            return Ok(await itemService.CreateAsync(model));
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ItemsModel model)
        {
            await itemService.UpdateAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await itemService.DeleteAsync(id);
            return Ok();
        }
    }
}

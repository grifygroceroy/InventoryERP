using InventoryERP.API.Applogics.Common.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> AddItem([FromBody] AddItemCommand query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}

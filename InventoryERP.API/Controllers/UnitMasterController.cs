using InventoryERP.API.Applogics.Common.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryERP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitMasterController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> AddUnitMaster([FromBody] AddUnitMasterCommand query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}

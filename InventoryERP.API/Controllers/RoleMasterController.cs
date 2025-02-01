using Common.Model;
using InventoryERP.API.Applogics.Common.Command;
using InventoryERP.API.Applogics.Common.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryERP.API.Controllers
{
    [Route(ApiRoutes.v1)]
    public class RoleMasterController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> AddRoleMaster([FromBody] AddRoleMasterCommand query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpGet]
        public async Task<ActionResult> GetRoleMaster([FromQuery] GetRoleMasterQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRoleMaster([FromBody] UpdateRoleMasterCommand query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteRoleMaster([FromForm] DeleteRoleMasterCommand query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}

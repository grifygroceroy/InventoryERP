using Common.Model;
using InventoryERP.API.Applogics.Common.Command;
using InventoryERP.API.Applogics.Common.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryERP.API.Controllers
{
    [Route(ApiRoutes.v1)]
    [AllowAnonymous]
    public class AuthController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> RefreshToken([FromQuery] AuthQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
        [HttpPost]
        public async Task<ActionResult> AddUserMaster([FromForm] AddUserMasterCommand query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}

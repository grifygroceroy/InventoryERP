using Common.Model;
using InventoryERP.API.Applogics.Common.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryERP.API.Controllers
{
    [Route(ApiRoutes.v1)]
    public class PartyController  : BaseController
    {
        [HttpPost]
        public async Task<ActionResult> AddParty([FromBody] AddPartyCommand query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}

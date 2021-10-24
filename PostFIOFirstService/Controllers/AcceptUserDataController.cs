using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostFIOFirstService.RequestPayloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostFIOFirstService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcceptUserDataController : Controller
    {
        private readonly IMediator mediator;

        public AcceptUserDataController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("AcceptUserData")]
        public async Task<IActionResult> AcceptUserData([FromBody] AcceptUserDataRequestPayload payload)
        {
            await mediator.Send(payload);
        }
    }
}

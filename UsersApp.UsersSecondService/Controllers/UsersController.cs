using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UsersApp.UsersSecondService.RequestPayloads;

namespace UsersApp.UsersSecondService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator mediator;

        public UsersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Получить пагинированный список сотрудников по организации.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetPagedUserDataOfOrganization")]
        public async Task<IActionResult> GetPagedUserDataOfOrganization([FromBody] GetPagedUserDataOfOrganizationRequestPayload payload)
        {
            return await mediator.Send(payload);
        }
    }
}

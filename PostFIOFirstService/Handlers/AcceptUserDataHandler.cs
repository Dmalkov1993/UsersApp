using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UsersApp.PostFIOFirstService.RequestPayloads;
using UsersApp.Infrastructure.Handlers;

namespace UsersApp.PostFIOFirstService.Handlers
{
    public class AcceptUserDataHandler : BaseHandler, IRequestHandler<AcceptUserDataRequestPayload, IActionResult>
    {
        public async Task<IActionResult> Handle(AcceptUserDataRequestPayload request, CancellationToken cancellationToken)
        {
            // Тут нужно будет отправить данные в шину IBus
            return Ok("Всё хорошо");
        }
    }
}

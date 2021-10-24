using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UsersApp.Infrastructure.Handlers;
using UsersApp.UsersSecondService.RequestPayloads;

namespace UsersApp.UsersSecondService.Handlers
{
    public class GetPagedUserDataOfOrganizationRequestHandler
        : BaseHandler, IRequestHandler<GetPagedUserDataOfOrganizationRequestPayload, IActionResult>
    {
        public Task<IActionResult> Handle(GetPagedUserDataOfOrganizationRequestPayload request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using UsersApp.Infrastructure.Handlers;
using UsersApp.Infrastructure.RequestPayloads;

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

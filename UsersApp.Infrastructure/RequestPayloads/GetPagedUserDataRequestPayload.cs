using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace UsersApp.Infrastructure.RequestPayloads
{
    public class GetPagedUserDataOfOrganizationRequestPayload : IRequest<IActionResult>
    {
        public int OrganizationId { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
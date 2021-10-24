using MediatR;
using PostFIOFirstService.RequestPayloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PostFIOFirstService.Handlers
{
    public class AcceptUserDataHandler : IRequestHandler<AcceptUserDataRequestPayload, string>
    {
        public Task<string> Handle(AcceptUserDataRequestPayload request, CancellationToken cancellationToken)
        {
            
        }
    }
}

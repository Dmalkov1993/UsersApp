using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UsersApp.PostFIOFirstService.RequestPayloads;
using UsersApp.Infrastructure.Handlers;
using FluentValidation;

namespace UsersApp.PostFIOFirstService.Handlers
{
    public class AcceptUserDataHandler : BaseHandler, IRequestHandler<AcceptUserDataRequestPayload, IActionResult>
    {
        private readonly IValidator<AcceptUserDataRequestPayload> payloadValidator;

        public AcceptUserDataHandler(IValidator<AcceptUserDataRequestPayload> payloadValidator)
        {
            this.payloadValidator = payloadValidator;
        }

        public async Task<IActionResult> Handle(AcceptUserDataRequestPayload requestPayload, CancellationToken cancellationToken)
        {
            var validationResult = payloadValidator.Validate(requestPayload);
            if (!validationResult.IsValid)
                return BadRequest(validationResult);

            // Тут нужно будет отправить данные в шину IBus
            var settedId = 999;
            return Ok($"Пользователь успешно добавлен, присвоенный ID: {settedId}");
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using UsersApp.PostFIOFirstService.RequestPayloads;
using FluentValidation;
using Serilog;
using UsersApp.Infrastructure.Handlers;
using MassTransit;
using UsersApp.Infrastructure.RabbitMqDTO;
using AutoMapper;

namespace UsersApp.PostFIOFirstService.Handlers
{
    public class AcceptUserDataHandler : BaseHandler, IRequestHandler<AcceptUserDataRequestPayload, IActionResult>
    {
        private readonly IValidator<AcceptUserDataRequestPayload> payloadValidator;
        private readonly IBus bus;
        private readonly IMapper mapper;

        public AcceptUserDataHandler(IValidator<AcceptUserDataRequestPayload> payloadValidator, IBus bus, IMapper mapper)
        {
            this.payloadValidator = payloadValidator;
            this.bus = bus;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Handle(AcceptUserDataRequestPayload requestPayload, CancellationToken cancellationToken)
        {
            var validationResult = payloadValidator.Validate(requestPayload);
            if (!validationResult.IsValid)
                return BadRequest(validationResult);

            // Если валидация прошла, можно посылать на второй сервис данные.
            Log.Information($"Sending user data to secondService: {requestPayload.ToString()}");

            await bus.Publish(mapper.Map<CreateUserInDbTaskData>(requestPayload));

            // Тут нужно будет отправить данные в шину IBus
            var settedId = 999;
            return Ok($"Пользователь успешно добавлен, присвоенный ID: {settedId}");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace UsersApp.Infrastructure.Handlers
{
    public class BaseHandler
    {
        protected BadRequestObjectResult BadRequest(string badRequestMessage)
        {
            return new BadRequestObjectResult(badRequestMessage);
        }

        protected BadRequestObjectResult BadRequest(ValidationResult validationResult)
        {
            var message = $"Следующие реквизиты не прошли валидацию: " +
                $"{string.Join(" ", validationResult.Errors.Select(failure => failure.ErrorMessage))}";

            return new BadRequestObjectResult(message);
        }

        protected OkObjectResult Ok(string okMessage)
        {
            return new OkObjectResult(okMessage);
        }
    }
}

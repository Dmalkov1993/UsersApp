using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersApp.Infrastructure.Handlers
{
    public class BaseHandler
    {
        protected BadRequestObjectResult BadRequest(string badRequestMessage)
        {
            return new BadRequestObjectResult(badRequestMessage);
        }

        protected OkObjectResult Ok(string okMessage)
        {
            return new OkObjectResult(okMessage);
        }
    }
}

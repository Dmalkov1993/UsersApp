using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostFIOFirstService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AcceptUserDataController : Controller
    {
        [HttpPost]
        [Route("AcceptUserData")]
        public IActionResult AcceptUserData()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coinbase.Controllers
{
	[ApiController]
    public class HealthCheckController : Controller
    {
        // GET: /<controller>/
        [HttpGet("health")]
        public IActionResult Index()
        {
            return Ok("Success v11");
        }
    }
}

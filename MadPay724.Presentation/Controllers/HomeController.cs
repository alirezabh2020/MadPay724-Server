using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadPay724.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            return new string[] { "Alireza", "Zahra" };
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id) { return "value"; }

        [HttpPut("{id}")]
        public async Task<string> Put(int id, [FromBody] string value) { return value; }
    }
}

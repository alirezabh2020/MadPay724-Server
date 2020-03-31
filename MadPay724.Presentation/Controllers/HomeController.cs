using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Repo.Infrastructure;
using MadPay724.Data.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using MadPay724.Data.Models;
using MadPay724.Services.Auth.Interface;
using MadPay724.Services.Auth.Repo;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadPay724.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly IUnitOfWork<MadPayDbContext> _db;
        private readonly IAuthService _authService;
        public HomeController(IUnitOfWork<MadPayDbContext> dbContext, IAuthService authService)
        {
            _db = dbContext;
            _authService = authService;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {

            var user = new User()
            {
                Name = "Alireza",
                UserName = "alirezabh",
                Address = "",
                City = "Tehran",
                Gender = "Male",
                DateOfBirth = "",
                PasswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, },
                PasswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, },
                PhoneNumber = "",
                IsActive = true,
                Status = true
            };
            var u = await _authService.Register(user, "alirezabh");

            return Ok(u);
        }

    }
}
    

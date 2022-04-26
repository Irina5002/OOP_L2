using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Lab_2;
using Microsoft.Extensions.Configuration;

namespace Lab_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserAdd _userService;
        private readonly IConfiguration _configuration;
        private readonly Mess getMessage;

        public UserController(IUserAdd userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
            getMessage = new Mess();
            _configuration.GetSection(Mess.Message).Bind(getMessage);
        }

        [HttpGet("hello")]
        public string GetHello([FromQuery(Name = "name")] string userName)
        {
            return _userService.Hello(getMessage.Text, userName);
        }

        [HttpPost("psyhAge")]
        public User PostPsyhAge([FromBody] User user)
        {
            return _userService.PsyhAge(user);
        }
    }
}

using CreditCardService.Middlewares;
using CreditCardService.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardService.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private JwtService _jwtService;
        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }
        [HttpPost("Login")]
        public IActionResult Login(UserViewModel user )
        {
            string token = string.Empty;
            if(user.UserName == "a" && user.Password== "a")
            {
                token = _jwtService.CreateToken();
                return Ok(new { status = true, token = token });
            }
            return BadRequest();
        }
    }
}

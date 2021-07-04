using CreditCardService.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BankingController : ControllerBase
    {
        [HttpGet("WithdrawMoney")]
        public IActionResult WithdrawMoney(CreditCardViewModel creditCard)
        {
            return Ok();
        }
    }
}

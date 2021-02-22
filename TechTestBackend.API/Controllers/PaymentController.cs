using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechTestBackend.API.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechTestBackend.API.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
       
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentDto model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            return Ok();

        }
    }
}

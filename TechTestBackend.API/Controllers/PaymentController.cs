using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TechTestBackend.API.Dtos;
using TechTestBackend.Domain.Entities;
using TechTestBackend.Domain.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechTestBackend.API.Controllers
{
    [Route("api/payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       
        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] PaymentDto model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (DateTime.Now > model.ExpirationDate)
                {
                    return BadRequest("Expiration Date cannot be in the past");
                }

                if (model.Amount <= 0)
                {
                    return BadRequest("Amount must be a positive number");
                }

                var paymentToProcess = JObject.FromObject(model, new JsonSerializer { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }).ToObject<Payment>();


                var processedPayment = _unitOfWork.Payments.ProcessPayment(paymentToProcess);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           

        }
    }
}

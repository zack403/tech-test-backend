using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestBackend.API.Dtos
{
    public class PaymentResponseDto
    {
        public bool IsProcessed { get; set; }
        public PaymentStateDto PaymentState { get; set; }
    }
}

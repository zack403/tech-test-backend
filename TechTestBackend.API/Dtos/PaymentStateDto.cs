using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTestBackend.Domain.Enum;

namespace TechTestBackend.API.Dtos
{
    public class PaymentStateDto
    {
        public PaymentStateEnum PaymentState { get; set; }
        public DateTime PaymentStateDate { get; set; }
    }
}

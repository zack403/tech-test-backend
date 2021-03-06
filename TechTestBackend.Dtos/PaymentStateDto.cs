using System;
using System.Collections.Generic;
using System.Text;
using TechTestBackend.Domain.Enum;

namespace TechTestBackend.Dtos
{
    public class PaymentStateDto
    {
        public PaymentStateEnum PaymentState { get; set; }
        public DateTime PaymentStateDate { get; set; }
    }
}

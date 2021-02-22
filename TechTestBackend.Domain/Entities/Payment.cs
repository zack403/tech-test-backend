using System;
using System.Collections.Generic;
using System.Text;
using TechTestBackend.Domain.Enum;

namespace TechTestBackend.Domain.Entities
{
    public class Payment
    {
        public string Id { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public decimal Amount { get; set; }
        public PaymentState State { get; set; }
    }
}

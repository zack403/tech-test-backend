using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TechTestBackend.API.Dtos
{
    public class PaymentDto
    {
        [Required]
        [CreditCard]
        public string CreditCardNumber { get; set; }
        [Required]
        public string CardHolder { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime ExpirationDate { get; set; }
        [MaxLength(3), MinLength(3)]
        public string SecurityCode { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
}

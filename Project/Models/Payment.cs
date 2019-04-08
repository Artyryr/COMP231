using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage = "The Card Number is required.")]
        [CreditCard]
        public int CardNumber { get; set; }

        [Required(ErrorMessage = "The Billing Address is required.")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "The Date is required.")]
        public DateTime ExpiryDate { get; set; }

        [Required(ErrorMessage = "The Province is required.")]
        [MinLength(3)]
        [MaxLength(3)]
        public int CVV { get; set; }

        [Required(ErrorMessage = "The Name is Required.")]
        public string NameOnCard { get; set; }

        [Required(ErrorMessage = "The ZIP is required.")]
        [RegularExpression("[a-zA-Z][0-9][a-zA-Z] ?[0-9][a-zA-Z][0-9]", ErrorMessage = "PLease type ZIP in format \"M1G 3T8\'")]
        public string PostalCode { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>  
    ///  Represents Payment Class.  
    /// </summary>  
    public class Payment
    {
        ///<value>
        /// Id of Payment
        ///</value>
        [Key]
        public int PaymentId { get; set; }
        ///<value>
        /// Id of user that is making payment
        ///</value>
        public string UserId { get; set; }

        ///<value>
        /// Cardnumber
        ///</value>
        [Required(ErrorMessage = "The Card Number is required.")]
        [RegularExpression("[0-9]{4}[-. ]?[0-9]{4}[-. ]?[0-9]{4}[-. ]?[0-9]{4}[-. ]?")]
        public string CardNumber { get; set; }

        ///<value>
        /// BIlling address of a credit card
        ///</value>
        [Required(ErrorMessage = "The Billing Address is required.")]
        public string BillingAddress { get; set; }

        ///<value>
        /// Expiry date of a credit card
        ///</value>
        [Required(ErrorMessage = "The Date is required.")]
        public DateTime ExpiryDate { get; set; }

        ///<value>
        /// CVV date of a credit card
        ///</value>
        [Required(ErrorMessage = "The Province is required.")]
        public int CVV { get; set; }

        ///<value>
        /// Name on the credit card
        ///</value>
        [Required(ErrorMessage = "The Name is Required.")]
        public string NameOnCard { get; set; }

        ///<value>
        /// Postal code of Billing Address
        ///</value>
        [Required(ErrorMessage = "The ZIP is required.")]
        [RegularExpression("[a-zA-Z][0-9][a-zA-Z] ?[0-9][a-zA-Z][0-9]", ErrorMessage = "PLease type ZIP in format \"M1G 3T8\'")]
        public string PostalCode { get; set; }
    }
}

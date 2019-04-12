using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Represents registered user
    /// </summary>
    public class GeneralUser : IdentityUser
    {
        /// <value>
        /// First Name of the user
        /// </value>
        [Required(ErrorMessage = "The First Name is required.")]
        public string FirstName { get; set; }

        /// <value>
        /// Last Name of the user
        /// </value>
        [Required(ErrorMessage = "The Last Name is required.")]
        public string LastName { get; set; }

        /// <value>
        /// Telephone of the user
        /// </value>
        [Required(ErrorMessage = "The Telephone is required.")]
        [RegularExpression(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})",
            ErrorMessage = "Please put telephone in format \"647-333-4444\" or \"6473334444\" ")]
        public string Telephone { get; set; }

        /// <value>
        /// Apartment of the user
        /// </value>
        [Required(ErrorMessage = "The Apartment is required.")]
        public string Apartment { get; set; }

        /// <value>
        /// Street of the user
        /// </value>
        [Required(ErrorMessage = "The Street is required.")]
        public string Street { get; set; }

        /// <value>
        /// City of the user
        /// </value>
        [Required(ErrorMessage = "The City is required.")]
        public string City { get; set; }

        /// <value>
        /// ZIP of the user
        /// </value>
        [Required(ErrorMessage = "The ZIP is required.")]
        [RegularExpression("[a-zA-Z][0-9][a-zA-Z] ?[0-9][a-zA-Z][0-9]", ErrorMessage ="PLease type ZIP in format \"M1G 3T8\'")]
        public string ZIP { get; set; }

        /// <value>
        /// Province of the user
        /// </value>
        [Required(ErrorMessage = "The Province is required.")]
        public string Province { get; set; }

        /// <value>
        /// Discount of the user
        /// </value>
        public double Discount { get; set; }
    }
}

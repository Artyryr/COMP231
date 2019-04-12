using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{

    /// <summary>
    /// Model for the registration page
    /// </summary>
    public class RegistrationModel
    {
        ///<value>
        /// Email of a new user
        ///</value>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        ///<value>
        /// Password of a new user
        ///</value>
        [Required]
        [UIHint("password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])" +
            "(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])" +
            "(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$",
            ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: " +
            "upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        ///<value>
        /// URL for the next operation
        ///</value>
        public string ReturnUrl { get; set; } = "/";

        ///<value>
        /// Confirmed password
        ///</value>
        [UIHint("Password")]
        [DataType(DataType.Password)]
        public string ConfirmationPassword { get; set; }

        /// <summary>
        /// Representation of user model
        /// </summary>
        public GeneralUser User { get; set; }
    }
}

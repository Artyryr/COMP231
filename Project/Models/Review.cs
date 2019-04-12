using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Model of a review for a service
    /// </summary>
    public class Review
    {
        ///<value>
        /// Id of a Review
        ///</value>
        [Key]
        public int ReviewId { get; set; }

        ///<value>
        /// Name of the reveiwer
        ///</value>
        public string UserName { get; set; }

        ///<value>
        /// Rating 
        ///</value>
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        ///<value>
        /// Text of the reveiw
        ///</value>
        [Required]
        public string ReviewText { get; set; }

        ///<value>
        /// Id of a reviewed service
        ///</value>
        public int ServiceId { get; set; }

        ///<value>
        /// Date of a Review
        ///</value>
        public DateTime Date { get; set; }

        ///<value>
        /// Id of the user that has written the review
        ///</value>
        public string UserId { get; set; }


        /// <summary>
        /// Method that adds a user to the review object
        /// </summary>
        /// <param name="userName">User name</param>
        public void AddUser(string userName)
        {
            UserName = userName;
        }
    }
}

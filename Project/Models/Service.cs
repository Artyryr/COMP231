using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// MOdel of a service
    /// </summary>
    public class Service
    {
        ///<value>
        /// Id of a specific service
        ///</value>
        [Key]
        public int ServiceId { get; set; }
        ///<value>
        /// Service Name of a specific service
        ///</value>
        public string ServiceName { get; set; }
        ///<value>
        /// Id of service type
        ///</value>
        public int ServiceTypeId { get; set; }
        ///<value>
        /// Price Per Hour of a specific service
        ///</value>
        public double PricePerHour { get; set; }
        ///<value>
        /// Description of a specific service
        ///</value>
        public string Description { get; set; }
        ///<value>
        /// Reviews of a specific service
        ///</value>
        public List<Review> Reviews { get; set; }

        /// <summary>
        /// Basic constructor for a service
        /// </summary>
        public Service()
        {

        }
        /// <summary>
        /// service constructor
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serviceTypeId"></param>
        /// <param name="pricePerHour"></param>
        public Service(string serviceName, int serviceTypeId, double pricePerHour)
        {
            ServiceName = serviceName;
            ServiceTypeId = serviceTypeId;
            PricePerHour = pricePerHour;
        }
        /// <summary>
        /// Service constructor
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="serviceTypeId"></param>
        /// <param name="pricePerHour"></param>
        /// <param name="description"></param>
        public Service(string serviceName, int serviceTypeId, double pricePerHour, string description)
        {
            ServiceName = serviceName;
            ServiceTypeId = serviceTypeId;
            PricePerHour = pricePerHour;
            Description = description;
        }

        /// <summary>
        /// Add list of reviews to a service
        /// </summary>
        /// <param name="reviews"></param>
        public void AddReviews(List<Review> reviews)
        {
            Reviews = reviews;
        }

        /// <summary>
        /// Add one review to a service
        /// </summary>
        /// <param name="review"></param>
        public void AddOneReview(Review review)
        {
            Reviews.Add(review);
        }
    }
}

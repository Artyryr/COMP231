using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Interface for handeling interactions with database
    /// </summary>
    public interface IServiceRepository
    {
        ///<value>
        /// Gets list of services
        ///</value>
        IQueryable<Service> Services { get; }
        ///<value>
        /// Gets list of service types
        ///</value>
        IQueryable<ServiceType> ServiceTypes { get; }
        ///<value>
        /// Gets list of requested services
        ///</value>
        IQueryable<RequestedService> RequestedServices { get; }

        ///<value>
        /// Gets list of reviews
        ///</value>
        IQueryable<Review> Reviews { get; }

        ///<value>
        /// Gets list of payments
        ///</value>
        IQueryable<Payment> Payments { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        void AddService(Service service);
        /// <summary>
        /// Removes service
        /// </summary>
        /// <param name="id">ServiceID</param>
        void RemoveService(int id);
        /// <summary>
        /// Adds ServiceType
        /// </summary>
        /// <param name="serviceType">ServiceType</param>
        void AddServiceType(ServiceType serviceType);
        /// <summary>
        /// Removes ServiceType 
        /// </summary>
        /// <param name="id">ServiceType ID</param>
        void RemoveServiceType(int id);
        /// <summary>
        /// Adds Reqeusted Service
        /// </summary>
        /// <param name="requestedService">Requested Service</param>
        void AddRequestedService(RequestedService requestedService);
        /// <summary>
        /// Removes Requested Service
        /// </summary>
        /// <param name="id">Requested Service ID</param>
        void RemoveRequestedService(int id);
        /// <summary>
        /// Adds a Review
        /// </summary>
        /// <param name="review">Review</param>
        void AddReview(Review review);
        /// <summary>
        /// Adds Payment
        /// </summary>
        /// <param name="payment">Payment</param>
        void AddPayment(Payment payment);
    }
}

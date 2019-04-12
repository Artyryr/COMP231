using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>  
    ///  This provides a representation of database tables in App.
    /// </summary>  
    public class ApplicationDbContext:DbContext
    {
        /// <summary>
        /// Basic constructor for class
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        /// <summary>
        /// Representation Of Services table
        /// </summary>
        public DbSet<Service> Services { get; set; }

        /// <summary>
        /// Representation Of ServiceTypes table
        /// </summary>
        public DbSet<ServiceType> ServiceTypes { get; set; }

        /// <summary>
        /// Representation Of RequestedServices table
        /// </summary>
        public DbSet<RequestedService> RequestedServices { get; set; }

        /// <summary>
        /// Representation Of Reviews table
        /// </summary>
        public DbSet<Review> Reviews { get; set; }

        /// <summary>
        /// Representation Of Payments table
        /// </summary>
        public DbSet<Payment> Payments { get; set; }
    }
}

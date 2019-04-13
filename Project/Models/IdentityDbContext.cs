using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    /// <summary>
    /// Access to Users Database
    /// </summary>
    public class IdentityDbContext : IdentityDbContext<GeneralUser>
    {
        /// <summary>
        /// Constructor for a IdentityDbContext class
        /// </summary>
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options) { }
    }
}

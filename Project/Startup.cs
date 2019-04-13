using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Project.Models;

namespace Project
{
    /// <summary>
    /// Main Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures services and the app's request pipeline.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration) =>
           Configuration = configuration;

        /// <value>
        /// Instance of a configuration
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configure services used in the app
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:Users:ConnectionString"]));

            services.AddIdentity<GeneralUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
                   Configuration["Data:Services:ConnectionString"]));
            services.AddTransient<IServiceRepository, ServiceRepository>();

            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
            });

            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default",
                                template: "{controller=Home}/{action=Index}");
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}

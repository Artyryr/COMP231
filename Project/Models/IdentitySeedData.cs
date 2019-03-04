using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class IdentitySeedData
    {
        private const string artur = "ArtyryrF@gmail.com";
        private const string user1Password = "Password123!";
        private const string testUser = "Test@gmail.com";
        private const string testPassword = "Password123!";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            UserManager<GeneralUser> userManager = app.ApplicationServices
               .GetRequiredService<UserManager<GeneralUser>>();

            GeneralUser user = await userManager.FindByEmailAsync(artur);
            if (user == null)
            {
                user = new GeneralUser { Email = artur, UserName = artur, FirstName = "Artur", LastName = "Fundukyan", };
                await userManager.CreateAsync(user, user1Password);
            }

            GeneralUser test = await userManager.FindByEmailAsync(testUser);

            if (test == null)
            {
                test = new GeneralUser { Email = testUser, UserName = testUser, FirstName = "Test", LastName = "Last Test", };
                await userManager.CreateAsync(test, testPassword);
            }
        }
    }
}

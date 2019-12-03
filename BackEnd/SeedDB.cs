using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections;
using WebApi2.Models;

namespace WebApi2.Data
{
    public class SeedDB
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<long>>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<ScrapOnlineContext>();
            context.Database.EnsureCreated();

            string[] roleNames = { "Admin", "Vendor", "Customer" };
            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist =  await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                  var roleResult = await RoleManager.CreateAsync(new IdentityRole<long>(roleName));
                }
            }

            
            if(!context.Users.Any())
            {
                string email = "siddiqui_shujaat91@hotmai.com";
                ApplicationUser user = new ApplicationUser()
                {
                    Email = email ,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin",

                };
                IdentityResult result =  await userManager.CreateAsync(user, "Admin@123..");
                if(result.Succeeded)
                {
                    user = await userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
               
            }
        } 
    }
}
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi2.Data;
using WebApi2.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticateController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole<long>> roleManager;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<long>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if(user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                };

                foreach (var userRole in await userManager.GetRolesAsync(user))
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    var role = await roleManager.FindByNameAsync(userRole);
                    if(role != null)
                    {
                        var roleClaims = await roleManager.GetClaimsAsync(role);
                        foreach(Claim roleClaim in roleClaims)
                        {
                            authClaims.Add(roleClaim);
                        }
                    }
                }
                
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YVBy0OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SBM="));

                var token = new JwtSecurityToken(
                    issuer: "ScrapOnline",
                    audience: "ScrapOnline",
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,                    
                    signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("Signup")]
        public async Task<IActionResult> Signup([FromBody] SignUp model)
        {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = model.Email ,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = model.Username  
                };
                IdentityResult result =  await userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    user = await userManager.FindByEmailAsync(model.Email);
                    if (user != null)
                    {
                        await userManager.AddToRoleAsync(user, model.Role);
                    }
                }
                return await Login(new LoginModel(){ Password = model.Password,Username = model.Username});
        }
    }
}
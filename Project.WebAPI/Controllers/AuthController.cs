using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Project.WebAPI.Context;
using Project.WebAPI.DTOs;
using Project.WebAPI.Helpers;
using Project.WebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : CustomBaseController
    {
        private readonly CodeDbContext _context;
        public IConfiguration _configuration;

        public AuthController(CodeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]

        public async Task<IActionResult> Login(AppUserDto appUser)
        {
            if (appUser != null && appUser.UserName != null && appUser.Password != null)
            {
                AppUser user = await GetUser(appUser.UserName, appUser.Password);
                
                Jwt jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                if(user != null)
                {
                    Claim[] claims = new[]
                    {
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, jwt.Subject),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", appUser.UserName),
                        new Claim("Password", appUser.Password)
                       
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken
                                    (
                                        jwt.Issuer,
                                        jwt.Audience,
                                        claims,
                                        expires : DateTime.Now.AddMinutes(20),
                                        signingCredentials : signIn
                                    );

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }

            }

  
            return BadRequest("Invalid Credentials");
           

        }

        [NonAction]
        public async Task<AppUser> GetUser(string userName, string Password)
        {
            return await _context.AppUsers.FirstOrDefaultAsync( a=> a.UserName == userName && a.Password == Password);
        }


    }
}

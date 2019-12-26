using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.PL.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using TaskManager.PL.Auth;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

namespace TaskManager.PL.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private List<AuthModel> people = new List<AuthModel>
        {
            new AuthModel { Login="admin@gmail.com", Password="12345"},
            new AuthModel { Login="test_login", Password="12345"}
        };

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]AuthModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.Login == "test_login" && user.Password == "12345")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:60359",
                    audience: "http://localhost:60359",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, Login = user.Login });
            }
            else
            {
                return Unauthorized();
            }
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            AuthModel person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
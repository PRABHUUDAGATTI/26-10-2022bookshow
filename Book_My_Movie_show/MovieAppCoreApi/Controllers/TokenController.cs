using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using Book_Show_Entity;
using Book_Show_DAL;
using System.Linq;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly Book_show_db _context;

        public TokenController(IConfiguration config, Book_show_db context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Post(UserDetails _userData)
        {

            if (_userData != null && _userData.UserEmail != null && _userData.UserPhoneNo != null)
            {
                var user = await GetUser(_userData.UserEmail, _userData.UserPassword);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("FirstName", user.UserName),
                    new Claim("Email", user.UserEmail),
                    new Claim("PassWord", user.UserPassword),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<UserDetails> GetUser(string email, string password)
        {
            UserDetails userInfo = null;
            var result = _context.userDetails.Where(u => u.UserEmail == email && u.UserPassword == password);
            foreach (var item in result)
            {
                userInfo = new UserDetails();
                userInfo.UserId = item.UserId;
                userInfo.UserName = item.UserName;
                
                userInfo.UserEmail = item.UserEmail;
                userInfo.UserPhoneNo = item.UserPhoneNo;
            }
            return userInfo;

        }
    }
    }


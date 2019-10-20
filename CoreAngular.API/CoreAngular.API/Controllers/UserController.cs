using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using CoreAngular.API.BLL.Services;
using CoreAngular.API.DAL.Models;

namespace CoreAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UserController(IUserService serv, IConfiguration config)
        {
            _config = config;
            _userService = serv;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User user)
        {
            user.UserName = user.UserName.ToLower();

            if (await _userService.UserExists(user.UserName))
            {
                return BadRequest("Username already exists.");
            }
            else
            {
                var createdUser = await _userService.Register(user, user.Password);
                return CreatedAtRoute("GetUser", new { controller = "Users", id = createdUser.Id }, createdUser);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(User user)
        {
            var loginUser = await _userService.Login(user.UserName.ToLower(), user.Password);

            if (loginUser == null)
            {
                return Unauthorized();
            }
            else
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, loginUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, loginUser.UserName)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), loginUser });
            }
        }
    }
}

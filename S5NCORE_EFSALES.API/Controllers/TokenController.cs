using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using S5NCORE_EFSALES.CORE.DTOs;
using S5NCORE_EFSALES.CORE.Entities;
using S5NCORE_EFSALES.CORE.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace S5NCORE_EFSALES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public TokenController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserAuthCredentialsDTO user)
        {
            var userAuth = await _userService.ValidateUser(user.Username, user.Password);
            var token = GenerateToken(userAuth);
            return Ok(token);
        }

        private string GenerateToken(UserAuth user)
        {
            var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(sc);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, "luis@qboinstitute.com"),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("CodigoSeguroSalud","SS99887711"),
                new Claim("Country","USA")
            };

            var payload = new JwtPayload(_configuration["Authentication:Issuer"], _configuration["Authentication:Audience"], claims, DateTime.UtcNow, DateTime.UtcNow.AddMinutes(1));

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }





    }
}

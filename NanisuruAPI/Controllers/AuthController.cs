using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NanisuruAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public class LoginModel
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel request)
        {
            //var builder = WebApplication.CreateBuilder();

            // Static user
            if ((request.username == _configuration["Userpass:User"]) &&
                (request.password == _configuration["Userpass:Pass"]))
            {
                //Token creation
                var tokenString = CreateToken();
                var response = new
                {
                    token = tokenString
                };
                return Ok(response);
            }

            return Unauthorized();
        }

        private string CreateToken()
        {
            //var builder = WebApplication.CreateBuilder();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                expires: DateTime.Now.AddMinutes(5), // Expires in 5 minutes
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

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

                // Save response to HttpOnly Cookie
                Response.Cookies.Append("X-Access-Token", tokenString, new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SameSite = SameSiteMode.None,
                    Secure = true
                });
                return Ok(new
                {
                    message = "success"
                });
            }

            return Unauthorized();
        }

        private string CreateToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "https://localhost",
                audience: "https://localhost",
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NanisuruAPI.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace NanisuruAPI.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IConfiguration _configuration;
        public AuthController(IConfiguration configuration, IUsersRepository usersRepository)
        {
            _configuration = configuration;
            _usersRepository = usersRepository;
        }
        public class LoginModel
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        readonly IUsersRepository _usersRepository;
        // public AuthController(IUsersRepository usersRepository)
        // {
        //     _usersRepository = usersRepository;
        // }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel request)
        {
            // Get users
            var users = await _usersRepository.GetUsersAsync();

            // Check for if user+pass is valid
            var matchedUsers = users.FirstOrDefault(u => u.Username == request.username && u.Password == request.password);

            if (matchedUsers != null)
            {
                //Token creation
                var tokenString = CreateToken();

                var response = new
                {
                    token = tokenString,
                    expire = DateTime.Now + TimeSpan.FromDays(7)
                };
                return Ok(response);
            }
            return Unauthorized();
        }

        /*[HttpPost("login")]
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
                    token = tokenString,
                    expire = DateTime.Now + TimeSpan.FromDays(7)
                };
                return Ok(response);
            }
            return Unauthorized();
        }*/

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

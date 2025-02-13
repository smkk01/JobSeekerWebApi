using CustomersWebApi.Data;
using JobSeekerWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobSeekerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private AppDbContext _db;
        private string _SecretKey;
        public UsersController(AppDbContext db,IConfiguration configuration)
        {
            _db = db;
            _SecretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }
        [HttpPost("Userlogin")]
        public async Task<UserLoginResponse> Login(UserLoginRequest logindetails )
        {
            var user = _db.LocalUser.FirstOrDefault(u => u.Username.ToLower() ==

            logindetails.UserName.ToLower() && logindetails.Password.ToLower() ==
            logindetails.Password.ToLower());

            if (user == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            UserLoginResponse loginResponse = new UserLoginResponse()
            {
                Token = tokenHandler.WriteToken(token),
                UserDetails = user
            };
            return loginResponse;
        }
    }
}

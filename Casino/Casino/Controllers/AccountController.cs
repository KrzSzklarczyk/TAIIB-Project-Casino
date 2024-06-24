using Casino.BLL;
using Casino.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUser _User;
        
        public AccountController(IUser u)
        {
            _User = u;
        }

        [HttpPost,Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserRequestDTO user)
        {            
            if (user == null) { return BadRequest("Invalid client request"); }
            var use = await _User.Login(user);
        if (use!=null)
            {
                var seckey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JanPawelPedofil"));
                var signCred=new SigningCredentials(seckey,SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(issuer: "http://localhost:5000",
                    audience: "http://localhost:5000",
                    claims: new List<Claim>{
                        new Claim(JwtRegisteredClaimNames.Sub,use.Email),
                        new Claim("userId", use.UserId),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        
                    },
                    expires: DateTime.Now.AddMinutes(5)
                    , signingCredentials: signCred);
                var token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = token });

            }
        return Unauthorized();
        
        }
        

       /* [HttpPost("Register")]
        public ActionResult Register(UserRequestDTO user,UserResponseDTO dane)
        {  
            return Ok(_User.Register(user));
        }*/
    }
}

using Casino.BLL;
using Casino.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("Login")]
        public ActionResult Login(UserDTO user)
        {            
            return Ok(_User.Login(user.Login, user.Password));
        }

        [HttpPost("Register")]
        public ActionResult Register(UserDTO user)
        {  
            return Ok(_User.Register(user));
        }
    }
}

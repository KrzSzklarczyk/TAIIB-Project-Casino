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
            this._User = u;
        }

        [HttpPost("login")]
        public ActionResult Login(UserDTO user)
        {
            
            return Ok(_User.Login(user.Login, user.Password));
        }

        [HttpPost("logout")]
        public ActionResult Logout()
        {
          _User.Logout();
            return Ok();
        }

        [HttpPost("Register")]
        public ActionResult Register(UserDTO user)
        {
          
            return Ok(_User.Register(user));
        }
    }
}

using Casino.BLL;
using Casino.BLL.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Casino.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUsers _User;

        public AccountController(IUsers u)
        {
            _User = u;
        }

       [HttpPost("Login")]
        public ActionResult Login(UserRequestDTO user)
        {            
            return Ok(_User.Login(user));
        }
        /*
        [HttpPost("Register")]
        public ActionResult Register(UserRequestDTO user)
        {  
            return Ok(_User.Register(user));
        }*/
    }
}

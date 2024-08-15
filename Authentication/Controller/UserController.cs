using Authentication.Entities;
using Authentication.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controller
{
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] User user) 
        {
            var authUser = await _userService.Login(user);

            if (authUser == null)
            {
                return BadRequest(new { message = "Nombre de usuario o contraseña incorrectos" });
            }

            return Ok(authUser);
        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<ActionResult> ChangePassword([FromBody] User user)
        {
            var resul = await _userService.ChangePassword(user);

            return Ok(user);
        }

        [HttpGet]
        public ActionResult<ICollection<User>> Get() 
        {
            return Ok(_userService.ListUsers());
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user) 
        {
            var result = await _userService.RegisterUser(user);
            return Ok(result);
        }
    }


}

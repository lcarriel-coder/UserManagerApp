using Microsoft.AspNetCore.Mvc;
using UserManagerApp.Services.PersonaUser;
using UserManagerApp.Services.PersonaUser.DTO;

namespace UserManagerApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaUserController :  ControllerBase
    {
        private readonly IPersonUser personUserService;
        public PersonaUserController(IPersonUser personUserService)
        {
            this.personUserService = personUserService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterPersonUserDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await personUserService.RegisterPersonUser(registerDto);

            if (!result.IsSuccess)
                return BadRequest(new { message = result.ErrorMessage });

            return Ok(new { message = "User registered successfully!" });
        }

    }
}

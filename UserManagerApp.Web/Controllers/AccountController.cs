using App.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using UserManagerApp.Services.Uitls;
using UserManagerApp.Services.User;
using UserManagerApp.Services.User.DTO;

namespace UserManagerApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
     
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await accountService.Authenticate(loginDto);

            if (!result.IsSuccess)
                return Unauthorized(new { message = result.ErrorMessage });

            return Ok(new { result });
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult<OperationResult>> GetUser()
        {
            try
            {
    
                var result = await accountService.GetCurrentUserAsync();

                if (!result.IsSuccess)
                    return Unauthorized(result);

               return Ok(new { result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new OperationResult { IsSuccess = false, ErrorMessage = ex.Message });
            }
        }

    }
}

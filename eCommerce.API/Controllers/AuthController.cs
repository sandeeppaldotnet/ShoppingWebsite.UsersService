using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
  [Route("api/[controller]")] //api/auth
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
      _usersService = usersService;
    }

        //Endpoint for user registration use case
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            try
            {
                if (registerRequest == null)
                    return BadRequest("Invalid registration data");

                var result = await _usersService.Register(registerRequest);
                return Ok(result);
               
                
            }
            catch (Exception ex)
            {
                // This helps identify the exact issue
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    detail = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }




        //Endpoint for user login use case
        [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
            try
            {
                //Check for invalid LoginRequest
                if (loginRequest == null)
      {
        return BadRequest("Invalid login data");
      }

      AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);

      if (authenticationResponse == null || authenticationResponse.Success == false)
      {
        return Unauthorized(authenticationResponse);
      }

      return Ok(authenticationResponse);
            }
            catch (Exception ex)
            {
                // This helps identify the exact issue
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    detail = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }
  }
}

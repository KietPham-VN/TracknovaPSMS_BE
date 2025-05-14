namespace Web.Controllers;

using Application.DTOs.UserDTO.Requests;
using Application.Services.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequest dto)
    {
        var userId = await userService.RegisterAsync(dto).ConfigureAwait(false);
        return Ok(new
        {
            message = "User registered successfully",
            userId = userId
        });
    }
}
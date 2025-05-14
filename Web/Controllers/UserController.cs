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
        try
        {
            var userId = await userService.RegisterAsync(dto.PhoneNumber, dto.Password).ConfigureAwait(false);
            return Ok(new { Message = "User registered successfully", UserId = userId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}

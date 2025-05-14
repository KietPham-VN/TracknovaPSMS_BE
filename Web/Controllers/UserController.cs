namespace Web.Controllers;

using System.IdentityModel.Tokens.Jwt;
using Application.DTOs.UserDTO.Requests;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

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
            userId
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest request)
    {
        var result = await userService.LoginAsync(request).ConfigureAwait(false);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest dto)
    {
        var result = await userService.RefreshTokenAsync(dto).ConfigureAwait(false);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        var userId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        return Ok(new
        {
            message = "Access token valid.",
            userId
        });
    }
}
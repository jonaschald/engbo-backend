using engbo_backend.DTOs;
using engbo_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace engbo_backend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    
    public AuthController(IAuthService authService, ITokenService tokenService)
    {
        _authService = authService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDTO register)
    {
        var user = await _authService.RegisterAsync(register);
        
        var token = _tokenService.Create(user);

        return Ok(new LoginResponseDTO
        {
            Token = token,
            Name = user.Name,
        });
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDTO login)
    {
        var user = await _authService.LoginAsync(login);

        if (user is null)
            return Unauthorized(new { message = "Brugernavn eller password er forket" });
        
        var token = _tokenService.Create(user);
        
        return Ok(new LoginResponseDTO
        {
            Token = token,
            Name = user.Name,
        });
    }
}
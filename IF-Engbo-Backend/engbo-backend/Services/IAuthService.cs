using engbo_backend.DTOs;
using engbo_backend.Models;

namespace engbo_backend.Services;

public interface IAuthService
{
    Task<User> RegisterAsync(RegisterDTO registerDTO);
    Task<User?> LoginAsync(LoginDTO loginDTO);
}
using engbo_backend.Models;

namespace engbo_backend.Services;

public interface ITokenService
{
    string Create(User user);
}
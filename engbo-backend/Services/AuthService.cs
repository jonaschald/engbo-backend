using engbo_backend.Data;
using engbo_backend.DTOs;
using engbo_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace engbo_backend.Services;

public class AuthService : IAuthService
{
    private readonly EngboDbContext _dbContext;
    private readonly PasswordHasher<User> _passwordHasher = new();
    
    public AuthService(EngboDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> RegisterAsync(RegisterDTO registerDto)
    {
        var emailExists = await _dbContext.Users.AnyAsync(u => u.Email == registerDto.Email);

        if (emailExists)
        {
            throw new InvalidOperationException("Email er allerede i brug");
        }

        var user = new User()
        {
            Name = registerDto.Name,
            Email = registerDto.Email
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, registerDto.Password);
        
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        
        return user;
    }

    public async Task<User?> LoginAsync(LoginDTO loginDto)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Email == loginDto.Email);

        if (user is null)
        {
            return null;
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
        
        return result == PasswordVerificationResult.Success ? user : null;
    }
}
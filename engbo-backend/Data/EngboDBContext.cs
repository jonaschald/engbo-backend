using engbo_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace engbo_backend.Data;

public class EngboDbContext : DbContext
{
    public EngboDbContext(DbContextOptions<EngboDbContext> options)
        : base(options) {}
    
    public DbSet<User> Users { get; set; }
}
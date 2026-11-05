using engbo_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace engbo_backend.Data;

public class EngboDbContext : DbContext
{
    public EngboDbContext(DbContextOptions<EngboDbContext> options)
        : base(options) {}
    
    public DbSet<User> Users { get; set; }
    public DbSet<Hold> Hold => Set<Hold>();
    public DbSet<Rolle> Roller => Set<Rolle>();
    public DbSet<AktivitetsKategori> AktivitetsKategorier => Set<AktivitetsKategori>();
    public DbSet<Aktivitet> Aktiviteter => Set<Aktivitet>();
    public DbSet<BaneType> BaneTyper => Set<BaneType>();
    public DbSet<Fremmoede> Fremmoede => Set<Fremmoede>();
    public DbSet<KampResultat> KampResultater => Set<KampResultat>();
    public DbSet<Tilmelding> Tilmeldinger => Set<Tilmelding>();
}
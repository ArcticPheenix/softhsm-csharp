using Microsoft.EntityFrameworkCore;

namespace softhsm_csharp.Models;

public class KeyContext : DbContext
{
    public KeyContext (DbContextOptions<KeyContext> options) : base(options)
    {
    }

    public DbSet<Key> keys { get; set; } = null!;
}
using Microsoft.EntityFrameworkCore;
using WorldRank.Domain.Entities;

namespace WorldRank.Infrastructure.Persistence;

public class WorldRankDbContext : DbContext
{
    public WorldRankDbContext(DbContextOptions<WorldRankDbContext> options): base(options)
    {
    }

    public DbSet<Player> Players => Set<Player>();
    public DbSet<Wallet> Wallets => Set<Wallet>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Score)
                .IsRequired();
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(w => w.Id);

            entity.Property(w => w.Balance)
                .HasPrecision(18, 2)
                .IsRequired();

            entity.Property(w => w.Currency)
                .IsRequired();

            entity.Property(w => w.IsBlocked)
                .IsRequired();

            entity.Property(w => w.PlayerId)
                .IsRequired();

            entity.HasIndex(w => new
            {
                w.PlayerId,
                w.Currency
            })
            .IsUnique();

            entity.HasOne<Player>()
                .WithMany()
                .HasForeignKey(w => w.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}


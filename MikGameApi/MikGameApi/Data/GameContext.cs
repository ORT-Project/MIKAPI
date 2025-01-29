namespace MikGameApi.Data
{
    using Microsoft.EntityFrameworkCore;

    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GameDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(e => e.PlayerID);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameID);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<GameSession>(entity =>
            {
                entity.HasKey(e => e.SessionID);
                entity.Property(e => e.StartTime).IsRequired();
                entity.Property(e => e.Score).HasDefaultValue(0);
                entity.Property(e => e.LastMove).HasMaxLength(50);

                entity.HasOne(e => e.Player)
                    .WithMany(p => p.GameSessions)
                    .HasForeignKey(e => e.PlayerID);

                entity.HasOne(e => e.Game)
                    .WithMany(g => g.GameSessions)
                    .HasForeignKey(e => e.GameID);
            });
        }
    }
}
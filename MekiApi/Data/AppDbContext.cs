using Microsoft.EntityFrameworkCore;
using MekiApi.Models;

namespace MekiApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        //users
        public DbSet<User> Users { get; set; }

        public DbSet<Score> Scores { get; set; }
        
        //configurations des relations entre les tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //relation entre User et Score
            modelBuilder.Entity<Score>()
                .HasOne(s => s.User) // un score appartient à un utilisateur
                .WithMany(u => u.Scores) // un utilisateur peut avoir plusieurs scores
                .HasForeignKey(s => s.UserId); // la clé étrangère de Score est UserId
        }
    }
}
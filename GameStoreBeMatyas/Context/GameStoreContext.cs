using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using GameStoreBeMatyas.Models;

namespace GameStoreBeMatyas.Context
{
    public class GameStoreContext:DbContext
    {
        public GameStoreContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<VideoGame> VideoGames { get; set; }
        public DbSet<VideoGameUser> VideoGameUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.VideoGames)
                .WithMany(e => e.Users)
                .UsingEntity<VideoGameUser>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=GameStore;Trusted_Connection=True");
        }
    }
}

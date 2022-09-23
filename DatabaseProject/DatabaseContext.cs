using Microsoft.EntityFrameworkCore;

namespace DatabaseProject
{
    public class DatabaseContext : DbContext
    {
        public DbSet<MasterMindGameStep> GameSteps { get; set; }
        public DbSet<Player> Players { get; set; }

        public string DbPath { get; }

        public DatabaseContext()
        {
            var folder = Directory.GetCurrentDirectory() + "\\";
            DbPath = System.IO.Path.Join(folder, "Database.db");

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterMindGameStep>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                //entity.Property(e => e.Id).ValueGeneratedNever();
            });
            modelBuilder.Entity<MasterMindGameStep>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .IsUnique();

                //entity.Property(e => e.Id).ValueGeneratedNever();
            });
        }
    }
}
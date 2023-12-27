using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Data.Persistence
{
    public class StreamerDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlServer(@"Data Source=localhost\sqlexpress;
            //    Initial Catalog=Streamer; Integrated Security=True");


            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Streamer;Trusted_Connection=True;TrustServerCertificate=True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging();


            // Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Streamer>()
                .HasMany(m => m.Videos)
                .WithOne(m => m.Streamer)
                .HasForeignKey(m => m.StreamerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<Video>()
                .HasMany(p => p.Actores)
                .WithMany(t => t.Videos)
                .UsingEntity<VideoActor>(
                    pt => pt.HasKey(e => new { e.ActorId, e.VideoId })
                );

                
        }

        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
        public DbSet<VideoActor>? VideosActores { get; set; }
        public DbSet<Director>? Directores { get; set;}
        public DbSet<Actor>? Actores { get;set; }

    }
}

namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;
    using static EntityValidationConstants.Song;
    using static EntityValidationConstants.Album;
    using static Configuration.ConnectionConfiguration;
    using MusicHub.Data.Configuration;
    using System.Reflection;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<SongPerformer> SongsPerformers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfiguration(new SongEntityConfiguration ());
            //builder.ApplyConfiguration(new AlbumEntityConfiguration());

            builder.ApplyConfigurationsFromAssembly(typeof(SongEntityConfiguration).Assembly);
        }
    }
}

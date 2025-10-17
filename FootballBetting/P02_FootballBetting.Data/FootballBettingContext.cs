using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static P02_FootballBetting.Data.ApplicationCommonConfiguration;

namespace P02_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }
        public FootballBettingContext(DbContextOptions options) :
            base(options)
        {

        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerStatistic> PlayersStatistics { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<User> Users { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new { ps.GameId, ps.PlayerId });

            modelBuilder.Entity<Player>()
                .Property(p => p.IsInjured)
                .HasDefaultValue(false);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(f => f.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(f => f.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(t => t.HomeTeam)
                .WithMany(c => c.HomeGames)
                .HasForeignKey(f => f.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
               .HasOne(t => t.AwayTeam)
               .WithMany(c => c.AwayGames)
               .HasForeignKey(f => f.AwayTeamId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Town)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TownId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System_do_zarządzania_ligą_piłkarską.Server.Models;

namespace System_do_zarządzania_ligą_piłkarską.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<FootballerStat> FootballerStats { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<RefereeStat> RefereeStats { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStat> TeamStats { get; set; }
        public DbSet<Trophy> Trophies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            IConfiguration configuration)
            : base(options, operationalStoreOptions)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Trophy>()
               .Property(t => t.TrophyOwner)
               .HasConversion<string>();

            modelBuilder.Entity<Match>()
                 .HasOne(m => m.HomeTeam)
                 .WithMany(t => t.HomeMatches)
                 .HasForeignKey(m => m.HomeTeamId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}

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
        public DbSet<LeagueSeason> LeagueSeasons { get; set; }
        public DbSet<LeagueInfo> LeagueInfos { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<RefereeStat> RefereeStats { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStat> TeamStats { get; set; }
        public DbSet<Trophy> Trophies { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<MatchFootballer> MatchFootballers { get; set; }
        public DbSet<Image> Images { get; set; }

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

            // Konwersje na string w bazie danych:

            modelBuilder.Entity<Trophy>()
               .Property(t => t.TrophyOwner)
               .HasConversion<string>();

            modelBuilder.Entity<Favourite>()
               .Property(f => f.FavouriteType)
               .HasConversion<string>();

            modelBuilder.Entity<MatchEvent>()
               .Property(f => f.EventType)
               .HasConversion<string>();

            modelBuilder.Entity<LeagueSeason>()
                .Property(x => x.Season)
                .HasConversion<string>();

            modelBuilder.Entity<LeagueInfo>()
                .Property(x => x.Level)
                .HasConversion<string>();

            modelBuilder.Entity<Footballer>()
                .Property(x => x.Position)
                .HasConversion<string>();

            // -----------------------------------

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

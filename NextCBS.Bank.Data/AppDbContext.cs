using Bank.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;
using Npgsql;



namespace NextCBS.Bank.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;
        public AppDbContext(DbContextOptions<AppDbContext> options, IOptions<DbOption> dbOptions) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehaviour", true);
            AppContext.SetSwitch("Npgsql.DisableDataTimeInfiniteyConversion", true);
            _connectionString = GetConnectionString(dbOptions.Value);
        }

        private static string GetConnectionString(DbOption dbOption)
        {
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = dbOption.Host,
                Port = dbOption.Port,
                Database = dbOption.Database,
                Username = dbOption.Username,
                Password = dbOption.Password,
                IncludeErrorDetail = true
            };
            return builder.ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseNpgsql(_connectionString)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .UseSnakeCaseNamingConvention()
                    .UseLazyLoadingProxies()
                    .ConfigureWarnings(w => w.Ignore(CoreEventId.DetachedLazyLoadingWarning));
            }
        }

    }
}

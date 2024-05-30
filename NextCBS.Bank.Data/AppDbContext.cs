using Bank.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using NextCBS.Bank.Module.Entities;
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            ChangeTracker.DetectChanges();
            var entries = ChangeTracker.Entries<AuditableEntity>()
                .Where(e => e.State is EntityState.Added or EntityState.Deleted or EntityState.Modified)
                .ToList();

            var audits = new List<AuditLog>();
            foreach (var entity in entries)
            {
                string? typeId;
                var tenant = string.Empty;
                if (entity.State is EntityState.Added && entity.Properties.Any(prop => prop.Metadata.IsPrimaryKey() && prop.IsTemporary))
                {
                    typeId = null;
                }
                else
                {
                    var primaryKey = entity.Metadata.FindPrimaryKey();
                    typeId = string.Join(",", primaryKey!.Properties.Select(prop => prop.PropertyInfo?.GetValue(entity.Entity)));
                }

                var changed = new Dictionary<string, string>();
                var old = new Dictionary<string, string>();
                foreach (var prop in entity.Properties)
                {
                    if (prop.Metadata.Name == "TenantId" || prop.Metadata.Name == "OrgId")
                    {
                        tenant = prop.CurrentValue?.ToString() ?? "";
                        continue;
                    }
                    if (prop.Metadata.IsPrimaryKey() || prop.Metadata.Name == "CreatedOn" || prop.Metadata.Name == "CreatedBy" || prop.Metadata.Name == "Tenant")
                        continue;

                    if (entity.State != EntityState.Added && prop.Metadata.GetAfterSaveBehavior() != PropertySaveBehavior.Save)
                        continue;

                   
                    if (entity.State == EntityState.Modified && !prop.IsModified)
                        continue;

                    if (entity.State == EntityState.Added || entity.State == EntityState.Modified)
                        changed.Add(prop.Metadata.Name, prop.CurrentValue?.ToString() ?? "");

                    if (entity.State == EntityState.Deleted)
                        old.Add(prop.Metadata.Name, prop.OriginalValue?.ToString() ?? "");
                }

                audits.Add(new AuditLog
                {
                    Pkey = typeId ?? "-",
                    EntityState = entity.State.ToString(),
                    NewValue = string.Join("", changed),
                    OldValue = string.Join("", old),
                    EntityType = entity.Entity.GetType().Name,
                    ChangedBy = entity.Entity.CreatedBy,
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    Time = TimeOnly.FromDateTime(DateTime.Now),
                    Tenant = tenant,
                });

            }
            await Set<AuditLog>().AddRangeAsync(audits, cancellationToken);
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

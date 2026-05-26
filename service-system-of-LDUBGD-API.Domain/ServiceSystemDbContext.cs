using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace service_system_of_LDUBGD_API.Domain;

public class ServiceSystemDbContext(DbContextOptions<ServiceSystemDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Statement> Statement { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<Statement>()
            .HasIndex(c => c.FullName)
            .HasDatabaseName("IX_Statement_FullName");
    }

}

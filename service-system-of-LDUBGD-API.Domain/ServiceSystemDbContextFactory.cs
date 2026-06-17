using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace service_system_of_LDUBGD_API.Domain;

public class ServiceSystemDbContextFactory
    : IDesignTimeDbContextFactory<ServiceSystemDbContext>
{
    public ServiceSystemDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ServiceSystemDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=StatementServiceDb;Trusted_Connection=True;TrustServerCertificate=True");

        return new ServiceSystemDbContext(optionsBuilder.Options);
    }
}
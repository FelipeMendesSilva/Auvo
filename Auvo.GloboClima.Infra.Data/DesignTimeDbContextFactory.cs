using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Auvo.GloboClima.Infra.Data.Context;

namespace Auvo.GloboClima.Infra.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var connectionString = "server=localhost;port=3306;database=GCDB;uid=usuario;pwd=senha;SslMode=none;";

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 43)),
                x => x.MigrationsAssembly("Auvo.GloboClima.Infra.Data"));

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
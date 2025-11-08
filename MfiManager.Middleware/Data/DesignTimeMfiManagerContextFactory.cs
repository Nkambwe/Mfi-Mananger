using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MfiManager.Middleware.Data {

    public class DesignTimeMfiManagerContextFactory : IDesignTimeDbContextFactory<MfiManagerDbContext>
    {
        public MfiManagerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MfiManagerDbContext>();

            //..connection for migrations:
            optionsBuilder.UseSqlServer("Data Source=HPMACJOHNAN;Initial Catalog=mfi_db;Trusted_Connection=True;TrustServerCertificate=True;");

            // PostgreSQL (commented out)
            // optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=mfi_db;Username=postgres;Password=\"skylite=2011\"");

            // Oracle (commented out)
            // optionsBuilder.UseOracle("User Id=app_user;Password=yourpassword;Data Source=localhost:1521/xe");

            return new MfiManagerDbContext(optionsBuilder.Options);
        }
    }
}

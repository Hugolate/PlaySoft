using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class RepositoryFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    public RepositoryContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
        optionsBuilder.UseSqlServer("Server=tcp:playsoft.database.windows.net,1433;Initial Catalog=playsoft-bbdd;Persist Security Info=False;User ID=azureUser;Password=Ricardo_hugo;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        return new RepositoryContext(optionsBuilder.Options);
    }
}
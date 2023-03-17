using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Models;

namespace Portfolio.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Projects> Projects {get; set;}
}


// dotnet aspnet-codegenerator identity -dc Portfolio.Data.ApplicationDbCotext --files "Account.Register;Account.Login;" --useSqlite

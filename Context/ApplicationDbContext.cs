using Microsoft.EntityFrameworkCore;
using server_dotnet_fitnessapp.Models;

namespace server_dotnet_fitnessapp.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options
    ) : base(options)        
    {
        
    }    
    
    public DbSet<User> Users { get; set; }

}
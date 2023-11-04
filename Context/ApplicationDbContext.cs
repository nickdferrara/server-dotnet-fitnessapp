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
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<MembershipType> MembershipTypes { get; set; }
    public DbSet<Membership> Memberships { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<UserWorkout> UserWorkouts { get; set; }
    public DbSet<Waitlist> Waitlist { get; set; }

    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {
        foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelbuilder.Entity<UserWorkout>()
            .HasKey(x => new { x.UserId, x.WorkoutId });
        
        modelbuilder.Entity<UserWorkout>()
            .HasOne(x => x.User)
            .WithMany(x => x.UserWorkouts)
            .HasForeignKey(x => x.UserId);
        
        modelbuilder.Entity<UserWorkout>()
            .HasOne(x => x.Workout)
            .WithMany(x => x.UserWorkouts)
            .HasForeignKey(x => x.WorkoutId);

        base.OnModelCreating(modelbuilder);
    }
}
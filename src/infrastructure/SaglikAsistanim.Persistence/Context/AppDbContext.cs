using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SaglikAsistanim.Domain.Entities;
using SaglikAsistanim.Identity.Models;
using System.Reflection;


namespace SaglikAsistanim.Persistence.Context;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser, Role, string>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityUserRole<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityUserToken<string>>();
        modelBuilder.Ignore<IdentityRoleClaim<string>>();
        modelBuilder.Ignore<IdentityRole<string>>();

    }

    public DbSet<BloodTest> BloodTests { get; set; } = null!;
    public DbSet<BloodTestValue> BloodTestValues { get; set; } = null!;
    public DbSet<HealthReport> HealthReports { get; set; } = null!;
    public DbSet<Measurement> Measurements { get; set; } = null!;
    public DbSet<Medication> Medications { get; set; } = null!;
    public DbSet<UserHealth> UserHealths { get; set; } = null!;







}
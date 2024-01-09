using System.Reflection;
using BloodDonationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Infrastructure.Persistence;

public class BloodDonationDbContext : DbContext 
{
    public BloodDonationDbContext(DbContextOptions<BloodDonationDbContext> options) : base(options)
    {
 
    }

    public DbSet<Donor> Donors { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<BloodStock> BloodStocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}

using BloodDonationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationSystem.Infrastructure.Persistence.Configurations;

public class DonationConfigurations : IEntityTypeConfiguration<Donation>
{
    public void Configure(EntityTypeBuilder<Donation> builder)
    {
        builder
            .HasKey(d => d.Id);

        builder
            .HasOne(d => d.Donor)
            .WithMany(d => d.Donations)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
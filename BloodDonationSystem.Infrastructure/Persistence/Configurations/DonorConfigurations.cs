using BloodDonationSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationSystem.Infrastructure.Persistence.Configurations;

public class DonorConfigurations : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder
            .HasKey(d => d.Id);

        builder
            .HasMany(d => d.Donations)
            .WithOne(d => d.Donor)
            .HasForeignKey(d => d.IdDonor)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(d => d.Name)  
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");

        builder
            .Property(d => d.Email)
            .HasMaxLength(50)
            .HasColumnType("varchar(50)");;

        builder
            .OwnsOne(d => d.Address,
                address =>
                {
                    address
                        .Property(a => a.Street)
                        .HasColumnName("Street")
                        .IsRequired();

                    address
                        .Property(a => a.City)
                        .HasColumnName("City")
                        .IsRequired();

                    address
                        .Property(a => a.State)
                        .HasColumnName("State")
                        .IsRequired();
                    
                    address
                        .Property(a => a.PostalCode)
                        .HasColumnName("PostalCode")
                        .IsRequired();
                });
    }
}
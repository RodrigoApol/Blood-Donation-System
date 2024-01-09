using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Entities.Base;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models.InputModels;

public class DonorInputModel 
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public EGender Gender { get; set; }
    public double Weight { get; set; }
    public EBloodType BloodType { get; set; }
    public ERhFactor RhFactor { get; set; }
    public Address? Address { get; set; }
}
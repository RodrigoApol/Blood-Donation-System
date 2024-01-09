using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models.ViewModels;

public class DonorDetailsViewModel
{
    public DonorDetailsViewModel(string name, string email, string birthDate, EGender gender, double weight, EBloodType bloodType, ERhFactor rhFactor, Address address)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = rhFactor;
        Address = address;
        Donations = new List<Donation>();
    }

    public string Name { get; set; } 
    public string Email { get; set; } 
    public string BirthDate { get; set; } 
    public EGender Gender { get; set; }
    public double Weight { get; set; }
    public EBloodType BloodType { get; set; }
    public ERhFactor RhFactor { get; set; } 
    public Address Address { get; set; }
    public List<Donation> Donations { get; set; } 
}

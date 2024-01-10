using BloodDonationSystem.Core.Enums;
using System.Text.Json.Serialization;
using BloodDonationSystem.Core.Entities.Base;

namespace BloodDonationSystem.Core.Entities;

public class Donor : BaseEntity
{
    protected Donor()
    {
        
    }

    public Donor(
        string name,
        string email,
        DateTime birthDate,
        EGender gender,
        double weight,
        EBloodType bloodType,
        ERhFactor rhFactor,
        Address address)
    {
        if (weight < 50)
        {
            throw new ArgumentException("The minimum weight must be 50Kg");
        }

        Name = name;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = rhFactor;
        Address = address;

        Donations = new List<Donation>();
        DonorStatus = EDonorStatus.Active;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public EGender Gender { get; private set; }
    public double Weight { get; private set; }
    public EBloodType BloodType { get; private set; }
    public ERhFactor RhFactor { get; private set; }
    public List<Donation> Donations { get; private set; }
    public Address Address { get; private set; }
    public EDonorStatus DonorStatus { get; private set; }

    public void UpdateDonor(
        string name,
        string email,
        DateTime birthDate,
        EGender gender,
        double weight,
        EBloodType bloodType,
        ERhFactor rhFactor,
        Address address)
    {
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Gender = gender;
        Weight = weight;
        BloodType = bloodType;
        RhFactor = rhFactor;
        Address = address;
    }

    public void DeleteDonor()
    {
        DonorStatus = EDonorStatus.Inactive;
    }

    public bool CanDonate()
    {
        var age = DateTime.Now.Year - BirthDate.Year;

        return age >= 18;
    }
}
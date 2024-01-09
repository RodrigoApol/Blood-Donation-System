using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models.ViewModels;

public class BloodStockViewModel
{
    public BloodStockViewModel(EBloodType bloodType, ERhFactor rhFactor, double mlAmount)
    {
        BloodType = bloodType;
        RhFactor = rhFactor;
        MlAmount = mlAmount;
    }

    public EBloodType BloodType { get; set; } 
    public ERhFactor RhFactor { get; set; } 
    public double MlAmount { get; set; }
}

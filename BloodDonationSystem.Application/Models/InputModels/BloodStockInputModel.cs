using BloodDonationSystem.Core.Entities.Base;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models.InputModels;

public class BloodStockInputModel
{
    public EBloodType BloodType { get; set; }
    public ERhFactor RhFactor { get; set; }
    public double MlAmount { get; set; }
}

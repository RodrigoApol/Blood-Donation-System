using BloodDonationSystem.Core.Entities.Base;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Core.Entities;

public class BloodStock : BaseEntity
{
    protected BloodStock()
    {
        
    }
    public BloodStock(EBloodType bloodType, ERhFactor rhFactor, double mlAmount)
    {
        BloodType = bloodType;
        RhFactor = rhFactor;
        MlAmount = mlAmount;
    }

    public EBloodType BloodType { get; private set; }
    public ERhFactor RhFactor { get; private set; }
    public double MlAmount { get; private set; }
    
    public void UpdateMlAmount(double mlAmount)
    {
        MlAmount += mlAmount;
    }
}

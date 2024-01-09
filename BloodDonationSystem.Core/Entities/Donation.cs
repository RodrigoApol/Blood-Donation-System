using System.Text.Json.Serialization;
using BloodDonationSystem.Core.Entities.Base;

namespace BloodDonationSystem.Core.Entities;

public class Donation : BaseEntity
{
    protected Donation()
    {
        
    }
    
    public Donation(int idDonor, double mlAmount)
    {
        IdDonor = idDonor;
        DonationDate = DateTime.Now;
        MlAmount = mlAmount;
    }

    public int IdDonor { get; private set; }
    public DateTime DonationDate { get; private set; }
    public double MlAmount { get; private set; }
    public Donor Donor { get; private set; }

    public void UpdateDonation(int idDonor, double mlAmount)
    {
        IdDonor = idDonor;
        MlAmount = mlAmount;
    }
}

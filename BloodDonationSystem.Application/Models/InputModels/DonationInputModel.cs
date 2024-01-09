using BloodDonationSystem.Core.Entities.Base;

namespace BloodDonationSystem.Application.Models.InputModels;

public class DonationInputModel
{
    public int IdDonor { get; set; }
    public DateTime DonationDate { get; set; }
    public double MlAmount { get; set; }
}

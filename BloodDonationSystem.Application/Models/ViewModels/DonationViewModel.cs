namespace BloodDonationSystem.Application.Models.ViewModels;

public class DonationViewModel
{
    public DonationViewModel(string donorName, string donationDate, double mlAmount)
    {
        DonorName = donorName;
        DonationDate = donationDate;
        MlAmount = mlAmount;
    }

    public string DonorName { get; set; } 
    public string DonationDate { get; set; } 
    public double MlAmount { get; set; }
}

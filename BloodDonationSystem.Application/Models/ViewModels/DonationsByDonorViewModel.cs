namespace BloodDonationSystem.Application.Models.ViewModels;

public class DonationsByDonorViewModel
{
    public DonationsByDonorViewModel(string donationDate, double mlAmount)
    {
        DonationDate = donationDate;
        MlAmount = mlAmount;
    }
    
    public string DonationDate { get; set; }
    public double MlAmount { get; set; }
}
using BloodDonationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationSystem.Application.Models.ViewModels;
public class DonationDetailsViewModel
{
    public DonationDetailsViewModel(string donorName, string donationDate, double mlAmount, Donor donor)
    {
        DonorName = donorName;
        DonationDate = donationDate;
        MlAmount = mlAmount;
        Donor = donor;
    }

    public string DonorName { get; set; }
    public string DonationDate { get; set; } 
    public double MlAmount { get; set; }
    public Donor Donor { get; set; }
}

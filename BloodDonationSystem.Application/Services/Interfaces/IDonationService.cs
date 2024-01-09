using BloodDonationSystem.Application.Models.InputModels;
using BloodDonationSystem.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationSystem.Application.Services.Interfaces;

public interface IDonationService
{
    List<DonationViewModel> GetAll();
    List<DonationViewModel> GetLast30Days();
    DonationDetailsViewModel GetDetails(int id);
    int CreateDonation(DonationInputModel donationInputModel);
    void UpdateDonation(DonationInputModel donationInputModel, int id);
}
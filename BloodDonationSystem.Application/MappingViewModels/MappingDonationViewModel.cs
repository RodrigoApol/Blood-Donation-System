using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Application.Models.ViewModels;

namespace BloodDonationSystem.Application.MappingViewModels;

public static class MappingDonationViewModel
{
    public static List<DonationViewModel> ToViewModel(this IEnumerable<Donation> donations)
    {
        return donations.Select(donation => new DonationViewModel(
            donation.Donor.Name,
            donation.DonationDate.ToString("dd/MM/yyyy"),
            donation.MlAmount
        )).ToList();
    }

    public static DonationDetailsViewModel ToViewModelWithId(this Donation donation)
        => new(
            donation.Donor.Name,
            donation.DonationDate.ToString("dd/MM/yyyy"),
            donation.MlAmount,
            donation.Donor
        );

    public static List<DonationsByDonorViewModel> MapToViewModel(this IEnumerable<Donation> donations)
    {
        return donations.Select(d => new DonationsByDonorViewModel(
            d.DonationDate.ToString("dd/MM/yyyy"),
            d.MlAmount)).ToList();
    }
}
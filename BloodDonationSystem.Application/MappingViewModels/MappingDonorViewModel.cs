using BloodDonationSystem.Application.Models.ViewModels;
using BloodDonationSystem.Core.Entities;

namespace BloodDonationSystem.Application.MappingViewModels;

public static class MappingDonorViewModel
{
    public static List<DonorViewModel> ToViewModel(this IEnumerable<Donor> donors)
    {
        return donors
            .Select(d => new DonorViewModel(d.Name, d.Email, d.Gender, d.DonorStatus))
            .ToList();
    }

    public static DonorDetailsViewModel ToViewModelWithId(this Donor donor) => new(
        donor.Name,
        donor.Email,
        donor.BirthDate.ToString("dd/MM/yyyy"),
        donor.Gender,
        donor.Weight,
        donor.BloodType,
        donor.RhFactor,
        donor.Address);
}
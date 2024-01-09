using BloodDonationSystem.Application.Models.ViewModels;
using BloodDonationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationSystem.Application.MappingViewModels;
public static class MappingBloodStockViewModel
{
    public static IEnumerable<BloodStockViewModel> ToViewModel(this IEnumerable<BloodStock> bloodStock)
    {
        return bloodStock.Select(b => new BloodStockViewModel(
            b.BloodType, 
            b.RhFactor,
            b.MlAmount));
    }

    public static BloodStockViewModel ToViewModelWithId(this BloodStock bloodStock) =>
        new BloodStockViewModel(bloodStock.BloodType, bloodStock.RhFactor,bloodStock.MlAmount);
}

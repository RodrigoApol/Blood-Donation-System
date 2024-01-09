using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodDonationSystem.Core.Enums;

namespace BloodDonationSystem.Application.Models.ViewModels;
public class BloodStockViewModel
{
    public BloodStockViewModel(EBloodType bloodType, double mlAmount)
    {
        BloodType = bloodType;
        MlAmount = mlAmount;
    }

    public EBloodType BloodType { get; set; }
    public double MlAmount { get; set; }
}

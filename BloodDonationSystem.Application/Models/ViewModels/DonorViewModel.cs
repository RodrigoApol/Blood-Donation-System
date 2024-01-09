using BloodDonationSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationSystem.Application.Models.ViewModels;
public class DonorViewModel
{
    public DonorViewModel(string name, string email, EGender gender, EDonorStatus donorStatus)
    {
        Name = name;
        Email = email;
        Gender = gender;
        DonorStatus = donorStatus;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public EGender Gender { get; set; }
    public EDonorStatus DonorStatus { get; set; }
}

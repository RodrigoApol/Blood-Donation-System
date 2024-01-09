using BloodDonationSystem.Application.Models.InputModels;
using BloodDonationSystem.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationSystem.Application.Services.Interfaces;
public interface IBloodStockService
{
    List<BloodStockViewModel> GetAll();
    BloodStockViewModel GetDetails(int id);
    int CreateBloodStock(BloodStockInputModel bloodStockInputModel);
}

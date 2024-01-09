using BloodDonationSystem.Application.Models.InputModels;
using BloodDonationSystem.Application.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonationSystem.Application.Services.Interfaces;
public interface IDonorService
{
    List<DonorViewModel> GetAll();
    DonorDetailsViewModel GetDetails(int id);
    List<DonorViewModel> GetDonorsByStreet(string street);
    List<DonorViewModel> GetDonorsByCity(string city);
    List<DonorViewModel> GetDonorsByState(string state);
    List<DonorViewModel> GetDonorsByPostalCode(string postalCode);
    int CreateDonor(DonorInputModel donorInputModel);
    void UpdateDonor(DonorInputModel donorInputModel, int id);
    void DeleteDonor(int id);
}

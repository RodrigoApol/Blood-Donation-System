using BloodDonationSystem.Application.MappingViewModels;
using BloodDonationSystem.Application.Models.InputModels;
using BloodDonationSystem.Application.Models.ViewModels;
using BloodDonationSystem.Application.Services.Interfaces;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Services.Implementations;

public class DonorService : IDonorService
{
    private readonly BloodDonationDbContext _dbContext;

    public DonorService(BloodDonationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<DonorViewModel> GetDonorsByPostalCode(string postalCode)
    {
        var donors = _dbContext.Donors.Where(d => d.Address.PostalCode == postalCode);
        
        return donors
            .ToViewModel()
            .ToList();
    }

    public int CreateDonor(DonorInputModel donorInputModel)
    {
        var donorExist = _dbContext.Donors.SingleOrDefault(d => d.Email == donorInputModel.Email);

        if (donorExist != null)
        {
            throw new ArgumentException("E-mail already registered");
        }
        
        var donor = new Donor(
            donorInputModel.Name,
            donorInputModel.Email,
            donorInputModel.BirthDate,
            donorInputModel.Gender,
            donorInputModel.Weight,
            donorInputModel.BloodType,
            donorInputModel.RhFactor,
            donorInputModel.Address);
        
        _dbContext.Donors.Add(donor);
        _dbContext.SaveChanges();

        return donor.Id;
    }

    public void DeleteDonor(int id)
    {
        var donor = _dbContext.Donors.SingleOrDefault(d => d.Id == id)
                    ?? throw new ArgumentException("Donor not Exists");

        donor.DeleteDonor();
        _dbContext.SaveChanges();
    }

    public List<DonorViewModel> GetAll()
    {
        var donors = _dbContext.Donors;

        var donorsViewModel = donors.ToViewModel();

        return donorsViewModel.ToList();
    }

    public DonorDetailsViewModel GetDetails(int id)
    {
        var donor = _dbContext.Donors
                        .Include(d => d.Donations)
                        .SingleOrDefault(d => d.Id == id)
                    ?? throw new ArgumentException("User not exists");

        var donorViewModel = donor.ToViewModelWithId();

        return donorViewModel;
    }

    public List<DonorViewModel> GetDonorsByStreet(string street)
    {
        var donors = _dbContext.Donors.Where(d => d.Address.Street == street);

        return donors
            .ToViewModel()
            .ToList();
    }

    public List<DonorViewModel> GetDonorsByCity(string city)
    {
        var donors = _dbContext.Donors.Where(d => d.Address.City == city);

        return donors
            .ToViewModel()
            .ToList();
    }

    public List<DonorViewModel> GetDonorsByState(string state)
    {
        var donors = _dbContext.Donors.Where(d => d.Address.State == state).ToList();

        return donors
            .ToViewModel();
    }

    public void UpdateDonor(DonorInputModel donorInputModel, int id)
    {
        var donor = _dbContext.Donors.SingleOrDefault(d => d.Id == id)
                    ?? throw new ArgumentException("User not exists");

        donor.UpdateDonor(
            donorInputModel.Name,
            donorInputModel.Email,
            donorInputModel.BirthDate,
            donorInputModel.Gender,
            donorInputModel.Weight,
            donorInputModel.BloodType,
            donorInputModel.RhFactor,
            donorInputModel.Address);

        _dbContext.Update(donor);
        _dbContext.SaveChanges();
    }
}
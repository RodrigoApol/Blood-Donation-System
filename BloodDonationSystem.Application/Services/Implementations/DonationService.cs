using BloodDonationSystem.Application.MappingViewModels;
using BloodDonationSystem.Application.Models.InputModels;
using BloodDonationSystem.Application.Models.ViewModels;
using BloodDonationSystem.Application.Services.Interfaces;
using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationSystem.Application.Services.Implementations;

public class DonationService : IDonationService
{
    private readonly BloodDonationDbContext _dbContext;

    public DonationService(BloodDonationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CreateDonation(DonationInputModel donationInputModel)
    {
        var donor = _dbContext.Donors.SingleOrDefault(d => d.Id == donationInputModel.IdDonor)
                    ?? throw new ArgumentException("Donor not exists");

        var donorAgeIsValid = donor.CanDonate();

        if (donorAgeIsValid is false)
        {
            throw new ArgumentException("Donor age not valid");
        }

        var bloodStock = _dbContext.BloodStocks
            .SingleOrDefault(s => s.BloodType == donor.BloodType
                                  && s.RhFactor == donor.RhFactor) ?? throw new ArgumentException("Donor Not Exists");
        ;

        var donation = new Donation(
            donationInputModel.IdDonor,
            donationInputModel.MlAmount);

        if (donation.MlAmount < 420 && donation.MlAmount > 470)
        {
            throw new ArgumentException("Error in quantity");
        }

        _dbContext.Donations.Add(donation);
        bloodStock.UpdateMlAmount(donation.MlAmount);
        _dbContext.SaveChanges();


        return donation.Id;
    }

    public List<DonationViewModel> GetAll()
    {
        var donation = _dbContext.Donations
            .Include(d => d.Donor);

        var donationViewModel = donation.ToViewModel();

        return donationViewModel.ToList();
    }

    public List<DonationViewModel> GetLast30Days()
    {
        var donations = _dbContext
            .Donations
            .Where(d => d.DonationDate >= DateTime.Now.AddDays(-30))
            .Include(d => d.Donor)
            .ToList();

        var donationsViewModel = donations.ToViewModel();

        return donationsViewModel;
    }

    public DonationDetailsViewModel GetDetails(int id)
    {
        var donation = _dbContext.Donations
                           .Include(d => d.Donor)
                           .SingleOrDefault(d => d.Id == id)
                       ?? throw new ArgumentException("Donation not exists");

        var donationViewModel = donation.ToViewModelWithId();

        return donationViewModel;
    }

    public void UpdateDonation(DonationInputModel donationInputModel, int id)
    {
        var donation = _dbContext.Donations.SingleOrDefault(d => d.Id == id)
                       ?? throw new ArgumentException("Donation not exists");
        
        donation.UpdateDonation(
            donationInputModel.IdDonor,
            donationInputModel.MlAmount);

        _dbContext.Update(donation);
        _dbContext.SaveChanges();
    }
}
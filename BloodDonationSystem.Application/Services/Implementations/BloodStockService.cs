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

namespace BloodDonationSystem.Application.Services.Implementations;

public class BloodStockService : IBloodStockService
{
    private readonly BloodDonationDbContext _dbContext;

    public BloodStockService(BloodDonationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int CreateBloodStock(BloodStockInputModel bloodStockInputModel)
    {
        var bloodStockExist = _dbContext
            .BloodStocks
            .SingleOrDefault(b => b.BloodType == bloodStockInputModel.BloodType
                                  && b.RhFactor == bloodStockInputModel.RhFactor);

        if (bloodStockExist != null)
        {
            throw new ArgumentException("");
        }

        var bloodStock = new BloodStock(
            bloodStockInputModel.BloodType,
            bloodStockInputModel.RhFactor,
            bloodStockInputModel.MlAmount);

        _dbContext.BloodStocks.Add(bloodStock);
        _dbContext.SaveChanges();

        return bloodStock.Id;
    }

    public List<BloodStockViewModel> GetAll()
    {
        var bloodStocks = _dbContext
            .BloodStocks
            .ToViewModel()
            .ToList();

        return bloodStocks;
    }

    public BloodStockViewModel GetDetails(int id)
    {
        var bloodStock = _dbContext.BloodStocks.SingleOrDefault(b => b.Id == id)
                         ?? throw new ArgumentException("BloodStock not exists");

        var bloodStockViewModel = bloodStock.ToViewModelWithId();

        return bloodStockViewModel;
    }
}
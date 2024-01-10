using BloodDonationSystem.Core.Entities;
using BloodDonationSystem.Application.MappingViewModels;
using BloodDonationSystem.Application.Models.InputModels;
using BloodDonationSystem.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BloodDonationSystem.Application.Services.Interfaces;

namespace BloodDonationSystem.API.Controllers;
[Route("api/donations")]
[ApiController]
public class DonationsController : ControllerBase
{
    private readonly IDonationService _donationService;

    public DonationsController(IDonationService donationService)
    {
        _donationService = donationService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var donations = _donationService.GetAll();

        return Ok(donations);
    }

    [HttpGet("last-30-days")]
    public IActionResult GetLast30Days()
    {
        var donations = _donationService.GetLast30Days();

        return Ok(donations);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var donation = _donationService.GetDetails(id);

        return Ok(donation);
    }

    [HttpPost]
    public IActionResult Post(DonationInputModel donationInputModel)
    {
        var idDonation = _donationService.CreateDonation(donationInputModel);

        return CreatedAtAction(
            nameof(GetById),
            new { id = idDonation },
            donationInputModel);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, DonationInputModel donationInputModel)
    {
        _donationService.UpdateDonation(donationInputModel, id);

        return NoContent();
    }
}

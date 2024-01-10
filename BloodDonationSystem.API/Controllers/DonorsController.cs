using BloodDonationSystem.Application.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using BloodDonationSystem.Application.Services.Interfaces;

namespace BloodDonationSystem.API.Controllers;
[Route("api/Donors")]
[ApiController]
public class DonorsController : ControllerBase
{
    private readonly IDonorService _donorService;

    public DonorsController(IDonorService donorService)
    {
        _donorService = donorService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var donors = _donorService.GetAll();

        return Ok(donors);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var donor = _donorService.GetDetails(id);

        return Ok(donor);
    }

    [HttpGet("street/{street}")]
    public IActionResult GetByStreet(string street)
    {
        var donors = _donorService.GetDonorsByStreet(street);

        return Ok(donors);
    }
    
    [HttpGet("city/{city}")]
    public IActionResult GetByCity(string city)
    {
        var donors = _donorService.GetDonorsByCity(city);

        return Ok(donors);
    }
    
    [HttpGet("state/{state}")]
    public IActionResult GetByState(string state)
    {
        var donors = _donorService.GetDonorsByState(state);

        return Ok(donors);
    }
    
    [HttpGet("postal-code/{postalCode}")]
    public IActionResult GetByPostalCode(string postalCode)
    {
        var donors = _donorService.GetDonorsByPostalCode(postalCode);

        return Ok(donors);
    }

    [HttpPost]
    public IActionResult Post(DonorInputModel donorInputModel)
    {
        var idDonor = _donorService.CreateDonor(donorInputModel);

        return CreatedAtAction(
            nameof(GetById), 
            new { id = idDonor }, 
            donorInputModel);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, DonorInputModel donorInputModel)
    {
        _donorService.UpdateDonor(donorInputModel, id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _donorService.DeleteDonor(id);

        return NoContent();
    }
}

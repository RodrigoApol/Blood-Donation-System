using BloodDonationSystem.Application.Models.InputModels;
using BloodDonationSystem.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonationSystem.API.Controllers;
[Route("api/bloodStock")]
[ApiController]
public class BloodStockController : ControllerBase
{
    private readonly IBloodStockService _bloodStockService;

    public BloodStockController(IBloodStockService bloodStockService)
    {
        _bloodStockService = bloodStockService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var bloodStocks = _bloodStockService.GetAll();

        return Ok(bloodStocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var bloodStockDetails = _bloodStockService.GetDetails(id);

        return Ok(bloodStockDetails);
    }

    [HttpPost]
    public IActionResult Post(BloodStockInputModel bloodStockInputModel)
    {
        var bloodStockId = _bloodStockService.CreateBloodStock(bloodStockInputModel);

        return CreatedAtAction(
            nameof(GetById),
            new { id = bloodStockId },
            bloodStockId);
    }
 }

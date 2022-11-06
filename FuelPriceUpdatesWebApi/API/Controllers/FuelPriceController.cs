using System.Collections.Generic;
using System.Net;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using static System.Console;

[ApiController]
[Route(template: "api/fuel_prices")] //or "api/[controller]"
public class FuelPriceController : ControllerBase
{
    private readonly MongoDBService _mongoDBService;

    public FuelPriceController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet(Name = "Retrieve all fuel price entries")]
    [ProducesResponseType(200, Type = typeof(List<FuelPrice>))]
    public async Task<List<FuelPrice>> Get()
    {
        List<FuelPrice>? prices = await _mongoDBService.RetrieveAllAsync();
        return prices;
    }

    [HttpPost(Name = "Create new fuel price entry")]
    [ProducesResponseType(201)]
    public async Task<IActionResult> Post([FromBody] NewFuelPrice newFuelPrice)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Please provide a new update");
        }

        newFuelPrice.DateAdded = DateTime.Now;
        try
        {
            await _mongoDBService.CreateAsync(newFuelPrice);
            return CreatedAtAction(
                actionName: nameof(Get),
                routeValues: new { id = newFuelPrice.Id },
                value: newFuelPrice
            );
        }
        catch
        {
            return BadRequest("Failed to add the new fuel price update");
        }
    }
}

using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace API.Services;

public class MongoDBService
{
    private readonly IMongoCollection<FuelPrice> _fuelPrices;
    private readonly IConfiguration? _config;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings, IConfiguration config)
    {
        MongoClient client = new MongoClient(config["ConnectionString"]);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _fuelPrices = database.GetCollection<FuelPrice>(mongoDBSettings.Value.CollectionName);
    }

    //Add a new price entry
    public async Task CreateAsync(NewFuelPrice price)
    {
        FuelPrice? priceToAdd = JsonConvert.DeserializeObject<FuelPrice>(
            JsonConvert.SerializeObject(price)
        );
        if (priceToAdd == null)
            return;
        await _fuelPrices.InsertOneAsync(priceToAdd);
    }

    //Get all price entries
    public async Task<List<FuelPrice>> RetrieveAllAsync()
    {
        return await _fuelPrices.Find(new BsonDocument()).ToListAsync();
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models;

public class FuelPrice
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [Required]
    [BsonElement("serviceStation")]
    [JsonPropertyName("serviceStation")]
    public string? ServiceStation { get; set; }

    [Required]
    [BsonElement("petrolPrice")]
    [JsonPropertyName("petrolPrice")]
    public decimal PetrolPrice { get; set; }

    [Required]
    [BsonElement("dieselPrice")]
    [JsonPropertyName("dieselPrice")]
    public decimal DieselPrice { get; set; }

    [Required]
    [BsonElement("location")]
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [StringLength(maximumLength: 100)]
    [BsonElement("additionalInfo")]
    [JsonPropertyName("additionalInfo")]
    public string? AdditionalInfo { get; set; } = null!;

    [BsonElement("dateCreated")]
    [JsonPropertyName("dateCreated")]
    public DateTime? DateAdded { get; set; }
}

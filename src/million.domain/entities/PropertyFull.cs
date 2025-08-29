using System;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace million.domain.entities;

public class PropertyFull : BaseEntity
{
  [BsonElement("ownerId")]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? ownerId { get; set; }
  public string? name { get; set; }
  public string? address { get; set; }

  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public decimal? minPrice { get; set; }

  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public decimal? maxPrice { get; set; }

  public decimal? price { get; set; }
  public string? image { get; set; }

  public override string ToString()
  {
    return $"Name: {name}, Address: {address}, MinPrice: {minPrice}, MaxPrice: {maxPrice}";
  }

}

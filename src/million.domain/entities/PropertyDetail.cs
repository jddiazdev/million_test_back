using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace million.domain.entities;

public class PropertyDetail : BaseEntity
{
  [BsonElement("propertyId")]
  [BsonRepresentation(BsonType.ObjectId)]
  public required string propertyId { get; set; } = null!;
  public required int bedrooms { get; set; }
  public required int bathrooms { get; set; }
  public required decimal areaM2 { get; set; }
  public required bool garage { get; set; }
  public required int yearBuilt { get; set; }
  public required string description { get; set; }

}

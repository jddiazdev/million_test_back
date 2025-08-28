using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace million.domain.entities;

public class PropertyImage : BaseEntity
{
  // fk 
  [BsonElement("propertyId")]
  [BsonRepresentation(BsonType.ObjectId)]
  public string propertyId { get; set; } = null!;

  public required string file { get; set; }
  public required bool enabled { get; set; }

}

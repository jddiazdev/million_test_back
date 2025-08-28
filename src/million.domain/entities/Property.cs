using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace million.domain.entities;

public class Property : BaseEntity
{

  public required string name { get; set; }
  public required string address { get; set; }
  public required decimal price { get; set; }
  public required string codeInternal { get; set; }
  public required string year { get; set; }

  // // FK 
  [BsonElement("ownerId")]
  [BsonRepresentation(BsonType.ObjectId)]
  public string ownerId { get; set; } = null!;

}

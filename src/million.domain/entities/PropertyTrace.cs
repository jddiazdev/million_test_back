using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace million.domain.entities;

public class PropertyTrace : BaseEntity
{
  // fk 
  [BsonElement("propertyId")]
  [BsonRepresentation(BsonType.ObjectId)]
  public string propertyId { get; set; } = null!;

  public DateTime dateSale { get; set; }

  public string name { get; set; } = null!;
  public string value { get; set; } = null!;
  public decimal tax { get; set; }


}

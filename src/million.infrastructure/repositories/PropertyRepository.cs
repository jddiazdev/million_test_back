using System;
using million.domain.entities;
using million.domain.interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace million.infrastructure.repositories;

public class PropertyRepository : IPropertyRepository
{
  private readonly IMongoCollection<Property> _collection;
  private readonly IMongoCollection<PropertyImage> _collectionPropertyImg;
  private readonly IMongoCollection<PropertyTrace> _collectionPropertyTrance;


  public PropertyRepository(IMongoDatabase database)
  {
    _collection = database.GetCollection<Property>("properties");
    _collectionPropertyImg = database.GetCollection<PropertyImage>("propertyImages");
    _collectionPropertyTrance = database.GetCollection<PropertyTrace>("propertyTraces");
  }



  public async Task addPAsync(Property property)
  {
    await _collection.InsertOneAsync(property);
  }

  public async Task addPropertyImg(PropertyImage propertyImage)
  {
    await _collectionPropertyImg.InsertOneAsync(propertyImage);
  }

  public async Task addPropertyTrace(PropertyTrace propertyTrace)
  {
    await _collectionPropertyTrance.InsertOneAsync(propertyTrace);
  }

  public async Task<List<PropertyFull>> GetFilteredPropertiesAsync(PropertyFull filter)
  {

    var builder = Builders<Property>.Filter;
    var filters = new List<FilterDefinition<Property>>();

    if (!string.IsNullOrEmpty(filter.name))
      filters.Add(builder.Regex(p => p.name, new MongoDB.Bson.BsonRegularExpression(filter.name, "i")));

    if (!string.IsNullOrEmpty(filter.address))
      filters.Add(builder.Regex(p => p.address, new MongoDB.Bson.BsonRegularExpression(filter.address, "i")));

    if (filter.minPrice.HasValue)
      filters.Add(builder.Gte(p => p.price, filter.minPrice.Value));

    if (filter.maxPrice.HasValue)
      filters.Add(builder.Lte(p => p.price, filter.maxPrice.Value));

    var combinedFilter = filters.Count > 0 ? builder.And(filters) : builder.Empty;

    var result = await _collection.Aggregate()
       .Match(combinedFilter)
       .Lookup("propertyImages", "_id", "propertyId", "images")
       .Lookup("propertyTraces", "_id", "propertyId", "trackers")
       .Project(new BsonDocument
       {
            { "idOwner", "$ownerId" },
            { "name", 1 },
            { "address", 1 },
            { "price", 1 },
            { "image", new BsonDocument("$reduce", new BsonDocument
                {
                    { "input", "$images.file" },
                    { "initialValue", "" },
                    { "in", new BsonDocument("$concat", new BsonArray { "$$value", new BsonString(", "), "$$this" }) }
                })
            },
       })
       .ToListAsync();

    var properties = result.Select(doc => new PropertyFull
    {
      id = doc["_id"].AsObjectId.ToString(),
      ownerId = doc["idOwner"].AsObjectId.ToString(),
      name = doc.Contains("name") ? doc["name"].AsString : "",
      address = doc.Contains("address") ? doc["address"].AsString : "",
      price = doc.Contains("price") ? doc["price"].ToDecimal() : 0,
      image = doc.Contains("image") ? doc["image"].AsString.TrimStart(',', ' ') : "",

    }).ToList();

    return properties;
  }
}

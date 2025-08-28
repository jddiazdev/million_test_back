using System;
using million.domain.entities;
using million.domain.interfaces;
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

  public async Task<Property?> GetByIdAsync(string id)
  {
    return await _collection
           .Find(p => p.id == id)
           .FirstOrDefaultAsync();
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
}

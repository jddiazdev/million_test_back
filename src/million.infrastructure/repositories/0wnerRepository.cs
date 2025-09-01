using System;
using Microsoft.Extensions.Options;
using million.domain.entities;
using million.infrastructure.persistence;
using MongoDB.Driver;

namespace million.infrastructure.repositories;

public class OwnerRepository : IOwnerRepository
{
  private readonly IMongoCollection<Owner> _collection;

  public OwnerRepository(IMongoDatabase database, IOptions<MongoDbSettings> settings)
  {
    _collection = database.GetCollection<Owner>(settings.Value.OwnersCollection);

  }
  public async Task addOwnerAsync(Owner owner)
  {
    await _collection.InsertOneAsync(owner);
  }

  public async Task<Owner?> GetByIdAsync(string id)
  {
    return await _collection
               .Find(o => o.id == id)
               .FirstOrDefaultAsync();
  }
}

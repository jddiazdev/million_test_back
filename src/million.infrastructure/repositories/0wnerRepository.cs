using System;
using million.domain.entities;
using MongoDB.Driver;

namespace million.infrastructure.repositories;

public class OwnerRepository : IOwnerRepository
{
  private readonly IMongoCollection<Owner> _collection;

  public OwnerRepository(IMongoDatabase database)
  {
    _collection = database.GetCollection<Owner>("owners");

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

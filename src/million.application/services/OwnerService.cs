using System;
using million.domain.entities;
using million.infrastructure.repositories;

namespace million.application.services;

public class OwnerService
{
  private readonly IOwnerRepository _repository;


  public OwnerService(IOwnerRepository repository)
  {
    _repository = repository;
  }


  public Task addOwner(Owner owner) => _repository.addOwnerAsync(owner);

  public Task<Owner?> GetOwnerByIdAsync(string id) => _repository.GetByIdAsync(id);

}

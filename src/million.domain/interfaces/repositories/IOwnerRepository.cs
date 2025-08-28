namespace million.infrastructure.repositories;

using million.domain.entities;

public interface IOwnerRepository
{

  Task addOwnerAsync(Owner owner);
  Task<Owner?> GetByIdAsync(string id);


}

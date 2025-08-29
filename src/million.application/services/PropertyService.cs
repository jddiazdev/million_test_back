using System;
using million.domain.entities;
using million.domain.interfaces;

namespace million.application;

public class PropertyService
{

  private readonly IPropertyRepository _repository;

  public PropertyService(IPropertyRepository repository)
  {
    _repository = repository;
  }


  public Task AddPropertyAsync(Property property) => _repository.addPAsync(property);



  public Task AddPropertyImg(PropertyImage propertyImage) => _repository.addPropertyImg(propertyImage);

  public Task AddPropertyTrace(PropertyTrace propertyTrace) => _repository.addPropertyTrace(propertyTrace);
  
  public Task<List<PropertyFull>> GetFilteredPropertiesAsync(PropertyFull filter) => _repository.GetFilteredPropertiesAsync(filter);


}

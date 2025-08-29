
using million.domain.entities;
namespace million.domain.interfaces;

public interface IPropertyRepository
{

  Task addPAsync(Property property);

  Task addPropertyImg(PropertyImage propertyImage);

  Task addPropertyTrace(PropertyTrace propertyTrace);

  Task<List<PropertyFull>> GetFilteredPropertiesAsync(PropertyFull filter);


}


using million.domain.entities;
namespace million.domain.interfaces;

public interface IPropertyRepository
{

  Task addPAsync(Property property);
  Task<Property?> GetByIdAsync(string id);

  Task addPropertyImg(PropertyImage propertyImage);

  Task addPropertyTrace(PropertyTrace propertyTrace);

}

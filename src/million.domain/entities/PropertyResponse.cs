using System;

namespace million.domain.entities;

public class PropertyResponse
{
  public Property? property { get; set; }
  public List<PropertyImage> propertyImages { get; set; } = new();
  public List<PropertyTrace> propertyTraces { get; set; } = new();
  public PropertyDetail? propertyDetail { get; set; }

}

using System;

namespace million.infrastructure.persistence;

public class MongoDbSettings
{
  public string ConnectionString { get; set; } = null!;
  public string DatabaseName { get; set; } = null!;

  public string OwnersCollection { get; set; } = null!;
  public string PropertyCollection { get; set; } = null!;
  public string PropertyImageCollection { get; set; } = null!;
  public string PropertyTraceCollection { get; set; } = null!;
  public string PropertyDetailCollection { get; set; } = null!;


}
